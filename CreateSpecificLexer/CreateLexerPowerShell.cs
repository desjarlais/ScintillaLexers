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
        public static bool CreatePowerShellLexer(Scintilla scintilla, LexerColors lexerColors)
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

            // Name: instre1
            scintilla.SetKeywords(0,
                "break continue do else elseif filter for foreach function if in return switch until where while");
            // Name: instre2
            scintilla.SetKeywords(1,
                "add-content add-history add-member add-pssnapin clear-content clear-item clear-itemproperty clear-variable compare-object convertfrom-securestring convert-path convertto-html convertto-securestring copy-item copy-itemproperty export-alias export-clixml export-console export-csv foreach-object format-custom format-list format-table format-wide get-acl get-alias get-authenticodesignature get-childitem get-command get-content get-credential get-culture get-date get-eventlog get-executionpolicy get-help get-history get-host get-item get-itemproperty get-location get-member get-pfxcertificate get-process get-psdrive get-psprovider get-pssnapin get-service get-tracesource get-uiculture get-unique get-variable get-wmiobject group-object import-alias import-clixml import-csv invoke-expression invoke-history invoke-item join-path measure-command measure-object move-item move-itemproperty new-alias new-item new-itemproperty new-object new-psdrive new-service new-timespan new-variable out-default out-file out-host out-null out-printer out-string pop-location push-location read-host remove-item remove-itemproperty remove-psdrive remove-pssnapin remove-variable rename-item rename-itemproperty resolve-path restart-service resume-service select-object select-string set-acl set-alias set-authenticodesignature set-content set-date set-executionpolicy set-item set-itemproperty set-location set-psdebug set-service set-tracesource set-variable sort-object split-path start-service start-sleep start-transcript stop-process stop-service stop-transcript suspend-service tee-object test-path trace-command update-formatdata update-typedata where-object write-debug write-error write-host write-output write-progress write-verbose write-warning");
            // Name: type1
            scintilla.SetKeywords(2,
                "ac asnp clc cli clp clv cpi cpp cvpa diff epal epcsv fc fl foreach ft fw gal gc gci gcm gdr ghy gi gl gm gp gps group gsv gsnp gu gv gwmi iex ihy ii ipal ipcsv mi mp nal ndr ni nv oh rdr ri rni rnp rp rsnp rv rvpa sal sasv sc select si sl sleep sort sp spps spsv sv tee where write cat cd clear cp h history kill lp ls mount mv popd ps pushd pwd r rm rmdir echo cls chdir copy del dir erase move rd ren set type");
            // Name: type4
            scintilla.SetKeywords(3,
                "component description example externalhelp forwardhelpcategory forwardhelptargetname functionality inputs link notes outputs parameter remotehelprunspace role synopsis");

            scintilla.Lexer = Lexer.PowerShell;

            AddFolding(scintilla);

            return true;
        }
    }
}
