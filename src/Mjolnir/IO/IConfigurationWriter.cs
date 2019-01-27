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
using System.IO;
using System.Threading.Tasks;
#endregion

namespace Mjolnir.IO
{
    /// <summary>
    /// Describes objects allowing to write configuration data to a <see cref="Stream"/>.
    /// </summary>
    public interface IConfigurationWriter
    {
        #region Methods

        /// <summary>
        /// Writes the given <paramref name="configuration"/> data to the given <paramref name="stream"/>.
        /// </summary>
        /// <param name="configuration">The configuration data that shall be written.</param>
        /// <param name="stream">The <see cref="Stream"/> the configuration data shall be written to.</param>
        /// <exception cref="ArgumentNullException"><c>configuration</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException"><c>stream</c> is <c>null</c>.</exception>
        /// <exception cref="IOException">Error while writing the data.</exception>
        void Write(IConfiguration configuration, Stream stream);

        /// <summary>
        /// Writes the given <paramref name="configuration"/> data to the given <paramref name="stream"/>.
        /// </summary>
        /// <param name="configuration">The configuration data that shall be written.</param>
        /// <param name="stream">The <see cref="Stream"/> the configuration data shall be written to.</param>
        /// <exception cref="ArgumentNullException"><c>configuration</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException"><c>stream</c> is <c>null</c>.</exception>
        /// <exception cref="IOException">Error while writing the data.</exception>
        /// <returns>A <see cref="Task"/> that represents the asynchronous write operation.</returns>
        Task WriteAsync(IConfiguration configuration, Stream stream);

        #endregion
    }
}
