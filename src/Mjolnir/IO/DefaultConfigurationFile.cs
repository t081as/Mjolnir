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
#endregion

namespace Mjolnir.IO
{
    /// <summary>
    /// Represents an implementation of the <see cref="IConfiguration"/> interface storing the data
    /// in a simple line-based text file.
    /// </summary>
    public class DefaultConfigurationFile : Configuration
    {
        #region Constants and Fields

        /// <summary>
        /// The synchronizable dictionary storing the configuration.
        /// </summary>
        private Synchronizable<Dictionary<string, string>> configurationValues =
            new Synchronizable<Dictionary<string, string>>(new Dictionary<string, string>());

        #endregion

        #region Constructors and Destructors

        #endregion

        #region Properties

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
        public override void SetValue(string key, string value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the value associated with the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key that shall be used to retrieve the value.</param>
        /// <returns>The value associated with the given key.</returns>
        /// <exception cref="ArgumentNullException"><c>key</c> is null.</exception>
        /// <exception cref="ArgumentException"><c>key</c> is empty.</exception>
        /// <exception cref="ArgumentException"><c>key</c> does not contain a value.</exception>
        public override string GetValue(string key)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
