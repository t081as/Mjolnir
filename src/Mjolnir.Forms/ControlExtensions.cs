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

using System.Reflection;
using System.Windows.Forms;

namespace Mjolnir.Forms
{
    /// <summary>
    /// Contains extension methods for the <see cref="Control"/> class.
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// Enables double buffering of a <see cref="Control"/>.
        /// </summary>
        /// <param name="control">The <see cref="Control"/> that shall be double buffered.</param>
        /// <example>
        /// The following example demonstrates how to use the <see cref="ControlExtensions.EnableDoubleBuffering(Control)"/>
        /// method to enable double buffering:
        /// <code>
        /// Control doubleBufferedControl = new Control();
        /// doubleBufferedControl.EnableDoubleBuffering();
        /// </code>
        /// </example>
        public static void EnableDoubleBuffering(this Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(control, true, null);
        }
    }
}