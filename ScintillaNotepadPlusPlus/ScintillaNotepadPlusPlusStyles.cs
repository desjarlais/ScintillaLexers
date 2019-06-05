#region License
/*
MIT License

Copyright(c) 2019 Petteri Kautonen

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
using ScintillaNET;
using VPKSoft.ScintillaLexers.CreateSpecificLexer;
using VPKSoft.ScintillaLexers.HelperClasses;

namespace VPKSoft.ScintillaLexers.ScintillaNotepadPlusPlus
{
    /// <summary>
    /// A class for loading global styles for the <see cref="Scintilla"/> from 
    /// </summary>
    public class ScintillaNotepadPlusPlusStyles
    {
        /// <summary>
        /// Sets the global and default styles for the given <see cref="Scintilla"/> instance depending on the other parameters.
        /// </summary>
        /// <param name="document">A XML document containing the lexer style data.</param>
        /// <param name="scintilla">The scintilla instance of which style to set.</param>
        /// <param name="useGlobalOverride">if set to <c>true</c> the "Global override" style is read from the <paramref name="document"/>.</param>
        /// <param name="font">If set to <c>true</c> the font name and size is read from the <paramref name="document"/>..</param>
        /// <returns><c>true</c> if the operation was successful, <c>false</c> otherwise.</returns>
        public static bool SetGlobalDefaultStyles(XDocument document, Scintilla scintilla, bool useGlobalOverride, bool font)
        {
            try
            {
                scintilla.StyleResetDefault();

                var globalStyle =
                    document.Descendants(XName.Get("WidgetStyle")).FirstOrDefault(f =>
                        f.Attribute("name") != null &&
                        f.Attribute("name").Value == "Global override");

                if (globalStyle != null && useGlobalOverride)
                {
                    SetStyle(scintilla, XmlStyleNotepadPlusPlusHelper.FromXElement(globalStyle), font);
                }

                var defaultStyle =
                    document.Descendants(XName.Get("WidgetStyle")).FirstOrDefault(f =>
                        f.Attribute("name") != null &&
                        f.Attribute("name").Value == "Default Style");

                SetStyle(scintilla, XmlStyleNotepadPlusPlusHelper.FromXElement(defaultStyle), font);

                scintilla.StyleClearAll();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the folding of a <see cref="Scintilla"/> based on the "Fold" style defined in the XML document.
        /// </summary>
        /// <param name="document">The XML document to read the folding style from.</param>
        /// <param name="scintilla">The instance to a scintilla of which folding style to set.</param>
        /// <returns><c>true</c> if the operation was successful, <c>false</c> otherwise.</returns>
        public static bool SetFolding(XDocument document, Scintilla scintilla)
        {
            try
            {
                var foldStyle = // <WidgetStyle name="Fold"...
                    document.Descendants(XName.Get("WidgetStyle")).FirstOrDefault(f =>
                        f.Attribute("name") != null &&
                        f.Attribute("name").Value == "Fold");

                if (foldStyle == null)
                {
                    return false;
                }

                var style = XmlStyleNotepadPlusPlusHelper.FromXElement(foldStyle);

                // the default colors as in the example.. (C)::https://github.com/jacobslusser/ScintillaNET/wiki/Automatic-Code-Folding

                // Instruct the lexer to calculate folding..
                LexerFoldProperties.FoldDefault(scintilla);

                // Configure a margin to display folding symbols
                scintilla.Margins[2].Type = MarginType.Symbol;
                scintilla.Margins[2].Mask = Marker.MaskFolders;
                scintilla.Margins[2].Sensitive = true;
                scintilla.Margins[2].Width = 20;

                // Set colors for all folding markers
                for (int i = 25; i <= 31; i++)
                {
                    scintilla.Markers[i].SetForeColor(style.ColorBackground);
                    scintilla.Markers[i].SetBackColor(style.ColorForeground);
                }

                // Configure folding markers with respective symbols
                scintilla.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
                scintilla.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
                scintilla.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
                scintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
                scintilla.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
                scintilla.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
                scintilla.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

                // Enable automatic folding
                scintilla.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the style of a given <see cref="Scintilla"/> with a given style.
        /// </summary>
        /// <param name="scintilla">The scintilla instance of which style to set.</param>
        /// <param name="style">The style to set for the <paramref name="scintilla"/>.</param>
        /// <param name="font">If set to <c>true</c> the font is also set from the given style.</param>
        private static void SetStyle(Scintilla scintilla, XmlStyleNotepadPlusPlusHelper style, bool font)
        {
            if (style.ColorForeground != Color.Empty)
            {
                scintilla.Styles[style.StyleId].ForeColor = style.ColorForeground;
            }

            if (style.ColorBackground != Color.Empty)
            {
                scintilla.Styles[style.StyleId].BackColor = style.ColorBackground;
            }

            scintilla.Styles[style.StyleId].Italic = style.Italic;
            scintilla.Styles[style.StyleId].Bold = style.Bold;
            if (font)
            {
                scintilla.Styles[style.StyleId].Font = style.FontName;
                scintilla.Styles[style.StyleId].Size = style.FontSize;
            }
        }

        /// <summary>
        /// Loads the Scintilla global styles from a Notepad++ style definition XML file.
        /// </summary>
        /// <param name="document">The XML document to read the global style from.</param>
        /// <param name="scintilla">The Scintilla of which global styles to set.</param>
        /// <param name="useWhiteSpace">A flag indicating whether to color the white space symbol.</param>
        /// <param name="useSelectionColors">A flag indicating whether to color the selection.</param>
        /// <param name="useMarginColors">A flag indicating whether to color the margin.</param>
        /// <returns><c>true</c> if the operations was successful, <c>false</c> otherwise.</returns>
        public static bool LoadScintillaStyleFromNotepadPlusXml(XDocument document, Scintilla scintilla,
            bool useWhiteSpace, bool useSelectionColors, bool useMarginColors)
        {
            try
            {
                var nodes = document.Descendants(XName.Get("WidgetStyle"));
                // loop through the color definition elements..

                foreach (var node in nodes)
                {
                    var style = XmlStyleNotepadPlusPlusHelper.FromXElement(node);

                    if (style.Name == "Indent guideline style" ||
                        style.Name == "Brace highlight style" ||
                        style.Name == "Bad brace colour" ||
                        style.Name == "Find Mark Style" || // unknown (?): 31
                        style.Name == "Line number margin" || // unknown (?): 33
                        style.Name == "Smart HighLighting" || // unknown (?): 29
                        style.Name == "Mark Style 1" || // unknown (?): 25
                        style.Name == "Mark Style 2" || // unknown (?): 24
                        style.Name == "Mark Style 3" || // unknown (?): 23
                        style.Name == "Mark Style 4" || // unknown (?): 22
                        style.Name == "Mark Style 5" || // unknown (?): 21
                        style.Name == "Incremental highlight all" || // unknown (?): 28
                        style.Name == "Tags match highlighting" || // unknown (?): 27
                        style.Name == "ags attribute") // unknown (?): 26
                    {
                        if (style.ColorForeground != Color.Empty)
                        {
                            scintilla.Styles[style.StyleId].ForeColor = style.ColorForeground;
                        }

                        if (style.ColorBackground != Color.Empty)
                        {
                            scintilla.Styles[style.StyleId].BackColor = style.ColorBackground;
                        }

                        scintilla.Styles[style.StyleId].Italic = style.Italic;
                        scintilla.Styles[style.StyleId].Bold = style.Bold;
                    }
                    else if (style.Name == "Current line background colour")
                    {
                        scintilla.CaretLineBackColor = style.ColorBackground;
                    }
                    else if (style.Name == "Selected text colour")
                    {
                        scintilla.SetSelectionForeColor(useSelectionColors, style.ColorForeground);
                        scintilla.SetSelectionBackColor(useSelectionColors, style.ColorBackground);
                    }
                    else if (style.Name == "Caret colour")
                    {
                        scintilla.CaretForeColor = style.ColorForeground;
                        //scintilla.Styles[style.StyleId].BackColor = style.ColorBackground;
                        //scintilla.Styles[style.StyleId].ForeColor = style.ColorBackground;
                        // caret background color not supported? StyleID: 2069
                    }
                    else if (style.Name == "Edge colour")
                    {
                        scintilla.EdgeColor = style.ColorForeground;
                    }
                    else if (style.Name == "Fold margin") // <WidgetStyle name="Fold margin"..
                    {
                        scintilla.SetFoldMarginHighlightColor(useMarginColors, style.ColorForeground);
                        scintilla.SetFoldMarginColor(useMarginColors, style.ColorBackground);
                    }
                    else if (style.Name == "White space symbol") // <WidgetStyle name="White space symbol"..
                    {
                        scintilla.SetWhitespaceForeColor(useWhiteSpace, style.ColorForeground);
                        scintilla.SetWhitespaceBackColor(useWhiteSpace, style.ColorBackground);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the styles for a <see cref="Scintilla"/> from the Notepad++'s XML style files for a given lexer.
        /// </summary>
        /// <param name="document">The XML document to read the lexer style from.</param>
        /// <param name="scintilla">The <see cref="Scintilla"/> which lexer style to set.</param>
        /// <param name="lexerType">A <see cref="LexerEnumerations.LexerType"/> enumeration.</param>
        /// <returns><c>true</c> if the operations was successful, <c>false</c> otherwise.</returns>
        public static bool LoadLexerStyleFromNotepadPlusXml(XDocument document, Scintilla scintilla, 
            LexerEnumerations.LexerType lexerType)
        {
            try
            {
                var nodes = document.Descendants(XName.Get("LexerType")).Where(f =>
                    f.Attribute("name")?.Value == LexerTypeName.GetLexerXmlName(lexerType)).Descendants();

                // loop through the color definition elements..
                foreach (var node in nodes)
                {
                    var style = XmlStyleNotepadPlusPlusHelper.FromXElement(node);

                    if (style.ColorForeground != Color.Empty)
                    {
                        scintilla.Styles[style.StyleId].ForeColor = style.ColorForeground;
                    }

                    if (style.ColorBackground != Color.Empty)
                    {
                        scintilla.Styles[style.StyleId].BackColor = style.ColorBackground;
                    }

                    scintilla.Styles[style.StyleId].Bold = style.Bold;
                    scintilla.Styles[style.StyleId].Italic = style.Italic;
                }

                return true;
            }
            catch
            {
                // an error occurred so return false..
                return false;
            }
        }
    }
}
