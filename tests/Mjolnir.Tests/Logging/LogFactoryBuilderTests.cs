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
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mjolnir.Logging;
using Moq;
#endregion

namespace Mjolnir.Tests.Logging
{
    /// <summary>
    /// Contains unit tests for the <see cref="LogFactoryBuilder"/> class.
    /// </summary>
    [TestClass]
    public class LogFactoryBuilderTests
    {
        #region Methods

        /// <summary>
        /// Checks the <see cref="LogFactoryBuilder.Build"/> method.
        /// </summary>
        [TestMethod]
        public void BuildTest()
        {
            var appenderMock = new Mock<ILogAppender>();
            var logFactory = LogFactoryBuilder
                                .New()
                                .WithAppender(appenderMock.Object)
                                .Build();

            Assert.AreEqual(1, logFactory.Appenders.Count());
        }

        #endregion
    }
}