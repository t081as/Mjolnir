﻿#region MIT License
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
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mjolnir.IO;
#endregion

namespace Mjolnir.Tests.IO
{
    /// <summary>
    /// Contains unit tests for the <see cref="ConfigurationFile"/> class.
    /// </summary>
    [TestClass]
    public class ConfigurationFileTests
    {
        #region Methods

        /// <summary>
        /// Checks the <see cref="ConfigurationFile.Read(System.IO.Stream)"/> method.
        /// </summary>
        [TestMethod]
        public void ReadTest()
        {
            string fileName = Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName, "IO", "ConfigurationFileTest.Default.txt");

            using (Stream configStream = File.OpenRead(fileName))
            {
                IConfiguration configuration = new ConfigurationFile().Read(configStream);

                Assert.AreEqual("value1", configuration.GetValue("key1"));
                Assert.AreEqual("value2", configuration.GetValue("key2"));
                Assert.AreEqual("value3", configuration.GetValue("key3"));
                Assert.AreEqual("value@value", configuration.GetValue("test.test:test"));
            }
        }

        #endregion
    }
}
