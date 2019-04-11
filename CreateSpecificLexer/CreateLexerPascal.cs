#region License
/*
MIT License

Copyright (c) 2019 Petteri Kautonen

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
    /// A class for the Pascal lexer.
    /// Implements the <see cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    /// </summary>
    /// <seealso cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    public class CreateLexerPascal: CreateLexerCommon
    {
        /// <summary>
        /// Creates the lexer for a given Scintilla class instance for the Pascal programming language.
        /// </summary>
        /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
        /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool CreatePascalLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
        {
            ClearStyle(scintilla);

            // DEFAULT, fontStyle = 0 
            scintilla.Styles[Style.Pascal.Default].ForeColor = lexerColors[LexerType.Pascal, "DefaultFore"];
            scintilla.Styles[Style.Pascal.Default].BackColor = lexerColors[LexerType.Pascal, "DefaultBack"];

            // IDENTIFIER, fontStyle = 0 
            scintilla.Styles[Style.Pascal.Identifier].ForeColor = lexerColors[LexerType.Pascal, "IdentifierFore"];
            scintilla.Styles[Style.Pascal.Identifier].BackColor = lexerColors[LexerType.Pascal, "IdentifierBack"];

            // COMMENT, fontStyle = 0 
            scintilla.Styles[Style.Pascal.Comment].ForeColor = lexerColors[LexerType.Pascal, "CommentFore"];
            scintilla.Styles[Style.Pascal.Comment].BackColor = lexerColors[LexerType.Pascal, "CommentBack"];

            // COMMENT LINE, fontStyle = 0 
            scintilla.Styles[Style.Pascal.Comment2].ForeColor = lexerColors[LexerType.Pascal, "Comment2Fore"];
            scintilla.Styles[Style.Pascal.Comment2].BackColor = lexerColors[LexerType.Pascal, "Comment2Back"];

            // COMMENT DOC, fontStyle = 0 
            scintilla.Styles[Style.Pascal.CommentLine].ForeColor = lexerColors[LexerType.Pascal, "CommentLineFore"];
            scintilla.Styles[Style.Pascal.CommentLine].BackColor = lexerColors[LexerType.Pascal, "CommentLineBack"];

            // PREPROCESSOR, fontStyle = 0 
            scintilla.Styles[Style.Pascal.Preprocessor].ForeColor = lexerColors[LexerType.Pascal, "PreprocessorFore"];
            scintilla.Styles[Style.Pascal.Preprocessor].BackColor = lexerColors[LexerType.Pascal, "PreprocessorBack"];

            // PREPROCESSOR2, fontStyle = 0 
            scintilla.Styles[Style.Pascal.Preprocessor2].ForeColor = lexerColors[LexerType.Pascal, "Preprocessor2Fore"];
            scintilla.Styles[Style.Pascal.Preprocessor2].BackColor = lexerColors[LexerType.Pascal, "Preprocessor2Back"];

            // NUMBER, fontStyle = 0 
            scintilla.Styles[Style.Pascal.Number].ForeColor = lexerColors[LexerType.Pascal, "NumberFore"];
            scintilla.Styles[Style.Pascal.Number].BackColor = lexerColors[LexerType.Pascal, "NumberBack"];

            // HEX NUMBER, fontStyle = 0 
            scintilla.Styles[Style.Pascal.HexNumber].ForeColor = lexerColors[LexerType.Pascal, "HexNumberFore"];
            scintilla.Styles[Style.Pascal.HexNumber].BackColor = lexerColors[LexerType.Pascal, "HexNumberBack"];

            // INSTRUCTION WORD, fontStyle = 1 
            scintilla.Styles[Style.Pascal.Word].Bold = true;
            scintilla.Styles[Style.Pascal.Word].ForeColor = lexerColors[LexerType.Pascal, "WordFore"];
            scintilla.Styles[Style.Pascal.Word].BackColor = lexerColors[LexerType.Pascal, "WordBack"];

            // STRING, fontStyle = 0 
            scintilla.Styles[Style.Pascal.String].ForeColor = lexerColors[LexerType.Pascal, "StringFore"];
            scintilla.Styles[Style.Pascal.String].BackColor = lexerColors[LexerType.Pascal, "StringBack"];

            // CHARACTER, fontStyle = 0 
            scintilla.Styles[Style.Pascal.Character].ForeColor = lexerColors[LexerType.Pascal, "CharacterFore"];
            scintilla.Styles[Style.Pascal.Character].BackColor = lexerColors[LexerType.Pascal, "CharacterBack"];

            // OPERATOR, fontStyle = 1 
            scintilla.Styles[Style.Pascal.Operator].Bold = true;
            scintilla.Styles[Style.Pascal.Operator].ForeColor = lexerColors[LexerType.Pascal, "OperatorFore"];
            scintilla.Styles[Style.Pascal.Operator].BackColor = lexerColors[LexerType.Pascal, "OperatorBack"];

            // ASM, fontStyle = 1 
            scintilla.Styles[Style.Pascal.Asm].Bold = true;
            scintilla.Styles[Style.Pascal.Asm].ForeColor = lexerColors[LexerType.Pascal, "ForeColorFore"];
            scintilla.Styles[Style.Pascal.Asm].BackColor = lexerColors[LexerType.Pascal, "ForeColorBack"];
            scintilla.Lexer = Lexer.Pascal;

            ScintillaKeyWords.SetKeywords(scintilla, LexerType.Pascal);

            AddFolding(scintilla);
            return true;
        }
    }
}
