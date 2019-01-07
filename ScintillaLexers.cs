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

using ScintillaNET; // (C)::https://github.com/jacobslusser/ScintillaNET
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;


// (C)::https://github.com/notepad-plus-plus/notepad-plus-plus
// (C)::https://notepad-plus-plus.org
// (C)::https://github.com/jacobslusser/ScintillaNET
// (C)::https://www.scintilla.org

namespace VPKSoft.ScintillaLexers
{
    /// <summary>
    /// An enumeration of currently supported Scintilla lexers.
    /// </summary>
    [Flags]
    public enum LexerType: int
    {
        /// <summary>
        /// An unknown language and / or file.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The C# programming language.
        /// </summary>
        Cs = 1,

        /// <summary>
        /// The C++ programming language.
        /// </summary>
        Cpp = 2,

        /// <summary>
        /// The Extensible Markup Language.
        /// </summary>
        Xml = 4,

        /// <summary>
        /// A plain text document.
        /// </summary>
        Text = 8,

        /// <summary>
        /// The NSIS (Nullsoft Scriptable Install System).
        /// </summary>
        Nsis = 16,

        /// <summary>
        /// The Structured Query Language (SQL).
        /// </summary>
        SQL = 32,

        /// <summary>
        /// A batch script file.
        /// </summary>
        Batch = 64,

        /// <summary>
        /// A lexer for the Pascal language.
        /// </summary>
        Pascal = 118
    }

