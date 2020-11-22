#region License
/*
MIT License

Copyright(c) 2020 Petteri Kautonen

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion

using System.Drawing;
using System.Linq;
using System.Xml.Linq;

namespace VPKSoft.ScintillaLexers.ScintillaNotepadPlusPlus
{
    /// <summary>
    /// A helper class to get the mark colors from the Notepad++ software XML lexer definition file.
    /// </summary>
    public class MarkColors
    {
        /// <summary>
        /// Gets or sets the smart high highlighting foreground color.
        /// </summary>
        public Color SmartHighLightingForeground { get; set; } = Color.Empty;

        /// <summary>
        /// Gets or sets the smart high highlighting background color.
        /// </summary>
        public Color SmartHighLightingBackground { get; set; } = Color.Empty;

        /// <summary>
        /// Gets or sets the incremental highlight all foreground color.
        /// </summary>
        public Color IncrementalHighlightAllForeground { get; set; } = Color.Empty;

        /// <summary>
        /// Gets or sets the incremental highlight all background color.
        /// </summary>
        public Color IncrementalHighlightAllBackground { get; set; } = Color.Empty;

        /// <summary>
        /// Gets or sets the mark one foreground color.
        /// </summary>
        public Color MarkOneForeground { get; set; } = Color.Empty;

        /// <summary>
        /// Gets or sets the mark one background color.
        /// </summary>
        public Color MarkOneBackground { get; set; } = Color.Empty;

        /// <summary>
        /// Gets or sets the mark two foreground color.
        /// </summary>
        public Color MarkTwoForeground { get; set; } = Color.Empty;

        /// <summary>
        /// Gets or sets the mark two background color.
        /// </summary>
        public Color MarkTwoBackground { get; set; } = Color.Empty;

        /// <summary>
        /// Gets or sets the mark three foreground color.
        /// </summary>
        public Color MarkThreeForeground { get; set; } = Color.Empty;

        /// <summary>
        /// Gets or sets the mark three background color.
        /// </summary>
        public Color MarkThreeBackground { get; set; } = Color.Empty;

        /// <summary>
        /// Gets or sets the mark four foreground color.
        /// </summary>
        public Color MarkFourForeground { get; set; } = Color.Empty;

        /// <summary>
        /// Gets or sets the mark four background color.
        /// </summary>
        public Color MarkFourBackground { get; set; } = Color.Empty;

        /// <summary>
        /// Gets or sets the mark five foreground color.
        /// </summary>
        public Color MarkFiveForeground { get; set; } = Color.Empty;

        /// <summary>
        /// Gets or sets the mark five background color.
        /// </summary>
        public Color MarkFiveBackground { get; set; } = Color.Empty;

        /// <summary>
        /// Gets or sets the current line background color.
        /// </summary>
        public Color CurrentLineBackground { get; set; } = Color.Empty;

        /// <summary>
        /// Gets or sets the current line background color.
        /// </summary>
        public Color CurrentLineForeground { get; set; } = Color.Empty;

        /// <summary>
        /// Gets the color definitions from a XML style definition file.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>An instance to this (<see cref="MarkColors"/>) class.</returns>
        public static MarkColors FromFile(string fileName)
        {
            return FromXDocument(XDocument.Load(fileName));
        }

        /// <summary>
        /// Gets the color definitions from a XDocument style definition instance.
        /// </summary>
        /// <param name="document">The XDocument to document to get the styles from.</param>
        /// <returns>An instance to this (<see cref="MarkColors"/>) class.</returns>
        public static MarkColors FromXDocument(XDocument document)
        {
            try
            {
                MarkColors result = new MarkColors();
                var nodes = document.Descendants(XName.Get("WidgetStyle")).Where(f =>
                    f.Attribute("name")?.Value == "Current line background colour" ||
                    f.Attribute("name")?.Value == "Smart HighLighting" ||
                    f.Attribute("name")?.Value == "Incremental highlight all" ||
                    f.Attribute("name")?.Value == "Mark Style 1" ||
                    f.Attribute("name")?.Value == "Mark Style 2" ||
                    f.Attribute("name")?.Value == "Mark Style 3" ||
                    f.Attribute("name")?.Value == "Mark Style 4" ||
                    f.Attribute("name")?.Value == "Mark Style 5");

                foreach (var node in nodes)
                {
                    var style = XmlStyleNotepadPlusPlusHelper.FromXElement(node);
                    if (style.Name == "Mark Style 1")
                    {
                        result.MarkOneForeground = style.ColorForeground;
                        result.MarkOneBackground = style.ColorBackground;
                    }

                    if (style.Name == "Mark Style 2")
                    {
                        result.MarkTwoForeground = style.ColorForeground;
                        result.MarkTwoBackground = style.ColorBackground;
                    }

                    if (style.Name == "Mark Style 3")
                    {
                        result.MarkThreeForeground = style.ColorForeground;
                        result.MarkThreeBackground = style.ColorBackground;
                    }

                    if (style.Name == "Mark Style 4")
                    {
                        result.MarkFourForeground = style.ColorForeground;
                        result.MarkFourBackground = style.ColorBackground;
                    }

                    if (style.Name == "Mark Style 5")
                    {
                        result.MarkFiveForeground = style.ColorForeground;
                        result.MarkFiveBackground = style.ColorBackground;
                    }

                    if (style.Name == "Smart HighLighting")
                    {
                        result.SmartHighLightingForeground = style.ColorForeground;
                        result.SmartHighLightingBackground = style.ColorBackground;
                    }

                    if (style.Name == "Incremental highlight all")
                    {
                        result.IncrementalHighlightAllForeground = style.ColorForeground;
                        result.IncrementalHighlightAllBackground = style.ColorBackground;
                    }

                    if (style.Name == "Incremental highlight all")
                    {
                        result.IncrementalHighlightAllForeground = style.ColorForeground;
                        result.IncrementalHighlightAllBackground = style.ColorBackground;
                    }

                    if (style.Name == "Current line background colour")
                    {
                        result.CurrentLineForeground = style.ColorForeground;
                        result.CurrentLineBackground = style.ColorBackground;
                    }
                }

                return result;
            }
            catch
            {
                return new MarkColors();
            }
        }
    }
}
