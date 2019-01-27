#region MIT License
// The MIT License (MIT)
//
// Copyright © 2017-2019 Tobias Koch <t.koch@tk-software.de>
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
#endregion

#region Namespaces
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Mjolnir.IO
{
    /// <summary>
    /// Provides methods to read and write configuration files in the default configuration file format.
    /// </summary>
    public class ConfigurationFile : IConfigurationReader, IConfigurationWriter
    {
        #region Constants and Fields

        /// <summary>
        /// The default marker for single line comments.
        /// </summary>
        public const string DefaultCommentMarker = "#";

        /// <summary>
        /// The default seperator for keys and values.
        /// </summary>
        public const string DefaultSeperator = "=";

        /// <summary>
        /// Represents the comment marker used by this instance.
        /// </summary>
        private string commentMarker;

        /// <summary>
        /// Represents the seperator used by this instance.
        /// </summary>
        private string seperator;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFile"/> class.
        /// </summary>
        public ConfigurationFile()
        {
            this.commentMarker = DefaultCommentMarker;
            this.seperator = DefaultSeperator;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFile"/> class with the given
        /// comment marker and seperator.
        /// </summary>
        /// <param name="commentMarker">The marker for single line comments.</param>
        /// <param name="seperator">The seperator for keys and values.</param>
        public ConfigurationFile(string commentMarker, string seperator)
        {
            this.commentMarker = commentMarker;
            this.seperator = seperator;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the comment marker used by this instance.
        /// </summary>
        /// <value>The comment marker used by this instance.</value>
        public string CommentMarker
        {
            get => this.commentMarker;
        }

        /// <summary>
        /// Gets the seperator used by this instance.
        /// </summary>
        /// <value>The seperator used by this instance.</value>
        public string Seperator
        {
            get => this.seperator;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public IConfiguration Read(Stream stream)
        {
            var result = this.ReadAsync(stream);
            Task.WaitAll(result);

            return result.Result;
        }

        /// <inheritdoc />
        public async Task<IConfiguration> ReadAsync(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream, new UTF8Encoding(false)))
            {
                IConfiguration configuration = new DefaultConfiguration();
                string line;

                while ((line = await reader.ReadLineAsync().ConfigureAwait(false)) != null)
                {
                    throw new NotImplementedException();
                }

                return configuration;
            }
        }

        /// <inheritdoc />
        public void Write(IConfiguration configuration, Stream stream)
        {
            var result = this.WriteAsync(configuration, stream);
            Task.WaitAll(result);
        }

        /// <inheritdoc />
        public async Task WriteAsync(IConfiguration configuration, Stream stream)
        {
            using (StreamWriter writer = new StreamWriter(stream, new UTF8Encoding(false)))
            {
                foreach (var entry in configuration.Entries)
                {
                    await writer.WriteLineAsync($"").ConfigureAwait(false);
                }
            }
        }

        #endregion
    }
}