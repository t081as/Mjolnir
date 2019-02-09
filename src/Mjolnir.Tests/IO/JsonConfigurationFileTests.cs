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
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mjolnir.IO;
#endregion

namespace Mjolnir.Tests.IO
{
    /// <summary>
    /// Contains unit tests for the <see cref="JsonConfigurationFile"/> class.
    /// </summary>
    [TestClass]
    public class JsonConfigurationFileTests
    {
        #region Methods

        /// <summary>
        /// Checks the <see cref="JsonConfigurationFile.Write(IConfiguration, Stream)"/> method.
        /// </summary>
        [TestMethod]
        public void WriteTest()
        {
            JsonConfigurationFile configurationFile = new JsonConfigurationFile();
            MemoryStream configurationStream = new MemoryStream();
            IConfiguration configuration = ConfigurationFactory.New();

            configuration.SetValue("My first key", "1");
            configuration.SetValue("Key:2", "This is a test");

            configurationFile.Write(configuration, configurationStream);

            configurationStream.Seek(0, SeekOrigin.Begin);
            IConfiguration configurationFromStream = configurationFile.Read(configurationStream);

            Assert.AreEqual(configuration.GetValue("My first key"), configurationFromStream.GetValue("My first key"));
            Assert.AreEqual(configuration.GetValue("Key:2"), configurationFromStream.GetValue("Key:2"));
        }

        #endregion
    }
}
