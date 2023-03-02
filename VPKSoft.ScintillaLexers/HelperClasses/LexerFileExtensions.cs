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
using System.IO;
using System.Linq;
using System.Text;
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace VPKSoft.ScintillaLexers.HelperClasses;

/// <summary>
/// A class containing lexer known file extensions for different lexers.
/// </summary>
public class LexerFileExtensions
{
    /// <summary>
    /// Gets or sets the type of the lexer.
    /// </summary>
    public LexerType LexerType { get; set; }

    /// <summary>
    /// Gets or sets the file extension list for a lexer.
    /// </summary>
    public string FileExtensionList { get; set; }

    /// <summary>
    /// A list of strings used to detect if a file by it's starting contents is a XML file.
    /// </summary>
    public static List<string> XmlFileDetectionStrings = new List<string>(
        new []{"<?xml "}
    );

    /// <summary>
    /// Gets a value indicating if the given file is an XML file.
    /// There are so many different extensions for XML files so it's better to peek inside the file if necessary.
    /// </summary>
    /// <param name="fileName">Name of the file to check for being a XML file.</param>
    /// <returns></returns>
    public static bool IsXmlFile(string fileName)
    {
        string ext = Path.GetExtension(fileName)?.ToLowerInvariant();

        var extensions = FileExtensions.FirstOrDefault(f => f.FileExtensionList.ToLowerInvariant().Split(' ').Contains(ext));

        if (extensions != null && // first through extensions as it is faster..
            extensions.LexerType == LexerType.Xml)
        {
            return true;
        }

        try
        {
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                using (var textReader = new StreamReader(fileStream))
                {
                    var bufferSize = XmlFileDetectionStrings.Max(f => f.Length);
                    var buffer = new char[bufferSize];
                    textReader.ReadBlock(buffer, 0, bufferSize);
                    var stringBuilder = new StringBuilder();
                    stringBuilder.Append(buffer);
                    var compareString = stringBuilder.ToString();

                    foreach (var xmlFileDetectionString in XmlFileDetectionStrings)
                    {
                        if (compareString.StartsWith(xmlFileDetectionString, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Gets or sets the value whether to peek inside to a file to check if the file is a XML file.
    /// </summary>
    public static bool DetectXmlFileFromFileContents { get; set; } = true;

    /// <summary>
    /// Gets or sets the file extensions for specified lexers.
    /// </summary>
    public static List<LexerFileExtensions> FileExtensions { get; set; } = new List<LexerFileExtensions>(new []
    {
        // File extensions for XML files.
        new LexerFileExtensions { LexerType = LexerType.Xml, FileExtensionList = ".xml .xaml .xsl .xslt .xsd .xul .kml .svg .mxml .xsml .wsdl .xlf " +
            ".xliff .xbl .sxbl .sitemap .gml .gpx .plist .resx .csproj .nuspec" },
        // File extensions for C# files.
        new LexerFileExtensions { LexerType = LexerType.Cs, FileExtensionList = ".cs" },

        // File extensions for C++ files.
        new LexerFileExtensions { LexerType = LexerType.Cpp, FileExtensionList = ".h .hpp .hxx .cpp .cxx .cc .ino" },

        // File extensions for SQL files.
        new LexerFileExtensions { LexerType = LexerType.SQL, FileExtensionList = ".sql .sql_script" },

        // File extensions for a batch file.
        new LexerFileExtensions { LexerType = LexerType.Batch, FileExtensionList = ".bat .cmd .btm .nt" },

        // File extensions for plain text files.
        new LexerFileExtensions { LexerType = LexerType.Text, FileExtensionList = ".txt" },

        // File extensions for the NSIS (Nullsoft Scriptable Install System).
        new LexerFileExtensions { LexerType = LexerType.Nsis, FileExtensionList = ".nsi .nsh" },

        // File extensions for the Inno Setup programming language.
        new LexerFileExtensions { LexerType = LexerType.InnoSetup, FileExtensionList = ".iss" },

        // File extensions for the Pascal programming language.
        new LexerFileExtensions { LexerType = LexerType.Pascal, FileExtensionList = ".pas" },

        // File extensions for the PHP programming language.
        new LexerFileExtensions { LexerType = LexerType.PHP, FileExtensionList = ".php3 .phtml .php" }, 

        // File extensions for the HTML markup language.
        new LexerFileExtensions { LexerType = LexerType.HTML, FileExtensionList = ".html .htm .shtml .shtm .xhtml .xht .hta" },

        // File extensions for the Windows PowerShell script files.
        new LexerFileExtensions { LexerType = LexerType.WindowsPowerShell, FileExtensionList = ".ps1 .psd1 .psm1" },

        // File extensions for the INI setting files.
        new LexerFileExtensions { LexerType = LexerType.INI, FileExtensionList = ".ini" },

        // File extension for the Python programming language files.
        new LexerFileExtensions { LexerType = LexerType.Python, FileExtensionList = ".py .pyw" },

        // File extension for the YAML (YAML Ain't Markup Language) language files.
        new LexerFileExtensions { LexerType = LexerType.Python, FileExtensionList = ".yml .yaml" },

        // File extension for the Java programming language.
        new LexerFileExtensions { LexerType = LexerType.Java, FileExtensionList = ".java" },

        // File extension for the JavaScript scripting language.
        new LexerFileExtensions { LexerType = LexerType.JavaScript, FileExtensionList = ".js .mjs" },

        // File extension for the Cascading Style Sheets (CSS).
        new LexerFileExtensions { LexerType = LexerType.Css, FileExtensionList = ".css" },

        // File extensions for the Visual Basic .NET programming language.
        new LexerFileExtensions { LexerType = LexerType.VbDotNet, FileExtensionList = ".vb" },

        // File extensions for the JavaScript Object Notation (Json) data format.
        new LexerFileExtensions { LexerType = LexerType.Json, FileExtensionList = ".json" },

        // new LexerFileExtensions { LexerType = LexerType.xxx, FileExtensionList = "" },
    }); 


    /// <summary>
    /// Gets a lexer type from a given file name.
    /// </summary>
    /// <param name="fileName">Name of the file from which to get the lexer type from.</param>
    /// <returns>A LexerType enumeration value.</returns>
    public static LexerType LexerTypeFromFileName(string fileName)
    {
        string ext = Path.GetExtension(fileName)?.ToLowerInvariant();

        var extensions = FileExtensions.FirstOrDefault(f => f.FileExtensionList.ToLowerInvariant().Split(' ').Contains(ext));

        if (extensions != null)
        {
            return extensions.LexerType;
        }

        if (DetectXmlFileFromFileContents && IsXmlFile(fileName))
        {
            return LexerType.Xml;
        }

        return LexerType.Unknown;
    }
}