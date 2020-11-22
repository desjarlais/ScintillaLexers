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
    // ReSharper disable once CommentTypo
    /// <summary>
    /// Constants for the InnoSetup script language.
    /// </summary>
    // ReSharper disable once IdentifierTypo
    public static class InnoSetup
    {
        ///
        /// Summary:
        ///     Default style index.
        public const int Default = 0;

        ///
        /// Summary:
        ///     Identifier style index.
        public const int Identifier = 1;

        ///
        /// Summary:
        ///     Comment style '{' index.
        public const int Comment = 2;

        ///
        /// Summary:
        ///     Comment style 2 "(*" index.
        public const int Comment2 = 3;

        ///
        /// Summary:
        ///     Comment line style "//" index.
        public const int CommentLine = 4;

        ///
        /// Summary:
        ///     Preprocessor style "{$" index.
        public const int Preprocessor = 5;

        ///
        /// Summary:
        ///     Preprocessor style 2 "(*$" index.
        public const int Preprocessor2 = 6;

        ///
        /// Summary:
        ///     Number style index.
        public const int Number = 7;

        ///
        /// Summary:
        ///     Hexadecimal number style index.
        public const int HexNumber = 8;

        ///
        /// Summary:
        ///     Word (keyword set 0) style index.
        public const int Word = 9;

        ///
        /// Summary:
        ///     Double-quoted string style index.
        public const int String = 10;

        ///
        /// Summary:
        ///     Unclosed string EOL style index.
        public const int StringEol = 11;

        ///
        /// Summary:
        ///     Single-quoted string style index.
        public const int Character = 12;

        ///
        /// Summary:
        ///     Operator style index.
        public const int Operator = 13;

        ///
        /// Summary:
        ///     Assembly style index.
        public const int Asm = 14;
    }

    // ReSharper disable once CommentTypo
    /// <summary>
    /// A class for the InnoSetup lexer.
    /// Implements the <see cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    /// </summary>
    /// <seealso cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    // ReSharper disable once IdentifierTypo
    public class CreateLexerInnoSetup: CreateLexerCommon
    {
        // ReSharper disable once CommentTypo
        /// <summary>
        /// Creates the lexer for a given Scintilla class instance for the InnoSetup programming language.
        /// </summary>
        /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
        /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        // ReSharper disable once IdentifierTypo
        public static bool CreateInnoSetupLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
        {
            ClearStyle(scintilla);

            // DEFAULT, fontStyle = 0 
            scintilla.Styles[InnoSetup.Default].ForeColor = lexerColors[LexerType.InnoSetup, "DefaultFore"];
            scintilla.Styles[InnoSetup.Default].BackColor = lexerColors[LexerType.InnoSetup, "DefaultBack"];

            // IDENTIFIER, fontStyle = 0 
            scintilla.Styles[InnoSetup.Identifier].ForeColor = lexerColors[LexerType.InnoSetup, "IdentifierFore"];
            scintilla.Styles[InnoSetup.Identifier].BackColor = lexerColors[LexerType.InnoSetup, "IdentifierBack"];

            // COMMENT, fontStyle = 0 
            scintilla.Styles[InnoSetup.Comment].ForeColor = lexerColors[LexerType.InnoSetup, "CommentFore"];
            scintilla.Styles[InnoSetup.Comment].BackColor = lexerColors[LexerType.InnoSetup, "CommentBack"];

            // COMMENT LINE, fontStyle = 0 
            scintilla.Styles[InnoSetup.Comment2].ForeColor = lexerColors[LexerType.InnoSetup, "Comment2Fore"];
            scintilla.Styles[InnoSetup.Comment2].BackColor = lexerColors[LexerType.InnoSetup, "Comment2Back"];

            // COMMENT DOC, fontStyle = 0 
            scintilla.Styles[InnoSetup.CommentLine].ForeColor = lexerColors[LexerType.InnoSetup, "CommentLineFore"];
            scintilla.Styles[InnoSetup.CommentLine].BackColor = lexerColors[LexerType.InnoSetup, "CommentLineBack"];

            // PREPROCESSOR, fontStyle = 0 
            scintilla.Styles[InnoSetup.Preprocessor].ForeColor = lexerColors[LexerType.InnoSetup, "PreprocessorFore"];
            scintilla.Styles[InnoSetup.Preprocessor].BackColor = lexerColors[LexerType.InnoSetup, "PreprocessorBack"];

            // PREPROCESSOR2, fontStyle = 0 
            scintilla.Styles[InnoSetup.Preprocessor2].ForeColor = lexerColors[LexerType.InnoSetup, "Preprocessor2Fore"];
            scintilla.Styles[InnoSetup.Preprocessor2].BackColor = lexerColors[LexerType.InnoSetup, "Preprocessor2Back"];

            // NUMBER, fontStyle = 0 
            scintilla.Styles[InnoSetup.Number].ForeColor = lexerColors[LexerType.InnoSetup, "NumberFore"];
            scintilla.Styles[InnoSetup.Number].BackColor = lexerColors[LexerType.InnoSetup, "NumberBack"];

            // HEX NUMBER, fontStyle = 0 
            scintilla.Styles[InnoSetup.HexNumber].ForeColor = lexerColors[LexerType.InnoSetup, "HexNumberFore"];
            scintilla.Styles[InnoSetup.HexNumber].BackColor = lexerColors[LexerType.InnoSetup, "HexNumberBack"];

            // INSTRUCTION WORD, fontStyle = 1 
            scintilla.Styles[InnoSetup.Word].Bold = true;
            scintilla.Styles[InnoSetup.Word].ForeColor = lexerColors[LexerType.InnoSetup, "WordFore"];
            scintilla.Styles[InnoSetup.Word].BackColor = lexerColors[LexerType.InnoSetup, "WordBack"];

            // STRING, fontStyle = 0 
            scintilla.Styles[InnoSetup.String].ForeColor = lexerColors[LexerType.InnoSetup, "StringFore"];
            scintilla.Styles[InnoSetup.String].BackColor = lexerColors[LexerType.InnoSetup, "StringBack"];

            // CHARACTER, fontStyle = 0 
            scintilla.Styles[InnoSetup.Character].ForeColor = lexerColors[LexerType.InnoSetup, "CharacterFore"];
            scintilla.Styles[InnoSetup.Character].BackColor = lexerColors[LexerType.InnoSetup, "CharacterBack"];

            // OPERATOR, fontStyle = 1 
            scintilla.Styles[InnoSetup.Operator].Bold = true;
            scintilla.Styles[InnoSetup.Operator].ForeColor = lexerColors[LexerType.InnoSetup, "OperatorFore"];
            scintilla.Styles[InnoSetup.Operator].BackColor = lexerColors[LexerType.InnoSetup, "OperatorBack"];

            // ASM, fontStyle = 1 
            scintilla.Styles[InnoSetup.Asm].Bold = true;
            scintilla.Styles[InnoSetup.Asm].ForeColor = lexerColors[LexerType.InnoSetup, "ForeColorFore"];
            scintilla.Styles[InnoSetup.Asm].BackColor = lexerColors[LexerType.InnoSetup, "ForeColorBack"];

            scintilla.Lexer = (Lexer)LexerTypeName.SCLEX_INNOSETUP;

            ScintillaKeyWords.SetKeywords(scintilla, LexerType.InnoSetup);

            AddFolding(scintilla);
            return true;
        }

        /// <summary>
        /// Creates a color value of a given integer containing an RGB color value.
        /// </summary>
        /// <param name="rgb">The RGB color value.</param>
        /// <returns>System.Drawing.Color.</returns>
        public static System.Drawing.Color IntToColor(int rgb)
        {
            return System.Drawing.Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }
    }
}
