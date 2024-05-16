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
using ScintillaLexers.HelperClasses;
using ScintillaLexers.LexerColors;
using static ScintillaLexers.LexerEnumerations;

namespace ScintillaLexers.CreateSpecificLexer;

/// <summary>
/// A class for the PHP lexer.
/// Implements the <see cref="ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
/// </summary>
/// <seealso cref="ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
public abstract class CreateLexerPhp: CreateLexerCommon
{
    /// <summary>
    /// Creates the lexer for a given Scintilla class instance for the PHP programming language.
    /// </summary>
    /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
    /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
    /// <returns>True if the operation was successful; otherwise false.</returns>
    public static bool CreatePhpLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
    {
        ClearStyle(scintilla);

        //..therefore the weird logic.. (which might malfunction)..
        SetPhpStyles(scintilla, lexerColors);
        SetHtmlStyles(scintilla, lexerColors);

        scintilla.LexerName = "phpscript";

        ScintillaKeyWords.SetKeywords(scintilla, LexerType.PHP);

        SetScriptedHtml(LexerType.PHP, scintilla, lexerColors);

        AddFolding(scintilla);
        return true;
    }
}