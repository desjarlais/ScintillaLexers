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

namespace VPKSoft.ScintillaLexers.HelperClasses
{
    /// <summary>
    /// A class containing lexer known file extensions for different lexers.
    /// </summary>
    public class LexerFileExtensions
    {
        /// <summary>
        /// Gets or sets the type of the lexer.
        /// </summary>
        public LexerEnumerations.LexerType LexerType { get; set; }

        /// <summary>
        /// Gets or sets the file extension list for a lexer.
        /// </summary>
        public string FileExtensionList { get; set; }

        /// <summary>
        /// Gets or sets the file extensions for specified lexers.
        /// </summary>
        public static List<LexerFileExtensions> FileExtensions { get; set; } = new List<LexerFileExtensions>(new []
        {
            // File extensions for XML files.
            new LexerFileExtensions { LexerType = LexerEnumerations.LexerType.Xml, FileExtensionList = ".xml .xaml .xsl .xslt .xsd .xul .kml .svg .mxml .xsml .wsdl .xlf .xliff .xbl .sxbl .sitemap .gml .gpx .plist" },

            // File extensions for C# files.
            new LexerFileExtensions { LexerType = LexerEnumerations.LexerType.Cs, FileExtensionList = ".cs" },

            // File extensions for C++ files.
            new LexerFileExtensions { LexerType = LexerEnumerations.LexerType.Cpp, FileExtensionList = ".h .hpp .hxx .cpp .cxx .cc .ino" },

            // File extensions for SQL files.
            new LexerFileExtensions { LexerType = LexerEnumerations.LexerType.SQL, FileExtensionList = ".sql .sql_script" },

            // File extensions for a batch file.
            new LexerFileExtensions { LexerType = LexerEnumerations.LexerType.Batch, FileExtensionList = ".bat .cmd .btm .nt" },

            // File extensions for plain text files.
            new LexerFileExtensions { LexerType = LexerEnumerations.LexerType.Text, FileExtensionList = ".txt" },

            // File extensions for the NSIS (Nullsoft Scriptable Install System).
            new LexerFileExtensions { LexerType = LexerEnumerations.LexerType.Nsis, FileExtensionList = ".nsi .nsh" },

            // File extensions for the Pascal programming language.
            new LexerFileExtensions { LexerType = LexerEnumerations.LexerType.Pascal, FileExtensionList = ".pas" },

            // File extensions for the PHP programming language.
            new LexerFileExtensions { LexerType = LexerEnumerations.LexerType.PHP, FileExtensionList = ".php3 .phtml .php" }, 

            // File extensions for the HTML markup language.
            new LexerFileExtensions { LexerType = LexerEnumerations.LexerType.HTML, FileExtensionList = ".html .htm .shtml .shtm .xhtml .xht .hta" },

            // File extensions for the Windows PowerShell script files.
            new LexerFileExtensions { LexerType = LexerEnumerations.LexerType.WindowsPowerShell, FileExtensionList = ".ps1 .psd1 .psm1" },

            // File extensions for the INI setting files.
            new LexerFileExtensions { LexerType = LexerEnumerations.LexerType.INI, FileExtensionList = ".ini" },

            // File extension for the Python programming language files.
            new LexerFileExtensions { LexerType = LexerEnumerations.LexerType.Python, FileExtensionList = ".py .pyw" },

            // new LexerFileExtensions { LexerType = LexerType.xxx, FileExtensionList = "" },
        }); 


        /// <summary>
        /// Gets a lexer type from a given file name.
        /// </summary>
        /// <param name="fileName">Name of the file from which to get the lexer type from.</param>
        /// <returns>A LexerType enumeration value.</returns>
        public static LexerEnumerations.LexerType LexerTypeFromFileName(string fileName)
        {
            string ext = Path.GetExtension(fileName)?.ToLowerInvariant();

            var extensions = FileExtensions.FirstOrDefault(f => f.FileExtensionList.ToLowerInvariant().Split(' ').Contains(ext));

            if (extensions != null)
            {
                return extensions.LexerType;
            }

            return LexerEnumerations.LexerType.Unknown;
        }
    }
}
