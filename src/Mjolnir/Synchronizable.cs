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

namespace Mjolnir
{
    /// <summary>
    /// Encapsulates objects that needs to be synchronized between different threads and provides
    /// a synchonization lock object.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the object that shall be synchronizable.</typeparam>
    /// <example>
    /// The following example demonstrates how to use the <see cref="Synchronizable{T}"/> class to synchronize objects:
    /// <code>
    /// Synchronizable&lt;List&lt;int&gt;&gt; synchronizable = new Synchronizable&lt;List&lt;int&gt;&gt;(new List&lt;int&gt;());
    ///
    /// lock (synchronizable.SyncRoot)
    /// {
    ///     synchronizable.Value.Add(500);
    /// }
    /// </code>
    /// </example>
    public class Synchronizable<T>
    {
        #region Constrcutors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Synchronizable{T}"/> class.
        /// </summary>
        /// <param name="value">The object that shall be encapsulated.</param>
        public Synchronizable(T value)
        {
            this.Value = value;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the encapsulated value.
        /// </summary>
        /// <value>The encapsulated value.</value>
        public T Value { get; private set; } = default(T);

        /// <summary>
        /// Gets the synchonization lock object.
        /// </summary>
        /// <value>The synchonization lock object.</value>
        public object SyncRoot { get; private set; } = new object();

        #endregion

        #region Methods

        /// <summary>
        /// Returns the value of a <see cref="Synchronizable{T}"/>.
        /// </summary>
        /// <param name="synchronizable">The <see cref="Synchronizable{T}.Value"/> of a <see cref="Synchronizable{T}"/>.</param>
        public static implicit operator T(Synchronizable<T> synchronizable)
        {
            return synchronizable.Value;
        }

        #endregion
    }
}
