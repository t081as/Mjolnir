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
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Mjolnir.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="TaskExtensions"/> class.
    /// </summary>
    [TestClass]
    public class TaskExtensionsTests
    {
        /// <summary>
        /// Checks the <see cref="TaskExtensions.Invoke(System.Threading.Tasks.Task, IExceptionHandler)"/> method.
        /// </summary>
        [TestMethod]
        public void InvokeTest()
        {
            Exception? lastException = null;
            var errorHandlerMock = new Mock<IExceptionHandler>();
            errorHandlerMock.Setup(h => h.HandleException(It.IsAny<Exception>())).Callback((Exception e) => { lastException = e; });

            Task task = this.GoodAsync();
            task.Invoke(errorHandlerMock.Object);

            Thread.Sleep(1000);

            Assert.IsNull(lastException);
        }

        /// <summary>
        /// Checks the <see cref="TaskExtensions.Invoke(System.Threading.Tasks.Task, IExceptionHandler)"/> method
        /// invoking a method throwing an exception.
        /// </summary>
        [TestMethod]
        public void InvokeErrorTest()
        {
            Exception? lastException = null;
            var errorHandlerMock = new Mock<IExceptionHandler>();
            errorHandlerMock.Setup(h => h.HandleException(It.IsAny<Exception>())).Callback((Exception e) => { lastException = e; });

            Task task = this.BadAsync();
            task.Invoke(errorHandlerMock.Object);

            Thread.Sleep(1000);

            Assert.IsNotNull(lastException);
        }

        /// <summary>
        /// An async method that does nothing.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task GoodAsync()
        {
            await Task.Delay(500).ConfigureAwait(false);
        }

        /// <summary>
        /// An async method that throws an exception.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task BadAsync()
        {
            await Task.Delay(500).ConfigureAwait(false);
            throw new Exception();
        }
    }
}
