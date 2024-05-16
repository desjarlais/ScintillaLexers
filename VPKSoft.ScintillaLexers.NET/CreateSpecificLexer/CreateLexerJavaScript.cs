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
using ScintillaLexers.HelperClasses;
using static ScintillaLexers.LexerEnumerations;

namespace ScintillaLexers.CreateSpecificLexer;

internal abstract class CreateLexerJavaScript: CreateLexerCommon
{
    /// <summary>
    /// Creates the lexer for a given Scintilla class instance for the Java programming language.
    /// </summary>
    /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
    /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
    /// <returns>True if the operation was successful; otherwise false.</returns>
    public static bool CreateJavaScriptLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
    {
        ClearStyle(scintilla);

        // 11 ?, Style.Cpp.Default = 0..
        // DEFAULT, fontStyle = 0, styleId = 11
        scintilla.Styles[Style.Cpp.Default].ForeColor = lexerColors[LexerType.JavaScript, "DefaultFore"];
        scintilla.Styles[Style.Cpp.Default].BackColor = lexerColors[LexerType.JavaScript, "DefaultBack"];
        // TODO::From here onward!!

        // INSTRUCTION WORD, fontStyle = 1, styleId = 5
        scintilla.Styles[Style.Cpp.Word].Bold = true;
        scintilla.Styles[Style.Cpp.Word].ForeColor = lexerColors[LexerType.JavaScript, "InstructionWordFore"];
        scintilla.Styles[Style.Cpp.Word].BackColor = lexerColors[LexerType.JavaScript, "InstructionWordBack"];

        // TYPE WORD, fontStyle = 0, styleId = 16
        scintilla.Styles[Style.Cpp.Word2].ForeColor = lexerColors[LexerType.JavaScript, "TypeWordFore"];
        scintilla.Styles[Style.Cpp.Word2].BackColor = lexerColors[LexerType.JavaScript, "TypeWordBack"];

        // WINDOW INSTRUCTION, fontStyle = 1, styleId = 19
        scintilla.Styles[Style.Cpp.GlobalClass].Bold = true;
        scintilla.Styles[Style.Cpp.GlobalClass].ForeColor = lexerColors[LexerType.JavaScript, "WindowInstructionFore"];
        scintilla.Styles[Style.Cpp.GlobalClass].BackColor = lexerColors[LexerType.JavaScript, "WindowInstructionBack"];

        // NUMBER, fontStyle = 0, styleId = 4
        scintilla.Styles[Style.Cpp.Number].ForeColor = lexerColors[LexerType.JavaScript, "NumberFore"];
        scintilla.Styles[Style.Cpp.Number].BackColor = lexerColors[LexerType.JavaScript, "NumberBack"];

        // STRING, fontStyle = 0, styleId = 6
        scintilla.Styles[Style.Cpp.String].ForeColor = lexerColors[LexerType.JavaScript, "StringFore"];
        scintilla.Styles[Style.Cpp.String].BackColor = lexerColors[LexerType.JavaScript, "StringBack"];

        // STRINGRAW, fontStyle = 0, styleId = 20
        scintilla.Styles[Style.Cpp.StringRaw].ForeColor = lexerColors[LexerType.JavaScript, "StringRawFore"];
        scintilla.Styles[Style.Cpp.StringRaw].BackColor = lexerColors[LexerType.JavaScript, "StringRawBack"];

        // CHARACTER, fontStyle = 0, styleId = 7
        scintilla.Styles[Style.Cpp.Character].ForeColor = lexerColors[LexerType.JavaScript, "CharacterFore"];
        scintilla.Styles[Style.Cpp.Character].BackColor = lexerColors[LexerType.JavaScript, "CharacterBack"];

        // OPERATOR, fontStyle = 1, styleId = 10
        scintilla.Styles[Style.Cpp.Operator].Bold = true;
        scintilla.Styles[Style.Cpp.Operator].ForeColor = lexerColors[LexerType.JavaScript, "OperatorFore"];
        scintilla.Styles[Style.Cpp.Operator].BackColor = lexerColors[LexerType.JavaScript, "OperatorBack"];

        // VERBATIM, fontStyle = 0, styleId = 13
        scintilla.Styles[Style.Cpp.Verbatim].ForeColor = lexerColors[LexerType.JavaScript, "VerbatimFore"];
        scintilla.Styles[Style.Cpp.Verbatim].BackColor = lexerColors[LexerType.JavaScript, "VerbatimBack"];

        // REGEX, fontStyle = 1, styleId = 14
        scintilla.Styles[Style.Cpp.Regex].Bold = true;
        scintilla.Styles[Style.Cpp.Regex].ForeColor = lexerColors[LexerType.JavaScript, "RegexFore"];
        scintilla.Styles[Style.Cpp.Regex].BackColor = lexerColors[LexerType.JavaScript, "RegexBack"];

        // COMMENT, fontStyle = 0, styleId = 1
        scintilla.Styles[Style.Cpp.Comment].ForeColor = lexerColors[LexerType.JavaScript, "CommentFore"];
        scintilla.Styles[Style.Cpp.Comment].BackColor = lexerColors[LexerType.JavaScript, "CommentBack"];

        // COMMENT LINE, fontStyle = 0, styleId = 2
        scintilla.Styles[Style.Cpp.CommentLine].ForeColor = lexerColors[LexerType.JavaScript, "CommentLineFore"];
        scintilla.Styles[Style.Cpp.CommentLine].BackColor = lexerColors[LexerType.JavaScript, "CommentLineBack"];

        // COMMENT DOC, fontStyle = 0, styleId = 3
        scintilla.Styles[Style.Cpp.CommentDoc].ForeColor = lexerColors[LexerType.JavaScript, "CommentDocFore"];
        scintilla.Styles[Style.Cpp.CommentDoc].BackColor = lexerColors[LexerType.JavaScript, "CommentDocBack"];

        // COMMENT LINE DOC, fontStyle = 0, styleId = 15
        scintilla.Styles[Style.Cpp.CommentLineDoc].ForeColor = lexerColors[LexerType.JavaScript, "CommentLineDocFore"];
        scintilla.Styles[Style.Cpp.CommentLineDoc].BackColor = lexerColors[LexerType.JavaScript, "CommentLineDocBack"];

        // COMMENT DOC KEYWORD, fontStyle = 1, styleId = 17
        scintilla.Styles[Style.Cpp.CommentDocKeyword].Bold = true;
        scintilla.Styles[Style.Cpp.CommentDocKeyword].ForeColor = lexerColors[LexerType.JavaScript, "CommentDocKeywordFore"];
        scintilla.Styles[Style.Cpp.CommentDocKeyword].BackColor = lexerColors[LexerType.JavaScript, "CommentDocKeywordBack"];

        // COMMENT DOC KEYWORD ERROR, fontStyle = 0, styleId = 18
        scintilla.Styles[Style.Cpp.CommentDocKeywordError].ForeColor = lexerColors[LexerType.JavaScript, "CommentDocKeywordErrorFore"];
        scintilla.Styles[Style.Cpp.CommentDocKeywordError].BackColor = lexerColors[LexerType.JavaScript, "CommentDocKeywordErrorBack"];

        scintilla.LexerName = "cpp";

        ScintillaKeyWords.SetKeywords(scintilla, LexerType.JavaScript);

        AddFolding(scintilla);

        return true;
    }
}