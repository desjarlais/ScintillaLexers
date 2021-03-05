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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScintillaNET;
using VPKSoft.ScintillaLexers.HelperClasses;
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace VPKSoft.ScintillaLexers.CreateSpecificLexer
{
    /// <summary>
    /// A class for the YAML lexer.
    /// Implements the <see cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    /// </summary>
    /// <seealso cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    public class CreateLexerJson: CreateLexerCommon
    {
        /// <summary>
        /// Creates the lexer for a given Scintilla class instance for the YAML (YAML Ain't Markup Language).
        /// </summary>
        /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
        /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool CreateJsonLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
        {
            ClearStyle(scintilla);

            // DEFAULT, fontStyle = 0
            // DEFAULT, fontStyle = 0, styleId = 11
            scintilla.Styles[Style.Json.Keyword].ForeColor = lexerColors[LexerType.Json, "JsonKeywordFore"];
            scintilla.Styles[Style.Json.Keyword].BackColor = lexerColors[LexerType.Json, "JsonKeywordFore"];

            // NUMBER, fontStyle = 0, styleId = 4
            scintilla.Styles[Style.Json.PropertyName].ForeColor = lexerColors[LexerType.Json, "JsonNumberFore"];
            scintilla.Styles[Style.Json.PropertyName].BackColor = lexerColors[LexerType.Json, "JsonNumberBack"];

            // STRING DOUBLE QUOTE, fontStyle = 0, styleId = 6
            scintilla.Styles[Style.Json.LineComment].ForeColor = lexerColors[LexerType.Json, "JsonDoubleQuoteFore"];
            scintilla.Styles[Style.Json.LineComment].BackColor = lexerColors[LexerType.Json, "JsonDoubleQuoteBack"];

            // STRING SINGLE QUOTE, fontStyle = 0, styleId = 7
            scintilla.Styles[Style.Json.BlockComment].ForeColor = lexerColors[LexerType.Json, "JsonSingleQuoteFore"];
            scintilla.Styles[Style.Json.BlockComment].BackColor = lexerColors[LexerType.Json, "JsonSingleQuoteBack"];
            
            // BOOLEAN NULL, fontStyle = 1, styleId = 5
            scintilla.Styles[Style.Json.EscapeSequence].Bold = true;
            scintilla.Styles[Style.Json.EscapeSequence].ForeColor = lexerColors[LexerType.Json, "JsonBollNullQuoteFore"];
            scintilla.Styles[Style.Json.EscapeSequence].BackColor = lexerColors[LexerType.Json, "JsonBollNullQuoteBack"];

            // OPERATOR, fontStyle = 1, styleId = 10
            scintilla.Styles[Style.Json.CompactIRI].Bold = true;
            scintilla.Styles[Style.Json.CompactIRI].ForeColor = lexerColors[LexerType.Json, "JsonOperatorFore"];
            scintilla.Styles[Style.Json.CompactIRI].BackColor = lexerColors[LexerType.Json, "JsonOperatorBack"];

            // Json one line comment..
            scintilla.Styles[8].ForeColor = lexerColors[LexerType.Json, "JsonCommentFore"];
            scintilla.Styles[8].BackColor = lexerColors[LexerType.Json, "JsonCommentBack"];

            // Json multi-line comment..
            scintilla.Styles[7].ForeColor = lexerColors[LexerType.Json, "JsonBlockCommentFore"];
            scintilla.Styles[7].BackColor = lexerColors[LexerType.Json, "JsonBlockCommentBack"];

            scintilla.Lexer = Lexer.Json;

            ScintillaKeyWords.SetKeywords(scintilla, LexerType.Json);

            AddFolding(scintilla);
            return true;
        }

    }
}
