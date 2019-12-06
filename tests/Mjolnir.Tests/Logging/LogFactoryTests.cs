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

using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mjolnir.Logging;
using Moq;

namespace Mjolnir.Tests.Logging
{
    /// <summary>
    /// Contains unit tests for the <see cref="LogFactory"/> class.
    /// </summary>
    [TestClass]
    public class LogFactoryTests
    {
        /// <summary>
        /// Checks the <see cref="LogFactory.GetLogger{T}"/> method.
        /// </summary>
        [TestMethod]
        public void GetLoggerTest()
        {
            LogEntry lastWrittenEntry = new LogEntry();
            LogEntry testEntry = new LogEntry(
                DateTime.UtcNow,
                this.GetType().FullName ?? string.Empty,
                LogLevel.Info,
                "TEST",
                "This is a test!");

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
    }
}
