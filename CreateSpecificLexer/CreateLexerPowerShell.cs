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
    /// A class for the Windows PowerShell lexer.
    /// Implements the <see cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    /// </summary>
    /// <seealso cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    public class CreateLexerPowerShell: CreateLexerCommon
    {
        /// <summary>
        /// Creates the lexer for a given Scintilla class instance for the Windows PowerShell script language.
        /// </summary>
        /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
        /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool CreatePowerShellLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
        {
            ClearStyle(scintilla);

            // DEFAULT, fontStyle = 0, styleId = 0
            scintilla.Styles[Style.PowerShell.Default].ForeColor =
                lexerColors[LexerType.WindowsPowerShell, "DefaultFore"];
            scintilla.Styles[Style.PowerShell.Default].BackColor =
                lexerColors[LexerType.WindowsPowerShell, "DefaultBack"];

            // COMMENT, fontStyle = 0, styleId = 1
            scintilla.Styles[Style.PowerShell.Comment].ForeColor =
                lexerColors[LexerType.WindowsPowerShell, "CommentFore"];
            scintilla.Styles[Style.PowerShell.Comment].BackColor =
                lexerColors[LexerType.WindowsPowerShell, "CommentBack"];

            // STRING, fontStyle = 0, styleId = 2
            scintilla.Styles[Style.PowerShell.String].ForeColor =
                lexerColors[LexerType.WindowsPowerShell, "StringFore"];
            scintilla.Styles[Style.PowerShell.String].BackColor =
                lexerColors[LexerType.WindowsPowerShell, "StringBack"];

            // CHARACTER, fontStyle = 0, styleId = 3
            scintilla.Styles[Style.PowerShell.Character].ForeColor =
                lexerColors[LexerType.WindowsPowerShell, "CharacterFore"];
            scintilla.Styles[Style.PowerShell.Character].BackColor =
                lexerColors[LexerType.WindowsPowerShell, "CharacterBack"];

            // NUMBER, fontStyle = 0, styleId = 4
            scintilla.Styles[Style.PowerShell.Number].ForeColor =
                lexerColors[LexerType.WindowsPowerShell, "NumberFore"];
            scintilla.Styles[Style.PowerShell.Number].BackColor =
                lexerColors[LexerType.WindowsPowerShell, "NumberBack"];

            // VARIABLE, fontStyle = 1, styleId = 5
            scintilla.Styles[Style.PowerShell.Variable].Bold = true;
            scintilla.Styles[Style.PowerShell.Variable].ForeColor =
                lexerColors[LexerType.WindowsPowerShell, "VariableFore"];
            scintilla.Styles[Style.PowerShell.Variable].BackColor =
                lexerColors[LexerType.WindowsPowerShell, "VariableBack"];

            // OPERATOR, fontStyle = 1, styleId = 6
            scintilla.Styles[Style.PowerShell.Operator].Bold = true;
            scintilla.Styles[Style.PowerShell.Operator].ForeColor =
                lexerColors[LexerType.WindowsPowerShell, "OperatorFore"];
            scintilla.Styles[Style.PowerShell.Operator].BackColor =
                lexerColors[LexerType.WindowsPowerShell, "OperatorBack"];

            // INSTRUCTION WORD, fontStyle = 1, styleId = 8
            scintilla.Styles[Style.PowerShell.Keyword].Bold = true;
            scintilla.Styles[Style.PowerShell.Keyword].ForeColor =
                lexerColors[LexerType.WindowsPowerShell, "InstructionWordFore"];
            scintilla.Styles[Style.PowerShell.Keyword].BackColor =
                lexerColors[LexerType.WindowsPowerShell, "InstructionWordBack"];

            // CMDLET, fontStyle = 0, styleId = 9
            scintilla.Styles[Style.PowerShell.Cmdlet].ForeColor =
                lexerColors[LexerType.WindowsPowerShell, "CommandletFore"];
            scintilla.Styles[Style.PowerShell.Cmdlet].BackColor =
                lexerColors[LexerType.WindowsPowerShell, "CommandletBack"];

            // ALIAS, fontStyle = 0, styleId = 10
            scintilla.Styles[Style.PowerShell.Alias].ForeColor = lexerColors[LexerType.WindowsPowerShell, "AliasFore"];
            scintilla.Styles[Style.PowerShell.Alias].BackColor = lexerColors[LexerType.WindowsPowerShell, "AliasBack"];

            // COMMENT STREAM, fontStyle = 0, styleId = 13
            scintilla.Styles[Style.PowerShell.CommentStream].ForeColor =
                lexerColors[LexerType.WindowsPowerShell, "CommentStreamFore"];
            scintilla.Styles[Style.PowerShell.CommentStream].BackColor =
                lexerColors[LexerType.WindowsPowerShell, "CommentStreamBack"];

            // HERE STRING, fontStyle = 0, styleId = 14
            scintilla.Styles[Style.PowerShell.HereString].ForeColor =
                lexerColors[LexerType.WindowsPowerShell, "HereStringFore"];
            scintilla.Styles[Style.PowerShell.HereString].BackColor =
                lexerColors[LexerType.WindowsPowerShell, "HereStringBack"];

            // HERE CHARACTER, fontStyle = 0, styleId = 15
            scintilla.Styles[Style.PowerShell.HereCharacter].ForeColor =
                lexerColors[LexerType.WindowsPowerShell, "HereCharacterFore"];
            scintilla.Styles[Style.PowerShell.HereCharacter].BackColor =
                lexerColors[LexerType.WindowsPowerShell, "HereCharacterBack"];

            // COMMENT DOC KEYWORD, fontStyle = 1, styleId = 16
            scintilla.Styles[Style.PowerShell.CommentDocKeyword].Bold = true;
            scintilla.Styles[Style.PowerShell.CommentDocKeyword].ForeColor =
                lexerColors[LexerType.WindowsPowerShell, "CommentDocKeywordFore"];
            scintilla.Styles[Style.PowerShell.CommentDocKeyword].BackColor =
                lexerColors[LexerType.WindowsPowerShell, "CommentDocKeywordBack"];

            ScintillaKeyWords.SetKeywords(scintilla, LexerType.WindowsPowerShell);

            scintilla.Lexer = Lexer.PowerShell;

            AddFolding(scintilla);

            return true;
        }
    }
}
