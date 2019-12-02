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
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mjolnir.Logging;
using Moq;
#endregion

namespace Mjolnir.Tests.Logging
{
    /// <summary>
    /// Contains unit tests for the <see cref="LogFactory"/> class.
    /// </summary>
    [TestClass]
    public class LogFactoryTests
    {
        #region Methods

        /// <summary>
        /// Checks the <see cref="LogFactory.GetLogger{T}"/> method.
        /// </summary>
        [TestMethod]
        public void GetLoggerTest()
        {
            LogEntry lastWrittenEntry = null;
            LogEntry testEntry = new LogEntry(DateTime.UtcNow, this.GetType().FullName, LogLevel.Info, "TEST", "This is a test!");

            var appenderMock = new Mock<ILogAppender>();
            appenderMock.Setup(a => a.Append(It.IsAny<LogEntry>()))
                .Callback((LogEntry e) => lastWrittenEntry = e);

            using (LogFactory logFactory = new LogFactory(new ILogAppender[] { appenderMock.Object }))
            {
                Thread.Sleep(150);
                var logger = logFactory.GetLogger<LogFactoryTests>();
                logger.Log(testEntry);
                Thread.Sleep(150);

                var nextLogger = logFactory.GetLogger<LogFactoryTests>();
                Assert.AreEqual(logger, nextLogger);
            }

            Assert.AreEqual(testEntry.TimeStamp, lastWrittenEntry.TimeStamp);
            Assert.AreEqual(testEntry.Logger, lastWrittenEntry.Logger);
            Assert.AreEqual(testEntry.Level, lastWrittenEntry.Level);
            Assert.AreEqual(testEntry.Thread, lastWrittenEntry.Thread);
            Assert.AreEqual(testEntry.Message, lastWrittenEntry.Message);
        }

        /// <summary>
        /// Checks the <see cref="LogFactory.GetLogger(Type)"/> method using an empty reference.
        /// </summary>
        [TestMethod]
        public void GetLoggerNullTest()
        {
            var appenderMock = new Mock<ILogAppender>();
            appenderMock.Setup(a => a.Append(It.IsAny<LogEntry>()));

            using (LogFactory logFactory = new LogFactory(new ILogAppender[] { appenderMock.Object }))
            {
                Thread.Sleep(150);
                Assert.ThrowsException<ArgumentNullException>(() => logFactory.GetLogger(null));
            }
        }

        #endregion
    }
}
