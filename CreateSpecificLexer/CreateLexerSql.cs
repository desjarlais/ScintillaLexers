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
    /// A class for the SQL lexer.
    /// Implements the <see cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    /// </summary>
    /// <seealso cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    public class CreateLexerSql: CreateLexerCommon
    {
        /// <summary>
        /// Creates the lexer for a given Scintilla class instance for the Structured Query Language (SQL).
        /// </summary>
        /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
        /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool CreateSqlLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
        {
            ClearStyle(scintilla);

            // KEYWORD, fontStyle = 1 
            scintilla.Styles[Style.Sql.Word].Bold = true;
            scintilla.Styles[Style.Sql.Word].ForeColor = lexerColors[LexerType.SQL, "WordFore"];
            scintilla.Styles[Style.Sql.Word].BackColor = lexerColors[LexerType.SQL, "WordBack"];

            // NUMBER, fontStyle = 0 
            scintilla.Styles[Style.Sql.Number].ForeColor = lexerColors[LexerType.SQL, "NumberFore"];
            scintilla.Styles[Style.Sql.Number].BackColor = lexerColors[LexerType.SQL, "NumberBack"];

            // STRING, fontStyle = 0 
            scintilla.Styles[Style.Sql.String].ForeColor = lexerColors[LexerType.SQL, "StringFore"];
            scintilla.Styles[Style.Sql.String].BackColor = lexerColors[LexerType.SQL, "StringBack"];

            // STRING2, fontStyle = 0 
            scintilla.Styles[Style.Sql.Character].ForeColor =
                lexerColors[LexerType.SQL, "CharacterFore"];
            scintilla.Styles[Style.Sql.Character].BackColor =
                lexerColors[LexerType.SQL, "CharacterBack"];

            // OPERATOR, fontStyle = 1 
            scintilla.Styles[Style.Sql.Operator].Bold = true;
            scintilla.Styles[Style.Sql.Operator].ForeColor =
                lexerColors[LexerType.SQL, "OperatorFore"];
            scintilla.Styles[Style.Sql.Operator].BackColor =
                lexerColors[LexerType.SQL, "OperatorBack"];

            // COMMENT, fontStyle = 0 
            scintilla.Styles[Style.Sql.Comment].ForeColor = lexerColors[LexerType.SQL, "CommentFore"];
            scintilla.Styles[Style.Sql.Comment].BackColor = lexerColors[LexerType.SQL, "CommentBack"];

            // COMMENT LINE, fontStyle = 0 
            scintilla.Styles[Style.Sql.CommentLine].ForeColor =
                lexerColors[LexerType.SQL, "CommentLineFore"];
            scintilla.Styles[Style.Sql.CommentLine].BackColor =
                lexerColors[LexerType.SQL, "CommentLineBack"];

            scintilla.Lexer = Lexer.Sql;
            
            ScintillaKeyWords.SetKeywords(scintilla, LexerType.SQL);

            LexerFoldProperties.SetScintillaProperties(scintilla, LexerFoldProperties.SqlFolding);

            AddFolding(scintilla);
            return true;
        }
    }
}
