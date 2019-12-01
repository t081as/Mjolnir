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

namespace Mjolnir.Logging
{
    /// <summary>
    /// Describes objects able to produce instances of <see cref="ILogger"/> classes.
    /// </summary>
    public interface ILogFactory
    {
        #region Properties

        /// <summary>
        /// Gets the configured appenders.
        /// </summary>
        /// <value>The configured appenders.</value>
        IEnumerable<ILogAppender> Appenders { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Produces and returns instances of <see cref="ILogger"/> classes.
        /// </summary>
        /// <typeparam name="T">The type the logger shall be produced for.</typeparam>
        /// <returns>An instances of an <see cref="ILogger"/> class.</returns>
        ILogger GetLogger<T>();

        /// <summary>
        /// Produces and returns instances of <see cref="ILogger"/> classes for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type the logger shall be produced for.</param>
        /// <returns>An instances of an <see cref="ILogger"/> class.</returns>
        /// <exception cref="ArgumentNullException"><c>type</c> is <c>null</c>.</exception>
        ILogger GetLogger(Type type);

        #endregion
    }
}
