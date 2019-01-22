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

        /// <summary>
        /// Gets all configuration key-value-pairs.
        /// </summary>
        /// <value>A <see cref="IReadOnlyDictionary{TKey, TValue}"/> containing all configuration key-value-pairs.</value>
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

        /// <summary>
        /// Sets the given <paramref name="key"/> to the given <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key that shall be used to store the value.</param>
        /// <param name="value">The value that shall be stored.</param>
        /// <exception cref="ArgumentNullException"><c>key</c> is null.</exception>
        /// <exception cref="ArgumentNullException"><c>value</c> is null.</exception>
        /// <exception cref="ArgumentException"><c>key</c> is empty.</exception>
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

        /// <summary>
        /// Gets the value associated with the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key that shall be used to retrieve the value.</param>
        /// <returns>The value associated with the given key.</returns>
        /// <exception cref="ArgumentNullException"><c>key</c> is null.</exception>
        /// <exception cref="ArgumentException"><c>key</c> is empty.</exception>
        /// <exception cref="ArgumentException"><c>key</c> does not contain a value.</exception>
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

        /// <summary>
        /// Gets the value associated with the given <paramref name="key"/> or the given
        /// <paramref name="defaultValue"/> if there is no value stored for the <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key that shall be used to retrieve the value.</param>
        /// <param name="defaultValue">The value that shall be returned if there is no stored value for the given key.</param>
        /// <returns>The value associated with the given key or the default value.</returns>
        /// <exception cref="ArgumentNullException"><c>key</c> is null.</exception>
        /// <exception cref="ArgumentException"><c>key</c> is empty.</exception>
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

        /// <summary>
        /// Gets the value associated with the given <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the value.</typeparam>
        /// <param name="key">The key that shall be used to retrieve the value.</param>
        /// <returns>The value associated with the given key.</returns>
        /// <exception cref="ArgumentNullException"><c>key</c> is null.</exception>
        /// <exception cref="ArgumentException"><c>key</c> is empty.</exception>
        /// <exception cref="ArgumentException"><c>key</c> does not contain a value.</exception>
        public T GetValue<T>(string key)
        {
            this.CheckKeyNullOrEmpty(key);
            return (T)Convert.ChangeType(this.GetValue(key), typeof(T), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the value associated with the given <paramref name="key"/> or the given
        /// <paramref name="defaultValue"/> if there is no value stored for the <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the value.</typeparam>
        /// <param name="key">The key that shall be used to retrieve the value.</param>
        /// <param name="defaultValue">The value that shall be returned if there is no stored value for the given key.</param>
        /// <returns>The value associated with the given key or the default value.</returns>
        /// <exception cref="ArgumentNullException"><c>key</c> is null.</exception>
        /// <exception cref="ArgumentException"><c>key</c> is empty.</exception>
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

        /// <summary>
        /// Tries to return a value for the given <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the value.</typeparam>
        /// <param name="key">The key that shall be used to retrieve the value.</param>
        /// <param name="value">The value associated with the given key if available.</param>
        /// <returns><c>True</c> if the value is available, <c>false</c> otherwise.</returns>
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
