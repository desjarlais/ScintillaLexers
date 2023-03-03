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
using ScintillaNET;
using VPKSoft.ScintillaLexers.HelperClasses;
using static VPKSoft.ScintillaLexers.LexerEnumerations;
using static VPKSoft.ScintillaLexers.GlobalScintillaFont;

namespace VPKSoft.ScintillaLexers.CreateSpecificLexer;

/// <summary>
/// A base class for creating static lexers.
/// </summary>
public class CreateLexerCommon
{
    /// <summary>
    /// Resets the Scintilla's style to default.
    /// </summary>
    /// <param name="scintilla">A Scintilla which style to reset.</param>
    public static void ClearStyle(Scintilla scintilla)
    {
        scintilla.StyleResetDefault();
        scintilla.Styles[Style.Default].Font = FontFamilyName;
        scintilla.Styles[Style.Default].Size = FontSize;
        scintilla.StyleClearAll();
    }

    /// <summary>
    /// Adds a "standard" folding to a lexer.
    /// </summary>
    /// <param name="scintilla">An instance to a Scintilla class.</param>
    public static void AddFolding(Scintilla scintilla)
    {
        // the default colors as in the example.. (C)::https://github.com/jacobslusser/ScintillaNET/wiki/Automatic-Code-Folding
        AddFolding(scintilla, SystemColors.ControlLightLight, SystemColors.ControlDark);
    }

    /// <summary>
    /// Adds a "standard" folding to a lexer with given foreground and background colors.
    /// </summary>
    /// <param name="scintilla">An instance to a Scintilla class.</param>
    /// <param name="foregroundColor">The foreground color to be used.</param>
    /// <param name="backgroundColor">The background color to be used.</param>
    public static void AddFolding(Scintilla scintilla, Color foregroundColor, Color backgroundColor)
    {
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
            scintilla.Markers[i].SetForeColor(foregroundColor);
            scintilla.Markers[i].SetBackColor(backgroundColor);
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
    }