    /// <summary>
    /// A class containing the colors for the lexers.
    /// </summary>
    public class LexerColors
    {
        /// <summary>
        /// Gets or sets the colors for a given LexerType enumeration.
        /// </summary>
        /// <param name="lexerType">The lexer's type.</param>
        /// <returns>A list of color belonging to a specific lexer.</returns>
        /// <exception cref="ArgumentOutOfRangeException">value</exception>
        public List<Color> this[LexerType lexerType]
        {
            get
            {
                List<Color> result = new List<Color>();
                if (lexerType == LexerType.Cpp)
                {
                    result.AddRange(cppColors);
                }
                else if (lexerType == LexerType.Nsis)
                {
                    result.AddRange(nsisColors);
                }
                else if (lexerType == LexerType.Cs)
                {
                    result.AddRange(csColors);
                }
                else if (lexerType == LexerType.Xml)
                {
                    return xmlColors;
                }
                else if (lexerType == LexerType.SQL)
                {
                    return sqlColors;
                }
                else if (lexerType == LexerType.Batch)
                {
                    return batchColors;
                }
                else if (lexerType == LexerType.Pascal)
                {
                    return pascalColors;
                }
                return result;
            }

            set
            {
                if (lexerType == LexerType.Cpp)
                {
                    if (value == null || value.Count != cppColors.Count)
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                    cppColors = value;
                }
                else if (lexerType == LexerType.Nsis)
                {
                    if (value == null || value.Count != nsisColors.Count)
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                    nsisColors = value;
                }
                else if (lexerType == LexerType.Cs)
                {
                    if (value == null || value.Count != csColors.Count)
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                    csColors = value;
                }
                else if (lexerType == LexerType.Xml)
                {
                    if (value == null || value.Count != xmlColors.Count)
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                    xmlColors = value;
                }
                else if (lexerType == LexerType.SQL)
                {
                    if (value == null || value.Count != sqlColors.Count)
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                    sqlColors = value;
                }
                else if (lexerType == LexerType.Batch)
                {
                    if (value == null || value.Count != batchColors.Count)
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                    batchColors = value;
                }
                else if (lexerType == LexerType.Pascal)
                {
                    if (value == null || value.Count != pascalColors.Count)
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                    pascalColors = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Color"/> with the specified lexer type and the color's name.
        /// </summary>
        /// <param name="lexerType">The type of the lexer.</param>
        /// <param name="colorName">The name of the color.</param>
        /// <returns>A color with the specified lexer type and with a specified name.</returns>
        /// <exception cref="ArgumentOutOfRangeException">value</exception>
        public Color this[LexerType lexerType, string colorName]
        {
            get
            {
                return this[lexerType][GetColorIndexByName(colorName, lexerType)];
            }

            set
            {
                try
                {
                    this[lexerType][GetColorIndexByName(colorName, lexerType)] = value;
                }
                catch
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
        }

        #region InternalColorList
        private List<Color> cppColors =
            new List<Color>(new Color[]
            {
                Color.FromArgb(128, 64, 0), // #804000 
                Color.FromArgb(255, 255, 255), // #804000 
                Color.FromArgb(0, 0, 0), // #000000 
                Color.FromArgb(255, 255, 255), // #000000 
                Color.FromArgb(0, 0, 255), // #0000FF 
                Color.FromArgb(255, 255, 255), // #0000FF 
                Color.FromArgb(128, 0, 255), // #8000FF 
                Color.FromArgb(255, 255, 255), // #8000FF 
                Color.FromArgb(255, 128, 0), // #FF8000 
                Color.FromArgb(255, 255, 255), // #FF8000 
                Color.FromArgb(128, 128, 128), // #808080 
                Color.FromArgb(255, 255, 255), // #808080 
                Color.FromArgb(128, 128, 128), // #808080 
                Color.FromArgb(255, 255, 255), // #808080 
                Color.FromArgb(0, 0, 128), // #000080 
                Color.FromArgb(255, 255, 255), // #000080 
                Color.FromArgb(0, 0, 0), // #000000 
                Color.FromArgb(255, 255, 255), // #000000 
                Color.FromArgb(0, 0, 0), // #000000 
                Color.FromArgb(255, 255, 255), // #000000 
                Color.FromArgb(0, 128, 0), // #008000 
                Color.FromArgb(255, 255, 255), // #008000 
                Color.FromArgb(0, 128, 0), // #008000 
                Color.FromArgb(255, 255, 255), // #008000 
                Color.FromArgb(0, 128, 128), // #008080 
                Color.FromArgb(255, 255, 255), // #008080 
                Color.FromArgb(0, 128, 128), // #008080 
                Color.FromArgb(255, 255, 255), // #008080 
                Color.FromArgb(0, 128, 128), // #008080 
                Color.FromArgb(255, 255, 255), // #008080 
                Color.FromArgb(0, 128, 128), // #008080 
                Color.FromArgb(255, 255, 255), // #008080 
                Color.FromArgb(0, 128, 0), // #008000 
                Color.FromArgb(255, 255, 255), // #008000 
                Color.FromArgb(0, 128, 128), // #008080 
                Color.FromArgb(255, 255, 255) // #008080 
                });

        private List<Color> nsisColors =
            new List<Color>(new Color[]
             {
                Color.FromArgb(0, 0, 0), // #000000 
                Color.FromArgb(255, 255, 255), // #000000 
                Color.FromArgb(0, 128, 0), // #008000 
                Color.FromArgb(255, 255, 255), // #008000 
                Color.FromArgb(128, 128, 128), // #808080 
                Color.FromArgb(238, 238, 238), // #808080 
                Color.FromArgb(0, 0, 128), // #000080 
                Color.FromArgb(192, 192, 192), // #000080 
                Color.FromArgb(0, 0, 0), // #000000 
                Color.FromArgb(192, 192, 192), // #000000 
                Color.FromArgb(0, 0, 255), // #0000FF 
                Color.FromArgb(255, 255, 255), // #0000FF 
                Color.FromArgb(255, 128, 0), // #FF8000 
                Color.FromArgb(255, 255, 255), // #FF8000 
                Color.FromArgb(255, 0, 0), // #FF0000 
                Color.FromArgb(255, 255, 128), // #FF0000 
                Color.FromArgb(253, 255, 236), // #FDFFEC 
                Color.FromArgb(255, 128, 255), // #FDFFEC 
                Color.FromArgb(0, 0, 255), // #0000FF 
                Color.FromArgb(255, 255, 255), // #0000FF 
                Color.FromArgb(0, 0, 0), // #000000 
                Color.FromArgb(255, 255, 255), // #000000 
                Color.FromArgb(128, 128, 64), // #808040 
                Color.FromArgb(255, 255, 255), // #808040 
                Color.FromArgb(128, 0, 0), // #800000 
                Color.FromArgb(255, 255, 255), // #800000 
                Color.FromArgb(255, 128, 0), // #FF8000 
                Color.FromArgb(239, 239, 239), // #FF8000 
                Color.FromArgb(255, 0, 0), // #FF0000 
                Color.FromArgb(255, 255, 255), // #FF0000 
                Color.FromArgb(0, 0, 255), // #0000FF 
                Color.FromArgb(255, 255, 255), // #0000FF 
                Color.FromArgb(0, 0, 255), // #0000FF 
                Color.FromArgb(255, 255, 255), // #0000FF 
                Color.FromArgb(0, 0, 255), // #0000FF 
                Color.FromArgb(255, 255, 255), // #0000FF 
                Color.FromArgb(0, 128, 0), // #008000 
                Color.FromArgb(255, 255, 255), // #008000 
             });

        private List<Color> csColors =
            new List<Color>(new Color[]
             {
                Color.FromArgb(128, 64, 0), // #804000 
                Color.FromArgb(255, 255, 255), // #804000 
                Color.FromArgb(0, 0, 0), // #000000 
                Color.FromArgb(255, 255, 255), // #000000 
                Color.FromArgb(0, 0, 255), // #0000FF 
                Color.FromArgb(255, 255, 255), // #0000FF 
                Color.FromArgb(128, 0, 255), // #8000FF 
                Color.FromArgb(255, 255, 255), // #8000FF 
                Color.FromArgb(255, 128, 0), // #FF8000 
                Color.FromArgb(255, 255, 255), // #FF8000 
                Color.FromArgb(128, 128, 128), // #808080 
                Color.FromArgb(255, 255, 255), // #808080 
                Color.FromArgb(128, 128, 128), // #808080 
                Color.FromArgb(255, 255, 255), // #808080 
                Color.FromArgb(0, 0, 128), // #000080 
                Color.FromArgb(255, 255, 255), // #000080 
                Color.FromArgb(0, 0, 0), // #000000 
                Color.FromArgb(255, 255, 255), // #000000 
                Color.FromArgb(0, 0, 0), // #000000 
                Color.FromArgb(255, 255, 255), // #000000 
                Color.FromArgb(0, 128, 0), // #008000 
                Color.FromArgb(255, 255, 255), // #008000 
                Color.FromArgb(0, 128, 0), // #008000 
                Color.FromArgb(255, 255, 255), // #008000 
                Color.FromArgb(0, 128, 128), // #008080 
                Color.FromArgb(255, 255, 255), // #008080 
                Color.FromArgb(0, 128, 128), // #008080 
                Color.FromArgb(255, 255, 255), // #008080 
                Color.FromArgb(0, 128, 128), // #008080 
                Color.FromArgb(255, 255, 255), // #008080 
                Color.FromArgb(0, 128, 128), // #008080 
                Color.FromArgb(255, 255, 255), // #008080 
                Color.FromArgb(0, 128, 0), // #008000 
                Color.FromArgb(255, 255, 255), // #008000 
                Color.FromArgb(0, 128, 128), // #008080 
                Color.FromArgb(255, 255, 255), // #008080 
             });

        private List<Color> xmlColors =
            new List<Color>(new Color[]
             {
                Color.FromArgb(255, 0, 0), // #FF0000 
                Color.FromArgb(255, 255, 0), // #FF0000 
                Color.FromArgb(255, 0, 0), // #FF0000 
                Color.FromArgb(255, 255, 0), // #FF0000 
                Color.FromArgb(0, 0, 0), // #000000 
                Color.FromArgb(255, 255, 255), // #000000 
                Color.FromArgb(0, 128, 0), // #008000 
                Color.FromArgb(255, 255, 255), // #008000 
                Color.FromArgb(255, 0, 0), // #FF0000 
                Color.FromArgb(255, 255, 255), // #FF0000 
                Color.FromArgb(128, 0, 255), // #8000FF 
                Color.FromArgb(255, 255, 255), // #8000FF 
                Color.FromArgb(128, 0, 255), // #8000FF 
                Color.FromArgb(255, 255, 255), // #8000FF 
                Color.FromArgb(0, 0, 255), // #0000FF 
                Color.FromArgb(255, 255, 255), // #0000FF 
                Color.FromArgb(0, 0, 255), // #0000FF 
                Color.FromArgb(255, 255, 255), // #0000FF 
                Color.FromArgb(0, 0, 255), // #0000FF 
                Color.FromArgb(255, 255, 255), // #0000FF 
                Color.FromArgb(255, 0, 0), // #FF0000 
                Color.FromArgb(255, 255, 255), // #FF0000 
                Color.FromArgb(255, 0, 0), // #FF0000 
                Color.FromArgb(255, 255, 255), // #FF0000 
                Color.FromArgb(0, 0, 0), // #000000 
                Color.FromArgb(166, 202, 240), // #000000 
                Color.FromArgb(255, 128, 0), // #FF8000 
                Color.FromArgb(255, 255, 255), // #FF8000 
                Color.FromArgb(0, 0, 0), // #000000 
                Color.FromArgb(254, 253, 224), // #000000 
             });

        private List<Color> sqlColors = 
            new List<Color>(new Color[]
            {
                Color.FromArgb(0, 0, 255), // #0000FF 
                Color.FromArgb(255, 255, 255), // #0000FF 
                Color.FromArgb(255, 128, 0), // #FF8000 
                Color.FromArgb(255, 255, 255), // #FF8000 
                Color.FromArgb(128, 128, 128), // #808080 
                Color.FromArgb(255, 255, 255), // #808080 
                Color.FromArgb(128, 128, 128), // #808080 
                Color.FromArgb(255, 255, 255), // #808080 
                Color.FromArgb(0, 0, 128), // #000080 
                Color.FromArgb(255, 255, 255), // #000080 
                Color.FromArgb(0, 128, 0), // #008000 
                Color.FromArgb(255, 255, 255), // #008000 
                Color.FromArgb(0, 128, 0), // #008000 
                Color.FromArgb(255, 255, 255), // #008000 
            });

        private List<Color> batchColors = 
            new List<Color>(new Color[]
            {
                Color.FromArgb(0, 0, 0), // #000000 
                Color.FromArgb(255, 255, 255), // #000000 
                Color.FromArgb(0, 128, 0), // #008000 
                Color.FromArgb(255, 255, 255), // #008000 
                Color.FromArgb(0, 0, 255), // #0000FF 
                Color.FromArgb(255, 255, 255), // #0000FF 
                Color.FromArgb(255, 0, 0), // #FF0000 
                Color.FromArgb(255, 255, 128), // #FF0000 
                Color.FromArgb(255, 0, 255), // #FF00FF 
                Color.FromArgb(255, 255, 255), // #FF00FF 
                Color.FromArgb(0, 128, 255), // #0080FF 
                Color.FromArgb(255, 255, 255), // #0080FF 
                Color.FromArgb(255, 128, 0), // #FF8000 
                Color.FromArgb(252, 255, 240), // #FF8000 
                Color.FromArgb(255, 0, 0), // #FF0000 
                Color.FromArgb(255, 255, 255), // #FF0000 
            });

        List<Color> pascalColors = 
            new List<Color>(new Color[]
            {
                Color.FromArgb(128, 128, 128), // #808080 
                Color.FromArgb(255, 255, 255), // #808080 
                Color.FromArgb(0, 0, 0), // #000000 
                Color.FromArgb(255, 255, 255), // #000000 
                Color.FromArgb(0, 128, 0), // #008000 
                Color.FromArgb(255, 255, 255), // #008000 
                Color.FromArgb(0, 128, 0), // #008000 
                Color.FromArgb(255, 255, 255), // #008000 
                Color.FromArgb(0, 128, 128), // #008080 
                Color.FromArgb(255, 255, 255), // #008080 
                Color.FromArgb(128, 64, 0), // #804000 
                Color.FromArgb(255, 255, 255), // #804000 
                Color.FromArgb(128, 64, 0), // #804000 
                Color.FromArgb(255, 255, 255), // #804000 
                Color.FromArgb(255, 128, 0), // #FF8000 
                Color.FromArgb(255, 255, 255), // #FF8000 
                Color.FromArgb(255, 128, 0), // #FF8000 
                Color.FromArgb(255, 255, 255), // #FF8000 
                Color.FromArgb(0, 0, 255), // #0000FF 
                Color.FromArgb(255, 255, 255), // #0000FF 
                Color.FromArgb(128, 128, 128), // #808080 
                Color.FromArgb(255, 255, 255), // #808080 
                Color.FromArgb(128, 128, 128), // #808080 
                Color.FromArgb(255, 255, 255), // #808080 
                Color.FromArgb(0, 0, 128), // #000080 
                Color.FromArgb(255, 255, 255), // #000080 
                Color.FromArgb(0, 0, 0), // #000000 
                Color.FromArgb(255, 255, 255), // #000000 
            });
        #endregion

        #region InteralColorIndexList
        private List<KeyValuePair<int, string>> CsColorIndexes { get; } =
            new List<KeyValuePair<int, string>>
            (
                new KeyValuePair<int, string>[]
                {
                    new KeyValuePair<int, string>(0, "PreprocessorFore"),
                    new KeyValuePair<int, string>(1, "PreprocessorBack"),

                    new KeyValuePair<int, string>(2, "DefaultFore"),
                    new KeyValuePair<int, string>(3, "DefaultBack"),

                    new KeyValuePair<int, string>(4, "WordFore"),
                    new KeyValuePair<int, string>(5, "WordBack"),

                    new KeyValuePair<int, string>(6, "Word2Fore"),
                    new KeyValuePair<int, string>(7, "Word2Back"),

                    new KeyValuePair<int, string>(8, "NumberFore"),
                    new KeyValuePair<int, string>(9, "NumberBack"),

                    new KeyValuePair<int, string>(10, "StringFore"),
                    new KeyValuePair<int, string>(11, "StringBack"),

                    new KeyValuePair<int, string>(12, "CharacterFore"),
                    new KeyValuePair<int, string>(13, "CharacterBack"),

                    new KeyValuePair<int, string>(14, "OperatorFore"),
                    new KeyValuePair<int, string>(15, "OperatorBack"),

                    new KeyValuePair<int, string>(16, "VerbatimFore"),
                    new KeyValuePair<int, string>(17, "VerbatimBack"),

                    new KeyValuePair<int, string>(18, "RegexFore"),
                    new KeyValuePair<int, string>(19, "RegexBack"),

                    new KeyValuePair<int, string>(20, "CommentFore"),
                    new KeyValuePair<int, string>(21, "CommentBack"),

                    new KeyValuePair<int, string>(22, "CommentLineFore"),
                    new KeyValuePair<int, string>(23, "CommentLineBack"),

                    new KeyValuePair<int, string>(24, "CommentDocFore"),
                    new KeyValuePair<int, string>(25, "CommentDocBack"),

                    new KeyValuePair<int, string>(26, "CommentLineDocFore"),
                    new KeyValuePair<int, string>(27, "CommentLineDocBack"),

                    new KeyValuePair<int, string>(28, "CommentDocKeywordFore"),
                    new KeyValuePair<int, string>(29, "CommentDocKeywordBack"),

                    new KeyValuePair<int, string>(30, "CommentDocKeywordErrorFore"),
                    new KeyValuePair<int, string>(31, "CommentDocKeywordErrorBack"),

                    new KeyValuePair<int, string>(32, "PreprocessorCommentFore"),
                    new KeyValuePair<int, string>(33, "PreprocessorCommentBack"),

                    new KeyValuePair<int, string>(34, "PreprocessorCommentDocFore"),
                    new KeyValuePair<int, string>(35, "PreprocessorCommentDocBack"),
                }
            );

        private List<KeyValuePair<int, string>> CppColorIndexes { get; } =
            new List<KeyValuePair<int, string>>
            (
                new KeyValuePair<int, string>[]
                {
                    new KeyValuePair<int, string>(0, "PreprocessorFore"),
                    new KeyValuePair<int, string>(1, "PreprocessorBack"),

                    new KeyValuePair<int, string>(2, "DefaultFore"),
                    new KeyValuePair<int, string>(3, "DefaultBack"),

                    new KeyValuePair<int, string>(4, "WordFore"),
                    new KeyValuePair<int, string>(5, "WordBack"),

                    new KeyValuePair<int, string>(6, "Word2Fore"),
                    new KeyValuePair<int, string>(7, "Word2Back"),

                    new KeyValuePair<int, string>(8, "NumberFore"),
                    new KeyValuePair<int, string>(9, "NumberBack"),

                    new KeyValuePair<int, string>(10, "StringFore"),
                    new KeyValuePair<int, string>(11, "StringBack"),

                    new KeyValuePair<int, string>(12, "CharacterFore"),
                    new KeyValuePair<int, string>(13, "CharacterBack"),

                    new KeyValuePair<int, string>(14, "OperatorFore"),
                    new KeyValuePair<int, string>(15, "OperatorBack"),

                    new KeyValuePair<int, string>(16, "VerbatimFore"),
                    new KeyValuePair<int, string>(17, "VerbatimBack"),

                    new KeyValuePair<int, string>(18, "RegexFore"),
                    new KeyValuePair<int, string>(19, "RegexBack"),

                    new KeyValuePair<int, string>(20, "CommentFore"),
                    new KeyValuePair<int, string>(21, "CommentBack"),

                    new KeyValuePair<int, string>(22, "CommentLineFore"),
                    new KeyValuePair<int, string>(23, "CommentLineBack"),

                    new KeyValuePair<int, string>(24, "CommentDocFore"),
                    new KeyValuePair<int, string>(25, "CommentDocBack"),

                    new KeyValuePair<int, string>(26, "CommentLineDocFore"),
                    new KeyValuePair<int, string>(27, "CommentLineDocBack"),

                    new KeyValuePair<int, string>(28, "CommentDocKeywordFore"),
                    new KeyValuePair<int, string>(29, "CommentDocKeywordBack"),

                    new KeyValuePair<int, string>(30, "CommentDocKeywordErrorFore"),
                    new KeyValuePair<int, string>(31, "CommentDocKeywordErrorBack"),

                    new KeyValuePair<int, string>(32, "PreprocessorCommentFore"),
                    new KeyValuePair<int, string>(33, "PreprocessorCommentBack"),

                    new KeyValuePair<int, string>(34, "PreprocessorCommentDocFore"),
                    new KeyValuePair<int, string>(35, "PreprocessorCommentDocBack"),
                }
            );

        private List<KeyValuePair<int, string>> XmlColorIndexes { get; } =
            new List<KeyValuePair<int, string>>
            (
                new KeyValuePair<int, string>[]
                {
                    new KeyValuePair<int, string>(0, "XmlStartFore"),
                    new KeyValuePair<int, string>(1, "XmlStartBack"),

                    new KeyValuePair<int, string>(2, "XmlEndFore"),
                    new KeyValuePair<int, string>(3, "XmlEndBack"),

                    new KeyValuePair<int, string>(4, "DefaultFore"),
                    new KeyValuePair<int, string>(5, "DefaultBack"),

                    new KeyValuePair<int, string>(6, "CommentFore"),
                    new KeyValuePair<int, string>(7, "CommentBack"),

                    new KeyValuePair<int, string>(8, "NumberFore"),
                    new KeyValuePair<int, string>(9, "NumberBack"),

                    new KeyValuePair<int, string>(10, "DoubleStringFore"),
                    new KeyValuePair<int, string>(11, "DoubleStringBack"),

                    new KeyValuePair<int, string>(12, "SingleStringFore"),
                    new KeyValuePair<int, string>(13, "SingleStringBack"),

                    new KeyValuePair<int, string>(14, "TagFore"),
                    new KeyValuePair<int, string>(15, "TagBack"),

                    new KeyValuePair<int, string>(16, "TagEndFore"),
                    new KeyValuePair<int, string>(17, "TagEndBack"),

                    new KeyValuePair<int, string>(18, "TagUnknownFore"),
                    new KeyValuePair<int, string>(19, "TagUnknownBack"),

                    new KeyValuePair<int, string>(20, "AttributeFore"),
                    new KeyValuePair<int, string>(21, "AttributeBack"),

                    new KeyValuePair<int, string>(22, "AttributeUnknownFore"),
                    new KeyValuePair<int, string>(23, "AttributeUnknownBack"),

                    new KeyValuePair<int, string>(24, "SgmlDefaultFore"),
                    new KeyValuePair<int, string>(25, "SgmlDefaultBack"),

                    new KeyValuePair<int, string>(26, "CDataFore"),
                    new KeyValuePair<int, string>(27, "CDataBack"),

                    new KeyValuePair<int, string>(28, "EntityFore"),
                    new KeyValuePair<int, string>(29, "EntityBack"),
                }
            );

        private List<KeyValuePair<int, string>> NsisColorIndexes { get; } =
            new List<KeyValuePair<int, string>>
            (
                new KeyValuePair<int, string>[]
                {
                    new KeyValuePair<int, string>(0, "DefaultFore"),
                    new KeyValuePair<int, string>(1, "DefaultBack"),

                    new KeyValuePair<int, string>(2, "CommentFore"),
                    new KeyValuePair<int, string>(3, "CommentBack"),

                    new KeyValuePair<int, string>(4, "StringDoubleQuoteFore"),
                    new KeyValuePair<int, string>(5, "StringDoubleQuoteBack"),

                    new KeyValuePair<int, string>(6, "StringLeftQuoteFore"),
                    new KeyValuePair<int, string>(7, "StringLeftQuoteBack"),

                    new KeyValuePair<int, string>(8, "StringRightQuoteFore"),
                    new KeyValuePair<int, string>(9, "StringRightQuoteBack"),

                    new KeyValuePair<int, string>(10, "FunctionFore"),
                    new KeyValuePair<int, string>(11, "FunctionBack"),

                    new KeyValuePair<int, string>(12, "VariableFore"),
                    new KeyValuePair<int, string>(13, "VariableBack"),

                    new KeyValuePair<int, string>(14, "LabelFore"),
                    new KeyValuePair<int, string>(15, "LabelBack"),

                    new KeyValuePair<int, string>(16, "UserDefinedFore"),
                    new KeyValuePair<int, string>(17, "UserDefinedBack"),

                    new KeyValuePair<int, string>(18, "SectionFore"),
                    new KeyValuePair<int, string>(19, "SectionBack"),

                    new KeyValuePair<int, string>(20, "SubSectionFore"),
                    new KeyValuePair<int, string>(21, "SubSectionBack"),

                    new KeyValuePair<int, string>(22, "IfDefineFore"),
                    new KeyValuePair<int, string>(23, "IfDefineBack"),

                    new KeyValuePair<int, string>(24, "MacroFore"),
                    new KeyValuePair<int, string>(25, "MacroBack"),

                    new KeyValuePair<int, string>(26, "StringVarFore"),
                    new KeyValuePair<int, string>(27, "StringVarBack"),

                    new KeyValuePair<int, string>(28, "NumberFore"),
                    new KeyValuePair<int, string>(29, "NumberBack"),

                    new KeyValuePair<int, string>(30, "SectionGroupFore"),
                    new KeyValuePair<int, string>(31, "SectionGroupBack"),

                    new KeyValuePair<int, string>(32, "PageExFore"),
                    new KeyValuePair<int, string>(33, "PageExBack"),

                    new KeyValuePair<int, string>(34, "FunctionDefinitionsFore"),
                    new KeyValuePair<int, string>(35, "FunctionDefinitionsBack"),

                    new KeyValuePair<int, string>(36, "CommentFore"),
                    new KeyValuePair<int, string>(37, "CommentBack"),
                }
            );

        private List<KeyValuePair<int, string>> SqlColorIndexes { get; } =
            new List<KeyValuePair<int, string>>
            (
                new KeyValuePair<int, string>[]
                {
                    new KeyValuePair<int, string>(0, "WordFore"),
                    new KeyValuePair<int, string>(1, "WordBack"),

                    new KeyValuePair<int, string>(2, "NumberFore"),
                    new KeyValuePair<int, string>(3, "NumberBack"),

                    new KeyValuePair<int, string>(4, "StringFore"),
                    new KeyValuePair<int, string>(5, "StringBack"),

                    new KeyValuePair<int, string>(6, "CharacterFore"),
                    new KeyValuePair<int, string>(7, "CharacterBack"),

                    new KeyValuePair<int, string>(8, "OperatorFore"),
                    new KeyValuePair<int, string>(9, "OperatorBack"),

                    new KeyValuePair<int, string>(10, "CommentFore"),
                    new KeyValuePair<int, string>(11, "CommentBack"),

                    new KeyValuePair<int, string>(12, "CommentLineFore"),
                    new KeyValuePair<int, string>(13, "CommentLineBack"),
                }
            );

        private List<KeyValuePair<int, string>> BatchColorIndexes { get; } =
            new List<KeyValuePair<int, string>>
            (
                new KeyValuePair<int, string>[]
                {
                    new KeyValuePair<int, string>(0, "DefaultFore"),
                    new KeyValuePair<int, string>(1, "DefaultBack"),

                    new KeyValuePair<int, string>(2, "CommentFore"),
                    new KeyValuePair<int, string>(3, "CommentBack"),

                    new KeyValuePair<int, string>(4, "WordFore"),
                    new KeyValuePair<int, string>(5, "WordBack"),

                    new KeyValuePair<int, string>(6, "LabelFore"),
                    new KeyValuePair<int, string>(7, "LabelBack"),

                    new KeyValuePair<int, string>(8, "HideFore"),
                    new KeyValuePair<int, string>(9, "HideBack"),

                    new KeyValuePair<int, string>(10, "CommandFore"),
                    new KeyValuePair<int, string>(11, "CommandBack"),

                    new KeyValuePair<int, string>(12, "IdentifierFore"),
                    new KeyValuePair<int, string>(13, "IdentifierBack"),

                    new KeyValuePair<int, string>(14, "OperatorFore"),
                    new KeyValuePair<int, string>(15, "OperatorBack"),
                }
            );

        private List<KeyValuePair<int, string>> PascalColorIndexes { get; } =
            new List<KeyValuePair<int, string>>
            (
                new KeyValuePair<int, string>[]
                {
                    new KeyValuePair<int, string>(0, "DefaultFore"),
                    new KeyValuePair<int, string>(1, "DefaultBack"),

                    new KeyValuePair<int, string>(2, "IdentifierFore"),
                    new KeyValuePair<int, string>(3, "IdentifierBack"),

                    new KeyValuePair<int, string>(4, "CommentFore"),
                    new KeyValuePair<int, string>(5, "CommentBack"),

                    new KeyValuePair<int, string>(6, "Comment2Fore"),
                    new KeyValuePair<int, string>(7, "Comment2Back"),

                    new KeyValuePair<int, string>(8, "CommentLineFore"),
                    new KeyValuePair<int, string>(9, "CommentLineBack"),

                    new KeyValuePair<int, string>(10, "PreprocessorFore"),
                    new KeyValuePair<int, string>(11, "PreprocessorBack"),

                    new KeyValuePair<int, string>(12, "Preprocessor2Fore"),
                    new KeyValuePair<int, string>(13, "Preprocessor2Back"),

                    new KeyValuePair<int, string>(14, "NumberFore"),
                    new KeyValuePair<int, string>(15, "NumberBack"),

                    new KeyValuePair<int, string>(16, "HexNumberFore"),
                    new KeyValuePair<int, string>(17, "HexNumberBack"),

                    new KeyValuePair<int, string>(18, "WordFore"),
                    new KeyValuePair<int, string>(19, "WordBack"),

                    new KeyValuePair<int, string>(20, "StringFore"),
                    new KeyValuePair<int, string>(21, "StringBack"),

                    new KeyValuePair<int, string>(22, "CharacterFore"),
                    new KeyValuePair<int, string>(23, "CharacterBack"),

                    new KeyValuePair<int, string>(24, "OperatorFore"),
                    new KeyValuePair<int, string>(25, "OperatorBack"),

                    new KeyValuePair<int, string>(26, "ForeColorFore"),
                    new KeyValuePair<int, string>(27, "ForeColorBack"),
                }
            );
        #endregion

        /// <summary>
        /// Saves a lexer color definition to a XML file.
        /// </summary>
        /// <param name="fileName">Name of the file where to save the lexer's color definitions.</param>
        /// <param name="lexerType">Type of the lexer.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public bool DescribeLexerColors(string fileName, LexerType lexerType)
        {
            try
            {
                DescribeLexerColors(lexerType).Save(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Saves a lexer color definition to a XDocument class instance.
        /// </summary>
        /// <param name="lexerType">Type of the lexer.</param>
        /// <returns>An instance to a XDocument class containing the color definitions.</returns>
        public XDocument DescribeLexerColors(LexerType lexerType)
        {
            // create an element for color value entries..
            XElement entryElement = new XElement("Colors", new XAttribute("Lexer", lexerType.ToString()));

            foreach (string colorName in GetColorNames(lexerType))
            {
                // add a color element to the container element..
                entryElement.Add(new XElement("Color",
                    new XAttribute("Name", colorName),
                    new XAttribute("R", this[lexerType, colorName].R.ToString("X2")), // the R component of the color..
                    new XAttribute("G", this[lexerType, colorName].R.ToString("X2")), // the G component of the color..
                    new XAttribute("B", this[lexerType, colorName].R.ToString("X2")), // the B component of the color..
                    new XAttribute("A", this[lexerType, colorName].R.ToString("X2")), // the A component of the color..
                    new XAttribute("HexARGB", this[lexerType, colorName].ToArgb().ToString("X8")))); // The color as ARGB hex string..
            }

            // create a XDocument for the color definitions..
            XDocument document = new XDocument(
                new XDeclaration("1.0", "utf-8", ""),
                entryElement);

            // return the created document..
            return document;
        }

        /// <summary>
        /// Loads the lexer's color definition from a XDocument class instance.
        /// </summary>
        /// <param name="document">The document containing the lexer's color definitions.</param>
        /// <param name="lexerType">Type of the lexer.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public bool LoadDescribedLexerColorsFromXml(XDocument document, LexerType lexerType)
        {
            try
            {
                // loop through the color definition elements..
                foreach (XElement element in document.Root.Elements("Color"))
                {
                    // assign the color for lexer..
                    this[lexerType, element.Attribute("Name").Value] =
                        Color.FromArgb(int.Parse(element.Attribute("HexARGB").Value, NumberStyles.HexNumber));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Loads the lexer's color definition from a XML file.
        /// </summary>
        /// <param name="fileName">Name of the file from where to load the lexer's color definitions.</param>
        /// <param name="lexerType">Type of the lexer.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public bool LoadDescribedLexerColorsFromXml(string fileName, LexerType lexerType)
        {
            if (File.Exists(fileName)) // the file must exist..
            {
                try
                {
                    // try to load the color definitions..
                    XDocument document = XDocument.Load(fileName);
                    return LoadDescribedLexerColorsFromXml(document, lexerType);
                }
                catch
                {
                    // an error occurred so return false..
                    return false;
                }
            }
            else
            {
                // the file wasn't found..
                return false;
            }
        }

        /// <summary>
        /// Gets the index of the color by name.
        /// </summary>
        /// <param name="name">The name of the color.</param>
        /// <param name="lexerType">Type of the lexer.</param>
        /// <returns>An index >= 0 if successful; otherwise -1.</returns>
        public int GetColorIndexByName(string name, LexerType lexerType)
        {
            if (lexerType == LexerType.Cs)
            {
                int idx = CsColorIndexes.FindIndex(f => f.Value == name);
                return idx;
            }
            else if (lexerType == LexerType.Cpp)
            {
                int idx = CppColorIndexes.FindIndex(f => f.Value == name);
                return idx;
            }
            else if (lexerType == LexerType.Xml)
            {
                int idx = XmlColorIndexes.FindIndex(f => f.Value == name);
                return idx;
            }
            else if (lexerType == LexerType.Nsis)
            {
                int idx = NsisColorIndexes.FindIndex(f => f.Value == name);
                return idx;
            }
            else if (lexerType == LexerType.SQL)
            {
                int idx = SqlColorIndexes.FindIndex(f => f.Value == name);
                return idx;
            }
            else if (lexerType == LexerType.SQL)
            {
                int idx = BatchColorIndexes.FindIndex(f => f.Value == name);
                return idx;
            }
            else if (lexerType == LexerType.Batch)
            {
                int idx = BatchColorIndexes.FindIndex(f => f.Value == name);
                return idx;
            }
            else if (lexerType == LexerType.Pascal)
            {
                int idx = PascalColorIndexes.FindIndex(f => f.Value == name);
                return idx;
            }
            return -1;
        }

        /// <summary>
        /// Gets the color names for a given lexer type.
        /// </summary>
        /// <param name="lexerType">Type of the lexer.</param>
        /// <returns>A collection of color names of the given lexer type if successful; otherwise an empty collection is returned.</returns>
        public IEnumerable<string> GetColorNames(LexerType lexerType)
        {
            if (lexerType == LexerType.Cs)
            {
                return CsColorIndexes.Select(f => f.Value);
            }
            else if (lexerType == LexerType.Cpp)
            {
                return CppColorIndexes.Select(f => f.Value);
            }
            else if (lexerType == LexerType.Xml)
            {
                return XmlColorIndexes.Select(f => f.Value);
            }
            else if (lexerType == LexerType.Nsis)
            {
                return NsisColorIndexes.Select(f => f.Value);
            }
            else if (lexerType == LexerType.SQL)
            {
                return SqlColorIndexes.Select(f => f.Value);
            }
            else if (lexerType == LexerType.Batch)
            {
                return BatchColorIndexes.Select(f => f.Value);
            }
            else if (lexerType == LexerType.Pascal)
            {
                return PascalColorIndexes.Select(f => f.Value);
            }

            return new List<string>();
        }
    }

    /// <summary>
    /// A class for setting a lexer for a Scintilla class instance.
    /// </summary>
    public static class ScintillaLexers
    {
        /// <summary>
        /// File extensions for XML files.
        /// </summary>
        public static readonly string XmlExtensions = ".xml .xaml .xsl .xslt .xsd .xul .kml .svg .mxml .xsml .wsdl .xlf .xliff .xbl .sxbl .sitemap .gml .gpx .plist";

        /// <summary>
        /// File extensions for C# files.
        /// </summary>
        public const string CsExtensions = ".cs";

        /// <summary>
        /// File extensions for C++ files.
        /// </summary>
        public const string CppExtensions = ".h .hpp .hxx .cpp .cxx .cc .ino";

        /// <summary>
        /// File extensions for SQL files.
        /// </summary>
        public const string SQLExtensions = ".sql .sql_script";

        /// <summary>
        /// File extensions for a batch file.
        /// </summary>
        public const string BatchExtensions = ".bat .cmd .btm .nt";

        /// <summary>
        /// File extensions for plain text files.
        /// </summary>
        public const string TxtExtensions = ".txt";

        /// <summary>
        /// File extensions for the NSIS (Nullsoft Scriptable Install System).
        /// </summary>
        public const string NsisExtensions = ".nsi .nsh";

        /// <summary>
        /// File extensions for the Pascal programming language.
        /// </summary>
        public const string PascalExtensions = ".pas";

        /// <summary>
        /// Gets or sets the value of a LexerColors class instance.
        /// </summary>
        public static LexerColors LexerColors { get; private set; } = new LexerColors();

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

            extensions = SQLExtensions.Split(' ');
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

            return LexerType.Unknown;
        }

        /// <summary>
        /// Resets the Scintilla's style to default.
        /// </summary>
        /// <param name="scintilla">A Scintilla which style to reset.</param>
        private static void ClearStyle(Scintilla scintilla)
        {
            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Default].Font = "Consolas";
            scintilla.Styles[Style.Default].Size = 10;
            scintilla.StyleClearAll();
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
                ClearStyle(scintilla);

                // PREPROCESSOR, fontStyle = 0
                scintilla.Styles[Style.Cpp.Preprocessor].ForeColor = LexerColors[LexerType.Cs, "PreprocessorFore"];
                scintilla.Styles[Style.Cpp.Preprocessor].BackColor = LexerColors[LexerType.Cs, "PreprocessorBack"];

                // DEFAULT, fontStyle = 0
                scintilla.Styles[Style.Cpp.Default].ForeColor = LexerColors[LexerType.Cs, "DefaultFore"];
                scintilla.Styles[Style.Cpp.Default].BackColor = LexerColors[LexerType.Cs, "DefaultBack"];

                // INSTRUCTION WORD, fontStyle = 1
                scintilla.Styles[Style.Cpp.Word].ForeColor = LexerColors[LexerType.Cs, "WordFore"];
                scintilla.Styles[Style.Cpp.Word].BackColor = LexerColors[LexerType.Cs, "WordBack"];

                // TYPE WORD, fontStyle = 0
                scintilla.Styles[Style.Cpp.Word2].ForeColor = LexerColors[LexerType.Cs, "Word2Fore"];
                scintilla.Styles[Style.Cpp.Word2].BackColor = LexerColors[LexerType.Cs, "Word2Back"];

                // NUMBER, fontStyle = 0
                scintilla.Styles[Style.Cpp.Number].ForeColor = LexerColors[LexerType.Cs, "NumberFore"];
                scintilla.Styles[Style.Cpp.Number].BackColor = LexerColors[LexerType.Cs, "NumberBack"];

                // STRING, fontStyle = 0
                scintilla.Styles[Style.Cpp.String].ForeColor = LexerColors[LexerType.Cs, "StringFore"];
                scintilla.Styles[Style.Cpp.String].BackColor = LexerColors[LexerType.Cs, "StringBack"];

                // CHARACTER, fontStyle = 0
                scintilla.Styles[Style.Cpp.Character].ForeColor = LexerColors[LexerType.Cs, "CharacterFore"];
                scintilla.Styles[Style.Cpp.Character].BackColor = LexerColors[LexerType.Cs, "CharacterBack"];

                // OPERATOR, fontStyle = 1
                scintilla.Styles[Style.Cpp.Operator].ForeColor = LexerColors[LexerType.Cs, "OperatorFore"];
                scintilla.Styles[Style.Cpp.Operator].BackColor = LexerColors[LexerType.Cs, "OperatorBack"];

                // VERBATIM, fontStyle = 0
                scintilla.Styles[Style.Cpp.Verbatim].ForeColor = LexerColors[LexerType.Cs, "VerbatimFore"];
                scintilla.Styles[Style.Cpp.Verbatim].BackColor = LexerColors[LexerType.Cs, "VerbatimBack"];

                // REGEX, fontStyle = 1
                scintilla.Styles[Style.Cpp.Regex].ForeColor = LexerColors[LexerType.Cs, "RegexFore"];
                scintilla.Styles[Style.Cpp.Regex].BackColor = LexerColors[LexerType.Cs, "RegexBack"];

                // COMMENT, fontStyle = 0
                scintilla.Styles[Style.Cpp.Comment].ForeColor = LexerColors[LexerType.Cs, "CommentFore"];
                scintilla.Styles[Style.Cpp.Comment].BackColor = LexerColors[LexerType.Cs, "CommentBack"];

                // COMMENT LINE, fontStyle = 0
                scintilla.Styles[Style.Cpp.CommentLine].ForeColor = LexerColors[LexerType.Cs, "CommentLineFore"];
                scintilla.Styles[Style.Cpp.CommentLine].BackColor = LexerColors[LexerType.Cs, "CommentLineBack"];

                // COMMENT DOC, fontStyle = 0
                scintilla.Styles[Style.Cpp.CommentDoc].ForeColor = LexerColors[LexerType.Cs, "CommentDocFore"];
                scintilla.Styles[Style.Cpp.CommentDoc].BackColor = LexerColors[LexerType.Cs, "CommentDocBack"];

                // COMMENT LINE DOC, fontStyle = 0
                scintilla.Styles[Style.Cpp.CommentLineDoc].ForeColor = LexerColors[LexerType.Cs, "CommentLineDocFore"];
                scintilla.Styles[Style.Cpp.CommentLineDoc].BackColor = LexerColors[LexerType.Cs, "CommentLineDocBack"];

                // COMMENT DOC KEYWORD, fontStyle = 1
                scintilla.Styles[Style.Cpp.CommentDocKeyword].ForeColor = LexerColors[LexerType.Cs, "CommentDocKeywordFore"];
                scintilla.Styles[Style.Cpp.CommentDocKeyword].BackColor = LexerColors[LexerType.Cs, "CommentDocKeywordBack"];

                // COMMENT DOC KEYWORD ERROR, fontStyle = 0
                scintilla.Styles[Style.Cpp.CommentDocKeywordError].ForeColor = LexerColors[LexerType.Cs, "CommentDocKeywordErrorFore"];
                scintilla.Styles[Style.Cpp.CommentDocKeywordError].BackColor = LexerColors[LexerType.Cs, "CommentDocKeywordErrorBack"];

                // PREPROCESSOR COMMENT, fontStyle = 0
                scintilla.Styles[Style.Cpp.PreprocessorComment].ForeColor = LexerColors[LexerType.Cs, "PreprocessorCommentFore"];
                scintilla.Styles[Style.Cpp.PreprocessorComment].BackColor = LexerColors[LexerType.Cs, "PreprocessorCommentBack"];

                // PREPROCESSOR COMMENT DOC, fontStyle = 0
                scintilla.Styles[Style.Cpp.PreprocessorCommentDoc].ForeColor = LexerColors[LexerType.Cs, "PreprocessorCommentDocFore"];
                scintilla.Styles[Style.Cpp.PreprocessorCommentDoc].BackColor = LexerColors[LexerType.Cs, "PreprocessorCommentDocBack"];

                scintilla.Lexer = Lexer.Cpp;

                scintilla.SetKeywords(0, "abstract add alias as ascending async await base break case catch checked continue default delegate descending do dynamic else event explicit extern false finally fixed for foreach from get global goto group if implicit in interface internal into is join let lock namespace new null object operator orderby out override params partial private protected public readonly ref remove return sealed select set sizeof stackalloc switch this throw true try typeof unchecked unsafe using value virtual where while yield");
                scintilla.SetKeywords(1, "bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort var void");

                AddFolding(scintilla);

                return true;
            }
            else if (lexerType == LexerType.Xml)
            {
                ClearStyle(scintilla);

                // XMLSTART, fontStyle = 0 
                scintilla.Styles[Style.Xml.XmlStart].ForeColor = LexerColors[LexerType.Xml, "XmlStartFore"];
                scintilla.Styles[Style.Xml.XmlStart].BackColor = LexerColors[LexerType.Xml, "XmlStartBack"];

                // XMLEND, fontStyle = 0 
                scintilla.Styles[Style.Xml.XmlEnd].ForeColor = LexerColors[LexerType.Xml, "XmlEndFore"];
                scintilla.Styles[Style.Xml.XmlEnd].BackColor = LexerColors[LexerType.Xml, "XmlEndBack"];

                // DEFAULT, fontStyle = 1 
                scintilla.Styles[Style.Xml.Default].ForeColor = LexerColors[LexerType.Xml, "DefaultFore"];
                scintilla.Styles[Style.Xml.Default].BackColor = LexerColors[LexerType.Xml, "DefaultBack"];

                // COMMENT, fontStyle = 0 
                scintilla.Styles[Style.Xml.Comment].ForeColor = LexerColors[LexerType.Xml, "CommentFore"];
                scintilla.Styles[Style.Xml.Comment].BackColor = LexerColors[LexerType.Xml, "CommentBack"];

                // NUMBER, fontStyle = 0 
                scintilla.Styles[Style.Xml.Number].ForeColor = LexerColors[LexerType.Xml, "NumberFore"];
                scintilla.Styles[Style.Xml.Number].BackColor = LexerColors[LexerType.Xml, "NumberBack"];

                // DOUBLESTRING, fontStyle = 1 
                scintilla.Styles[Style.Xml.DoubleString].ForeColor = LexerColors[LexerType.Xml, "DoubleStringFore"];
                scintilla.Styles[Style.Xml.DoubleString].BackColor = LexerColors[LexerType.Xml, "DoubleStringBack"];

                // SINGLESTRING, fontStyle = 1 
                scintilla.Styles[Style.Xml.SingleString].ForeColor = LexerColors[LexerType.Xml, "SingleStringFore"];
                scintilla.Styles[Style.Xml.SingleString].BackColor = LexerColors[LexerType.Xml, "SingleStringBack"];

                // TAG, fontStyle = 0 
                scintilla.Styles[Style.Xml.Tag].ForeColor = LexerColors[LexerType.Xml, "TagFore"];
                scintilla.Styles[Style.Xml.Tag].BackColor = LexerColors[LexerType.Xml, "TagBack"];

                // TAGEND, fontStyle = 0 
                scintilla.Styles[Style.Xml.TagEnd].ForeColor = LexerColors[LexerType.Xml, "TagEndFore"];
                scintilla.Styles[Style.Xml.TagEnd].BackColor = LexerColors[LexerType.Xml, "TagEndBack"];

                // TAGUNKNOWN, fontStyle = 0 
                scintilla.Styles[Style.Xml.TagUnknown].ForeColor = LexerColors[LexerType.Xml, "TagUnknownFore"];
                scintilla.Styles[Style.Xml.TagUnknown].BackColor = LexerColors[LexerType.Xml, "TagUnknownBack"];

                // ATTRIBUTE, fontStyle = 0 
                scintilla.Styles[Style.Xml.Attribute].ForeColor = LexerColors[LexerType.Xml, "AttributeFore"];
                scintilla.Styles[Style.Xml.Attribute].BackColor = LexerColors[LexerType.Xml, "AttributeBack"];

                // ATTRIBUTEUNKNOWN, fontStyle = 0 
                scintilla.Styles[Style.Xml.AttributeUnknown].ForeColor = LexerColors[LexerType.Xml, "AttributeUnknownFore"];
                scintilla.Styles[Style.Xml.AttributeUnknown].BackColor = LexerColors[LexerType.Xml, "AttributeUnknownBack"];

                // SGMLDEFAULT, fontStyle = 0 
                scintilla.Styles[21].ForeColor = LexerColors[LexerType.Xml, "SgmlDefaultFore"];
                scintilla.Styles[21].BackColor = LexerColors[LexerType.Xml, "SgmlDefaultBack"];

                // CDATA, fontStyle = 0 
                scintilla.Styles[Style.Xml.CData].ForeColor = LexerColors[LexerType.Xml, "CDataFore"];
                scintilla.Styles[Style.Xml.CData].BackColor = LexerColors[LexerType.Xml, "CDataBack"];

                // ENTITY, fontStyle = 2 
                scintilla.Styles[Style.Xml.Entity].ForeColor = LexerColors[LexerType.Xml, "EntityFore"];
                scintilla.Styles[Style.Xml.Entity].BackColor = LexerColors[LexerType.Xml, "EntityBack"];

                scintilla.Lexer = Lexer.Xml;

                scintilla.SetProperty("fold.html", "1"); // for a XML lexer..
                scintilla.SetProperty("html.tags.case.sensitive", "1"); // for a XML lexer..

                AddFolding(scintilla);
                return true;
            }
            else if (lexerType == LexerType.Cpp)
            {
                ClearStyle(scintilla);

                // PREPROCESSOR, fontStyle = 0 
                scintilla.Styles[Style.Cpp.Preprocessor].ForeColor = LexerColors[LexerType.Cpp, "PreprocessorFore"];
                scintilla.Styles[Style.Cpp.Preprocessor].BackColor = LexerColors[LexerType.Cpp, "PreprocessorBack"];

                // DEFAULT, fontStyle = 0 
                scintilla.Styles[Style.Cpp.Default].ForeColor = LexerColors[LexerType.Cpp, "DefaultFore"];
                scintilla.Styles[Style.Cpp.Default].BackColor = LexerColors[LexerType.Cpp, "DefaultBack"];

                // INSTRUCTION WORD, fontStyle = 1 
                scintilla.Styles[Style.Cpp.Word].ForeColor = LexerColors[LexerType.Cpp, "WordFore"];
                scintilla.Styles[Style.Cpp.Word].BackColor = LexerColors[LexerType.Cpp, "WordBack"];

                // TYPE WORD, fontStyle = 0 
                scintilla.Styles[Style.Cpp.Word2].ForeColor = LexerColors[LexerType.Cpp, "Word2Fore"];
                scintilla.Styles[Style.Cpp.Word2].BackColor = LexerColors[LexerType.Cpp, "Word2Back"];

                // NUMBER, fontStyle = 0 
                scintilla.Styles[Style.Cpp.Number].ForeColor = LexerColors[LexerType.Cpp, "NumberFore"];
                scintilla.Styles[Style.Cpp.Number].BackColor = LexerColors[LexerType.Cpp, "NumberBack"];

                // STRING, fontStyle = 0 
                scintilla.Styles[Style.Cpp.String].ForeColor = LexerColors[LexerType.Cpp, "StringFore"];
                scintilla.Styles[Style.Cpp.String].BackColor = LexerColors[LexerType.Cpp, "StringBack"];

                // CHARACTER, fontStyle = 0 
                scintilla.Styles[Style.Cpp.Character].ForeColor = LexerColors[LexerType.Cpp, "CharacterFore"];
                scintilla.Styles[Style.Cpp.Character].BackColor = LexerColors[LexerType.Cpp, "CharacterBack"];

                // OPERATOR, fontStyle = 1 
                scintilla.Styles[Style.Cpp.Operator].ForeColor = LexerColors[LexerType.Cpp, "OperatorFore"];
                scintilla.Styles[Style.Cpp.Operator].BackColor = LexerColors[LexerType.Cpp, "OperatorBack"];

                // VERBATIM, fontStyle = 0 
                scintilla.Styles[Style.Cpp.Verbatim].ForeColor = LexerColors[LexerType.Cpp, "VerbatimFore"];
                scintilla.Styles[Style.Cpp.Verbatim].BackColor = LexerColors[LexerType.Cpp, "VerbatimBack"];

                // REGEX, fontStyle = 1 
                scintilla.Styles[Style.Cpp.Regex].ForeColor = LexerColors[LexerType.Cpp, "RegexFore"];
                scintilla.Styles[Style.Cpp.Regex].BackColor = LexerColors[LexerType.Cpp, "RegexBack"];

                // COMMENT, fontStyle = 0 
                scintilla.Styles[Style.Cpp.Comment].ForeColor = LexerColors[LexerType.Cpp, "CommentFore"];
                scintilla.Styles[Style.Cpp.Comment].BackColor = LexerColors[LexerType.Cpp, "CommentBack"];

                // COMMENT LINE, fontStyle = 0 
                scintilla.Styles[Style.Cpp.CommentLine].ForeColor = LexerColors[LexerType.Cpp, "CommentLineFore"];
                scintilla.Styles[Style.Cpp.CommentLine].BackColor = LexerColors[LexerType.Cpp, "CommentLineBack"];

                // COMMENT DOC, fontStyle = 0 
                scintilla.Styles[Style.Cpp.CommentDoc].ForeColor = LexerColors[LexerType.Cpp, "CommentDocFore"];
                scintilla.Styles[Style.Cpp.CommentDoc].BackColor = LexerColors[LexerType.Cpp, "CommentDocBack"];

                // COMMENT LINE DOC, fontStyle = 0 
                scintilla.Styles[Style.Cpp.CommentLineDoc].ForeColor = LexerColors[LexerType.Cpp, "CommentLineDocFore"];
                scintilla.Styles[Style.Cpp.CommentLineDoc].BackColor = LexerColors[LexerType.Cpp, "CommentLineDocBack"];

                // COMMENT DOC KEYWORD, fontStyle = 1 
                scintilla.Styles[Style.Cpp.CommentDocKeyword].ForeColor = LexerColors[LexerType.Cpp, "CommentDocKeywordFore"];
                scintilla.Styles[Style.Cpp.CommentDocKeyword].BackColor = LexerColors[LexerType.Cpp, "CommentDocKeywordBack"];

                // COMMENT DOC KEYWORD ERROR, fontStyle = 0 
                scintilla.Styles[Style.Cpp.CommentDocKeywordError].ForeColor = LexerColors[LexerType.Cpp, "CommentDocKeywordErrorFore"];
                scintilla.Styles[Style.Cpp.CommentDocKeywordError].BackColor = LexerColors[LexerType.Cpp, "CommentDocKeywordErrorBack"];

                // PREPROCESSOR COMMENT, fontStyle = 0 
                scintilla.Styles[Style.Cpp.PreprocessorComment].ForeColor = LexerColors[LexerType.Cpp, "PreprocessorCommentFore"];
                scintilla.Styles[Style.Cpp.PreprocessorComment].BackColor = LexerColors[LexerType.Cpp, "PreprocessorCommentBack"];

                // PREPROCESSOR COMMENT DOC, fontStyle = 0 
                scintilla.Styles[Style.Cpp.PreprocessorCommentDoc].ForeColor = LexerColors[LexerType.Cpp, "PreprocessorCommentDocFore"];
                scintilla.Styles[Style.Cpp.PreprocessorCommentDoc].BackColor = LexerColors[LexerType.Cpp, "PreprocessorCommentDocBack"];

                scintilla.Lexer = Lexer.Cpp;

                scintilla.SetKeywords(0, "alignof and and_eq bitand bitor break case catch compl const_cast continue default delete do dynamic_cast else false for goto if namespace new not not_eq nullptr operator or or_eq reinterpret_cast return sizeof static_assert static_cast switch this throw true try typedef typeid using while xor xor_eq NULL");
                scintilla.SetKeywords(1, "alignas asm auto bool char char16_t char32_t class clock_t const constexpr decltype double enum explicit export extern final float friend inline int int8_t int16_t int32_t int64_t int_fast8_t int_fast16_t int_fast32_t int_fast64_t intmax_t intptr_t long mutable noexcept override private protected ptrdiff_t public register short signed size_t ssize_t static struct template thread_local time_t typename uint8_t uint16_t uint32_t uint64_t uint_fast8_t uint_fast16_t uint_fast32_t uint_fast64_t uintmax_t uintptr_t union unsigned virtual void volatile wchar_t");
                scintilla.SetKeywords(2, "a addindex addtogroup anchor arg attention author authors b brief bug c callergraph callgraph category cite class code cond copybrief copydetails copydoc copyright date def defgroup deprecated details diafile dir docbookonly dontinclude dot dotfile e else elseif em endcode endcond enddocbookonly enddot endhtmlonly endif endinternal endlatexonly endlink endmanonly endmsc endparblock endrtfonly endsecreflist enduml endverbatim endxmlonly enum example exception extends f$ f[ f] file fn f{ f} headerfile hidecallergraph hidecallgraph hideinitializer htmlinclude htmlonly idlexcept if ifnot image implements include includelineno ingroup interface internal invariant latexinclude latexonly li line link mainpage manonly memberof msc mscfile n name namespace nosubgrouping note overload p package page par paragraph param parblock post pre private privatesection property protected protectedsection protocol public publicsection pure ref refitem related relatedalso relates relatesalso remark remarks result return returns retval rtfonly sa secreflist section see short showinitializer since skip skipline snippet startuml struct subpage subsection subsubsection tableofcontents test throw throws todo tparam typedef union until var verbatim verbinclude version vhdlflow warning weakgroup xmlonly xrefitem");

                AddFolding(scintilla);

                return true;
            }
            else if (lexerType == LexerType.Text || lexerType == LexerType.Unknown)
            {
                ClearStyle(scintilla);

                scintilla.Lexer = Lexer.Null;
                return true;
            }
            else if (lexerType == LexerType.Nsis)
            {
                ClearStyle(scintilla);

                // NSIS not found..
                #region NSIS_CONSTANTS
                const int SCLEX_NSIS = 43;
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
                scintilla.Styles[SCE_NSIS_DEFAULT].ForeColor = LexerColors[LexerType.Nsis, "DefaultFore"];
                scintilla.Styles[SCE_NSIS_DEFAULT].BackColor = LexerColors[LexerType.Nsis, "DefaultBack"];

                // COMMENTLINE, fontStyle = 0 
                scintilla.Styles[SCE_NSIS_COMMENT].ForeColor = LexerColors[LexerType.Nsis, "CommentFore"];
                scintilla.Styles[SCE_NSIS_COMMENT].BackColor = LexerColors[LexerType.Nsis, "CommentBack"];

                // STRING DOUBLE QUOTE, fontStyle = 0 
                scintilla.Styles[SCE_NSIS_STRINGDQ].ForeColor = LexerColors[LexerType.Nsis, "StringDoubleQuoteFore"];
                scintilla.Styles[SCE_NSIS_STRINGDQ].BackColor = LexerColors[LexerType.Nsis, "StringDoubleQuoteBack"];

                // STRING LEFT QUOTE, fontStyle = 0 
                scintilla.Styles[SCE_NSIS_STRINGLQ].ForeColor = LexerColors[LexerType.Nsis, "StringLeftQuoteFore"];
                scintilla.Styles[SCE_NSIS_STRINGLQ].BackColor = LexerColors[LexerType.Nsis, "StringLeftQuoteBack"];

                // STRING RIGHT QUOTE, fontStyle = 0 
                scintilla.Styles[SCE_NSIS_STRINGRQ].ForeColor = LexerColors[LexerType.Nsis, "StringRightQuoteFore"];
                scintilla.Styles[SCE_NSIS_STRINGRQ].BackColor = LexerColors[LexerType.Nsis, "StringRightQuoteBack"];

                // FUNCTION, fontStyle = 0 
                scintilla.Styles[SCE_NSIS_FUNCTION].ForeColor = LexerColors[LexerType.Nsis, "FunctionFore"];
                scintilla.Styles[SCE_NSIS_FUNCTION].BackColor = LexerColors[LexerType.Nsis, "FunctionBack"];

                // VARIABLE, fontStyle = 0 
                scintilla.Styles[SCE_NSIS_VARIABLE].ForeColor = LexerColors[LexerType.Nsis, "VariableFore"];
                scintilla.Styles[SCE_NSIS_VARIABLE].BackColor = LexerColors[LexerType.Nsis, "VariableBack"];

                // LABEL, fontStyle = 0 
                scintilla.Styles[SCE_NSIS_LABEL].ForeColor = LexerColors[LexerType.Nsis, "LabelFore"];
                scintilla.Styles[SCE_NSIS_LABEL].BackColor = LexerColors[LexerType.Nsis, "LabelBack"];

                // USER DEFINED, fontStyle = 4 
                scintilla.Styles[SCE_NSIS_USERDEFINED].ForeColor = LexerColors[LexerType.Nsis, "UserDefinedFore"];
                scintilla.Styles[SCE_NSIS_USERDEFINED].BackColor = LexerColors[LexerType.Nsis, "UserDefinedBack"];

                // SECTION, fontStyle = 1 
                scintilla.Styles[SCE_NSIS_SECTIONDEF].ForeColor = LexerColors[LexerType.Nsis, "SectionFore"];
                scintilla.Styles[SCE_NSIS_SECTIONDEF].BackColor = LexerColors[LexerType.Nsis, "SectionBack"];

                // SUBSECTION, fontStyle = 1 
                scintilla.Styles[SCE_NSIS_SUBSECTIONDEF].ForeColor = LexerColors[LexerType.Nsis, "SubSectionFore"];
                scintilla.Styles[SCE_NSIS_SUBSECTIONDEF].BackColor = LexerColors[LexerType.Nsis, "SubSectionBack"];

                // IF DEFINE, fontStyle = 0 
                scintilla.Styles[SCE_NSIS_IFDEFINEDEF].ForeColor = LexerColors[LexerType.Nsis, "IfDefineFore"];
                scintilla.Styles[SCE_NSIS_IFDEFINEDEF].BackColor = LexerColors[LexerType.Nsis, "IfDefineBack"];

                // MACRO, fontStyle = 1 
                scintilla.Styles[SCE_NSIS_MACRODEF].ForeColor = LexerColors[LexerType.Nsis, "MacroFore"];
                scintilla.Styles[SCE_NSIS_MACRODEF].BackColor = LexerColors[LexerType.Nsis, "MacroBack"];

                // STRING VAR, fontStyle = 0 
                scintilla.Styles[SCE_NSIS_STRINGVAR].ForeColor = LexerColors[LexerType.Nsis, "StringVarFore"];
                scintilla.Styles[SCE_NSIS_STRINGVAR].BackColor = LexerColors[LexerType.Nsis, "StringVarBack"];

                // NUMBER, fontStyle = 0 
                scintilla.Styles[SCE_NSIS_NUMBER].ForeColor = LexerColors[LexerType.Nsis, "NumberFore"];
                scintilla.Styles[SCE_NSIS_NUMBER].BackColor = LexerColors[LexerType.Nsis, "NumberBack"];

                // SECTION GROUP, fontStyle = 1 
                scintilla.Styles[SCE_NSIS_SECTIONGROUP].ForeColor = LexerColors[LexerType.Nsis, "SectionGroupFore"];
                scintilla.Styles[SCE_NSIS_SECTIONGROUP].BackColor = LexerColors[LexerType.Nsis, "SectionGroupBack"];

                // PAGE EX, fontStyle = 1 
                scintilla.Styles[SCE_NSIS_PAGEEX].ForeColor = LexerColors[LexerType.Nsis, "PageExFore"];
                scintilla.Styles[SCE_NSIS_PAGEEX].BackColor = LexerColors[LexerType.Nsis, "PageExBack"];

                // FUNCTION DEFINITIONS, fontStyle = 1 
                scintilla.Styles[SCE_NSIS_FUNCTIONDEF].ForeColor = LexerColors[LexerType.Nsis, "FunctionDefinitionsFore"];
                scintilla.Styles[SCE_NSIS_FUNCTIONDEF].BackColor = LexerColors[LexerType.Nsis, "FunctionDefinitionsBack"];

                // COMMENT, fontStyle = 0 
                scintilla.Styles[SCE_NSIS_COMMENTBOX].ForeColor = LexerColors[LexerType.Nsis, "CommentFore"];
                scintilla.Styles[SCE_NSIS_COMMENTBOX].BackColor = LexerColors[LexerType.Nsis, "CommentBack"];

                scintilla.Lexer = (Lexer)SCLEX_NSIS;

                // Name: instre1
                scintilla.SetKeywords(0, "Abort AddBrandingImage AddSize AllowRootDirInstall AllowSkipFiles AutoCloseWindow BGFont BGGradient BrandingText BringToFront Call CallInstDLL Caption ChangeUI CheckBitmap ClearErrors CompletedText ComponentText CopyFiles CRCCheck CreateDirectory CreateFont CreateShortCut Delete DeleteINISec DeleteINIStr DeleteRegKey DeleteRegValue DetailPrint DetailsButtonText DirText DirVar DirVerify EnableWindow EnumRegKey EnumRegValue Exch Exec ExecShell ExecWait ExpandEnvStrings File FileBufSize FileClose FileErrorText FileOpen FileRead FileReadByte FileReadUTF16LE FileSeek FileWrite FileWriteByte FileWriteUTF16LE FindClose FindFirst FindNext FindWindow FlushINI Function FunctionEnd GetCurInstType GetCurrentAddress GetDlgItem GetDLLVersion GetDLLVersionLocal GetErrorLevel GetExeName GetExePath GetFileTime GetFileTimeLocal GetFullPathName GetFunctionAddress GetInstDirError GetLabelAddress GetTempFileName Goto HideWindow Icon IfAbort IfErrors IfFileExists IfRebootFlag IfSilent InitPluginsDir InstallButtonText InstallColors InstallDir InstallDirRegKey InstProgressFlags InstType InstTypeGetText InstTypeSetText IntCmp IntCmpU IntFmt IntOp IsWindow LangString LangStringUP LicenseBkColor LicenseData LicenseForceSelection LicenseLangString LicenseText LoadLanguageFile LockWindow LogSet LogText ManifestDPIAware ManifestSupportedOS MessageBox MiscButtonText Nop Name OutFile Page PageEx PageExEnd PluginDir Pop Push Quit ReadEnvStr ReadINIStr ReadRegDWORD ReadRegStr Reboot RegDLL Rename RequestExecutionLevel ReserveFile Return RMDir SearchPath Section SectionEnd SectionGetFlags SectionGetInstTypes SectionGetSize SectionGetText SectionGroup SectionGroupEnd SectionIn SectionSetFlags SectionSetInstTypes SectionSetSize SectionSetText SendMessage SetAutoClose SetBrandingImage SetCompress SetCompressionLevel SetCompressor SetCompressorDictSize SetCtlColors SetCurInstType SetDatablockOptimize SetDateSave SetDetailsPrint SetDetailsView SetErrorLevel SetErrors SetFileAttributes SetFont SetOutPath SetOverwrite SetPluginUnload SetRebootFlag SetRegView SetShellVarContext SetSilent SetStaticBkColor ShowInstDetails ShowUninstDetails ShowWindow SilentInstall SilentUnInstall Sleep SpaceTexts StrCmp StrCmpS StrCpy StrLen SubSection SubSectionEnd Unicode UninstallButtonText UninstallCaption UninstallIcon UninstallSubCaption UninstallText UninstPage UnRegDLL UnsafeStrCpy Var VIAddVersionKey VIFileVersion VIProductVersion WindowIcon WriteINIStr WriteRegBin WriteRegDWORD WriteRegExpandStr WriteRegStr WriteUninstaller XPStyle !AddIncludeDir !AddPluginDir !appendfile !cd !define !delfile !echo !else !endif !error !execute !finalize !getdllversion !if !ifdef !ifmacrodef !ifmacrondef !ifndef !include !insertmacro !macro !macroend !macroundef !packhdr !searchparse !searchreplace !system !tempfile !undef !verbose !warning");
                // Name: instre2
                scintilla.SetKeywords(1, "$0 $1 $2 $3 $4 $5 $6 $7 $8 $9 $R0 $R1 $R2 $R3 $R4 $R5 $R6 $R7 $R8 $R9 $ADMINTOOLS $APPDATA $CDBURN_AREA $CMDLINE $COMMONFILES $COMMONFILES32 $COMMONFILES64 $COOKIES $DESKTOP $DOCUMENTS $EXEDIR $EXEFILE $EXEPATH $FAVORITES $FONTS $HISTORY $HWNDPARENT $INTERNET_CACHE $INSTDIR $LANGUAGE $LOCALAPPDATA $MUSIC $NETHOOD ${NSISDIR} $OUTDIR $PICTURES $PLUGINSDIR $PRINTHOOD $PROFILE $PROGRAMFILES $PROGRAMFILES32 $PROGRAMFILES64 $QUICKLAUNCH $RECENT $RESOURCES $RESOURCES_LOCALIZED $SENDTO $SMPROGRAMS $SMSTARTUP $STARTMENU $SYSDIR $TEMP $TEMPLATES $VIDEOS $WINDIR $$ $\n $\r $\t");
                // Name: type1
                scintilla.SetKeywords(2, "ARCHIVE CUR END FILE_ATTRIBUTE_ARCHIVE FILE_ATTRIBUTE_HIDDEN FILE_ATTRIBUTE_NORMAL FILE_ATTRIBUTE_OFFLINE FILE_ATTRIBUTE_READONLY FILE_ATTRIBUTE_SYSTEM FILE_ATTRIBUTE_TEMPORARY HIDDEN HKCC HKCR HKCU HKDD HKEY_CLASSES_ROOT HKEY_CURRENT_CONFIG HKEY_CURRENT_USER HKEY_DYN_DATA HKEY_LOCAL_MACHINE HKEY_PERFORMANCE_DATA HKEY_USERS HKLM HKPD HKU IDABORT IDCANCEL IDIGNORE IDNO IDOK IDRETRY IDYES MB_ABORTRETRYIGNORE MB_DEFBUTTON1 MB_DEFBUTTON2 MB_DEFBUTTON3 MB_DEFBUTTON4 MB_ICONEXCLAMATION MB_ICONINFORMATION MB_ICONQUESTION MB_ICONSTOP MB_OK MB_OKCANCEL MB_RETRYCANCEL MB_RIGHT MB_SETFOREGROUND MB_TOPMOST MB_USERICON MB_YESNO MB_YESNOCANCEL NORMAL OFFLINE READONLY SET SHCTX SW_HIDE SW_SHOWMAXIMIZED SW_SHOWMINIMIZED SW_SHOWNORMAL SYSTEM TEMPORARY all auto both bottom bzip2 checkbox colored current false force hide ifdiff ifnewer lastused leave left listonly lzma nevershow none normal off on pop push radiobuttons right show silent silentlog smooth textonly top true try zlib");

                AddFolding(scintilla);
                return true;

            }
            else if (lexerType == LexerType.SQL)
            {
                ClearStyle(scintilla);

                // KEYWORD, fontStyle = 1 
                scintilla.Styles[Style.Sql.Word].ForeColor = LexerColors[LexerType.SQL, "WordFore"];
                scintilla.Styles[Style.Sql.Word].BackColor = LexerColors[LexerType.SQL, "WordBack"];

                // NUMBER, fontStyle = 0 
                scintilla.Styles[Style.Sql.Number].ForeColor = LexerColors[LexerType.SQL, "NumberFore"];
                scintilla.Styles[Style.Sql.Number].BackColor = LexerColors[LexerType.SQL, "NumberBack"];

                // STRING, fontStyle = 0 
                scintilla.Styles[Style.Sql.String].ForeColor = LexerColors[LexerType.SQL, "StringFore"];
                scintilla.Styles[Style.Sql.String].BackColor = LexerColors[LexerType.SQL, "StringBack"];

                // STRING2, fontStyle = 0 
                scintilla.Styles[Style.Sql.Character].ForeColor = LexerColors[LexerType.SQL, "CharacterFore"];
                scintilla.Styles[Style.Sql.Character].BackColor = LexerColors[LexerType.SQL, "CharacterBack"];

                // OPERATOR, fontStyle = 1 
                scintilla.Styles[Style.Sql.Operator].ForeColor = LexerColors[LexerType.SQL, "OperatorFore"];
                scintilla.Styles[Style.Sql.Operator].BackColor = LexerColors[LexerType.SQL, "OperatorBack"];

                // COMMENT, fontStyle = 0 
                scintilla.Styles[Style.Sql.Comment].ForeColor = LexerColors[LexerType.SQL, "CommentFore"];
                scintilla.Styles[Style.Sql.Comment].BackColor = LexerColors[LexerType.SQL, "CommentBack"];

                // COMMENT LINE, fontStyle = 0 
                scintilla.Styles[Style.Sql.CommentLine].ForeColor = LexerColors[LexerType.SQL, "CommentLineFore"];
                scintilla.Styles[Style.Sql.CommentLine].BackColor = LexerColors[LexerType.SQL, "CommentLineBack"];

                scintilla.Lexer = Lexer.Sql;

                // Name: instre1
                // self added: autoincrement..
                scintilla.SetKeywords(0, "abs absolute access acos add add_months adddate admin after aggregate all allocate alter and any app_name are array as asc ascii asin assertion at atan atn2 audit authid authorization autonomous_transaction avg before begin benchmark between bfilename bigint bin binary binary_checksum binary_integer bit bit_count bit_and bit_or blob body boolean both breadth bulk by call cascade cascaded case cast catalog ceil ceiling char char_base character charindex chartorowid check checksum checksum_agg chr class clob close cluster coalesce col_length col_name collate collation collect column comment commit completion compress concat concat_ws connect connection constant constraint constraints constructorcreate contains containsable continue conv convert corr corresponding cos cot count count_big covar_pop covar_samp create cross cube cume_dist current current_date current_path current_role current_time current_timestamp current_user currval cursor cycle data datalength databasepropertyex date date_add date_format date_sub dateadd datediff datename datepart datetime day db_id db_name deallocate dec declare decimal decode default deferrable deferred degrees delete dense_rank depth deref desc describe descriptor destroy destructor deterministic diagnostics dictionary disconnect difference distinct do domain double drop dump dynamic each else elsif empth encode encrypt end end-exec equals escape every except exception exclusive exec execute exists exit exp export_set extends external extract false fetch first first_value file float floor file_id file_name filegroup_id filegroup_name filegroupproperty fileproperty for forall foreign format formatmessage found freetexttable from from_days fulltextcatalog fulltextservice function general get get_lock getdate getansinull getutcdate global go goto grant greatest group grouping having heap hex hextoraw host host_id host_name hour ident_incr ident_seed ident_current identified identity if ifnull ignore immediate in increment index index_col indexproperty indicator initcap initial initialize initially inner inout input insert instr instrb int integer interface intersect interval into is is_member is_srvrolemember is_null is_numeric isdate isnull isolation iterate java join key lag language large last last_day last_value lateral lcase lead leading least left len length lengthb less level like limit limited ln lpad local localtime localtimestamp locator lock log log10 long loop lower ltrim make_ref map match max maxextents merge mid min minus minute mlslabel mod mode modifies modify module month months_between names national natural naturaln nchar nclob new new_time newid next next_day nextval no noaudit nocompress nocopy none not nowait null nullif number number_base numeric nvl nvl2 nvarchar object object_id object_name object_property ocirowid oct of off offline old on online only opaque open operator operation option or ord order ordinalityorganization others out outer output package pad parameter parameters partial partition path pctfree percent_rank pi pls_integer positive positiven postfix pow power pragma precision prefix preorder prepare preserve primary prior private privileges procedure public radians raise rand range rank ratio_to_export raw rawtohex read reads real record recursive ref references referencing reftohex relative release release_lock rename repeat replace resource restrict result return returns reverse revoke right rollback rollup round routine row row_number rowid rowidtochar rowlabel rownum rows rowtype rpad rtrim savepoint schema scroll scope search second section seddev_samp select separate sequence session session_user set sets share sign sin sinh size smallint some soundex space specific specifictype sql sqlcode sqlerrm sqlexception sqlstate sqlwarning sqrt start state statement static std stddev stdev_pop strcmp structure subdate substr substrb substring substring_index subtype successful sum synonym sys_context sys_guid sysdate system_user table tan tanh temporary terminate than then time timestamp timezone_abbr timezone_minute timezone_hour timezone_region tinyint to to_char to_date to_days to_number to_single_byte trailing transaction translate translation treat trigger trim true trunc truncate type ucase uid under union unique uniqueidentifier unknown unnest update upper usage use user userenv using validate value values var_pop var_samp varbinary varchar varchar2 variable variance varying view vsize when whenever where with without while work write year zone autoincrement");

                scintilla.SetProperty("fold.sql.at.else", "1"); // for a SQL lexer..
                scintilla.SetProperty("fold.comment", "1"); // for a SQL lexer..
                scintilla.SetProperty("sql.backslash.escapes", "1"); // for a SQL lexer.. (Enables backslash as an escape character in SQL.)
                scintilla.SetProperty("lexer.sql.numbersign.comment", "0"); // for a SQL lexer.. (If lexer.sql.numbersign.comment property is set to 0 a line beginning with '#' will not be a comment.)
                scintilla.SetProperty("lexer.sql.allow.dotted.word", "1"); // for a SQL lexer.. (set to 1 to colourise recognized words with dots (recommended for Oracle PL/SQL objects))

                AddFolding(scintilla);
                return true;
            }
            else if (lexerType == LexerType.Batch)
            {
                ClearStyle(scintilla);

                // DEFAULT, fontStyle = 0 
                scintilla.Styles[Style.Batch.Default].ForeColor = LexerColors[LexerType.Batch, "DefaultFore"];
                scintilla.Styles[Style.Batch.Default].BackColor = LexerColors[LexerType.Batch, "DefaultBack"];

                // COMMENT, fontStyle = 0 
                scintilla.Styles[Style.Batch.Comment].ForeColor = LexerColors[LexerType.Batch, "CommentFore"];
                scintilla.Styles[Style.Batch.Comment].BackColor = LexerColors[LexerType.Batch, "CommentBack"];

                // KEYWORDS, fontStyle = 1 
                scintilla.Styles[Style.Batch.Word].ForeColor = LexerColors[LexerType.Batch, "WordFore"];
                scintilla.Styles[Style.Batch.Word].BackColor = LexerColors[LexerType.Batch, "WordBack"];

                // LABEL, fontStyle = 1 
                scintilla.Styles[Style.Batch.Label].ForeColor = LexerColors[LexerType.Batch, "LabelFore"];
                scintilla.Styles[Style.Batch.Label].BackColor = LexerColors[LexerType.Batch, "LabelBack"];

                // HIDE SYBOL, fontStyle = 0 
                scintilla.Styles[Style.Batch.Hide].ForeColor = LexerColors[LexerType.Batch, "HideFore"];
                scintilla.Styles[Style.Batch.Hide].BackColor = LexerColors[LexerType.Batch, "HideBack"];

                // COMMAND, fontStyle = 0 
                scintilla.Styles[Style.Batch.Command].ForeColor = LexerColors[LexerType.Batch, "CommandFore"];
                scintilla.Styles[Style.Batch.Command].BackColor = LexerColors[LexerType.Batch, "CommandBack"];

                // VARIABLE, fontStyle = 1 
                scintilla.Styles[Style.Batch.Identifier].ForeColor = LexerColors[LexerType.Batch, "IdentifierFore"];
                scintilla.Styles[Style.Batch.Identifier].BackColor = LexerColors[LexerType.Batch, "IdentifierBack"];

                // OPERATOR, fontStyle = 1 
                scintilla.Styles[Style.Batch.Operator].ForeColor = LexerColors[LexerType.Batch, "OperatorFore"];
                scintilla.Styles[Style.Batch.Operator].BackColor = LexerColors[LexerType.Batch, "OperatorBack"];
                scintilla.Lexer = Lexer.Batch;

                // Name: instre1
                scintilla.SetKeywords(0, "assoc aux break call cd chcp chdir choice cls cmdextversion color com com1 com2 com3 com4 con copy country ctty date defined del dir do dpath echo else endlocal erase errorlevel exist exit for ftype goto if in loadfix loadhigh lpt lpt1 lpt2 lpt3 lpt4 md mkdir move not nul path pause popd prn prompt pushd rd rem ren rename rmdir set setlocal shift start time title type ver verify vol");

                AddFolding(scintilla);
                return true;
            }
            else if (lexerType == LexerType.Pascal)
            {
                ClearStyle(scintilla);

                // DEFAULT, fontStyle = 0 
                scintilla.Styles[Style.Pascal.Default].ForeColor = LexerColors[LexerType.Pascal, "DefaultFore"];
                scintilla.Styles[Style.Pascal.Default].BackColor = LexerColors[LexerType.Pascal, "DefaultBack"];

                // IDENTIFIER, fontStyle = 0 
                scintilla.Styles[Style.Pascal.Identifier].ForeColor = LexerColors[LexerType.Pascal, "IdentifierFore"];
                scintilla.Styles[Style.Pascal.Identifier].BackColor = LexerColors[LexerType.Pascal, "IdentifierBack"];

                // COMMENT, fontStyle = 0 
                scintilla.Styles[Style.Pascal.Comment].ForeColor = LexerColors[LexerType.Pascal, "CommentFore"];
                scintilla.Styles[Style.Pascal.Comment].BackColor = LexerColors[LexerType.Pascal, "CommentBack"];

                // COMMENT LINE, fontStyle = 0 
                scintilla.Styles[Style.Pascal.Comment2].ForeColor = LexerColors[LexerType.Pascal, "Comment2Fore"];
                scintilla.Styles[Style.Pascal.Comment2].BackColor = LexerColors[LexerType.Pascal, "Comment2Back"];

                // COMMENT DOC, fontStyle = 0 
                scintilla.Styles[Style.Pascal.CommentLine].ForeColor = LexerColors[LexerType.Pascal, "CommentLineFore"];
                scintilla.Styles[Style.Pascal.CommentLine].BackColor = LexerColors[LexerType.Pascal, "CommentLineBack"];

                // PREPROCESSOR, fontStyle = 0 
                scintilla.Styles[Style.Pascal.Preprocessor].ForeColor = LexerColors[LexerType.Pascal, "PreprocessorFore"];
                scintilla.Styles[Style.Pascal.Preprocessor].BackColor = LexerColors[LexerType.Pascal, "PreprocessorBack"];

                // PREPROCESSOR2, fontStyle = 0 
                scintilla.Styles[Style.Pascal.Preprocessor2].ForeColor = LexerColors[LexerType.Pascal, "Preprocessor2Fore"];
                scintilla.Styles[Style.Pascal.Preprocessor2].BackColor = LexerColors[LexerType.Pascal, "Preprocessor2Back"];

                // NUMBER, fontStyle = 0 
                scintilla.Styles[Style.Pascal.Number].ForeColor = LexerColors[LexerType.Pascal, "NumberFore"];
                scintilla.Styles[Style.Pascal.Number].BackColor = LexerColors[LexerType.Pascal, "NumberBack"];

                // HEX NUMBER, fontStyle = 0 
                scintilla.Styles[Style.Pascal.HexNumber].ForeColor = LexerColors[LexerType.Pascal, "HexNumberFore"];
                scintilla.Styles[Style.Pascal.HexNumber].BackColor = LexerColors[LexerType.Pascal, "HexNumberBack"];

                // INSTRUCTION WORD, fontStyle = 1 
                scintilla.Styles[Style.Pascal.Word].ForeColor = LexerColors[LexerType.Pascal, "WordFore"];
                scintilla.Styles[Style.Pascal.Word].BackColor = LexerColors[LexerType.Pascal, "WordBack"];

                // STRING, fontStyle = 0 
                scintilla.Styles[Style.Pascal.String].ForeColor = LexerColors[LexerType.Pascal, "StringFore"];
                scintilla.Styles[Style.Pascal.String].BackColor = LexerColors[LexerType.Pascal, "StringBack"];

                // CHARACTER, fontStyle = 0 
                scintilla.Styles[Style.Pascal.Character].ForeColor = LexerColors[LexerType.Pascal, "CharacterFore"];
                scintilla.Styles[Style.Pascal.Character].BackColor = LexerColors[LexerType.Pascal, "CharacterBack"];

                // OPERATOR, fontStyle = 1 
                scintilla.Styles[Style.Pascal.Operator].ForeColor = LexerColors[LexerType.Pascal, "OperatorFore"];
                scintilla.Styles[Style.Pascal.Operator].BackColor = LexerColors[LexerType.Pascal, "OperatorBack"];

                // ASM, fontStyle = 1 
                scintilla.Styles[Style.Pascal.Asm].ForeColor = LexerColors[LexerType.Pascal, "ForeColorFore"];
                scintilla.Styles[Style.Pascal.Asm].BackColor = LexerColors[LexerType.Pascal, "ForeColorBack"];
                scintilla.Lexer = Lexer.Pascal;

                // Name: instre1
                scintilla.SetKeywords(0, "and array asm begin case cdecl class const constructor default destructor div do downto else end end. except exit exports external far file finalization finally for function goto if implementation in index inherited initialization inline interface label library message mod near nil not object of on or out overload override packed pascal private procedure program property protected public published raise read record register repeat resourcestring safecall set shl shr stdcall stored string then threadvar to try type unit until uses var virtual while with write xor");

                AddFolding(scintilla);
                return true;
            }
            else // a lexer wasn't found..
            {
                return false;
            }
        }

        /// <summary>
        /// Adds a "standard" folding to a lexer.
        /// </summary>
        /// <param name="scintilla">An instance to a Scintilla class.</param>
        private static void AddFolding(Scintilla scintilla)
        {
            // the default colors as in the example.. (C)::https://github.com/jacobslusser/ScintillaNET/wiki/Automatic-Code-Folding
            AddFolding(scintilla, SystemColors.ControlLightLight, SystemColors.ControlDark);
        }

        /// <summary>
        /// Adds a "standard" folding to a lexer with given foreground and background colors.
        /// </summary>
        /// <param name="scintilla">An instance to a Scintilla class.</param>
        /// <param name="foregroundColor">The foreground color to be used.</param>
        /// <param name="backgroundColor">The background color to be used.</param>
        private static void AddFolding(Scintilla scintilla, Color foregroundColor, Color backgroundColor)
        {
            // the default colors as in the example.. (C)::https://github.com/jacobslusser/ScintillaNET/wiki/Automatic-Code-Folding

            // Instruct the lexer to calculate folding
            scintilla.SetProperty("fold", "1");
            scintilla.SetProperty("fold.compact", "1");
            scintilla.SetProperty("fold.preprocessor", "1");

            // Configure a margin to display folding symbols
            scintilla.Margins[2].Type = MarginType.Symbol;
            scintilla.Margins[2].Mask = Marker.MaskFolders;
            scintilla.Margins[2].Sensitive = true;
            scintilla.Margins[2].Width = 20;


            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                scintilla.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                scintilla.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Configure folding markers with respective symbols
            scintilla.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scintilla.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            scintilla.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }
    }
}
