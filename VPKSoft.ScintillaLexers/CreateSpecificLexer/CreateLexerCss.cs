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

using ScintillaNET;
using VPKSoft.ScintillaLexers.HelperClasses;
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace VPKSoft.ScintillaLexers.CreateSpecificLexer;

class CreateLexerCss: CreateLexerCommon
{
    /// <summary>
    /// Creates the lexer for a given Scintilla class instance for the Cascading Style Sheets (CSS).
    /// </summary>
    /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
    /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
    /// <returns>True if the operation was successful; otherwise false.</returns>
    public static bool CreateCssLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
    {
        ClearStyle(scintilla);

        // DEFAULT, fontStyle = 0, styleId = 0
        scintilla.Styles[Style.Css.Default].ForeColor = lexerColors[LexerType.Css, "DefaultFore"];
        scintilla.Styles[Style.Css.Default].BackColor = lexerColors[LexerType.Css, "DefaultFore"];

        // TAG, fontStyle = 0, styleId = 1
        scintilla.Styles[Style.Css.Tag].ForeColor = lexerColors[LexerType.Css, "TagFore"];
        scintilla.Styles[Style.Css.Tag].BackColor = lexerColors[LexerType.Css, "TagBack"];

        // CLASS, fontStyle = 0, styleId = 2
        scintilla.Styles[Style.Css.Class].ForeColor = lexerColors[LexerType.Css, "ClassFore"];
        scintilla.Styles[Style.Css.Class].BackColor = lexerColors[LexerType.Css, "ClassBack"];

        // PSEUDOCLASS, fontStyle = 1, styleId = 3
        scintilla.Styles[Style.Css.PseudoClass].Bold = true;
        scintilla.Styles[Style.Css.PseudoClass].ForeColor = lexerColors[LexerType.Css, "PseudoClassFore"];
        scintilla.Styles[Style.Css.PseudoClass].BackColor = lexerColors[LexerType.Css, "PseudoClassBack"];

        // UNKNOWN_PSEUDOCLASS, fontStyle = 0, styleId = 4
        scintilla.Styles[Style.Css.UnknownPseudoClass].ForeColor = lexerColors[LexerType.Css, "UnknownPseudoClassFore"];
        scintilla.Styles[Style.Css.UnknownPseudoClass].BackColor = lexerColors[LexerType.Css, "UnknownPseudoClassBack"];

        // OPERATOR, fontStyle = 1, styleId = 5
        scintilla.Styles[Style.Css.Operator].Bold = true;
        scintilla.Styles[Style.Css.Operator].ForeColor = lexerColors[LexerType.Css, "OperatorFore"];
        scintilla.Styles[Style.Css.Operator].BackColor = lexerColors[LexerType.Css, "OperatorBack"];

        // IDENTIFIER, fontStyle = 1, styleId = 6
        scintilla.Styles[Style.Css.Identifier].Bold = true;
        scintilla.Styles[Style.Css.Identifier].ForeColor = lexerColors[LexerType.Css, "IdentifierFore"];
        scintilla.Styles[Style.Css.Identifier].BackColor = lexerColors[LexerType.Css, "IdentifierBack"];

        // UNKNOWN_IDENTIFIER, fontStyle = 0, styleId = 7
        scintilla.Styles[Style.Css.UnknownIdentifier].ForeColor = lexerColors[LexerType.Css, "UnknownIdentifierFore"];
        scintilla.Styles[Style.Css.UnknownIdentifier].BackColor = lexerColors[LexerType.Css, "UnknownIdentifierBack"];

        // VALUE, fontStyle = 1, styleId = 8
        scintilla.Styles[Style.Css.Value].Bold = true;
        scintilla.Styles[Style.Css.Value].ForeColor = lexerColors[LexerType.Css, "ValueFore"];
        scintilla.Styles[Style.Css.Value].BackColor = lexerColors[LexerType.Css, "ValueBack"];

        // COMMENT, fontStyle = 0, styleId = 9
        scintilla.Styles[Style.Css.Comment].ForeColor = lexerColors[LexerType.Css, "CommentFore"];
        scintilla.Styles[Style.Css.Comment].BackColor = lexerColors[LexerType.Css, "CommentBack"];

        // ID, fontStyle = 1, styleId = 10
        scintilla.Styles[Style.Css.Id].Bold = true;
        scintilla.Styles[Style.Css.Id].ForeColor = lexerColors[LexerType.Css, "IdFore"];
        scintilla.Styles[Style.Css.Id].BackColor = lexerColors[LexerType.Css, "IdBack"];

        // IMPORTANT, fontStyle = 1, styleId = 11
        scintilla.Styles[Style.Css.Important].Bold = true;
        scintilla.Styles[Style.Css.Important].ForeColor = lexerColors[LexerType.Css, "ImportantFore"];
        scintilla.Styles[Style.Css.Important].BackColor = lexerColors[LexerType.Css, "ImportantBack"];

        // DIRECTIVE, fontStyle = 0, styleId = 12
        scintilla.Styles[Style.Css.Directive].ForeColor = lexerColors[LexerType.Css, "DirectiveFore"];
        scintilla.Styles[Style.Css.Directive].BackColor = lexerColors[LexerType.Css, "DirectiveBack"];


        scintilla.LexerName = "css";

        ScintillaKeyWords.SetKeywords(scintilla, LexerType.Css);

        AddFolding(scintilla);

        return true;
    }
}