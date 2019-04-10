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
        public static bool CreateNsisLexer(Scintilla scintilla, LexerColors lexerColors)
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

                scintilla.Lexer = (Lexer)LexerTypeName.SCLEX_NSIS;

                // Name: instre1
                scintilla.SetKeywords(0, "Abort AddBrandingImage AddSize AllowRootDirInstall AllowSkipFiles AutoCloseWindow BGFont BGGradient BrandingText BringToFront Call CallInstDLL Caption ChangeUI CheckBitmap ClearErrors CompletedText ComponentText CopyFiles CRCCheck CreateDirectory CreateFont CreateShortCut Delete DeleteINISec DeleteINIStr DeleteRegKey DeleteRegValue DetailPrint DetailsButtonText DirText DirVar DirVerify EnableWindow EnumRegKey EnumRegValue Exch Exec ExecShell ExecWait ExpandEnvStrings File FileBufSize FileClose FileErrorText FileOpen FileRead FileReadByte FileReadUTF16LE FileSeek FileWrite FileWriteByte FileWriteUTF16LE FindClose FindFirst FindNext FindWindow FlushINI Function FunctionEnd GetCurInstType GetCurrentAddress GetDlgItem GetDLLVersion GetDLLVersionLocal GetErrorLevel GetExeName GetExePath GetFileTime GetFileTimeLocal GetFullPathName GetFunctionAddress GetInstDirError GetLabelAddress GetTempFileName Goto HideWindow Icon IfAbort IfErrors IfFileExists IfRebootFlag IfSilent InitPluginsDir InstallButtonText InstallColors InstallDir InstallDirRegKey InstProgressFlags InstType InstTypeGetText InstTypeSetText IntCmp IntCmpU IntFmt IntOp IsWindow LangString LangStringUP LicenseBkColor LicenseData LicenseForceSelection LicenseLangString LicenseText LoadLanguageFile LockWindow LogSet LogText ManifestDPIAware ManifestSupportedOS MessageBox MiscButtonText Nop Name OutFile Page PageEx PageExEnd PluginDir Pop Push Quit ReadEnvStr ReadINIStr ReadRegDWORD ReadRegStr Reboot RegDLL Rename RequestExecutionLevel ReserveFile Return RMDir SearchPath Section SectionEnd SectionGetFlags SectionGetInstTypes SectionGetSize SectionGetText SectionGroup SectionGroupEnd SectionIn SectionSetFlags SectionSetInstTypes SectionSetSize SectionSetText SendMessage SetAutoClose SetBrandingImage SetCompress SetCompressionLevel SetCompressor SetCompressorDictSize SetCtlColors SetCurInstType SetDatablockOptimize SetDateSave SetDetailsPrint SetDetailsView SetErrorLevel SetErrors SetFileAttributes SetFont SetOutPath SetOverwrite SetPluginUnload SetRebootFlag SetRegView SetShellVarContext SetSilent SetStaticBkColor ShowInstDetails ShowUninstDetails ShowWindow SilentInstall SilentUnInstall Sleep SpaceTexts StrCmp StrCmpS StrCpy StrLen SubSection SubSectionEnd Unicode UninstallButtonText UninstallCaption UninstallIcon UninstallSubCaption UninstallText UninstPage UnRegDLL UnsafeStrCpy Var VIAddVersionKey VIFileVersion VIProductVersion WindowIcon WriteINIStr WriteRegBin WriteRegDWORD WriteRegExpandStr WriteRegStr WriteUninstaller XPStyle !AddIncludeDir !AddPluginDir !appendfile !cd !define !delfile !echo !else !endif !error !execute !finalize !getdllversion !if !ifdef !ifmacrodef !ifmacrondef !ifndef !include !insertmacro !macro !macroend !macroundef !packhdr !searchparse !searchreplace !system !tempfile !undef !verbose !warning");
                // Name: instre2
                scintilla.SetKeywords(1, "$0 $1 $2 $3 $4 $5 $6 $7 $8 $9 $R0 $R1 $R2 $R3 $R4 $R5 $R6 $R7 $R8 $R9 $ADMINTOOLS $APPDATA $CDBURN_AREA $CMDLINE $COMMONFILES $COMMONFILES32 $COMMONFILES64 $COOKIES $DESKTOP $DOCUMENTS $EXEDIR $EXEFILE $EXEPATH $FAVORITES $FONTS $HISTORY $HWNDPARENT $INTERNET_CACHE $INSTDIR $LANGUAGE $LOCALAPPDATA $MUSIC $NETHOOD ${NSISDIR} $OUTDIR $PICTURES $PLUGINSDIR $PRINTHOOD $PROFILE $PROGRAMFILES $PROGRAMFILES32 $PROGRAMFILES64 $QUICKLAUNCH $RECENT $RESOURCES $RESOURCES_LOCALIZED $SENDTO $SMPROGRAMS $SMSTARTUP $STARTMENU $SYSDIR $TEMP $TEMPLATES $VIDEOS $WINDIR $$ $\n $\r $\t");
                // Name: type1
                scintilla.SetKeywords(2, "ARCHIVE CUR END FILE_ATTRIBUTE_ARCHIVE FILE_ATTRIBUTE_HIDDEN FILE_ATTRIBUTE_NORMAL FILE_ATTRIBUTE_OFFLINE FILE_ATTRIBUTE_READONLY FILE_ATTRIBUTE_SYSTEM FILE_ATTRIBUTE_TEMPORARY HIDDEN HKCC HKCR HKCU HKDD HKEY_CLASSES_ROOT HKEY_CURRENT_CONFIG HKEY_CURRENT_USER HKEY_DYN_DATA HKEY_LOCAL_MACHINE HKEY_PERFORMANCE_DATA HKEY_USERS HKLM HKPD HKU IDABORT IDCANCEL IDIGNORE IDNO IDOK IDRETRY IDYES MB_ABORTRETRYIGNORE MB_DEFBUTTON1 MB_DEFBUTTON2 MB_DEFBUTTON3 MB_DEFBUTTON4 MB_ICONEXCLAMATION MB_ICONINFORMATION MB_ICONQUESTION MB_ICONSTOP MB_OK MB_OKCANCEL MB_RETRYCANCEL MB_RIGHT MB_SETFOREGROUND MB_TOPMOST MB_USERICON MB_YESNO MB_YESNOCANCEL NORMAL OFFLINE READONLY SET SHCTX SW_HIDE SW_SHOWMAXIMIZED SW_SHOWMINIMIZED SW_SHOWNORMAL SYSTEM TEMPORARY all auto both bottom bzip2 checkbox colored current false force hide ifdiff ifnewer lastused leave left listonly lzma nevershow none normal off on pop push radiobuttons right show silent silentlog smooth textonly top true try zlib");

                AddFolding(scintilla);
                return true;

        }
    }
}
