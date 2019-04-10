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
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace VPKSoft.ScintillaLexers.CreateSpecificLexer
{
    /// <summary>
    /// A class for the C++ lexer.
    /// Implements the <see cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    /// </summary>
    /// <seealso cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    public class CreateLexerCpp: CreateLexerCommon
    {
        /// <summary>
        /// Creates the lexer for a given Scintilla class instance for the C++ programming language.
        /// </summary>
        /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
        /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool CreateCppLexer(Scintilla scintilla, LexerColors lexerColors)
        {
            ClearStyle(scintilla);

            // PREPROCESSOR, fontStyle = 0 
            scintilla.Styles[Style.Cpp.Preprocessor].ForeColor = lexerColors[LexerType.Cpp, "PreprocessorFore"];
            scintilla.Styles[Style.Cpp.Preprocessor].BackColor = lexerColors[LexerType.Cpp, "PreprocessorBack"];

            // DEFAULT, fontStyle = 0 
            scintilla.Styles[Style.Cpp.Default].ForeColor = lexerColors[LexerType.Cpp, "DefaultFore"];
            scintilla.Styles[Style.Cpp.Default].BackColor = lexerColors[LexerType.Cpp, "DefaultBack"];

            // INSTRUCTION WORD, fontStyle = 1 
            scintilla.Styles[Style.Cpp.Word].Bold = true;
            scintilla.Styles[Style.Cpp.Word].ForeColor = lexerColors[LexerType.Cpp, "WordFore"];
            scintilla.Styles[Style.Cpp.Word].BackColor = lexerColors[LexerType.Cpp, "WordBack"];

            // TYPE WORD, fontStyle = 0 
            scintilla.Styles[Style.Cpp.Word2].ForeColor = lexerColors[LexerType.Cpp, "Word2Fore"];
            scintilla.Styles[Style.Cpp.Word2].BackColor = lexerColors[LexerType.Cpp, "Word2Back"];

            // NUMBER, fontStyle = 0 
            scintilla.Styles[Style.Cpp.Number].ForeColor = lexerColors[LexerType.Cpp, "NumberFore"];
            scintilla.Styles[Style.Cpp.Number].BackColor = lexerColors[LexerType.Cpp, "NumberBack"];

            // STRING, fontStyle = 0 
            scintilla.Styles[Style.Cpp.String].ForeColor = lexerColors[LexerType.Cpp, "StringFore"];
            scintilla.Styles[Style.Cpp.String].BackColor = lexerColors[LexerType.Cpp, "StringBack"];

            // CHARACTER, fontStyle = 0 
            scintilla.Styles[Style.Cpp.Character].ForeColor = lexerColors[LexerType.Cpp, "CharacterFore"];
            scintilla.Styles[Style.Cpp.Character].BackColor = lexerColors[LexerType.Cpp, "CharacterBack"];

            // OPERATOR, fontStyle = 1 
            scintilla.Styles[Style.Cpp.Operator].Bold = true;
            scintilla.Styles[Style.Cpp.Operator].ForeColor = lexerColors[LexerType.Cpp, "OperatorFore"];
            scintilla.Styles[Style.Cpp.Operator].BackColor = lexerColors[LexerType.Cpp, "OperatorBack"];

            // VERBATIM, fontStyle = 0 
            scintilla.Styles[Style.Cpp.Verbatim].ForeColor = lexerColors[LexerType.Cpp, "VerbatimFore"];
            scintilla.Styles[Style.Cpp.Verbatim].BackColor = lexerColors[LexerType.Cpp, "VerbatimBack"];

            // REGEX, fontStyle = 1 
            scintilla.Styles[Style.Cpp.Regex].Bold = true;
            scintilla.Styles[Style.Cpp.Regex].ForeColor = lexerColors[LexerType.Cpp, "RegexFore"];
            scintilla.Styles[Style.Cpp.Regex].BackColor = lexerColors[LexerType.Cpp, "RegexBack"];

            // COMMENT, fontStyle = 0 
            scintilla.Styles[Style.Cpp.Comment].ForeColor = lexerColors[LexerType.Cpp, "CommentFore"];
            scintilla.Styles[Style.Cpp.Comment].BackColor = lexerColors[LexerType.Cpp, "CommentBack"];

            // COMMENT LINE, fontStyle = 0 
            scintilla.Styles[Style.Cpp.CommentLine].ForeColor = lexerColors[LexerType.Cpp, "CommentLineFore"];
            scintilla.Styles[Style.Cpp.CommentLine].BackColor = lexerColors[LexerType.Cpp, "CommentLineBack"];

            // COMMENT DOC, fontStyle = 0 
            scintilla.Styles[Style.Cpp.CommentDoc].ForeColor = lexerColors[LexerType.Cpp, "CommentDocFore"];
            scintilla.Styles[Style.Cpp.CommentDoc].BackColor = lexerColors[LexerType.Cpp, "CommentDocBack"];

            // COMMENT LINE DOC, fontStyle = 0 
            scintilla.Styles[Style.Cpp.CommentLineDoc].ForeColor = lexerColors[LexerType.Cpp, "CommentLineDocFore"];
            scintilla.Styles[Style.Cpp.CommentLineDoc].BackColor = lexerColors[LexerType.Cpp, "CommentLineDocBack"];

            // COMMENT DOC KEYWORD, fontStyle = 1 
            scintilla.Styles[Style.Cpp.CommentDocKeyword].Bold = true;
            scintilla.Styles[Style.Cpp.CommentDocKeyword].ForeColor =
                lexerColors[LexerType.Cpp, "CommentDocKeywordFore"];
            scintilla.Styles[Style.Cpp.CommentDocKeyword].BackColor =
                lexerColors[LexerType.Cpp, "CommentDocKeywordBack"];

            // COMMENT DOC KEYWORD ERROR, fontStyle = 0 
            scintilla.Styles[Style.Cpp.CommentDocKeywordError].ForeColor =
                lexerColors[LexerType.Cpp, "CommentDocKeywordErrorFore"];
            scintilla.Styles[Style.Cpp.CommentDocKeywordError].BackColor =
                lexerColors[LexerType.Cpp, "CommentDocKeywordErrorBack"];

            // PREPROCESSOR COMMENT, fontStyle = 0 
            scintilla.Styles[Style.Cpp.PreprocessorComment].ForeColor =
                lexerColors[LexerType.Cpp, "PreprocessorCommentFore"];
            scintilla.Styles[Style.Cpp.PreprocessorComment].BackColor =
                lexerColors[LexerType.Cpp, "PreprocessorCommentBack"];

            // PREPROCESSOR COMMENT DOC, fontStyle = 0 
            scintilla.Styles[Style.Cpp.PreprocessorCommentDoc].ForeColor =
                lexerColors[LexerType.Cpp, "PreprocessorCommentDocFore"];
            scintilla.Styles[Style.Cpp.PreprocessorCommentDoc].BackColor =
                lexerColors[LexerType.Cpp, "PreprocessorCommentDocBack"];

            scintilla.Lexer = Lexer.Cpp;

            scintilla.SetKeywords(0,
                "alignof and and_eq bitand bitor break case catch compl const_cast continue default delete do dynamic_cast else false for goto if namespace new not not_eq nullptr operator or or_eq reinterpret_cast return sizeof static_assert static_cast switch this throw true try typedef typeid using while xor xor_eq NULL");
            scintilla.SetKeywords(1,
                "alignas asm auto bool char char16_t char32_t class clock_t const constexpr decltype double enum explicit export extern final float friend inline int int8_t int16_t int32_t int64_t int_fast8_t int_fast16_t int_fast32_t int_fast64_t intmax_t intptr_t long mutable noexcept override private protected ptrdiff_t public register short signed size_t ssize_t static struct template thread_local time_t typename uint8_t uint16_t uint32_t uint64_t uint_fast8_t uint_fast16_t uint_fast32_t uint_fast64_t uintmax_t uintptr_t union unsigned virtual void volatile wchar_t");
            scintilla.SetKeywords(2,
                "a addindex addtogroup anchor arg attention author authors b brief bug c callergraph callgraph category cite class code cond copybrief copydetails copydoc copyright date def defgroup deprecated details diafile dir docbookonly dontinclude dot dotfile e else elseif em endcode endcond enddocbookonly enddot endhtmlonly endif endinternal endlatexonly endlink endmanonly endmsc endparblock endrtfonly endsecreflist enduml endverbatim endxmlonly enum example exception extends f$ f[ f] file fn f{ f} headerfile hidecallergraph hidecallgraph hideinitializer htmlinclude htmlonly idlexcept if ifnot image implements include includelineno ingroup interface internal invariant latexinclude latexonly li line link mainpage manonly memberof msc mscfile n name namespace nosubgrouping note overload p package page par paragraph param parblock post pre private privatesection property protected protectedsection protocol public publicsection pure ref refitem related relatedalso relates relatesalso remark remarks result return returns retval rtfonly sa secreflist section see short showinitializer since skip skipline snippet startuml struct subpage subsection subsubsection tableofcontents test throw throws todo tparam typedef union until var verbatim verbinclude version vhdlflow warning weakgroup xmlonly xrefitem");

            AddFolding(scintilla);

            return true;
        }
    }
}
