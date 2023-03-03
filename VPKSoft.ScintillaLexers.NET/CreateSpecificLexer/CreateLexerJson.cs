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

namespace VPKSoft.ScintillaLexers.CreateSpecificLexer;

/// <summary>
/// A class for the YAML lexer.
/// Implements the <see cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
/// </summary>
/// <seealso cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
public abstract class CreateLexerJson: CreateLexerCommon
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

        // DEFAULT
        scintilla.Styles[Style.Json.Default].ForeColor = lexerColors[LexerType.Json, "JsonDefaultFore"];
        scintilla.Styles[Style.Json.Default].BackColor = lexerColors[LexerType.Json, "JsonDefaultBack"];

        // NUMBER
        scintilla.Styles[Style.Json.Number].ForeColor = lexerColors[LexerType.Json, "JsonNumberFore"];
        scintilla.Styles[Style.Json.Number].BackColor = lexerColors[LexerType.Json, "JsonNumberBack"];

        // STRING
        scintilla.Styles[Style.Json.String].ForeColor = lexerColors[LexerType.Json, "JsonStringFore"];
        scintilla.Styles[Style.Json.String].BackColor = lexerColors[LexerType.Json, "JsonStringBack"];

        // UNCLOSED STRING
        scintilla.Styles[Style.Json.StringEol].ForeColor = lexerColors[LexerType.Json, "JsonUnclosedStringFore"];
        scintilla.Styles[Style.Json.StringEol].BackColor = lexerColors[LexerType.Json, "JsonUnclosedStringBack"];
            
        // PROPERTY
        scintilla.Styles[Style.Json.PropertyName].ForeColor = lexerColors[LexerType.Json, "JsonPropertyFore"];
        scintilla.Styles[Style.Json.PropertyName].BackColor = lexerColors[LexerType.Json, "JsonPropertyBack"];

        // ESCAPE SEQUENCE
        scintilla.Styles[Style.Json.LineComment].ForeColor = lexerColors[LexerType.Json, "JsonEscapeSequenceFore"];
        scintilla.Styles[Style.Json.LineComment].BackColor = lexerColors[LexerType.Json, "JsonEscapeSequenceBack"];

        // LINE COMMENT
        scintilla.Styles[Style.Json.LineComment].ForeColor = lexerColors[LexerType.Json, "JsonLineCommentFore"];
        scintilla.Styles[Style.Json.LineComment].BackColor = lexerColors[LexerType.Json, "JsonLineCommentBack"];
        scintilla.Styles[Style.Json.LineComment].Italic = true;

        // BLOCK COMMENT
        scintilla.Styles[Style.Json.BlockComment].ForeColor = lexerColors[LexerType.Json, "JsonBlockCommentFore"];
        scintilla.Styles[Style.Json.BlockComment].BackColor = lexerColors[LexerType.Json, "JsonBlockCommentBack"];

        // OPERATOR
        scintilla.Styles[Style.Json.Operator].ForeColor = lexerColors[LexerType.Json, "JsonOperatorFore"];
        scintilla.Styles[Style.Json.Operator].BackColor = lexerColors[LexerType.Json, "JsonOperatorBack"];

        // URL/IRI
        scintilla.Styles[Style.Json.Uri].ForeColor = lexerColors[LexerType.Json, "JsonUriFore"];
        scintilla.Styles[Style.Json.Uri].BackColor = lexerColors[LexerType.Json, "JsonUriBack"];

        // JSON-LD COMPACT IRI
        scintilla.Styles[Style.Json.CompactIRI].ForeColor = lexerColors[LexerType.Json, "JsonCompactIRIFore"];
        scintilla.Styles[Style.Json.CompactIRI].BackColor = lexerColors[LexerType.Json, "JsonCompactIRIBack"];

        // JSON KEYWORD
        scintilla.Styles[Style.Json.Keyword].ForeColor = lexerColors[LexerType.Json, "JsonKeywordFore"];
        scintilla.Styles[Style.Json.Keyword].BackColor = lexerColors[LexerType.Json, "JsonKeywordBack"];

        // JSON-LD KEYWORD
        scintilla.Styles[Style.Json.LdKeyword].ForeColor = lexerColors[LexerType.Json, "JsonLdKeywordFore"];
        scintilla.Styles[Style.Json.LdKeyword].BackColor = lexerColors[LexerType.Json, "JsonLdKeywordBack"];

        // PARSING ERROR
        scintilla.Styles[Style.Json.LdKeyword].ForeColor = lexerColors[LexerType.Json, "JsonErrorFore"];
        scintilla.Styles[Style.Json.LdKeyword].BackColor = lexerColors[LexerType.Json, "JsonErrorBack"];
        scintilla.LexerName = "json";

        ScintillaKeyWords.SetKeywords(scintilla, LexerType.Json);

        scintilla.SetProperty("lexer.json.allow.comments", "1");
        scintilla.SetProperty("lexer.json.escape.sequence", "1");

        AddFolding(scintilla);
        return true;
    }

}