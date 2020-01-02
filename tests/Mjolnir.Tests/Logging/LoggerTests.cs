// The MIT License (MIT)
//
// Copyright © 2017-2020 Tobias Koch
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mjolnir.Logging;
using Moq;

namespace Mjolnir.Tests.Logging
{
    /// <summary>
    /// Contains unit tests for the <see cref="Logger"/> class.
    /// </summary>
    [TestClass]
    public class LoggerTests
    {
        /// <summary>
        /// Checks the <see cref="Logger.Trace(string)"/> method.
        /// </summary>
        [TestMethod]
        public void TraceTest()
        {
            LogEntry lastEntry = null;
            var logWriterMock = new Mock<ILogEntryWriter>();
            logWriterMock.Setup(w => w.Write(It.IsAny<LogEntry>()))
                .Callback((LogEntry e) => lastEntry = e);

            ILogger logger = new Logger(logWriterMock.Object, this.GetType().FullName);
            logger.Trace("Test");

            Assert.IsNotNull(lastEntry);
            Assert.AreEqual(LogLevel.Trace, lastEntry.Level);
            Assert.AreEqual("Test", lastEntry.Message);
        }

        /// <summary>
        /// Checks the <see cref="Logger.Debug(string)"/> method.
        /// </summary>
        [TestMethod]
        public void DebugTest()
        {
            LogEntry lastEntry = null;
            var logWriterMock = new Mock<ILogEntryWriter>();
            logWriterMock.Setup(w => w.Write(It.IsAny<LogEntry>()))
                .Callback((LogEntry e) => lastEntry = e);

            ILogger logger = new Logger(logWriterMock.Object, this.GetType().FullName);
            logger.Debug("Test");

            Assert.IsNotNull(lastEntry);
            Assert.AreEqual(LogLevel.Debug, lastEntry.Level);
            Assert.AreEqual("Test", lastEntry.Message);
        }

        /// <summary>
        /// Checks the <see cref="Logger.Info(string)"/> method.
        /// </summary>
        [TestMethod]
        public void InfoTest()
        {
            LogEntry lastEntry = null;
            var logWriterMock = new Mock<ILogEntryWriter>();
            logWriterMock.Setup(w => w.Write(It.IsAny<LogEntry>()))
                .Callback((LogEntry e) => lastEntry = e);

            ILogger logger = new Logger(logWriterMock.Object, this.GetType().FullName);
            logger.Info("Test");

            Assert.IsNotNull(lastEntry);
            Assert.AreEqual(LogLevel.Info, lastEntry.Level);
            Assert.AreEqual("Test", lastEntry.Message);
        }

        /// <summary>
        /// Checks the <see cref="Logger.Warning(string)"/> method.
        /// </summary>
        [TestMethod]
        public void WarningTest()
        {
            LogEntry lastEntry = null;
            var logWriterMock = new Mock<ILogEntryWriter>();
            logWriterMock.Setup(w => w.Write(It.IsAny<LogEntry>()))
                .Callback((LogEntry e) => lastEntry = e);

            ILogger logger = new Logger(logWriterMock.Object, this.GetType().FullName);
            logger.Warning("Test");

            Assert.IsNotNull(lastEntry);
            Assert.AreEqual(LogLevel.Warning, lastEntry.Level);
            Assert.AreEqual("Test", lastEntry.Message);
        }

        /// <summary>
        /// Checks the <see cref="Logger.Warning(string, Exception)"/> method.
        /// </summary>
        [TestMethod]
        public void WarningExceptionTest()
        {
            LogEntry lastEntry = null;
            var logWriterMock = new Mock<ILogEntryWriter>();
            logWriterMock.Setup(w => w.Write(It.IsAny<LogEntry>()))
                .Callback((LogEntry e) => lastEntry = e);

            ILogger logger = new Logger(logWriterMock.Object, this.GetType().FullName);
            logger.Warning("Test", new Exception());

            Assert.IsNotNull(lastEntry);
            Assert.IsNotNull(lastEntry.Exception);
            Assert.AreEqual(LogLevel.Warning, lastEntry.Level);
            Assert.AreEqual("Test", lastEntry.Message);
        }

        /// <summary>
        /// Checks the <see cref="Logger.Error(string)"/> method.
        /// </summary>
        [TestMethod]
        public void ErrorTest()
        {
            LogEntry lastEntry = null;
            var logWriterMock = new Mock<ILogEntryWriter>();
            logWriterMock.Setup(w => w.Write(It.IsAny<LogEntry>()))
                .Callback((LogEntry e) => lastEntry = e);

            ILogger logger = new Logger(logWriterMock.Object, this.GetType().FullName);
            logger.Error("Test");

            Assert.IsNotNull(lastEntry);
            Assert.AreEqual(LogLevel.Error, lastEntry.Level);
            Assert.AreEqual("Test", lastEntry.Message);
        }

        /// <summary>
        /// Checks the <see cref="Logger.Error(string, Exception)"/> method.
        /// </summary>
        [TestMethod]
        public void ErrorExceptionTest()
        {
            LogEntry lastEntry = null;
            var logWriterMock = new Mock<ILogEntryWriter>();
            logWriterMock.Setup(w => w.Write(It.IsAny<LogEntry>()))
                .Callback((LogEntry e) => lastEntry = e);

            ILogger logger = new Logger(logWriterMock.Object, this.GetType().FullName);
            logger.Error("Test", new Exception());

            Assert.IsNotNull(lastEntry);
            Assert.IsNotNull(lastEntry.Exception);
            Assert.AreEqual(LogLevel.Error, lastEntry.Level);
            Assert.AreEqual("Test", lastEntry.Message);
        }

        /// <summary>
        /// Checks the <see cref="Logger.Fatal(string)"/> method.
        /// </summary>
        [TestMethod]
        public void FatalTest()
        {
            LogEntry lastEntry = null;
            var logWriterMock = new Mock<ILogEntryWriter>();
            logWriterMock.Setup(w => w.Write(It.IsAny<LogEntry>()))
                .Callback((LogEntry e) => lastEntry = e);

            ILogger logger = new Logger(logWriterMock.Object, this.GetType().FullName);
            logger.Fatal("Test");

            Assert.IsNotNull(lastEntry);
            Assert.AreEqual(LogLevel.Fatal, lastEntry.Level);
            Assert.AreEqual("Test", lastEntry.Message);
        }

        /// <summary>
        /// Checks the <see cref="Logger.Fatal(string, Exception)"/> method.
        /// </summary>
        [TestMethod]
        public void FatalExceptionTest()
        {
            LogEntry lastEntry = null;
            var logWriterMock = new Mock<ILogEntryWriter>();
            logWriterMock.Setup(w => w.Write(It.IsAny<LogEntry>()))
                .Callback((LogEntry e) => lastEntry = e);

            ILogger logger = new Logger(logWriterMock.Object, this.GetType().FullName);
            logger.Fatal("Test", new Exception());

            Assert.IsNotNull(lastEntry);
            Assert.IsNotNull(lastEntry.Exception);
            Assert.AreEqual(LogLevel.Fatal, lastEntry.Level);
            Assert.AreEqual("Test", lastEntry.Message);
        }
    }
}
