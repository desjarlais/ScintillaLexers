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
using ScintillaLexers.LexerColors;
using static ScintillaLexers.LexerEnumerations;

namespace ScintillaLexers.CreateSpecificLexer;

/// <summary>
/// A class for the C# lexer.
/// Implements the <see cref="ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
/// </summary>
/// <seealso cref="ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
public abstract class CreateLexerCs: CreateLexerCommon
{
    /// <summary>
    /// Creates the lexer for a given Scintilla class instance for the C# programming language.
    /// </summary>
    /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
    /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
    /// <returns>True if the operation was successful; otherwise false.</returns>
    public static bool CreateCsLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
    {
        ClearStyle(scintilla);

        // PREPROCESSOR, fontStyle = 0
        scintilla.Styles[Style.Cpp.Preprocessor].ForeColor =
            lexerColors[LexerType.Cs, "PreprocessorFore"];
        scintilla.Styles[Style.Cpp.Preprocessor].BackColor =
            lexerColors[LexerType.Cs, "PreprocessorBack"];

        // DEFAULT, fontStyle = 0
        scintilla.Styles[Style.Cpp.Default].ForeColor =
            lexerColors[LexerType.Cs, "DefaultFore"];
        scintilla.Styles[Style.Cpp.Default].BackColor =
            lexerColors[LexerType.Cs, "DefaultBack"];

        // INSTRUCTION WORD, fontStyle = 1
        scintilla.Styles[Style.Cpp.Word].Bold = true;
        scintilla.Styles[Style.Cpp.Word].ForeColor = lexerColors[LexerType.Cs, "WordFore"];
        scintilla.Styles[Style.Cpp.Word].BackColor = lexerColors[LexerType.Cs, "WordBack"];

        // TYPE WORD, fontStyle = 0
        scintilla.Styles[Style.Cpp.Word2].ForeColor = lexerColors[LexerType.Cs, "Word2Fore"];
        scintilla.Styles[Style.Cpp.Word2].BackColor = lexerColors[LexerType.Cs, "Word2Back"];

        // NUMBER, fontStyle = 0
        scintilla.Styles[Style.Cpp.Number].ForeColor =
            lexerColors[LexerType.Cs, "NumberFore"];
        scintilla.Styles[Style.Cpp.Number].BackColor =
            lexerColors[LexerType.Cs, "NumberBack"];

        // STRING, fontStyle = 0
        scintilla.Styles[Style.Cpp.String].ForeColor =
            lexerColors[LexerType.Cs, "StringFore"];
        scintilla.Styles[Style.Cpp.String].BackColor =
            lexerColors[LexerType.Cs, "StringBack"];

        // CHARACTER, fontStyle = 0
        scintilla.Styles[Style.Cpp.Character].ForeColor =
            lexerColors[LexerType.Cs, "CharacterFore"];
        scintilla.Styles[Style.Cpp.Character].BackColor =
            lexerColors[LexerType.Cs, "CharacterBack"];

        // OPERATOR, fontStyle = 1
        scintilla.Styles[Style.Cpp.Operator].Bold = true;
        scintilla.Styles[Style.Cpp.Operator].ForeColor =
            lexerColors[LexerType.Cs, "OperatorFore"];
        scintilla.Styles[Style.Cpp.Operator].BackColor =
            lexerColors[LexerType.Cs, "OperatorBack"];

        // VERBATIM, fontStyle = 0
        scintilla.Styles[Style.Cpp.Verbatim].ForeColor =
            lexerColors[LexerType.Cs, "VerbatimFore"];
        scintilla.Styles[Style.Cpp.Verbatim].BackColor =
            lexerColors[LexerType.Cs, "VerbatimBack"];

        // REGEX, fontStyle = 1
        scintilla.Styles[Style.Cpp.Regex].Bold = true;
        scintilla.Styles[Style.Cpp.Regex].ForeColor = lexerColors[LexerType.Cs, "RegexFore"];
        scintilla.Styles[Style.Cpp.Regex].BackColor = lexerColors[LexerType.Cs, "RegexBack"];

        // COMMENT, fontStyle = 0
        scintilla.Styles[Style.Cpp.Comment].ForeColor =
            lexerColors[LexerType.Cs, "CommentFore"];
        scintilla.Styles[Style.Cpp.Comment].BackColor =
            lexerColors[LexerType.Cs, "CommentBack"];

        // COMMENT LINE, fontStyle = 0
        scintilla.Styles[Style.Cpp.CommentLine].ForeColor =
            lexerColors[LexerType.Cs, "CommentLineFore"];
        scintilla.Styles[Style.Cpp.CommentLine].BackColor =
            lexerColors[LexerType.Cs, "CommentLineBack"];

        // COMMENT DOC, fontStyle = 0
        scintilla.Styles[Style.Cpp.CommentDoc].ForeColor =
            lexerColors[LexerType.Cs, "CommentDocFore"];
        scintilla.Styles[Style.Cpp.CommentDoc].BackColor =
            lexerColors[LexerType.Cs, "CommentDocBack"];

        // COMMENT LINE DOC, fontStyle = 0
        scintilla.Styles[Style.Cpp.CommentLineDoc].ForeColor =
            lexerColors[LexerType.Cs, "CommentLineDocFore"];
        scintilla.Styles[Style.Cpp.CommentLineDoc].BackColor =
            lexerColors[LexerType.Cs, "CommentLineDocBack"];

        // COMMENT DOC KEYWORD, fontStyle = 1
        scintilla.Styles[Style.Cpp.CommentDocKeyword].Bold = true;
        scintilla.Styles[Style.Cpp.CommentDocKeyword].ForeColor =
            lexerColors[LexerType.Cs, "CommentDocKeywordFore"];
        scintilla.Styles[Style.Cpp.CommentDocKeyword].BackColor =
            lexerColors[LexerType.Cs, "CommentDocKeywordBack"];

        // COMMENT DOC KEYWORD ERROR, fontStyle = 0
        scintilla.Styles[Style.Cpp.CommentDocKeywordError].ForeColor =
            lexerColors[LexerType.Cs, "CommentDocKeywordErrorFore"];
        scintilla.Styles[Style.Cpp.CommentDocKeywordError].BackColor =
            lexerColors[LexerType.Cs, "CommentDocKeywordErrorBack"];

        // PREPROCESSOR COMMENT, fontStyle = 0
        scintilla.Styles[Style.Cpp.PreprocessorComment].ForeColor =
            lexerColors[LexerType.Cs, "PreprocessorCommentFore"];
        scintilla.Styles[Style.Cpp.PreprocessorComment].BackColor =
            lexerColors[LexerType.Cs, "PreprocessorCommentBack"];

        // PREPROCESSOR COMMENT DOC, fontStyle = 0
        scintilla.Styles[Style.Cpp.PreprocessorCommentDoc].ForeColor =
            lexerColors[LexerType.Cs, "PreprocessorCommentDocFore"];
        scintilla.Styles[Style.Cpp.PreprocessorCommentDoc].BackColor =
            lexerColors[LexerType.Cs, "PreprocessorCommentDocBack"];

        scintilla.LexerName = "cpp";

        ScintillaKeyWords.SetKeywords(scintilla, LexerType.Cs);

        AddFolding(scintilla);

        return true;
    }
}