    /// <summary>
    /// Sets the HTML styles for a lexer.
    /// </summary>
    /// <param name="scintilla">A <see cref="Scintilla"/> class instance.</param>
    /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
    public static void SetHtmlStyles(Scintilla scintilla, LexerColors.LexerColors lexerColors)
    {
        // DEFAULT, fontStyle = 1, styleId = 0
        scintilla.Styles[Style.Html.Default].Bold = true;
        scintilla.Styles[Style.Html.Default].ForeColor = lexerColors[LexerType.HTML, "DefaultFore"];
        scintilla.Styles[Style.Html.Default].BackColor = lexerColors[LexerType.HTML, "DefaultBack"];

        // COMMENT, fontStyle = 0, styleId = 9
        scintilla.Styles[Style.Html.Comment].ForeColor = lexerColors[LexerType.HTML, "CommentFore"];
        scintilla.Styles[Style.Html.Comment].BackColor = lexerColors[LexerType.HTML, "CommentBack"];

        // NUMBER, fontStyle = 0, styleId = 5
        scintilla.Styles[Style.Html.Number].ForeColor = lexerColors[LexerType.HTML, "NumberFore"];
        scintilla.Styles[Style.Html.Number].BackColor = lexerColors[LexerType.HTML, "NumberBack"];

        // self added, seemed to be missing..
        scintilla.Styles[Style.Html.Entity].Italic = true;
        scintilla.Styles[Style.Html.Entity].ForeColor = lexerColors[LexerType.HTML, "EntityFore"];
        scintilla.Styles[Style.Html.Entity].BackColor = lexerColors[LexerType.HTML, "EntityBack"];
           

        // DOUBLESTRING, fontStyle = 1, styleId = 6
        scintilla.Styles[Style.Html.DoubleString].Bold = true;
        scintilla.Styles[Style.Html.DoubleString].ForeColor = lexerColors[LexerType.HTML, "DoubleStringFore"];
        scintilla.Styles[Style.Html.DoubleString].BackColor = lexerColors[LexerType.HTML, "DoubleStringBack"];

        // SINGLESTRING, fontStyle = 1, styleId = 7
        scintilla.Styles[Style.Html.SingleString].Bold = true;
        scintilla.Styles[Style.Html.SingleString].ForeColor = lexerColors[LexerType.HTML, "SingleStringFore"];
        scintilla.Styles[Style.Html.SingleString].BackColor = lexerColors[LexerType.HTML, "SingleStringBack"];

        // TAG, fontStyle = 0, styleId = 1
        scintilla.Styles[Style.Html.Tag].ForeColor = lexerColors[LexerType.HTML, "TagFore"];
        scintilla.Styles[Style.Html.Tag].BackColor = lexerColors[LexerType.HTML, "TagBack"];

        // TAGEND, fontStyle = 0, styleId = 11
        scintilla.Styles[Style.Html.TagEnd].ForeColor = lexerColors[LexerType.HTML, "TagEndFore"];
        scintilla.Styles[Style.Html.TagEnd].BackColor = lexerColors[LexerType.HTML, "TagEndBack"];

        // TAGUNKNOWN, fontStyle = 0, styleId = 2
        scintilla.Styles[Style.Html.TagUnknown].ForeColor = lexerColors[LexerType.HTML, "TagUnknownFore"];
        scintilla.Styles[Style.Html.TagUnknown].BackColor = lexerColors[LexerType.HTML, "TagUnknownBack"];

        // ATTRIBUTE, fontStyle = 0, styleId = 3
        scintilla.Styles[Style.Html.Attribute].ForeColor = lexerColors[LexerType.HTML, "AttributeFore"];
        scintilla.Styles[Style.Html.Attribute].BackColor = lexerColors[LexerType.HTML, "AttributeBack"];

        // ATTRIBUTEUNKNOWN, fontStyle = 0, styleId = 4
        scintilla.Styles[Style.Html.AttributeUnknown].ForeColor = lexerColors[LexerType.HTML, "AttributeUnknownFore"];
        scintilla.Styles[Style.Html.AttributeUnknown].BackColor = lexerColors[LexerType.HTML, "AttributeUnknownBack"];

        // SGMLDEFAULT, fontStyle = 0, styleId = 21
        scintilla.Styles[21].ForeColor = lexerColors[LexerType.HTML, "SGMDefaultFore"];
        scintilla.Styles[21].BackColor = lexerColors[LexerType.HTML, "SGMDefaultBack"];
    }

