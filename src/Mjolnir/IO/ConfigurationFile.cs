// The MIT License (MIT)
//
// Copyright © 2017-2020 Tobias Koch
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the “Software”), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.IO
{
    /// <summary>
    /// Provides methods to read and write configuration files in the default configuration file format.
    /// </summary>
    public class ConfigurationFile : IConfigurationReader, IConfigurationWriter
    {
        /// <summary>
        /// The default marker for single line comments.
        /// </summary>
        public const string DefaultCommentMarker = "#";

        /// <summary>
        /// The default seperator for keys and values.
        /// </summary>
        public const string DefaultSeperator = "=";

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFile"/> class.
        /// </summary>
        public ConfigurationFile()
        {
            this.CommentMarker = DefaultCommentMarker;
            this.Seperator = DefaultSeperator;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFile"/> class with the given
        /// comment marker and seperator.
        /// </summary>
        /// <param name="commentMarker">The marker for single line comments.</param>
        /// <param name="seperator">The seperator for keys and values.</param>
        public ConfigurationFile(string commentMarker, string seperator)
        {
            this.CommentMarker = commentMarker;
            this.Seperator = seperator;
        }

        /// <summary>
        /// Gets the comment marker used by this instance.
        /// </summary>
        /// <value>The comment marker used by this instance.</value>
        public string CommentMarker { get; private set; }

        /// <summary>
        /// Gets the seperator used by this instance.
        /// </summary>
        /// <value>The seperator used by this instance.</value>
        public string Seperator { get; private set; }

        /// <inheritdoc />
        public IConfiguration Read(Stream stream)
        {
            Task<IConfiguration>? result = null;

            try
            {
                result = this.ReadAsync(stream);
                Task.WaitAll(result);
            }
            catch (AggregateException aex)
            {
                aex.Handle((exception) =>
                {
                    if (exception is IOException ioex)
                    {
                        throw ioex;
                    }

                    return false;
                });
            }

            return result?.Result ?? new DefaultConfiguration();
        }

        /// <inheritdoc />
        public async Task<IConfiguration> ReadAsync(Stream stream)
        {
            StreamReader reader = new StreamReader(stream, new UTF8Encoding(false));

            IConfiguration configuration = new DefaultConfiguration();
            string? line;
            ulong lineNumber = 0;

            while ((line = await reader.ReadLineAsync().ConfigureAwait(false)) != null)
            {
                lineNumber++;
                line = line.Trim();

                if (line.Contains(this.CommentMarker))
                {
                    line = line.Substring(0, line.IndexOf(this.CommentMarker, 0, StringComparison.InvariantCulture));
                }

                if (!string.IsNullOrEmpty(line))
                {
                    string[] parts = line.Split(new string[] { this.Seperator }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != 2)
                    {
                        throw new IOException($"Error in line {lineNumber}; expecting format: key{this.Seperator}value (but got {line})");
                    }

                    string key = parts[0].Trim();
                    string value = parts[1].Trim();

                    if (configuration.Entries.ContainsKey(key))
                    {
                        throw new IOException($"Error in line {lineNumber}; key {key} not unique");
                    }

                    configuration.SetValue(key, value);
                }
            }

            return configuration;
        }

        /// <inheritdoc />
        public void Write(IConfiguration configuration, Stream stream)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            try
            {
                var result = this.WriteAsync(configuration, stream);
                Task.WaitAll(result);
            }
            catch (AggregateException aex)
            {
                aex.Handle((exception) =>
                {
                    if (exception is IOException ioex)
                    {
                        throw ioex;
                    }

                    return false;
                });
            }
        }

        /// <inheritdoc />
        public async Task WriteAsync(IConfiguration configuration, Stream stream)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            try
            {
                StreamWriter writer = new StreamWriter(stream, new UTF8Encoding(false));

                foreach (var entry in configuration.Entries)
                {
                    if (this.ContainsInvalidSequences(entry.Key, out string keySequence))
                    {
                        throw new IOException($"Entry {entry.Key}: the key contains the following invalid sequence: {keySequence}");
                    }

                    if (this.ContainsInvalidSequences(entry.Value, out string valueSequence))
                    {
                        throw new IOException($"Entry {entry.Key}: the value contains the following invalid sequence: {valueSequence}");
                    }

                    await writer.WriteLineAsync($"{entry.Key}{this.Seperator}{entry.Value}").ConfigureAwait(false);
                }

                await writer.FlushAsync().ConfigureAwait(false);
            }
            catch (IOException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new IOException("Error while reading the configuration data", ex);
            }
        }

        /// <summary>
        /// Checks the given <paramref name="value"/> for invalid sequences that can not be stored using this
        /// file format.
        /// </summary>
        /// <param name="value">The value that shall be checked.</param>
        /// <param name="invalidSequence">The invalid sequence that has been detected.</param>
        /// <returns><c>True</c> if the value contains an invalid sequence, <c>false</c> otherwise.</returns>
        protected virtual bool ContainsInvalidSequences(string value, out string invalidSequence)
        {
            string[] invalidSequences = new string[] { this.CommentMarker, this.Seperator, "\n", "\r\n" };

            foreach (var sequence in invalidSequences)
            {
                if (value.Contains(sequence))
                {
                    invalidSequence = sequence.Replace(@"\", @"\\");
                    return true;
                }
            }

            invalidSequence = string.Empty;
            return false;
        }
    }
}