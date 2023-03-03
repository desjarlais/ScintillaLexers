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

using System;
using System.Collections.Generic;
using System.Linq;
using ScintillaNET;

namespace VPKSoft.ScintillaLexers.HelperClasses;

/// <summary>
/// A helper class for Class LexerTypeName.
/// </summary>
public class LexerTypeName
{
    /// <summary>
    /// The NSIS (Nullsoft Scriptable Install System) lexer value.
    /// </summary>
    public const int SCLEX_NSIS = 43;

    /// <summary>
    /// The Inno Setup lexer value.
    /// </summary>
    public const int SCLEX_INNOSETUP = 76;

    /// <summary>
    /// The YAML (YAML Ain't Markup Language) lexer value.
    /// </summary>
    public const int SCLEX_YAML = 48;

    /// <summary>
    /// A list of currently supported lexers by this library.
    /// </summary>
    public static readonly List<Tuple<LexerEnumerations.LexerType, string, Lexer>> LexerTypeNameList = new List<Tuple<LexerEnumerations.LexerType, string, Lexer>>(
        new[]
        {
            Tuple.Create(LexerEnumerations.LexerType.Unknown, "text", Lexer.Null),
            Tuple.Create(LexerEnumerations.LexerType.Cs, "cs", Lexer.Cpp),
            Tuple.Create(LexerEnumerations.LexerType.Cpp, "cpp", Lexer.Cpp),
            Tuple.Create(LexerEnumerations.LexerType.Xml, "xml", Lexer.Xml),
            Tuple.Create(LexerEnumerations.LexerType.Text, "text", Lexer.Null),
            Tuple.Create(LexerEnumerations.LexerType.Nsis, "nsis", (Lexer)SCLEX_NSIS),
            Tuple.Create(LexerEnumerations.LexerType.InnoSetup, "inno", (Lexer)SCLEX_INNOSETUP),
            Tuple.Create(LexerEnumerations.LexerType.SQL, "sql", Lexer.Xml),
            Tuple.Create(LexerEnumerations.LexerType.Batch, "batch", Lexer.Batch),
            Tuple.Create(LexerEnumerations.LexerType.Pascal, "pascal", Lexer.Pascal),
            Tuple.Create(LexerEnumerations.LexerType.PHP, "php", Lexer.PhpScript),
            Tuple.Create(LexerEnumerations.LexerType.WindowsPowerShell, "powershell", Lexer.PowerShell),
            Tuple.Create(LexerEnumerations.LexerType.INI, "ini", Lexer.Properties),
            Tuple.Create(LexerEnumerations.LexerType.Python, "python", Lexer.Python),
            Tuple.Create(LexerEnumerations.LexerType.YAML, "yaml", (Lexer)SCLEX_YAML),
            Tuple.Create(LexerEnumerations.LexerType.Java, "java", Lexer.Cpp),
            Tuple.Create(LexerEnumerations.LexerType.Css, "css", Lexer.Css),
            Tuple.Create(LexerEnumerations.LexerType.VbDotNet, "vb", Lexer.Vb),
            Tuple.Create(LexerEnumerations.LexerType.Json, "json", Lexer.Json),
        });

    /// <summary>
    /// Gets the name of the lexer XML used in Notepad++'s XML style files.
    /// </summary>
    /// <param name="lexerType">Type of the lexer.</param>
    /// <returns>The name of the lexer used in Notepad++'s XML style files if successful; otherwise "text".</returns>
    public static string GetLexerXmlName(LexerEnumerations.LexerType lexerType)
    {
        var result = LexerTypeNameList.FirstOrDefault(f => f.Item1 == lexerType);
        return result == null ? "text" : result.Item2;
    }

    /// <summary>
    /// Gets the name of the lexer XML used in Notepad++'s XML style files.
    /// </summary>
    /// <param name="lexer">The Scintilla lexer enumeration value.</param>
    /// <returns>The name of the lexer used in Notepad++'s XML style files if successful; otherwise "text".</returns>
    public static string GetLexerXmlName(Lexer lexer)
    {
        var result = LexerTypeNameList.FirstOrDefault(f => f.Item3 == lexer);
        return result == null ? "text" : result.Item2;
    }

    /// <summary>
    /// Gets the type of the lexer by a given <see cref="LexerEnumerations.LexerType"/> enumeration.
    /// </summary>
    /// <param name="lexerType">Type of the lexer.</param>
    /// <returns>A <see cref="Lexer"/> matching the given <see cref="LexerEnumerations.LexerType"/> enumeration.</returns>
    public static string? GetLexerByLexerType(LexerEnumerations.LexerType lexerType)
    {
        var result = LexerTypeNameList.FirstOrDefault(f => f.Item1 == lexerType);
        return result?.Item2;
    }
}