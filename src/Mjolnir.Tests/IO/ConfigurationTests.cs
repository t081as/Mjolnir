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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mjolnir.IO;
#endregion

namespace Mjolnir.Tests.IO
{
    /// <summary>
    /// Contains unit tests for the <see cref="IConfiguration"/> interface.
    /// </summary>
    [TestClass]
    public class ConfigurationTests
    {
        #region Methods

        /// <summary>
        /// Checks the <see cref="IConfiguration.SetValue(string, string)"/> method.
        /// </summary>
        [TestMethod]
        public void SetValueTest()
        {
            IConfiguration configuration = ConfigurationFactory.New();
            configuration.SetValue("test1", "ab-c");

            Assert.AreEqual("ab-c", configuration.GetValue("test1"));
        }

        /// <summary>
        /// Checks the <see cref="IConfiguration.SetValue(string, string)"/> method.
        /// </summary>
        [TestMethod]
        public void SetValueChangeValueTest()
        {
            IConfiguration configuration = ConfigurationFactory.New();
            configuration.SetValue("test1", "ab-c");
            configuration.SetValue("test1", "d19465G");

            Assert.AreEqual("d19465G", configuration.GetValue("test1"));
        }

        /// <summary>
        /// Checks the <see cref="IConfiguration.SetValue(string, string)"/> method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetValueKeyNullTest()
        {
            IConfiguration configuration = ConfigurationFactory.New();
            configuration.SetValue(null, "ab-c");
        }

        /// <summary>
        /// Checks the <see cref="IConfiguration.SetValue(string, string)"/> method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetValueKeyEmptyTest()
        {
            IConfiguration configuration = ConfigurationFactory.New();
            configuration.SetValue(string.Empty, "ab-c");
        }

        /// <summary>
        /// Checks the <see cref="IConfiguration.SetValue(string, string)"/> method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetValueValueNullTest()
        {
            IConfiguration configuration = ConfigurationFactory.New();
            configuration.SetValue("test-2", null);
        }

        /// <summary>
        /// Checks the <see cref="IConfiguration"/> copy constructor.
        /// </summary>
        [TestMethod]
        public void CopyTest()
        {
            IConfiguration configuration = ConfigurationFactory.New();
            configuration.SetValue("test1", "ab-c");
            configuration.SetValue("test2", "adgt-h");

            IConfiguration newConfiguration = ConfigurationFactory.Copy(configuration);

            Assert.AreEqual("ab-c", newConfiguration.GetValue("test1"));
            Assert.AreEqual("adgt-h", newConfiguration.GetValue("test2"));
        }

        /// <summary>
        /// Checks the <see cref="IConfiguration.Entries"/> property.
        /// </summary>
        [TestMethod]
        public void EntriesTest()
        {
            IConfiguration configuration = ConfigurationFactory.New();
            configuration.SetValue("test1", "ab-c");

            Assert.AreEqual("ab-c", configuration.Entries["test1"]);
        }

        /// <summary>
        /// Checks the <see cref="IConfiguration.GetValue(string)"/> method.
        /// </summary>
        [TestMethod]
        public void GetValueTest()
        {
            IConfiguration configuration = ConfigurationFactory.New();
            configuration.SetValue("test1", "ab-c");

            Assert.AreEqual("ab-c", configuration.GetValue("test1"));
        }

        /// <summary>
        /// Checks the <see cref="IConfiguration.GetValue(string)"/> method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetValueKeyNullTest()
        {
            IConfiguration configuration = ConfigurationFactory.New();
            configuration.SetValue("test1", "ab-c");

            Assert.AreEqual("ab-c", configuration.GetValue(null));
        }

        /// <summary>
        /// Checks the <see cref="IConfiguration.GetValue(string)"/> method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetValueKeyEmptyTest()
        {
            IConfiguration configuration = ConfigurationFactory.New();
            configuration.SetValue("test1", "ab-c");

            Assert.AreEqual("ab-c", configuration.GetValue(string.Empty));
        }

        /// <summary>
        /// Checks the <see cref="IConfiguration.GetValue(string)"/> method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetValueWrongKeyTest()
        {
            IConfiguration configuration = ConfigurationFactory.New();
            configuration.SetValue("test1", "ab-c");

            Assert.AreEqual("ab-c", configuration.GetValue("i-do-not-exist"));
        }

        /// <summary>
        /// Checks the <see cref="IConfiguration.GetValue(string, string)"/> method.
        /// </summary>
        [TestMethod]
        public void GetValueDefaultTest()
        {
            IConfiguration configuration = ConfigurationFactory.New();
            configuration.SetValue("test1", "ab-c");

            Assert.AreEqual("ab-c", configuration.GetValue("test1", "de-f"));
            Assert.AreEqual("de-f", configuration.GetValue("i-do-not-exist", "de-f"));
        }

        /// <summary>
        /// Checks the <see cref="IConfiguration.GetValue(string, string)"/> method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetValueDefaultKeyNullTest()
        {
            IConfiguration configuration = ConfigurationFactory.New();
            configuration.SetValue("test1", "ab-c");

            Assert.AreEqual("ab-c", configuration.GetValue(null, "de-f"));
        }

        /// <summary>
        /// Checks the <see cref="IConfiguration.GetValue(string, string)"/> method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetValueDefaultKeyEmptyTest()
        {
            IConfiguration configuration = ConfigurationFactory.New();
            configuration.SetValue("test1", "ab-c");

            Assert.AreEqual("ab-c", configuration.GetValue(string.Empty, "de-f"));
        }

        #endregion
    }
}