    /// <summary>
    /// Sets the PHP styles for a lexer.
    /// </summary>
    /// <param name="scintilla">A <see cref="Scintilla"/> class instance.</param>
    /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
    public static void SetPhpStyles(Scintilla scintilla, LexerColors.LexerColors lexerColors)
    {
        // QUESTION MARK, fontStyle = 0, styleId = 18
        scintilla.Styles[Style.Html.Question].ForeColor = lexerColors[LexerType.PHP, "HQuestionFore"];
        scintilla.Styles[Style.Html.Question].BackColor = lexerColors[LexerType.PHP, "HQuestionBack"];

        // DEFAULT, fontStyle = 0, styleId = 118
        scintilla.Styles[Style.PhpScript.Default].ForeColor = lexerColors[LexerType.PHP, "DefaultFore"];
        scintilla.Styles[Style.PhpScript.Default].BackColor = lexerColors[LexerType.PHP, "DefaultBack"];

        // STRING, fontStyle = 0, styleId = 119
        scintilla.Styles[Style.PhpScript.HString].ForeColor = lexerColors[LexerType.PHP, "HStringFore"];
        scintilla.Styles[Style.PhpScript.HString].BackColor = lexerColors[LexerType.PHP, "HStringBack"];

        // STRING VARIABLE, fontStyle = 1, styleId = 126
        scintilla.Styles[Style.PhpScript.HStringVariable].Bold = true;
        scintilla.Styles[Style.PhpScript.HStringVariable].ForeColor = lexerColors[LexerType.PHP, "HStringVariableFore"];
        scintilla.Styles[Style.PhpScript.HStringVariable].BackColor = lexerColors[LexerType.PHP, "HStringVariableBack"];

        // SIMPLESTRING, fontStyle = 0, styleId = 120
        scintilla.Styles[Style.PhpScript.SimpleString].ForeColor = lexerColors[LexerType.PHP, "SimpleStringFore"];
        scintilla.Styles[Style.PhpScript.SimpleString].BackColor = lexerColors[LexerType.PHP, "SimpleStringBack"];

        // WORD, fontStyle = 1, styleId = 121
        scintilla.Styles[Style.PhpScript.Word].Bold = true;
        scintilla.Styles[Style.PhpScript.Word].ForeColor = lexerColors[LexerType.PHP, "WordFore"];
        scintilla.Styles[Style.PhpScript.Word].BackColor = lexerColors[LexerType.PHP, "WordBack"];

        // NUMBER, fontStyle = 0, styleId = 122
        scintilla.Styles[Style.PhpScript.Number].ForeColor = lexerColors[LexerType.PHP, "NumberFore"];
        scintilla.Styles[Style.PhpScript.Number].BackColor = lexerColors[LexerType.PHP, "NumberBack"];

        // VARIABLE, fontStyle = 0, styleId = 123
        scintilla.Styles[Style.PhpScript.Variable].ForeColor = lexerColors[LexerType.PHP, "VariableFore"];
        scintilla.Styles[Style.PhpScript.Variable].BackColor = lexerColors[LexerType.PHP, "VariableBack"];

        // COMMENT, fontStyle = 0, styleId = 124
        scintilla.Styles[Style.PhpScript.Comment].ForeColor = lexerColors[LexerType.PHP, "CommentFore"];
        scintilla.Styles[Style.PhpScript.Comment].BackColor = lexerColors[LexerType.PHP, "CommentBack"];

        // COMMENTLINE, fontStyle = 0, styleId = 125
        scintilla.Styles[Style.PhpScript.CommentLine].ForeColor = lexerColors[LexerType.PHP, "CommentLineFore"];
        scintilla.Styles[Style.PhpScript.CommentLine].BackColor = lexerColors[LexerType.PHP, "CommentLineBack"];

        // OPERATOR, fontStyle = 0, styleId = 127
        scintilla.Styles[Style.PhpScript.Operator].ForeColor = lexerColors[LexerType.PHP, "OperatorFore"];
        scintilla.Styles[Style.PhpScript.Operator].BackColor = lexerColors[LexerType.PHP, "OperatorBack"];
    }

    /// <summary>
    /// A helper method to be used with HTML including scripts.
    /// </summary>
    /// <param name="lexerType">Type of the lexer to embed into the HTML lexer.</param>
    /// <param name="scintilla">An instance to a scintilla to which to append the script lexer.</param>
    /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
    public static void SetScriptedHtml(LexerType lexerType, Scintilla scintilla, LexerColors.LexerColors lexerColors)
    {
        if (lexerType == LexerType.PHP || lexerType == LexerType.HTML)
        {
            SetHtmlStyles(scintilla, lexerColors);

            if (lexerType == LexerType.PHP)
            {
                var keyWords =
                    ScintillaKeyWords.KeyWordList.FirstOrDefault(f => f.LexerType == LexerType.HTML);

                if (keyWords != null)
                {
                    scintilla.SetKeywords(1, keyWords.KeyWords);
                }
            }
            else if (lexerType == LexerType.HTML)
            {
                var keyWords =
                    ScintillaKeyWords.KeyWordList.FirstOrDefault(f => f.LexerType == LexerType.PHP);

                if (keyWords != null)
                {
                    scintilla.SetKeywords(1, keyWords.KeyWords);
                }
            }


            LexerFoldProperties.SetScintillaProperties(scintilla, LexerFoldProperties.HyperTextFolding);

            SetHtmlStyles(scintilla, lexerColors);
        }
    }
}