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

// (C)::https://github.com/jacobslusser/ScintillaNET
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using ScintillaNET;
using VPKSoft.ScintillaLexers.CreateSpecificLexer;
using VPKSoft.ScintillaLexers.HelperClasses;
using VPKSoft.ScintillaLexers.ScintillaNotepadPlusPlus;
using static VPKSoft.ScintillaLexers.LexerEnumerations;


// (C)::https://github.com/notepad-plus-plus/notepad-plus-plus
// (C)::https://notepad-plus-plus.org
// (C)::https://github.com/jacobslusser/ScintillaNET
// (C)::https://www.scintilla.org

namespace VPKSoft.ScintillaLexers;

/// <summary>
/// A class for setting a lexer for a Scintilla class instance.
/// </summary>
public static class ScintillaLexers
{
    /// <summary>
    /// Gets or sets the value of a LexerColors class instance.
    /// </summary>
    public static LexerColors.LexerColors LexerColors { get; private set; } = new LexerColors.LexerColors();

    /// <summary>
    /// Creates the lexer from XML file used by the Notepad++ software.
    /// </summary>
    /// <param name="scintilla">The <see cref="Scintilla"/> which lexer style to set.</param>
    /// <param name="lexerType">Type of the lexer.</param>
    /// <param name="fileName">A file name to get the lexer type from.</param>
    /// <returns><c>true</c> if the operation was successful, <c>false</c> otherwise.</returns>
    public static bool CreateLexerFromFile(Scintilla scintilla, LexerType lexerType,
        string fileName)
    {
        return CreateLexerFromFile(scintilla, lexerType, fileName, true, true, true, true, true);
    }

    /// <summary>
    /// Creates the lexer from XML file used by the Notepad++ software.
    /// </summary>
    /// <param name="scintilla">The <see cref="Scintilla"/> which lexer style to set.</param>
    /// <param name="fileName">A file name to get the lexer type from.</param>
    /// <param name="definitionFile">A XML file to load the lexer style from.</param>
    /// <returns><c>true</c> if the operation was successful, <c>false</c> otherwise.</returns>
    public static bool CreateLexerFromFile(Scintilla scintilla, string fileName, string definitionFile)
    {
        return CreateLexerFromFile(scintilla, LexerFileExtensions.LexerTypeFromFileName(fileName), definitionFile, true, true, true, true, true);
    }

    /// <summary>
    /// Creates the lexer from XML file used by the Notepad++ software.
    /// </summary>
    /// <param name="scintilla">The <see cref="Scintilla"/> which lexer style to set.</param>
    /// <param name="fileName">A file name to get the lexer type from.</param>
    /// <param name="definitionFile">A XML file to load the lexer style from.</param>
    /// <param name="useGlobalOverride">A flag indicating whether the style "Global override" should be set for the lexer from the XML document.</param>
    /// <param name="font">A flag indicating whether to use the defined font name from the XML document or not.</param>
    /// <returns><c>true</c> if the operation was successful, <c>false</c> otherwise.</returns>
    public static bool CreateLexerFromFile(Scintilla scintilla, string fileName, string definitionFile, bool useGlobalOverride, bool font)
    {
        return CreateLexerFromFile(scintilla, LexerFileExtensions.LexerTypeFromFileName(fileName), definitionFile, useGlobalOverride, font, true, true, true);
    }


    /// <summary>
    /// Creates the lexer from XML file used by the Notepad++ software.
    /// </summary>
    /// <param name="scintilla">The <see cref="Scintilla"/> which lexer style to set.</param>
    /// <param name="lexerType">Type of the lexer.</param>
    /// <param name="fileName">A file name to get the lexer type from.</param>
    /// <param name="useGlobalOverride">A flag indicating whether the style "Global override" should be set for the lexer from the XML document.</param>
    /// <param name="font">A flag indicating whether to use the defined font name from the XML document or not.</param>
    /// <returns><c>true</c> if the operation was successful, <c>false</c> otherwise.</returns>
    public static bool CreateLexerFromFile(Scintilla scintilla, LexerType lexerType,
        string fileName, bool useGlobalOverride, bool font)
    {
        return CreateLexerFromFile(scintilla, lexerType, fileName, useGlobalOverride, font, true, true, true);
    }

    /// <summary>
    /// Creates the lexer from XML file used by the Notepad++ software.
    /// </summary>
    /// <param name="scintilla">The <see cref="Scintilla"/> which lexer style to set.</param>
    /// <param name="fileName">A file name to get the lexer type from.</param>
    /// <param name="definitionFile">A XML file to load the lexer style from.</param>
    /// <param name="useGlobalOverride">A flag indicating whether the style "Global override" should be set for the lexer from the XML document.</param>
    /// <param name="font">A flag indicating whether to use the defined font name from the XML document or not.</param>
    /// <param name="useWhiteSpace">A flag indicating whether to color the white space symbol.</param>
    /// <param name="useSelectionColors">A flag indicating whether to color the selection.</param>
    /// <param name="useMarginColors">A flag indicating whether to color the margin.</param>
    /// <returns><c>true</c> if the operation was successful, <c>false</c> otherwise.</returns>
    public static bool CreateLexerFromFile(Scintilla scintilla, string fileName, string definitionFile,
        bool useGlobalOverride, bool font, bool useWhiteSpace, bool useSelectionColors,
        bool useMarginColors)
    {
        return CreateLexerFromFile(scintilla, LexerFileExtensions.LexerTypeFromFileName(fileName), definitionFile, useGlobalOverride, font, useWhiteSpace, useSelectionColors, useMarginColors);
    }

