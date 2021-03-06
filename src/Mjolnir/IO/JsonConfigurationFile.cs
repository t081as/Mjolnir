﻿// The MIT License (MIT)
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
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Mjolnir.IO
{
    /// <summary>
    /// Provides methods to read and write configuration files in JSON format.
    /// </summary>
    public class JsonConfigurationFile : IConfigurationReader, IConfigurationWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonConfigurationFile"/> class.
        /// </summary>
        public JsonConfigurationFile()
        {
        }

        /// <inheritdoc />
        public IConfiguration Read(Stream stream)
        {
            try
            {
                IConfiguration configuration = ConfigurationFactory.New();
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
                Dictionary<string, string> configurationValues = (Dictionary<string, string>)serializer.ReadObject(stream);

                foreach (var key in configurationValues.Keys)
                {
                    configuration.SetValue(key, configurationValues[key]);
                }

                return configuration;
            }
            catch (Exception ex)
            {
                throw new IOException("Error while reading the configuration data", ex);
            }
        }

        /// <inheritdoc />
        public async Task<IConfiguration> ReadAsync(Stream stream)
        {
            return await Task.Run(() => this.Read(stream)).ConfigureAwait(false);
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
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<string, string>));
                Dictionary<string, string> configurationValues = new Dictionary<string, string>();

                foreach (var key in configuration.Entries.Keys)
                {
                    configurationValues.Add(key, configuration.Entries[key]);
                }

                serializer.WriteObject(stream, configurationValues);
            }
            catch (Exception ex)
            {
                throw new IOException("Error while writing the configuration data", ex);
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

            await Task.Run(() => this.Write(configuration, stream)).ConfigureAwait(false);
        }
    }
}
