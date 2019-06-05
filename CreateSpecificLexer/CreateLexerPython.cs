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

using ScintillaNET;
using VPKSoft.ScintillaLexers.HelperClasses;
using VPKSoft.ScintillaLexers.LexerColors;
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace VPKSoft.ScintillaLexers.CreateSpecificLexer
{
    /// <summary>
    /// A class for the Python lexer.
    /// Implements the <see cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    /// </summary>
    /// <seealso cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    public class CreateLexerPython: CreateLexerCommon
    {
        /// <summary>
        /// Creates the lexer for a given Scintilla class instance for the Python programming language.
        /// </summary>
        /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
        /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool CreatePythonLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
        {
            ClearStyle(scintilla);

            // DEFAULT, fontStyle = 0, styleId = 0
            scintilla.Styles[Style.Python.Default].ForeColor = lexerColors[LexerType.Python, "DefaultFore"];
            scintilla.Styles[Style.Python.Default].BackColor = lexerColors[LexerType.Python, "DefaultBack"];

            // COMMENTLINE, fontStyle = 0, styleId = 1
            scintilla.Styles[Style.Python.CommentLine].ForeColor = lexerColors[LexerType.Python, "CommentLineFore"];
            scintilla.Styles[Style.Python.CommentLine].BackColor = lexerColors[LexerType.Python, "CommentLineBack"];

            // NUMBER, fontStyle = 0, styleId = 2
            scintilla.Styles[Style.Python.Number].ForeColor = lexerColors[LexerType.Python, "NumberFore"];
            scintilla.Styles[Style.Python.Number].BackColor = lexerColors[LexerType.Python, "NumberBack"];

            // STRING, fontStyle = 0, styleId = 3
            scintilla.Styles[Style.Python.String].ForeColor = lexerColors[LexerType.Python, "StringFore"];
            scintilla.Styles[Style.Python.String].BackColor = lexerColors[LexerType.Python, "StringBack"];

            // CHARACTER, fontStyle = 0, styleId = 4
            scintilla.Styles[Style.Python.Character].ForeColor = lexerColors[LexerType.Python, "CharacterFore"];
            scintilla.Styles[Style.Python.Character].BackColor = lexerColors[LexerType.Python, "CharacterBack"];

            // KEYWORDS, fontStyle = 1, styleId = 5
            scintilla.Styles[Style.Python.Word].Bold = true;
            scintilla.Styles[Style.Python.Word].ForeColor = lexerColors[LexerType.Python, "WordFore"];
            scintilla.Styles[Style.Python.Word].BackColor = lexerColors[LexerType.Python, "WordBack"];

            // TRIPLE, fontStyle = 0, styleId = 6
            scintilla.Styles[Style.Python.Triple].ForeColor = lexerColors[LexerType.Python, "TripleFore"];
            scintilla.Styles[Style.Python.Triple].BackColor = lexerColors[LexerType.Python, "TripleBack"];

            // TRIPLEDOUBLE, fontStyle = 0, styleId = 7
            scintilla.Styles[Style.Python.TripleDouble].ForeColor = lexerColors[LexerType.Python, "TripleDoubleFore"];
            scintilla.Styles[Style.Python.TripleDouble].BackColor = lexerColors[LexerType.Python, "TripleDoubleBack"];

            // CLASSNAME, fontStyle = 1, styleId = 8
            scintilla.Styles[Style.Python.ClassName].Bold = true;
            scintilla.Styles[Style.Python.ClassName].ForeColor = lexerColors[LexerType.Python, "ClassNameFore"];
            scintilla.Styles[Style.Python.ClassName].BackColor = lexerColors[LexerType.Python, "ClassNameBack"];

            // DEFNAME, fontStyle = 0, styleId = 9
            scintilla.Styles[Style.Python.DefName].ForeColor = lexerColors[LexerType.Python, "DefNameFore"];
            scintilla.Styles[Style.Python.DefName].BackColor = lexerColors[LexerType.Python, "DefNameBack"];

            // OPERATOR, fontStyle = 1, styleId = 10
            scintilla.Styles[Style.Python.Operator].Bold = true;
            scintilla.Styles[Style.Python.Operator].ForeColor = lexerColors[LexerType.Python, "OperatorFore"];
            scintilla.Styles[Style.Python.Operator].BackColor = lexerColors[LexerType.Python, "OperatorBack"];

            // IDENTIFIER, fontStyle = 0, styleId = 11
            scintilla.Styles[Style.Python.Identifier].ForeColor = lexerColors[LexerType.Python, "IdentifierFore"];
            scintilla.Styles[Style.Python.Identifier].BackColor = lexerColors[LexerType.Python, "IdentifierBack"];

            // COMMENTBLOCK, fontStyle = 0, styleId = 12
            scintilla.Styles[Style.Python.CommentBlock].ForeColor = lexerColors[LexerType.Python, "CommentBlockFore"];
            scintilla.Styles[Style.Python.CommentBlock].BackColor = lexerColors[LexerType.Python, "CommentBlockBack"];

            // DECORATOR, fontStyle = 2, styleId = 15
            scintilla.Styles[Style.Python.Decorator].Italic = true;
            scintilla.Styles[Style.Python.Decorator].ForeColor = lexerColors[LexerType.Python, "DecoratorFore"];
            scintilla.Styles[Style.Python.Decorator].BackColor = lexerColors[LexerType.Python, "DecoratorBack"];

            scintilla.Lexer = Lexer.Python;
            
            ScintillaKeyWords.SetKeywords(scintilla, LexerType.Python);

            AddFolding(scintilla);

            return true;
        }
    }
}
