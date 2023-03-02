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
using VPKSoft.ScintillaLexers.LexerColors;
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace VPKSoft.ScintillaLexers.CreateSpecificLexer
{
    /// <summary>
    /// A class for the Batch lexer.
    /// Implements the <see cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    /// </summary>
    /// <seealso cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    public class CreateLexerVb: CreateLexerCommon
    {
        /// <summary>
        /// Creates the lexer for a given Scintilla class instance for the batch script file.
        /// </summary>
        /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
        /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool CreateVbLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
        {
            ClearStyle(scintilla);

            // DEFAULT, fontStyle = 0, styleId = 7
            scintilla.Styles[Style.Vb.Default].ForeColor = lexerColors[LexerType.VbDotNet, "DefaultFore"];
            scintilla.Styles[Style.Vb.Default].BackColor = lexerColors[LexerType.VbDotNet, "DefaultBack"];

            // COMMENT, fontStyle = 0, styleId = 1
            scintilla.Styles[Style.Vb.Comment].ForeColor = lexerColors[LexerType.VbDotNet, "CommentFore"];
            scintilla.Styles[Style.Vb.Comment].BackColor = lexerColors[LexerType.VbDotNet, "CommentBack"];

            // NUMBER, fontStyle = 1, styleId = 2
            scintilla.Styles[Style.Vb.Number].Bold = true;
            scintilla.Styles[Style.Vb.Number].ForeColor = lexerColors[LexerType.VbDotNet, "NumberFore"];
            scintilla.Styles[Style.Vb.Number].BackColor = lexerColors[LexerType.VbDotNet, "NumberBack"];

            // WORD, fontStyle = 0, styleId = 3
            scintilla.Styles[Style.Vb.Keyword].ForeColor = lexerColors[LexerType.VbDotNet, "WordFore"];
            scintilla.Styles[Style.Vb.Keyword].BackColor = lexerColors[LexerType.VbDotNet, "WordBack"];

            // WORD2, fontStyle = 0, styleId = 10
            scintilla.Styles[Style.Vb.Keyword2].ForeColor = lexerColors[LexerType.VbDotNet, "Word2Fore"];
            scintilla.Styles[Style.Vb.Keyword2].BackColor = lexerColors[LexerType.VbDotNet, "Word2Back"];

            // STRING, fontStyle = 0, styleId = 4
            scintilla.Styles[Style.Vb.String].ForeColor = lexerColors[LexerType.VbDotNet, "StringFore"];
            scintilla.Styles[Style.Vb.String].BackColor = lexerColors[LexerType.VbDotNet, "StringBack"];

            // PREPROCESSOR, fontStyle = 0, styleId = 5
            scintilla.Styles[Style.Vb.Preprocessor].ForeColor = lexerColors[LexerType.VbDotNet, "PreprocessorFore"];
            scintilla.Styles[Style.Vb.Preprocessor].BackColor = lexerColors[LexerType.VbDotNet, "PreprocessorBack"];

            // OPERATOR, fontStyle = 1, styleId = 6
            scintilla.Styles[Style.Vb.Operator].Bold = true;
            scintilla.Styles[Style.Vb.Operator].ForeColor = lexerColors[LexerType.VbDotNet, "OperatorFore"];
            scintilla.Styles[Style.Vb.Operator].BackColor = lexerColors[LexerType.VbDotNet, "OperatorBack"];

            // DATE, fontStyle = 0, styleId = 8
            scintilla.Styles[Style.Vb.Date].ForeColor = lexerColors[LexerType.VbDotNet, "DateFore"];
            scintilla.Styles[Style.Vb.Date].BackColor = lexerColors[LexerType.VbDotNet, "DateBack"];
            scintilla.LexerName = "vb";
            
            ScintillaKeyWords.SetKeywords(scintilla, LexerType.VbDotNet);

            AddFolding(scintilla);
            return true;
        }
    }
}
