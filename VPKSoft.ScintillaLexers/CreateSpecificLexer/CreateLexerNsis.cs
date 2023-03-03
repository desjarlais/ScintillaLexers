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

namespace VPKSoft.ScintillaLexers.CreateSpecificLexer;

/// <summary>
/// A class for the NSIS lexer.
/// Implements the <see cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
/// </summary>
/// <seealso cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
public class CreateLexerNsis: CreateLexerCommon
{
    /// <summary>
    /// Creates the lexer for a given Scintilla class instance for the NSIS (Nullsoft Scriptable Install System).
    /// </summary>
    /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
    /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
    /// <returns>True if the operation was successful; otherwise false.</returns>
    public static bool CreateNsisLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
    {
        ClearStyle(scintilla);

        // NSIS not found..
        #region NSIS_CONSTANTS
        const int SCE_NSIS_DEFAULT = 0;
        const int SCE_NSIS_COMMENT = 1;
        const int SCE_NSIS_STRINGDQ = 2;
        const int SCE_NSIS_STRINGLQ = 3;
        const int SCE_NSIS_STRINGRQ = 4;
        const int SCE_NSIS_FUNCTION = 5;
        const int SCE_NSIS_VARIABLE = 6;
        const int SCE_NSIS_LABEL = 7;
        const int SCE_NSIS_USERDEFINED = 8;
        const int SCE_NSIS_SECTIONDEF = 9;
        const int SCE_NSIS_SUBSECTIONDEF = 10;
        const int SCE_NSIS_IFDEFINEDEF = 11;
        const int SCE_NSIS_MACRODEF = 12;
        const int SCE_NSIS_STRINGVAR = 13;
        const int SCE_NSIS_NUMBER = 14;
        const int SCE_NSIS_SECTIONGROUP = 15;
        const int SCE_NSIS_PAGEEX = 16;
        const int SCE_NSIS_FUNCTIONDEF = 17;
        const int SCE_NSIS_COMMENTBOX = 18;
        #endregion

        // DEFAULT, fontStyle = 0 
        scintilla.Styles[SCE_NSIS_DEFAULT].ForeColor = lexerColors[LexerType.Nsis, "DefaultFore"];
        scintilla.Styles[SCE_NSIS_DEFAULT].BackColor = lexerColors[LexerType.Nsis, "DefaultBack"];

        // COMMENTLINE, fontStyle = 0 
        scintilla.Styles[SCE_NSIS_COMMENT].ForeColor = lexerColors[LexerType.Nsis, "CommentFore"];
        scintilla.Styles[SCE_NSIS_COMMENT].BackColor = lexerColors[LexerType.Nsis, "CommentBack"];

        // STRING DOUBLE QUOTE, fontStyle = 0 
        scintilla.Styles[SCE_NSIS_STRINGDQ].ForeColor = lexerColors[LexerType.Nsis, "StringDoubleQuoteFore"];
        scintilla.Styles[SCE_NSIS_STRINGDQ].BackColor = lexerColors[LexerType.Nsis, "StringDoubleQuoteBack"];

        // STRING LEFT QUOTE, fontStyle = 0 
        scintilla.Styles[SCE_NSIS_STRINGLQ].ForeColor = lexerColors[LexerType.Nsis, "StringLeftQuoteFore"];
        scintilla.Styles[SCE_NSIS_STRINGLQ].BackColor = lexerColors[LexerType.Nsis, "StringLeftQuoteBack"];

        // STRING RIGHT QUOTE, fontStyle = 0 
        scintilla.Styles[SCE_NSIS_STRINGRQ].ForeColor = lexerColors[LexerType.Nsis, "StringRightQuoteFore"];
        scintilla.Styles[SCE_NSIS_STRINGRQ].BackColor = lexerColors[LexerType.Nsis, "StringRightQuoteBack"];

        // FUNCTION, fontStyle = 0 
        scintilla.Styles[SCE_NSIS_FUNCTION].ForeColor = lexerColors[LexerType.Nsis, "FunctionFore"];
        scintilla.Styles[SCE_NSIS_FUNCTION].BackColor = lexerColors[LexerType.Nsis, "FunctionBack"];

        // VARIABLE, fontStyle = 0 
        scintilla.Styles[SCE_NSIS_VARIABLE].ForeColor = lexerColors[LexerType.Nsis, "VariableFore"];
        scintilla.Styles[SCE_NSIS_VARIABLE].BackColor = lexerColors[LexerType.Nsis, "VariableBack"];

        // LABEL, fontStyle = 0 
        scintilla.Styles[SCE_NSIS_LABEL].ForeColor = lexerColors[LexerType.Nsis, "LabelFore"];
        scintilla.Styles[SCE_NSIS_LABEL].BackColor = lexerColors[LexerType.Nsis, "LabelBack"];

        // USER DEFINED, fontStyle = 4 
        scintilla.Styles[SCE_NSIS_USERDEFINED].ForeColor = lexerColors[LexerType.Nsis, "UserDefinedFore"];
        scintilla.Styles[SCE_NSIS_USERDEFINED].BackColor = lexerColors[LexerType.Nsis, "UserDefinedBack"];

        // SECTION, fontStyle = 1 
        scintilla.Styles[SCE_NSIS_SECTIONDEF].Bold = true;
        scintilla.Styles[SCE_NSIS_SECTIONDEF].ForeColor = lexerColors[LexerType.Nsis, "SectionFore"];
        scintilla.Styles[SCE_NSIS_SECTIONDEF].BackColor = lexerColors[LexerType.Nsis, "SectionBack"];

        // SUBSECTION, fontStyle = 1 
        scintilla.Styles[SCE_NSIS_SUBSECTIONDEF].Bold = true;
        scintilla.Styles[SCE_NSIS_SUBSECTIONDEF].ForeColor = lexerColors[LexerType.Nsis, "SubSectionFore"];
        scintilla.Styles[SCE_NSIS_SUBSECTIONDEF].BackColor = lexerColors[LexerType.Nsis, "SubSectionBack"];

        // IF DEFINE, fontStyle = 0 
        scintilla.Styles[SCE_NSIS_IFDEFINEDEF].ForeColor = lexerColors[LexerType.Nsis, "IfDefineFore"];
        scintilla.Styles[SCE_NSIS_IFDEFINEDEF].BackColor = lexerColors[LexerType.Nsis, "IfDefineBack"];

        // MACRO, fontStyle = 1 
        scintilla.Styles[SCE_NSIS_MACRODEF].Bold = true;
        scintilla.Styles[SCE_NSIS_MACRODEF].ForeColor = lexerColors[LexerType.Nsis, "MacroFore"];
        scintilla.Styles[SCE_NSIS_MACRODEF].BackColor = lexerColors[LexerType.Nsis, "MacroBack"];

        // STRING VAR, fontStyle = 0 
        scintilla.Styles[SCE_NSIS_STRINGVAR].ForeColor = lexerColors[LexerType.Nsis, "StringVarFore"];
        scintilla.Styles[SCE_NSIS_STRINGVAR].BackColor = lexerColors[LexerType.Nsis, "StringVarBack"];

        // NUMBER, fontStyle = 0 
        scintilla.Styles[SCE_NSIS_NUMBER].ForeColor = lexerColors[LexerType.Nsis, "NumberFore"];
        scintilla.Styles[SCE_NSIS_NUMBER].BackColor = lexerColors[LexerType.Nsis, "NumberBack"];

        // SECTION GROUP, fontStyle = 1 
        scintilla.Styles[SCE_NSIS_SECTIONGROUP].Bold = true;
        scintilla.Styles[SCE_NSIS_SECTIONGROUP].ForeColor = lexerColors[LexerType.Nsis, "SectionGroupFore"];
        scintilla.Styles[SCE_NSIS_SECTIONGROUP].BackColor = lexerColors[LexerType.Nsis, "SectionGroupBack"];

        // PAGE EX, fontStyle = 1 
        scintilla.Styles[SCE_NSIS_PAGEEX].Bold = true;
        scintilla.Styles[SCE_NSIS_PAGEEX].ForeColor = lexerColors[LexerType.Nsis, "PageExFore"];
        scintilla.Styles[SCE_NSIS_PAGEEX].BackColor = lexerColors[LexerType.Nsis, "PageExBack"];

        // FUNCTION DEFINITIONS, fontStyle = 1 
        scintilla.Styles[SCE_NSIS_FUNCTIONDEF].Bold = true;
        scintilla.Styles[SCE_NSIS_FUNCTIONDEF].ForeColor = lexerColors[LexerType.Nsis, "FunctionDefinitionsFore"];
        scintilla.Styles[SCE_NSIS_FUNCTIONDEF].BackColor = lexerColors[LexerType.Nsis, "FunctionDefinitionsBack"];

        // COMMENT, fontStyle = 0 
        scintilla.Styles[SCE_NSIS_COMMENTBOX].ForeColor = lexerColors[LexerType.Nsis, "CommentFore"];
        scintilla.Styles[SCE_NSIS_COMMENTBOX].BackColor = lexerColors[LexerType.Nsis, "CommentBack"];

        scintilla.LexerName = "nsis";
                
        ScintillaKeyWords.SetKeywords(scintilla, LexerType.Nsis);

        AddFolding(scintilla);
        return true;

    }
}