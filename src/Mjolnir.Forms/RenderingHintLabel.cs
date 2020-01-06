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

using System.Drawing.Text;
using System.Windows.Forms;

namespace Mjolnir.Forms
{
    /// <summary>
    /// A <see cref="Label"/> supporting a <see cref="TextRenderingHint"/>.
    /// </summary>
    public class RenderingHintLabel : Label
    {
        /// <summary>
        /// Gets or sets the rendering mode for text associated with this <see cref="RenderingHintLabel"/>.
        /// </summary>
        /// <value>The rendering mode for text associated with this <see cref="RenderingHintLabel"/>.</value>
        public TextRenderingHint TextRenderingHint { get; set; } = TextRenderingHint.SystemDefault;

        /// <summary>
        /// Overrides the <see cref="Control.Paint"/> event handler.
        /// </summary>
        /// <param name="e">A <see cref="PaintEventArgs"/> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (e != null && e.Graphics != null)
            {
                e.Graphics.TextRenderingHint = this.TextRenderingHint;
            }

            base.OnPaint(e);
        }
    }
}
