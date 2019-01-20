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
#endregion

namespace Mjolnir.IO
{
    /// <summary>
    /// Describes objects allowing to read and write key-value-based configurations.
    /// </summary>
    public interface IConfiguration
    {
        #region Methods

        /// <summary>
        /// Sets the given <paramref name="key"/> to the given <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key that shall be used to store the value.</param>
        /// <param name="value">The value that shall be stored.</param>
        /// <exception cref="ArgumentNullException"><c>key</c> is null.</exception>
        /// <exception cref="ArgumentNullException"><c>value</c> is null.</exception>
        /// <exception cref="ArgumentException"><c>key</c> is empty.</exception>
        void SetValue(string key, string value);

        /// <summary>
        /// Gets the value associated with the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key that shall be used to retrieve the value.</param>
        /// <returns>The value associated with the given key.</returns>
        /// <exception cref="ArgumentNullException"><c>key</c> is null.</exception>
        /// <exception cref="ArgumentException"><c>key</c> is empty.</exception>
        /// <exception cref="ArgumentException"><c>key</c> does not contain a value.</exception>
        string GetValue(string key);

        /// <summary>
        /// Gets the value associated with the given <paramref name="key"/> or the given
        /// <paramref name="defaultValue"/> if there is no value stored for the <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key that shall be used to retrieve the value.</param>
        /// <param name="defaultValue">The value that shall be returned if there is no stored value for the given key.</param>
        /// <returns>The value associated with the given key or the default value.</returns>
        /// <exception cref="ArgumentNullException"><c>key</c> is null.</exception>
        /// <exception cref="ArgumentException"><c>key</c> is empty.</exception>
        string GetValue(string key, string defaultValue);

        /// <summary>
        /// Gets the value associated with the given <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the value.</typeparam>
        /// <param name="key">The key that shall be used to retrieve the value.</param>
        /// <returns>The value associated with the given key.</returns>
        /// <exception cref="ArgumentNullException"><c>key</c> is null.</exception>
        /// <exception cref="ArgumentException"><c>key</c> is empty.</exception>
        /// <exception cref="ArgumentException"><c>key</c> does not contain a value.</exception>
        T GetValue<T>(string key);

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
        T GetValue<T>(string key, T defaultValue);

        /// <summary>
        /// Tries to return a value for the given <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the value.</typeparam>
        /// <param name="key">The key that shall be used to retrieve the value.</param>
        /// <param name="value">The value associated with the given key if available.</param>
        /// <returns><c>True</c> if the value is available, <c>false</c> otherwise.</returns>
        bool TryGetValue<T>(string key, out T value);

        #endregion
    }
}
