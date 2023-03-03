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

/// <summary>
/// A class for the Java lexer.
/// Implements the <see cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
/// </summary>
/// <seealso cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
public class CreateLexerJava : CreateLexerCommon
{
    /// <summary>
    /// Creates the lexer for a given Scintilla class instance for the Java programming language.
    /// </summary>
    /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
    /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
    /// <returns>True if the operation was successful; otherwise false.</returns>
    public static bool CreateJavaLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
    {
        ClearStyle(scintilla);

        // PREPROCESSOR, fontStyle = 0, styleId = 9
        scintilla.Styles[Style.Cpp.Preprocessor].ForeColor = lexerColors[LexerType.Java, "PreprocessorFore"];
        scintilla.Styles[Style.Cpp.Preprocessor].BackColor = lexerColors[LexerType.Java, "PreprocessorBack"];

        // Style.Cpp.Identifier ?, Style.Cpp.Default = 0..
        // DEFAULT, fontStyle = 0, styleId = 11
        scintilla.Styles[Style.Cpp.Default].ForeColor = lexerColors[LexerType.Java, "DefaultFore"];
        scintilla.Styles[Style.Cpp.Default].BackColor = lexerColors[LexerType.Java, "DefaultBack"];

        // INSTRUCTION WORD, fontStyle = 1, styleId = 5
        scintilla.Styles[Style.Cpp.Word].Bold = true;
        scintilla.Styles[Style.Cpp.Word].ForeColor = lexerColors[LexerType.Java, "InstructionWordFore"];
        scintilla.Styles[Style.Cpp.Word].BackColor = lexerColors[LexerType.Java, "InstructionWordBack"];

        // TYPE WORD, fontStyle = 0, styleId = 16
        scintilla.Styles[Style.Cpp.Word2].ForeColor = lexerColors[LexerType.Java, "TypeWordFore"];
        scintilla.Styles[Style.Cpp.Word2].BackColor = lexerColors[LexerType.Java, "TypeWordBack"];

        // NUMBER, fontStyle = 0, styleId = 4
        scintilla.Styles[Style.Cpp.Number].ForeColor = lexerColors[LexerType.Java, "NumberFore"];
        scintilla.Styles[Style.Cpp.Number].BackColor = lexerColors[LexerType.Java, "NumberBack"];

        // STRING, fontStyle = 0, styleId = 6
        scintilla.Styles[Style.Cpp.String].ForeColor = lexerColors[LexerType.Java, "StringFore"];
        scintilla.Styles[Style.Cpp.String].BackColor = lexerColors[LexerType.Java, "StringBack"];

        // CHARACTER, fontStyle = 0, styleId = 7
        scintilla.Styles[Style.Cpp.Character].ForeColor = lexerColors[LexerType.Java, "CharacterFore"];
        scintilla.Styles[Style.Cpp.Character].BackColor = lexerColors[LexerType.Java, "CharacterBack"];

        // OPERATOR, fontStyle = 1, styleId = 10
        scintilla.Styles[Style.Cpp.Operator].Bold = true;
        scintilla.Styles[Style.Cpp.Operator].ForeColor = lexerColors[LexerType.Java, "OperatorFore"];
        scintilla.Styles[Style.Cpp.Operator].BackColor = lexerColors[LexerType.Java, "OperatorBack"];

        // VERBATIM, fontStyle = 0, styleId = 13
        scintilla.Styles[Style.Cpp.Verbatim].ForeColor = lexerColors[LexerType.Java, "VerbatimFore"];
        scintilla.Styles[Style.Cpp.Verbatim].BackColor = lexerColors[LexerType.Java, "VerbatimBack"];

        // REGEX, fontStyle = 1, styleId = 14
        scintilla.Styles[Style.Cpp.Regex].Bold = true;
        scintilla.Styles[Style.Cpp.Regex].ForeColor = lexerColors[LexerType.Java, "RegexFore"];
        scintilla.Styles[Style.Cpp.Regex].BackColor = lexerColors[LexerType.Java, "RegexBack"];

        // COMMENT, fontStyle = 0, styleId = 1
        scintilla.Styles[Style.Cpp.Comment].ForeColor = lexerColors[LexerType.Java, "CommentFore"];
        scintilla.Styles[Style.Cpp.Comment].BackColor = lexerColors[LexerType.Java, "CommentBack"];

        // COMMENT LINE, fontStyle = 0, styleId = 2
        scintilla.Styles[Style.Cpp.CommentLine].ForeColor = lexerColors[LexerType.Java, "CommentLineFore"];
        scintilla.Styles[Style.Cpp.CommentLine].BackColor = lexerColors[LexerType.Java, "CommentLineBack"];

        // COMMENT DOC, fontStyle = 0, styleId = 3
        scintilla.Styles[Style.Cpp.CommentDoc].ForeColor = lexerColors[LexerType.Java, "CommentDocFore"];
        scintilla.Styles[Style.Cpp.CommentDoc].BackColor = lexerColors[LexerType.Java, "CommentDocBack"];

        // COMMENT LINE DOC, fontStyle = 0, styleId = 15
        scintilla.Styles[Style.Cpp.CommentLineDoc].ForeColor = lexerColors[LexerType.Java, "CommentLineDocFore"];
        scintilla.Styles[Style.Cpp.CommentLineDoc].BackColor = lexerColors[LexerType.Java, "CommentLineDocBack"];

        // COMMENT DOC KEYWORD, fontStyle = 1, styleId = 17
        scintilla.Styles[Style.Cpp.CommentDocKeyword].Bold = true;
        scintilla.Styles[Style.Cpp.CommentDocKeyword].ForeColor = lexerColors[LexerType.Java, "CommentDocKeywordFore"];
        scintilla.Styles[Style.Cpp.CommentDocKeyword].BackColor = lexerColors[LexerType.Java, "CommentDocKeywordBack"];

        // COMMENT DOC KEYWORD ERROR, fontStyle = 0, styleId = 18
        scintilla.Styles[Style.Cpp.CommentDocKeywordError].ForeColor = lexerColors[LexerType.Java, "CommentDocKeywordErrorFore"];
        scintilla.Styles[Style.Cpp.CommentDocKeywordError].BackColor = lexerColors[LexerType.Java, "CommentDocKeywordErrorBack"];

        scintilla.LexerName = "cpp";

        ScintillaKeyWords.SetKeywords(scintilla, LexerType.Java);

        AddFolding(scintilla);

        return true;
    }
}