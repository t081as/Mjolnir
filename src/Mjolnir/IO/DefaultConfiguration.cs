#region MIT License
// The MIT License (MIT)
//
// Copyright © 2017-2019 Tobias Koch
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
using System.Collections.Generic;
using System.Globalization;
#endregion

namespace Mjolnir.IO
{
    /// <summary>
    /// Provides a key-value-based configuration.
    /// </summary>
    internal class DefaultConfiguration : IConfiguration
    {
        #region Constants and Fields

        /// <summary>
        /// The synchronizable dictionary storing the actual configuration.
        /// </summary>
        private Synchronizable<Dictionary<string, string>> configurationValues =
            new Synchronizable<Dictionary<string, string>>(new Dictionary<string, string>());

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultConfiguration"/> class.
        /// </summary>
        public DefaultConfiguration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultConfiguration"/> class
        /// based on the given <paramref name="configuration"/>.
        /// </summary>
        /// <param name="configuration">The configuration that shall be copied.</param>
        public DefaultConfiguration(IConfiguration configuration)
            : this()
        {
            lock (this.configurationValues.SyncRoot)
            {
                foreach (KeyValuePair<string, string> entry in configuration.Entries)
                {
                    this.configurationValues.Value.Add(entry.Key, entry.Value);
                }
            }
        }

        #endregion

        #region Properties

        /// <inheritdoc />
        public IReadOnlyDictionary<string, string> Entries
        {
            get
            {
                lock (this.configurationValues.SyncRoot)
                {
                    return new Dictionary<string, string>(this.configurationValues.Value);
                }
            }
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public void SetValue(string key, string value)
        {
            this.CheckKeyNullOrEmpty(key);

            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            lock (this.configurationValues.SyncRoot)
            {
                if (this.configurationValues.Value.ContainsKey(key))
                {
                    this.configurationValues.Value[key] = value;
                }
                else
                {
                    this.configurationValues.Value.Add(key, value);
                }
            }
        }

        /// <inheritdoc />
        public string GetValue(string key)
        {
            this.CheckKeyNullOrEmpty(key);

            lock (this.configurationValues.SyncRoot)
            {
                if (!this.configurationValues.Value.ContainsKey(key))
                {
                    throw new ArgumentException($"No value found for key {key}", nameof(key));
                }

                return this.configurationValues.Value[key];
            }
        }

        /// <inheritdoc />
        public string GetValue(string key, string defaultValue)
        {
            this.CheckKeyNullOrEmpty(key);

            try
            {
                return this.GetValue(key);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <inheritdoc />
        public T GetValue<T>(string key)
        {
            this.CheckKeyNullOrEmpty(key);
            return (T)Convert.ChangeType(this.GetValue(key), typeof(T), CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public T GetValue<T>(string key, T defaultValue)
        {
            this.CheckKeyNullOrEmpty(key);

            try
            {
                return this.GetValue<T>(key);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <inheritdoc />
        public bool TryGetValue<T>(string key, out T value)
        {
            this.CheckKeyNullOrEmpty(key);

            try
            {
                value = this.GetValue<T>(key);
                return true;
            }
            catch
            {
                value = default(T);
                return false;
            }
        }

        /// <summary>
        /// Checks the <paramref name="key"/> parameter.
        /// </summary>
        /// <param name="key">The key that shall be checked.</param>
        /// <exception cref="ArgumentNullException"><c>key</c> is null.</exception>
        /// <exception cref="ArgumentException"><c>key</c> is empty.</exception>
        protected virtual void CheckKeyNullOrEmpty(string key)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("The key must not be empty", nameof(key));
            }
        }

        #endregion
    }
}
