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
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mjolnir.Build.IO;

namespace Mjolnir.Tests.Build.IO
{
    /// <summary>
    /// Contains unit tests for the <see cref="TextTasks"/> class.
    /// </summary>
    [TestClass]
    public class TextTasksTests
    {
        /// <summary>
        /// Checks the <see cref="TextTasks.ReplaceInFile"/> method.
        /// </summary>
        [TestMethod]
        public void ReplaceInFileTest()
        {
            const string tempFileContent = "This is a %TEST%.";
            const string searchPattern = "%TEST%";
            const string replacement = "test";
            string tempFile = Path.GetTempFileName();

            File.WriteAllText(tempFile, tempFileContent);
            TextTasks.ReplaceInFile(tempFile, (searchPattern, replacement));

            string content = File.ReadAllText(tempFile);

            StringAssert.Contains(content, replacement);
            Assert.IsFalse(content.Contains(searchPattern));
        }

        /// <summary>
        /// Checks the <see cref="TextTasks.ReplaceInFile"/> method with an invalid filename.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ReplaceInFileInvalidTest()
        {
            TextTasks.ReplaceInFile(@"C:\i-do-not-exist-ab123.xtx", (string.Empty, string.Empty));
        }

        /// <summary>
        /// Checks the <see cref="TextTasks.ReplaceInFile"/> method with an invalid reference (<c>null</c>).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReplaceInFileNullTest()
        {
            TextTasks.ReplaceInFile(null!, (string.Empty, string.Empty));
        }
    }
}
