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

namespace ScintillaLexers;

/// <summary>
/// A class containing the <see cref="LexerType"/> enumeration values.
/// </summary>
public class LexerEnumerations
{
    /// <summary>
    /// An enumeration of currently supported Scintilla lexers.
    /// </summary>
    public enum LexerType
    {
        /// <summary>
        /// An unknown language and / or file.
        /// </summary>
        Unknown = 0, // previously: 0

        /// <summary>
        /// The C# programming language.
        /// </summary>
        Cs = 1, // previously: 1

        /// <summary>
        /// The C++ programming language.
        /// </summary>
        Cpp = 2, // previously: 2

        /// <summary>
        /// The eXtensible Markup Language.
        /// </summary>
        Xml = 3, // previously: 4

        /// <summary>
        /// A plain text document.
        /// </summary>
        Text = 4, // previously: 8

        /// <summary>
        /// The NSIS (Nullsoft Scriptable Install System).
        /// </summary>
        Nsis = 5, // previously: 16

        /// <summary>
        /// The Structured Query Language (SQL).
        /// </summary>
        SQL = 6, // previously: 32

        /// <summary>
        /// A batch script file.
        /// </summary>
        Batch = 7, // previously: 64

        /// <summary>
        /// A lexer for the Pascal programming language.
        /// </summary>
        Pascal = 8, // previously: 128

        /// <summary>
        /// A lexer for the PHP programming language.
        /// </summary>
        PHP = 9, // previously: 256

        /// <summary>
        /// A lexer type for the HTML (Hypertext Markup Language).
        /// </summary>
        HTML = 10, // previously: 512

        /// <summary>
        /// A lexer type for the Windows PowerShell scripting language.
        /// </summary>
        WindowsPowerShell = 11,

        /// <summary>
        /// An INI file lexer.
        /// </summary>
        INI = 12,

        /// <summary>
        /// A lexer for the Python programming language.
        /// </summary>
        Python = 13,

        /// <summary>
        /// A lexer for the YAML Ain't Markup Language.
        /// </summary>
        YAML = 14,

        /// <summary>
        /// A lexer for the Java programming language.
        /// </summary>
        Java = 15,

        /// <summary>
        /// A lexer for the JavaScript scripting language.
        /// </summary>
        JavaScript = 16,

        /// <summary>
        /// A lexer for the Cascading Style Sheets (CSS).
        /// </summary>
        Css = 17,

        /// <summary>
        /// A lexer for the Inno Setup.
        /// </summary>
        InnoSetup = 18,

        /// <summary>
        /// The Visual Basic .NET programming language.
        /// </summary>
        VbDotNet = 19,

        /// <summary>
        /// The JavaScript Object Notation (JSON) data format.
        /// </summary>
        Json,

        /// <summary>
        /// The error list lexer (diff).
        /// </summary>
        ErrorList,
    }
}