#region License
/*
MIT License

Copyright(c) 2023 Petteri Kautonen

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

using System.Drawing;
using ScintillaNET;
using static ScintillaLexers.LexerEnumerations;

namespace ScintillaLexers.CreateSpecificLexer;

internal abstract class CreateLexerErrorList : CreateLexerCommon
{
    public static bool CreateLexerErrorListLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
    {
        ClearStyle(scintilla);
        scintilla.LexerName = "errorlist";

        // Default
        scintilla.Styles[0].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListDefaultFore"];
        scintilla.Styles[0].BackColor = lexerColors[LexerType.ErrorList, "ErrorListDefaultBack"];
        // python Error
        scintilla.Styles[1].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListPythonErrorFore"];
        scintilla.Styles[1].BackColor = lexerColors[LexerType.ErrorList, "ErrorListPythonErrorBack"];
        // gcc Error
        scintilla.Styles[2].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListGccErrorFore"];
        scintilla.Styles[2].BackColor = lexerColors[LexerType.ErrorList, "ErrorListGccErrorBack"];
        // Microsoft Error
        scintilla.Styles[3].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListMicrosoftErrorFore"];
        scintilla.Styles[3].BackColor = lexerColors[LexerType.ErrorList, "ErrorListMicrosoftErrorBack"];
        // command or return status
        scintilla.Styles[4].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListStatusFore"];
        scintilla.Styles[4].BackColor = lexerColors[LexerType.ErrorList, "ErrorListStatusBack"];
        // Borland error and warning messages
        scintilla.Styles[5].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListBorlandErrorFore"];
        scintilla.Styles[5].BackColor = lexerColors[LexerType.ErrorList, "ErrorListBorlandErrorBack"];
        // perl error and warning messages
        scintilla.Styles[6].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListPerlErrorFore"];
        scintilla.Styles[6].BackColor = lexerColors[LexerType.ErrorList, "ErrorListPerlErrorBack"];
        // .NET tracebacks
        scintilla.Styles[7].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListNETTraceBacksFore"];
        scintilla.Styles[7].BackColor = lexerColors[LexerType.ErrorList, "ErrorListNETTraceBacksBack"];
        // Lua error and warning messages
        scintilla.Styles[8].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListLuaErrorFore"];
        scintilla.Styles[8].BackColor = lexerColors[LexerType.ErrorList, "ErrorListLuaErrorBack"];
        // ctags
        scintilla.Styles[9].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListCTagsFore"];
        scintilla.Styles[9].BackColor = lexerColors[LexerType.ErrorList, "ErrorListCTagsBack"];
        // diff changed !
        scintilla.Styles[10].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListDiffChangedFore"];
        scintilla.Styles[10].BackColor = lexerColors[LexerType.ErrorList, "ErrorListDiffChangedBack"];
        // diff addition +
        scintilla.Styles[11].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListDiffAdditionFore"];
        scintilla.Styles[11].BackColor = lexerColors[LexerType.ErrorList, "ErrorListDiffAdditionBack"];
        // diff deletion -
        scintilla.Styles[12].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListDiffDeletionFore"];
        scintilla.Styles[12].BackColor = lexerColors[LexerType.ErrorList, "ErrorListDiffDeletionBack"];
        // diff message ---
        scintilla.Styles[13].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListDiffMessageFore"];
        scintilla.Styles[13].BackColor = lexerColors[LexerType.ErrorList, "ErrorListDiffMessageBack"];
        // PHP error
        scintilla.Styles[14].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListPHPErrorFore"];
        scintilla.Styles[14].BackColor = lexerColors[LexerType.ErrorList, "ErrorListPHPErrorBack"];
        // Essential Lahey Fortran 90 error
        scintilla.Styles[15].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListFortran90ErrorFore"];
        scintilla.Styles[15].BackColor = lexerColors[LexerType.ErrorList, "ErrorListFortran90ErrorBack"];
        // Intel Fortran Compiler error
        scintilla.Styles[16].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListFortranError1Fore"];
        scintilla.Styles[16].BackColor = lexerColors[LexerType.ErrorList, "ErrorListFortranError1Back"];
        // Intel Fortran Compiler v8.0 error/warning
        scintilla.Styles[17].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListFortranError2Fore"];
        scintilla.Styles[17].BackColor = lexerColors[LexerType.ErrorList, "ErrorListFortranError2Back"];
        // Absoft Pro Fortran 90/95 v8.2 error or warning
        scintilla.Styles[18].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListFortranError3Fore"];
        scintilla.Styles[18].BackColor = lexerColors[LexerType.ErrorList, "ErrorListFortranError3Back"];
        // HTML Tidy
        scintilla.Styles[19].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListHTMLTidyFore"];
        scintilla.Styles[19].BackColor = lexerColors[LexerType.ErrorList, "ErrorListHTMLTidyBack"];
        // Java runtime stack trace
        scintilla.Styles[20].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListJREStackFore"];
        scintilla.Styles[20].BackColor = lexerColors[LexerType.ErrorList, "ErrorListJREStackBack"];
        // Text matched with find in files and message part of GCC errors
        scintilla.Styles[21].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListGCCTextMatchFore"];
        scintilla.Styles[21].BackColor = lexerColors[LexerType.ErrorList, "ErrorListGCCTextMatchBack"];
        // GCC showing include path to following error
        scintilla.Styles[22].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListGCCIncludeFore"];
        scintilla.Styles[22].BackColor = lexerColors[LexerType.ErrorList, "ErrorListGCCIncludeBack"];
        // Escape sequence
        scintilla.Styles[23].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListEscapeSequenceFore"];
        scintilla.Styles[23].BackColor = lexerColors[LexerType.ErrorList, "ErrorListEscapeSequenceBack"];
        scintilla.Styles[23].FillLine = true;
        scintilla.Styles[23].Visible = false;
        // Escape sequence unknown
        scintilla.Styles[24].BackColor = lexerColors[LexerType.ErrorList, "ErrorListEscapeSequenceUnknownFore"];
        scintilla.Styles[24].BackColor = lexerColors[LexerType.ErrorList, "ErrorListEscapeSequenceUnknownBack"];
        // GCC showing excerpt of code with pointer
        scintilla.Styles[25].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListGCCPointerFore"];
        scintilla.Styles[25].BackColor = lexerColors[LexerType.ErrorList, "ErrorListGCCPointerBack"];
        // ???
        scintilla.Styles[32].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListUnknown1Fore"];
        scintilla.Styles[32].BackColor = lexerColors[LexerType.ErrorList, "ErrorListUnknown1Back"];

        // Basic colors
        scintilla.Styles[40].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListBasic1Fore"];
        scintilla.Styles[40].BackColor = lexerColors[LexerType.ErrorList, "ErrorListBasic1Back"];
        scintilla.Styles[41].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListBasic2Fore"];
        scintilla.Styles[41].BackColor = lexerColors[LexerType.ErrorList, "ErrorListBasic1Back"];
        scintilla.Styles[42].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListBasic3Fore"];
        scintilla.Styles[42].BackColor = lexerColors[LexerType.ErrorList, "ErrorListBasic1Back"];
        scintilla.Styles[43].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListBasic4Fore"];
        scintilla.Styles[43].BackColor = lexerColors[LexerType.ErrorList, "ErrorListBasic1Back"];
        scintilla.Styles[44].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListBasic5Fore"];
        scintilla.Styles[44].BackColor = lexerColors[LexerType.ErrorList, "ErrorListBasic1Back"];
        scintilla.Styles[45].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListBasic6Fore"];
        scintilla.Styles[45].BackColor = lexerColors[LexerType.ErrorList, "ErrorListBasic1Back"];
        scintilla.Styles[46].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListBasic7Fore"];
        scintilla.Styles[46].BackColor = lexerColors[LexerType.ErrorList, "ErrorListBasic1Back"];
        scintilla.Styles[47].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListBasic8Fore"];
        scintilla.Styles[47].BackColor = lexerColors[LexerType.ErrorList, "ErrorListBasic1Back"];

        // Intense colors
        scintilla.Styles[48].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListIntense1Fore"];
        scintilla.Styles[48].BackColor = lexerColors[LexerType.ErrorList, "ErrorListIntense1Back"];
        scintilla.Styles[48].Bold = true;
        scintilla.Styles[49].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListIntense2Fore"];
        scintilla.Styles[49].BackColor = lexerColors[LexerType.ErrorList, "ErrorListIntense2Back"];
        scintilla.Styles[49].Bold = true;
        scintilla.Styles[50].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListIntense3Fore"];
        scintilla.Styles[50].BackColor = lexerColors[LexerType.ErrorList, "ErrorListIntense3Back"];
        scintilla.Styles[50].Bold = true;
        scintilla.Styles[51].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListIntense4Fore"];
        scintilla.Styles[51].BackColor = lexerColors[LexerType.ErrorList, "ErrorListIntense4Back"];
        scintilla.Styles[51].Bold = true;
        scintilla.Styles[52].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListIntense5Fore"];
        scintilla.Styles[52].BackColor = lexerColors[LexerType.ErrorList, "ErrorListIntense5Back"];
        scintilla.Styles[52].Bold = true;
        scintilla.Styles[53].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListIntense6Fore"];
        scintilla.Styles[53].BackColor = lexerColors[LexerType.ErrorList, "ErrorListIntense6Back"];
        scintilla.Styles[53].Bold = true;
        scintilla.Styles[54].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListIntense7Fore"];
        scintilla.Styles[54].BackColor = lexerColors[LexerType.ErrorList, "ErrorListIntense7Back"];
        scintilla.Styles[54].Bold = true;
        scintilla.Styles[55].ForeColor = lexerColors[LexerType.ErrorList, "ErrorListIntense8Fore"];
        scintilla.Styles[55].BackColor = lexerColors[LexerType.ErrorList, "ErrorListIntense8Back"];
        scintilla.Styles[55].Bold = true;

        scintilla.SetProperty("lexer.errorlist.escape.sequences", "1");
        scintilla.SetProperty("lexer.errorlist.value.separate", "1");

        AddFolding(scintilla);

        return true;
    }
}