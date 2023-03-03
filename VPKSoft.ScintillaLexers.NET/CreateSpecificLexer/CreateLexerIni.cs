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
using VPKSoft.ScintillaLexers.LexerColors;
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace VPKSoft.ScintillaLexers.CreateSpecificLexer;

/// <summary>
/// A class for the INI lexer.
/// Implements the <see cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
/// </summary>
/// <seealso cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
public class CreateLexerIni: CreateLexerCommon
{
    /// <summary>
    /// Creates the lexer for a given Scintilla class instance for the INI (properties file).
    /// </summary>
    /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
    /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
    /// <returns>True if the operation was successful; otherwise false.</returns>
    public static bool CreateIniLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
    {
        ClearStyle(scintilla);

        // DEFAULT, fontStyle = 0, styleId = 0
        scintilla.Styles[Style.Properties.Default].ForeColor = lexerColors[LexerType.INI, "DefaultFore"];
        scintilla.Styles[Style.Properties.Default].BackColor = lexerColors[LexerType.INI, "DefaultBack"];

        // COMMENT, fontStyle = 0, styleId = 1
        scintilla.Styles[Style.Properties.Comment].ForeColor = lexerColors[LexerType.INI, "CommentFore"];
        scintilla.Styles[Style.Properties.Comment].BackColor = lexerColors[LexerType.INI, "CommentBack"];

        // SECTION, fontStyle = 1, styleId = 2
        scintilla.Styles[Style.Properties.Section].Bold = true;
        scintilla.Styles[Style.Properties.Section].ForeColor = lexerColors[LexerType.INI, "SectionFore"];
        scintilla.Styles[Style.Properties.Section].BackColor = lexerColors[LexerType.INI, "SectionBack"];

        // ASSIGNMENT, fontStyle = 1, styleId = 3
        scintilla.Styles[Style.Properties.Assignment].Bold = true;
        scintilla.Styles[Style.Properties.Assignment].ForeColor = lexerColors[LexerType.INI, "AssignmentFore"];
        scintilla.Styles[Style.Properties.Assignment].BackColor = lexerColors[LexerType.INI, "AssignmentBack"];

        // DEFVAL, fontStyle = 0, styleId = 4
        scintilla.Styles[Style.Properties.DefVal].ForeColor = lexerColors[LexerType.INI, "DefValFore"];
        scintilla.Styles[Style.Properties.DefVal].BackColor = lexerColors[LexerType.INI, "DefValBack"];

        scintilla.LexerName = "props";

        AddFolding(scintilla);

        return true;
    }
}