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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace VPKSoft.ScintillaLexers
{
    /// <summary>
    /// A class containing lexer known file extensions for different lexers.
    /// </summary>
    public class LexerFileExtensions
    {
        /// <summary>
        /// File extensions for XML files.
        /// </summary>
        public static string XmlExtensions { get; set; } =
            ".xml .xaml .xsl .xslt .xsd .xul .kml .svg .mxml .xsml .wsdl .xlf .xliff .xbl .sxbl .sitemap .gml .gpx .plist";

        /// <summary>
        /// File extensions for C# files.
        /// </summary>
        public static string CsExtensions { get; set; } = ".cs";

        /// <summary>
        /// File extensions for C++ files.
        /// </summary>
        public static string CppExtensions { get; set; } = ".h .hpp .hxx .cpp .cxx .cc .ino";

        /// <summary>
        /// File extensions for SQL files.
        /// </summary>
        public static string SqlExtensions { get; set; } = ".sql .sql_script";

        /// <summary>
        /// File extensions for a batch file.
        /// </summary>
        public static string BatchExtensions { get; set; } = ".bat .cmd .btm .nt";

        /// <summary>
        /// File extensions for plain text files.
        /// </summary>
        public static string TxtExtensions { get; set; } = ".txt";

        /// <summary>
        /// File extensions for the NSIS (Nullsoft Scriptable Install System).
        /// </summary>
        public static string NsisExtensions { get; set; } = ".nsi .nsh";

        /// <summary>
        /// File extensions for the Pascal programming language.
        /// </summary>
        public static string PascalExtensions { get; set; } = ".pas";

        /// <summary>
        /// File extensions for the PHP programming language.
        /// </summary>
        public static string PhpExtensions { get; set; } = ".php3 .phtml .php";

        /// <summary>
        /// File extensions for the HTML markup language.
        /// </summary>
        public static string HtmlExtensions { get; set; } = ".html .htm .shtml .shtm .xhtml .xht .hta";

        /// <summary>
        /// File extensions for the Windows PowerShell script files.
        /// </summary>
        public static string PowerShellExtensions { get; set; } = ".ps1 .psd1 .psm1";

        /// <summary>
        /// File extensions for the INI setting files.
        /// </summary>
        public static string IniExtensions { get; set; } = ".ini";

        /// <summary>
        /// File extension for the Python programming language files.
        /// </summary>
        public static string PythonExtensions { get; set; } = ".py .pyw";

        /// <summary>
        /// Gets a lexer type from a given file name.
        /// </summary>
        /// <param name="fileName">Name of the file from which to get the lexer type from.</param>
        /// <returns>A LexerType enumeration value.</returns>
        public static LexerType LexerTypeFromFileName(string fileName)
        {
            string ext = Path.GetExtension(fileName).ToLowerInvariant();
            IEnumerable<string> extensions = XmlExtensions.Split(' ');
            if (extensions.Contains(ext))
            {
                return LexerType.Xml;
            }

            extensions = CsExtensions.Split(' ');
            if (extensions.Contains(ext))
            {
                return LexerType.Cs;
            }

            extensions = CppExtensions.Split(' ');
            if (extensions.Contains(ext))
            {
                return LexerType.Cs;
            }

            extensions = TxtExtensions.Split(' ');
            if (extensions.Contains(ext))
            {
                return LexerType.Text;
            }

            extensions = NsisExtensions.Split(' ');
            if (extensions.Contains(ext))
            {
                return LexerType.Nsis;
            }

            extensions = SqlExtensions.Split(' ');
            if (extensions.Contains(ext))
            {
                return LexerType.SQL;
            }

            extensions = BatchExtensions.Split(' ');
            if (extensions.Contains(ext))
            {
                return LexerType.Batch;
            }

            extensions = PascalExtensions.Split(' ');
            if (extensions.Contains(ext))
            {
                return LexerType.Pascal;
            }

            extensions = PhpExtensions.Split(' ');
            if (extensions.Contains(ext))
            {
                return LexerType.PHP;
            }

            extensions = HtmlExtensions.Split(' ');
            if (extensions.Contains(ext))
            {
                return LexerType.HTML;
            }

            extensions = PowerShellExtensions.Split(' ');
            if (extensions.Contains(ext))
            {
                return LexerType.WindowsPowerShell;
            }

            extensions = IniExtensions.Split(' ');
            if (extensions.Contains(ext))
            {
                return LexerType.INI;
            }

            extensions = PythonExtensions.Split(' ');
            if (extensions.Contains(ext))
            {
                return LexerType.Python;
            }

            return LexerType.Unknown;
        }
    }
}
