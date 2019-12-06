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

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mjolnir.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="Synchronizable{T}"/> class.
    /// </summary>
    [TestClass]
    public class SynchronizableTests
    {
        /// <summary>
        /// Checks the <see cref="Synchronizable{T}"/> class.
        /// </summary>
        [TestMethod]
        public void TestSynchronizable()
        {
            Synchronizable<List<int>> synchronizable = new Synchronizable<List<int>>(new List<int>());

            synchronizable.Value.Add(11);
            synchronizable.Value.Add(275);

            lock (synchronizable.SyncRoot)
            {
                ((List<int>)synchronizable).Add(500);
            }

            Assert.AreEqual(3, synchronizable.Value.Count);
        }
    }
}
