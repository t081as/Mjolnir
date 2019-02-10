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
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Mjolnir.IO
{
    /// <summary>
    /// Represents an author with a name and an email address.
    /// </summary>
    public class Author
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Author"/> class.
        /// </summary>
        public Author()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Author"/> class.
        /// </summary>
        /// <param name="name">The name of the author.</param>
        /// <param name="eMailAddress">The email address of the author.</param>
        public Author(string name, string eMailAddress)
        {
            this.Name = name;
            this.EMailAddress = eMailAddress;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the author.
        /// </summary>
        /// <value>The name of the author.</value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address of the author.
        /// </summary>
        /// <value>The email address of the author.</value>
        public string EMailAddress { get; set; } = string.Empty;

        #endregion

        #region Methods

        /// <summary>
        /// Reads a list of authros from the given <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> containing the author list.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> containing the authors.</returns>
        /// <exception cref="ArgumentNullException"><c>stream</c> is <c>null</c>.</exception>
        /// <exception cref="IOException">Error while reading the stream.</exception>
        public static IEnumerable<Author> From(Stream stream)
        {
            Task<IEnumerable<Author>> result = null;

            try
            {
                result = FromAsync(stream);
                Task.WaitAll(result);
            }
            catch (AggregateException aex)
            {
                aex.Handle((exception) =>
                {
                    if (exception is IOException)
                    {
                        throw exception as IOException;
                    }

                    return false;
                });
            }

            return result?.Result;
        }

        /// <summary>
        /// Reads a list of authros from the given <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> containing the author list.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> that represents the asynchronous write operation.
        /// The <c>TResult</c> parameter contains an <see cref="IEnumerable{T}"/>
        /// containing the authors.
        /// </returns>
        /// <exception cref="ArgumentNullException"><c>stream</c> is <c>null</c>.</exception>
        /// <exception cref="IOException">Error while reading the stream.</exception>
        public static async Task<IEnumerable<Author>> FromAsync(Stream stream)
        {
            try
            {
                List<Author> authors = new List<Author>();
                StreamReader reader = new StreamReader(stream);

                IConfiguration configuration = new DefaultConfiguration();
                string line;

                while ((line = await reader.ReadLineAsync().ConfigureAwait(false)) != null)
                {
                    // TODO: Implement RegEx to read the authors
                }

                return authors;
            }
            catch (Exception ex)
            {
                throw new IOException("Error while reading the stream", ex);
            }
        }

        #endregion
    }
}