    /// <summary>
    /// Creates the lexer from XML file used by the Notepad++ software.
    /// </summary>
    /// <param name="scintilla">The <see cref="Scintilla"/> which lexer style to set.</param>
    /// <param name="lexerType">Type of the lexer.</param>
    /// <param name="fileName">A file name to get the lexer type from.</param>
    /// <param name="useGlobalOverride">A flag indicating whether the style "Global override" should be set for the lexer from the XML document.</param>
    /// <param name="font">A flag indicating whether to use the defined font name from the XML document or not.</param>
    /// <param name="useWhiteSpace">A flag indicating whether to color the white space symbol.</param>
    /// <param name="useSelectionColors">A flag indicating whether to color the selection.</param>
    /// <param name="useMarginColors">A flag indicating whether to color the margin.</param>
    /// <returns><c>true</c> if the operation was successful, <c>false</c> otherwise.</returns>
    public static bool CreateLexerFromFile(Scintilla scintilla, LexerType lexerType, 
        string fileName, bool useGlobalOverride, bool font, bool useWhiteSpace, bool useSelectionColors,
        bool useMarginColors)
    {
        try
        {
            XDocument document = XDocument.Load(fileName);

            ScintillaNotepadPlusPlusStyles.SetGlobalDefaultStyles(document, scintilla, useGlobalOverride, font);

            ScintillaNotepadPlusPlusStyles.LoadScintillaStyleFromNotepadPlusXml(document, scintilla, useWhiteSpace,
                useSelectionColors, useMarginColors);

            ScintillaNotepadPlusPlusStyles.LoadLexerStyleFromNotepadPlusXml(document, scintilla,
                lexerType); // TODO::Font?

            var lexerTypeDetected = LexerTypeName.GetLexerByLexerType(lexerType);

            scintilla.LexerName = lexerTypeDetected;

            ScintillaKeyWords.SetKeywords(scintilla, lexerType);

            LexerFoldProperties.SetFoldProperties(scintilla, lexerType);

            ScintillaNotepadPlusPlusStyles.SetFolding(document, scintilla);

            System.Diagnostics.Debug.WriteLine(scintilla.DescribeKeywordSets());

            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Creates the lexer for a given Scintilla class instance with a given language type enumeration.
    /// </summary>
    /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
    /// <param name="fileName">A file name to get the lexer type from.</param>
    /// <returns>True if the given lexer was found; otherwise false (a work in progress).</returns>
    public static bool CreateLexer(Scintilla scintilla, string fileName)
    {
        return CreateLexer(scintilla, LexerFileExtensions.LexerTypeFromFileName(fileName));
    }

    /// <summary>
    /// Creates the lexer for a given Scintilla class instance with a given language type enumeration.
    /// </summary>
    /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
    /// <param name="lexerType">Type of the lexer / programming language.</param>
    /// <returns>True if the given lexer was found; otherwise false (a work in progress).</returns>
    public static bool CreateLexer(Scintilla scintilla, LexerType lexerType)
    {
        if (lexerType == LexerType.Cs)
        {
            return CreateLexerCs.CreateCsLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.Xml)
        {
            return CreateLexerXml.CreateXmlLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.Cpp)
        {
            return CreateLexerCpp.CreateCppLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.Text || lexerType == LexerType.Unknown)
        {
            return CreateLexerNull.CreateNullLexer(scintilla);
        }

        if (lexerType == LexerType.Nsis)
        {
            return CreateLexerNsis.CreateNsisLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.InnoSetup)
        {
            return CreateLexerInnoSetup.CreateInnoSetupLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.SQL)
        {
            return CreateLexerSql.CreateSqlLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.Batch)
        {
            return CreateLexerBatch.CreateBatchLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.Pascal)
        {
            return CreateLexerPascal.CreatePascalLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.PHP)
        {
            return CreateLexerPhp.CreatePhpLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.HTML)
        {
            return CreateLexerHtml.CreateHtmlLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.WindowsPowerShell)
        {
            return CreateLexerPowerShell.CreatePowerShellLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.INI)
        {
            return CreateLexerIni.CreateIniLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.Python)
        {
            return CreateLexerPython.CreatePythonLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.YAML)
        {
            return CreateLexerYaml.CreateYamlLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.Java)
        {
            return CreateLexerJava.CreateJavaLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.JavaScript)
        {
            return CreateLexerJavaScript.CreateJavaScriptLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.Css)
        {
            return CreateLexerCss.CreateCssLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.VbDotNet)
        {
            return CreateLexerVb.CreateVbLexer(scintilla, LexerColors);
        }

        if (lexerType == LexerType.Json)
        {
            return CreateLexerJson.CreateJsonLexer(scintilla, LexerColors);
        }

        // a lexer wasn't found..
        return false;
    }
}