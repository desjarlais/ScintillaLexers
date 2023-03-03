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

using System.Collections.Generic;
using ScintillaNET;
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace VPKSoft.ScintillaLexers.CreateSpecificLexer;

/// <summary>
/// A class containing code folding properties for different lexers.
/// </summary>
public class LexerFoldProperties
{
    /// <summary>
    /// Gets or sets the name of the fold property.
    /// </summary>
    /// <value>The name of the fold property.</value>
    public string FoldPropertyName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the fold property value.
    /// </summary>
    /// <value>The fold property value.</value>
    public string FoldPropertyValue { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the default folding properties for all lexers.
    /// </summary>
    public static List<LexerFoldProperties> DefaultFolding { get; set; } = new List<LexerFoldProperties>(new[]
    {
        new LexerFoldProperties {FoldPropertyName = "fold", FoldPropertyValue = "1", },
        new LexerFoldProperties {FoldPropertyName = "fold.compact", FoldPropertyValue = "1", },
        new LexerFoldProperties {FoldPropertyName = "fold.preprocessor", FoldPropertyValue = "1", },
    });

    /// <summary>
    /// Gets or sets the additional folding properties for the XML (eXtensible Markup Language) lexer.
    /// </summary>
    public static List<LexerFoldProperties> XmlFolding { get; set; } = new List<LexerFoldProperties>(new[]
    {
        new LexerFoldProperties {FoldPropertyName = "fold.html", FoldPropertyValue = "1", },
        new LexerFoldProperties {FoldPropertyName = "html.tags.case.sensitive", FoldPropertyValue = "1", },
    });

    /// <summary>
    /// Gets or sets the additional folding properties for the SQL (Structured Query Language) lexer.
    /// </summary>
    public static List<LexerFoldProperties> SqlFolding { get; set; } = new List<LexerFoldProperties>(new[]
    {
        new LexerFoldProperties {FoldPropertyName = "fold.sql.at.else", FoldPropertyValue = "1", }, // for a SQL lexer..
        new LexerFoldProperties {FoldPropertyName = "fold.comment", FoldPropertyValue = "1", }, // for a SQL lexer..
        new LexerFoldProperties {FoldPropertyName = "sql.backslash.escapes", FoldPropertyValue = "1", }, // for a SQL lexer.. (Enables backslash as an escape character in SQL.)
        new LexerFoldProperties {FoldPropertyName = "lexer.sql.numbersign.comment", FoldPropertyValue = "1", }, // for a SQL lexer.. (If lexer.sql.numbersign.comment property is set to 0 a line beginning with '#' will not be a comment.)
        new LexerFoldProperties {FoldPropertyName = "lexer.sql.allow.dotted.word", FoldPropertyValue = "1", }, // for a SQL lexer.. (set to 1 to colorize recognized words with dots (recommended for Oracle PL/SQL objects))
    });

    /// <summary>
    /// Gets or sets the additional folding properties for the HTML (Hypertext Markup Language) lexer.
    /// </summary>
    public static List<LexerFoldProperties> HyperTextFolding { get; set; } = new List<LexerFoldProperties>(new[]
    {
        new LexerFoldProperties {FoldPropertyName = "fold.hypertext.comment", FoldPropertyValue = "1", },
        new LexerFoldProperties {FoldPropertyName = "fold.hypertext.heredoc", FoldPropertyValue = "1", },
        new LexerFoldProperties {FoldPropertyName = "fold.html.preprocessor", FoldPropertyValue = "1", },
        new LexerFoldProperties {FoldPropertyName = "fold.html", FoldPropertyValue = "1", },
    });

    /// <summary>
    /// Sets the <see cref="Scintilla"/> properties.
    /// </summary>
    /// <param name="scintilla">The <see cref="Scintilla"/> instance of which properties to set.</param>
    /// <param name="foldProperties">A list of fold properties.</param>
    public static void SetScintillaProperties(Scintilla scintilla, List<LexerFoldProperties> foldProperties)
    {
        foreach (var foldProperty in foldProperties)
        {
            scintilla.SetProperty(foldProperty.FoldPropertyName, foldProperty.FoldPropertyValue);
        }
    }

    /// <summary>
    /// Sets the default folding for all lexers.
    /// </summary>
    /// <param name="scintilla">The <see cref="Scintilla"/> instance of which default folding properties to set.</param>
    public static void FoldDefault(Scintilla scintilla)
    {
        SetScintillaProperties(scintilla, DefaultFolding);
    }

    /// <summary>
    /// Sets the fold properties to a given lexer type.
    /// </summary>
    /// <param name="scintilla">The <see cref="Scintilla"/> of which fold properties to set.</param>
    /// <param name="lexerType">Type of the lexer.</param>
    public static void SetFoldProperties(Scintilla scintilla, LexerType lexerType)
    {
        switch (lexerType)
        {
            case LexerType.HTML:
                SetScintillaProperties(scintilla, HyperTextFolding); break;
            case LexerType.SQL:
                SetScintillaProperties(scintilla, SqlFolding); break;
            case LexerType.Xml:
                SetScintillaProperties(scintilla, XmlFolding); break;
            default:
                SetScintillaProperties(scintilla, DefaultFolding); break;
        }
    }
}