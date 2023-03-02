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
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace VPKSoft.ScintillaLexers.LexerColors;

/// <summary>
/// A class containing the colors for the lexers.
/// </summary>
public class LexerColors
{
    /// <summary>
    /// Gets or sets the colors for a given LexerType enumeration.
    /// </summary>
    /// <param name="lexerType">The type of the lexer.</param>
    /// <returns>A list of color belonging to a specific lexer.</returns>
    /// <exception cref="ArgumentOutOfRangeException">value</exception>
    public List<Tuple<Color, string, bool>> this[LexerType lexerType]
    {
        get
        {
            if (lexerType == LexerType.Cpp)
            {
                return cppColors;
            }

            if (lexerType == LexerType.Nsis)
            {
                return nsisColors;
            }

            if (lexerType == LexerType.InnoSetup)
            {
                return innoSetupColors;
            }

            if (lexerType == LexerType.Cs)
            {
                return csColors;
            }

            if (lexerType == LexerType.Xml)
            {
                return xmlColors;
            }

            if (lexerType == LexerType.SQL)
            {
                return sqlColors;
            }

            if (lexerType == LexerType.Batch)
            {
                return batchColors;
            }

            if (lexerType == LexerType.Pascal)
            {
                return pascalColors;
            }

            if (lexerType == LexerType.PHP)
            {
                return phpColors;
            }

            if (lexerType == LexerType.HTML)
            {
                return htmlColors;
            }

            if (lexerType == LexerType.WindowsPowerShell)
            {
                return powerShellColors;
            }

            if (lexerType == LexerType.INI)
            {
                return iniColors;
            }

            if (lexerType == LexerType.Python)
            {
                return pythonColors;
            }

            if (lexerType == LexerType.YAML)
            {
                return yamlColors;
            }

            if (lexerType == LexerType.Java)
            {
                return javaColors;
            }

            if (lexerType == LexerType.JavaScript)
            {
                return javascriptColors;
            }

            if (lexerType == LexerType.Css)
            {
                return cssColors;
            }

            if (lexerType == LexerType.VbDotNet)
            {
                return vbDotNetColors;
            }

            if (lexerType == LexerType.Json)
            {
                return jsonColors;
            }

            return new List<Tuple<Color, string, bool>>();
        }

        set
        {
            if (lexerType == LexerType.Cpp)
            {
                if (value == null || value.Count != cppColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                cppColors = value;
            }
            else if (lexerType == LexerType.Nsis)
            {
                if (value == null || value.Count != nsisColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                nsisColors = value;
            }
            else if (lexerType == LexerType.InnoSetup)
            {
                if (value == null || value.Count != innoSetupColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                innoSetupColors = value;
            }
            else if (lexerType == LexerType.Cs)
            {
                if (value == null || value.Count != csColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                csColors = value;
            }
            else if (lexerType == LexerType.Xml)
            {
                if (value == null || value.Count != xmlColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                xmlColors = value;
            }
            else if (lexerType == LexerType.SQL)
            {
                if (value == null || value.Count != sqlColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                sqlColors = value;
            }
            else if (lexerType == LexerType.Batch)
            {
                if (value == null || value.Count != batchColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                batchColors = value;
            }
            else if (lexerType == LexerType.Pascal)
            {
                if (value == null || value.Count != pascalColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                pascalColors = value;
            }
            else if (lexerType == LexerType.PHP)
            {
                if (value == null || value.Count != phpColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                phpColors = value;
            }
            else if (lexerType == LexerType.HTML)
            {
                if (value == null || value.Count != htmlColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                htmlColors = value;
            }
            else if (lexerType == LexerType.WindowsPowerShell)
            {
                if (value == null || value.Count != powerShellColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                powerShellColors = value;
            }
            else if (lexerType == LexerType.INI)
            {
                if (value == null || value.Count != iniColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                iniColors = value;
            }
            else if (lexerType == LexerType.Python)
            {
                if (value == null || value.Count != pythonColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                pythonColors = value;
            }
            else if (lexerType == LexerType.YAML)
            {
                if (value == null || value.Count != yamlColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                yamlColors = value;
            }
            else if (lexerType == LexerType.Java)
            {
                if (value == null || value.Count != javaColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                javaColors = value;
            }
            else if (lexerType == LexerType.JavaScript)
            {
                if (value == null || value.Count != javascriptColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                javascriptColors = value;
            }
            else if (lexerType == LexerType.Css)
            {
                if (value == null || value.Count != cssColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                cssColors = value;
            }
            else if (lexerType == LexerType.VbDotNet)
            {
                if (value == null || value.Count != vbDotNetColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                vbDotNetColors = value;
            }
            else if (lexerType == LexerType.Json)
            {
                if (value == null || value.Count != jsonColors.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                jsonColors = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the color uses by the SciTE color name and a value indicating whether a foreground or a background color is requested.
    /// <note type="note">URL: https://www.scintilla.org/SciTE.html</note>
    /// </summary>
    /// <param name="lexerType">The type of the lexer.</param>
    /// <param name="colorName">The name of the color in the SciTE.</param>
    /// <param name="isForeground">A flag indicating whether a foreground or a background color is requested.</param>
    /// <returns>A color with the specified lexer, a specified SciTE name and a flag indicating whether the color in question is a background or a foreground color.</returns>
    /// <exception cref="ArgumentOutOfRangeException">value</exception>
    public Color this[LexerType lexerType, string colorName, bool isForeground]
    {
        get => this[lexerType][GetColorIndexBySciTEName(colorName, lexerType, isForeground)].Item1;

        set
        {
            try
            {
                var tuple = this[lexerType][GetColorIndexBySciTEName(colorName, lexerType, isForeground)];
                this[lexerType][GetColorIndexBySciTEName(colorName, lexerType, isForeground)] =
                    Tuple.Create(value, tuple.Item2, tuple.Item3);
            }
            catch
            {
                throw new ArgumentOutOfRangeException(nameof(value));
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
        get => this[lexerType][GetColorIndexByName(colorName, lexerType)].Item1;

        set
        {
            try
            {
                this[lexerType][GetColorIndexByName(colorName, lexerType)] =
                    Tuple.Create(value, this[lexerType][GetColorIndexByName(colorName, lexerType)].Item2, this[lexerType][GetColorIndexByName(colorName, lexerType)].Item3);
            }
            catch
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
        }
    }

    #region InternalColorList
    private List<Tuple<Color, string, bool>> cppColors = new List<Tuple<Color, string, bool>>(new[]
    {
        Tuple.Create(Color.FromArgb(128, 64, 0), "PREPROCESSOR", true), // #804000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "PREPROCESSOR", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "DEFAULT", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "INSTRUCTION WORD", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "INSTRUCTION WORD", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 0, 255), "TYPE WORD", true), // #8000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "TYPE WORD", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 128, 0), "NUMBER", true), // #FF8000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "NUMBER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "STRING", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "STRING", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "CHARACTER", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "CHARACTER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 128), "OPERATOR", true), // #000080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "OPERATOR", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "VERBATIM", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "VERBATIM", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "REGEX", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "REGEX", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT LINE", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT LINE", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT DOC", true), // #008080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT DOC", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT LINE DOC", true), // #008080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT LINE DOC", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT DOC KEYWORD", true), // #008080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT DOC KEYWORD", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT DOC KEYWORD ERROR", true), // #008080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT DOC KEYWORD ERROR", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "PREPROCESSOR COMMENT", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "PREPROCESSOR COMMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 128), "PREPROCESSOR COMMENT DOC", true), // #008080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "PREPROCESSOR COMMENT DOC", false) // #FFFFFF 
    });

    private List<Tuple<Color, string, bool>> nsisColors = new List<Tuple<Color, string, bool>>(new[]
    {
        Tuple.Create(Color.FromArgb(0, 0, 0), "DEFAULT", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENTLINE", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENTLINE", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "STRING DOUBLE QUOTE", true), // #808080 
        Tuple.Create(Color.FromArgb(238, 238, 238), "STRING DOUBLE QUOTE", false), // #EEEEEE 
        Tuple.Create(Color.FromArgb(0, 0, 128), "STRING LEFT QUOTE", true), // #000080 
        Tuple.Create(Color.FromArgb(192, 192, 192), "STRING LEFT QUOTE", false), // #C0C0C0 
        Tuple.Create(Color.FromArgb(0, 0, 0), "STRING RIGHT QUOTE", true), // #000000 
        Tuple.Create(Color.FromArgb(192, 192, 192), "STRING RIGHT QUOTE", false), // #C0C0C0 
        Tuple.Create(Color.FromArgb(0, 0, 255), "FUNCTION", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "FUNCTION", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 128, 0), "VARIABLE", true), // #FF8000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "VARIABLE", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 0, 0), "LABEL", true), // #FF0000 
        Tuple.Create(Color.FromArgb(255, 255, 128), "LABEL", false), // #FFFF80 
        Tuple.Create(Color.FromArgb(253, 255, 236), "USER DEFINED", true), // #FDFFEC 
        Tuple.Create(Color.FromArgb(255, 128, 255), "USER DEFINED", false), // #FF80FF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "SECTION", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "SECTION", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "SUBSECTION", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "SUBSECTION", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 64), "IF DEFINE", true), // #808040 
        Tuple.Create(Color.FromArgb(255, 255, 255), "IF DEFINE", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 0, 0), "MACRO", true), // #800000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "MACRO", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 128, 0), "STRING VAR", true), // #FF8000 
        Tuple.Create(Color.FromArgb(239, 239, 239), "STRING VAR", false), // #EFEFEF 
        Tuple.Create(Color.FromArgb(255, 0, 0), "NUMBER", true), // #FF0000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "NUMBER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "SECTION GROUP", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "SECTION GROUP", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "PAGE EX", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "PAGE EX", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "FUNCTION DEFINITIONS", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "FUNCTION DEFINITIONS", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT", false) // #FFFFFF 
    });

    private List<Tuple<Color, string, bool>> innoSetupColors = new List<Tuple<Color, string, bool>>(new[]
    {
        Tuple.Create(Color.FromArgb(128, 128, 128), "DEFAULT", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "IDENTIFIER", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "IDENTIFIER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT LINE", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT LINE", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT DOC", true), // #008080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT DOC", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 64, 0), "PREPROCESSOR", true), // #804000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "PREPROCESSOR", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 64, 0), "PREPROCESSOR2", true), // #804000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "PREPROCESSOR2", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 128, 0), "NUMBER", true), // #FF8000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "NUMBER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 128, 0), "HEX NUMBER", true), // #FF8000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "HEX NUMBER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "INSTRUCTION WORD", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "INSTRUCTION WORD", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "STRING", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "STRING", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "CHARACTER", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "CHARACTER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 128), "OPERATOR", true), // #000080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "OPERATOR", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "ASM", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "ASM", false) // #FFFFFF 
    });

    private List<Tuple<Color, string, bool>> csColors = new List<Tuple<Color, string, bool>>(new[]
    {
        Tuple.Create(Color.FromArgb(128, 64, 0), "PREPROCESSOR", true), // #804000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "PREPROCESSOR", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "DEFAULT", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "INSTRUCTION WORD", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "INSTRUCTION WORD", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 0, 255), "TYPE WORD", true), // #8000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "TYPE WORD", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 128, 0), "NUMBER", true), // #FF8000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "NUMBER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "STRING", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "STRING", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "CHARACTER", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "CHARACTER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 128), "OPERATOR", true), // #000080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "OPERATOR", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "VERBATIM", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "VERBATIM", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "REGEX", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "REGEX", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT LINE", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT LINE", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT DOC", true), // #008080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT DOC", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT LINE DOC", true), // #008080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT LINE DOC", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT DOC KEYWORD", true), // #008080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT DOC KEYWORD", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT DOC KEYWORD ERROR", true), // #008080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT DOC KEYWORD ERROR", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "PREPROCESSOR COMMENT", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "PREPROCESSOR COMMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 128), "PREPROCESSOR COMMENT DOC", true), // #008080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "PREPROCESSOR COMMENT DOC", false) // #FFFFFF 
    });

    private List<Tuple<Color, string, bool>> xmlColors = new List<Tuple<Color, string, bool>>(new[]
    {
        Tuple.Create(Color.FromArgb(255, 0, 0), "XMLSTART", true), // #FF0000 
        Tuple.Create(Color.FromArgb(255, 255, 0), "XMLSTART", false), // #FFFF00 
        Tuple.Create(Color.FromArgb(255, 0, 0), "XMLEND", true), // #FF0000 
        Tuple.Create(Color.FromArgb(255, 255, 0), "XMLEND", false), // #FFFF00 
        Tuple.Create(Color.FromArgb(0, 0, 0), "DEFAULT", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 0, 0), "NUMBER", true), // #FF0000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "NUMBER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 0, 255), "DOUBLESTRING", true), // #8000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DOUBLESTRING", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 0, 255), "SINGLESTRING", true), // #8000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "SINGLESTRING", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "TAG", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "TAG", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "TAGEND", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "TAGEND", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "TAGUNKNOWN", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "TAGUNKNOWN", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 0, 0), "ATTRIBUTE", true), // #FF0000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "ATTRIBUTE", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 0, 0), "ATTRIBUTEUNKNOWN", true), // #FF0000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "ATTRIBUTEUNKNOWN", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "SGMLDEFAULT", true), // #000000 
        Tuple.Create(Color.FromArgb(166, 202, 240), "SGMLDEFAULT", false), // #A6CAF0 
        Tuple.Create(Color.FromArgb(255, 128, 0), "CDATA", true), // #FF8000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "CDATA", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "ENTITY", true), // #000000 
        Tuple.Create(Color.FromArgb(254, 253, 224), "ENTITY", false) // #FEFDE0 
    });

    private List<Tuple<Color, string, bool>> sqlColors = new List<Tuple<Color, string, bool>>(new[]
    {
        Tuple.Create(Color.FromArgb(0, 0, 255), "KEYWORD", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "KEYWORD", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 128, 0), "NUMBER", true), // #FF8000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "NUMBER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "STRING", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "STRING", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "STRING2", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "STRING2", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 128), "OPERATOR", true), // #000080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "OPERATOR", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT LINE", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT LINE", false) // #FFFFFF 
    });

    private List<Tuple<Color, string, bool>> batchColors = new List<Tuple<Color, string, bool>>(new[]
    {
        Tuple.Create(Color.FromArgb(0, 0, 0), "DEFAULT", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "KEYWORDS", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "KEYWORDS", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 0, 0), "LABEL", true), // #FF0000 
        Tuple.Create(Color.FromArgb(255, 255, 128), "LABEL", false), // #FFFF80 
        Tuple.Create(Color.FromArgb(255, 0, 255), "HIDE SYBOL", true), // #FF00FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "HIDE SYBOL", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 255), "COMMAND", true), // #0080FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMAND", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 128, 0), "VARIABLE", true), // #FF8000 
        Tuple.Create(Color.FromArgb(252, 255, 240), "VARIABLE", false), // #FCFFF0 
        Tuple.Create(Color.FromArgb(255, 0, 0), "OPERATOR", true), // #FF0000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "OPERATOR", false) // #FFFFFF 
    });

    private List<Tuple<Color, string, bool>> pascalColors = new List<Tuple<Color, string, bool>>(new[]
    {
        Tuple.Create(Color.FromArgb(128, 128, 128), "DEFAULT", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "IDENTIFIER", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "IDENTIFIER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT LINE", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT LINE", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT DOC", true), // #008080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT DOC", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 64, 0), "PREPROCESSOR", true), // #804000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "PREPROCESSOR", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 64, 0), "PREPROCESSOR2", true), // #804000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "PREPROCESSOR2", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 128, 0), "NUMBER", true), // #FF8000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "NUMBER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 128, 0), "HEX NUMBER", true), // #FF8000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "HEX NUMBER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "INSTRUCTION WORD", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "INSTRUCTION WORD", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "STRING", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "STRING", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "CHARACTER", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "CHARACTER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 128), "OPERATOR", true), // #000080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "OPERATOR", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "ASM", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "ASM", false) // #FFFFFF 
    });

    private List<Tuple<Color, string, bool>> phpColors = new List<Tuple<Color, string, bool>>(new[]
    {
        Tuple.Create(Color.FromArgb(255, 0, 0), "QUESTION MARK", true), // #FF0000 
        Tuple.Create(Color.FromArgb(253, 248, 227), "QUESTION MARK", false), // #FDF8E3 
        Tuple.Create(Color.FromArgb(0, 0, 0), "DEFAULT", true), // #000000 
        Tuple.Create(Color.FromArgb(254, 252, 245), "DEFAULT", false), // #FEFCF5 
        Tuple.Create(Color.FromArgb(128, 128, 128), "STRING", true), // #808080 
        Tuple.Create(Color.FromArgb(254, 252, 245), "STRING", false), // #FEFCF5 
        Tuple.Create(Color.FromArgb(128, 128, 128), "STRING VARIABLE", true), // #808080 
        Tuple.Create(Color.FromArgb(254, 252, 245), "STRING VARIABLE", false), // #FEFCF5 
        Tuple.Create(Color.FromArgb(128, 128, 128), "SIMPLESTRING", true), // #808080 
        Tuple.Create(Color.FromArgb(254, 252, 245), "SIMPLESTRING", false), // #FEFCF5 
        Tuple.Create(Color.FromArgb(0, 0, 255), "WORD", true), // #0000FF 
        Tuple.Create(Color.FromArgb(254, 252, 245), "WORD", false), // #FEFCF5 
        Tuple.Create(Color.FromArgb(255, 128, 0), "NUMBER", true), // #FF8000 
        Tuple.Create(Color.FromArgb(254, 252, 245), "NUMBER", false), // #FEFCF5 
        Tuple.Create(Color.FromArgb(0, 0, 128), "VARIABLE", true), // #000080 
        Tuple.Create(Color.FromArgb(254, 252, 245), "VARIABLE", false), // #FEFCF5 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
        Tuple.Create(Color.FromArgb(254, 252, 245), "COMMENT", false), // #FEFCF5 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENTLINE", true), // #008000 
        Tuple.Create(Color.FromArgb(254, 252, 245), "COMMENTLINE", false), // #FEFCF5 
        Tuple.Create(Color.FromArgb(128, 0, 255), "OPERATOR", true), // #8000FF 
        Tuple.Create(Color.FromArgb(254, 252, 245), "OPERATOR", false) // #FEFCF5 
    });

    private List<Tuple<Color, string, bool>> htmlColors = new List<Tuple<Color, string, bool>>(new[]
    {
        Tuple.Create(Color.FromArgb(0, 0, 0), "DEFAULT", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 0, 0), "NUMBER", true), // #FF0000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "NUMBER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 0, 255), "DOUBLESTRING", true), // #8000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DOUBLESTRING", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 0, 255), "SINGLESTRING", true), // #8000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "SINGLESTRING", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "TAG", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "TAG", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "TAGEND", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "TAGEND", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "TAGUNKNOWN", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "TAGUNKNOWN", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 0, 0), "ATTRIBUTE", true), // #FF0000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "ATTRIBUTE", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "ATTRIBUTEUNKNOWN", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "ATTRIBUTEUNKNOWN", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "SGMLDEFAULT", true), // #000000 
        Tuple.Create(Color.FromArgb(166, 202, 240), "SGMLDEFAULT", false), // #A6CAF0 
        Tuple.Create(Color.FromArgb(255, 128, 0), "CDATA", true), // #FF8000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "CDATA", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 128, 0), "VALUE", true), // #FF8000 
        Tuple.Create(Color.FromArgb(254, 253, 224), "VALUE", false), // #FEFDE0 
        Tuple.Create(Color.FromArgb(0, 0, 0), "ENTITY", true), // #000000 
        Tuple.Create(Color.FromArgb(254, 253, 224), "ENTITY", false) // #FEFDE0 
    });

    private List<Tuple<Color, string, bool>> powerShellColors = new List<Tuple<Color, string, bool>>(new[]
    {
        Tuple.Create(Color.FromArgb(0, 0, 0), "DEFAULT", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "STRING", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "STRING", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "CHARACTER", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "CHARACTER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 128, 0), "NUMBER", true), // #FF8000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "NUMBER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "VARIABLE", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "VARIABLE", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 128), "OPERATOR", true), // #000080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "OPERATOR", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "INSTRUCTION WORD", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "INSTRUCTION WORD", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 0, 255), "CMDLET", true), // #8000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "CMDLET", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 255), "ALIAS", true), // #0080FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "ALIAS", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT STREAM", true), // #008080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT STREAM", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "HERE STRING", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "HERE STRING", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "HERE CHARACTER", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "HERE CHARACTER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT DOC KEYWORD", true), // #008080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT DOC KEYWORD", false) // #FFFFFF 
    });


    private List<Tuple<Color, string, bool>> iniColors = new List<Tuple<Color, string, bool>>(new[]
    {
        Tuple.Create(Color.FromArgb(0, 0, 0), "DEFAULT", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 0, 255), "SECTION", true), // #8000FF 
        Tuple.Create(Color.FromArgb(242, 244, 255), "SECTION", false), // #F2F4FF 
        Tuple.Create(Color.FromArgb(255, 0, 0), "ASSIGNMENT", true), // #FF0000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "ASSIGNMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 0, 0), "DEFVAL", true), // #FF0000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DEFVAL", false) // #FFFFFF 
    });

    private List<Tuple<Color, string, bool>> pythonColors = new List<Tuple<Color, string, bool>>(new[]
    {
        Tuple.Create(Color.FromArgb(0, 0, 0), "DEFAULT", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENTLINE", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENTLINE", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 0, 0), "NUMBER", true), // #FF0000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "NUMBER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "STRING", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "STRING", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "CHARACTER", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "CHARACTER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "KEYWORDS", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "KEYWORDS", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 128, 0), "TRIPLE", true), // #FF8000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "TRIPLE", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 128, 0), "TRIPLEDOUBLE", true), // #FF8000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "TRIPLEDOUBLE", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "CLASSNAME", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "CLASSNAME", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 0, 255), "DEFNAME", true), // #FF00FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DEFNAME", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 128), "OPERATOR", true), // #000080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "OPERATOR", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0), "IDENTIFIER", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "IDENTIFIER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENTBLOCK", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENTBLOCK", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 128, 0), "DECORATOR", true), // #FF8000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DECORATOR", false) // #FFFFFF 
    });

    private List<Tuple<Color, string, bool>> yamlColors = new List<Tuple<Color, string, bool>>(new[]
    {
        Tuple.Create(Color.FromArgb(0, 0, 0), "DEFAULT", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 128), "IDENTIFIER", true), // #000080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "IDENTIFIER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "INSTRUCTION WORD", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "INSTRUCTION WORD", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 128, 64), "NUMBER", true), // #FF8040 
        Tuple.Create(Color.FromArgb(255, 255, 255), "NUMBER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 64, 0), "REFERENCE", true), // #804000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "REFERENCE", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 255), "DOCUMENT", true), // #0000FF 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DOCUMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(128, 128, 128), "TEXT", true), // #808080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "TEXT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(255, 0, 0), "ERROR", true), // #FF0000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "ERROR", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 128), "OPERATOR", true), // #000080 
        Tuple.Create(Color.FromArgb(255, 255, 255), "OPERATOR", false) // #FFFFFF 
    });

    private List<Tuple<Color, string, bool>> javaColors = new List<Tuple<Color, string, bool>>(
        new[]
        {
            Tuple.Create(Color.FromArgb(128, 64, 0), "PREPROCESSOR", true), // #804000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "PREPROCESSOR", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 0), "DEFAULT", true), // #000000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 255), "INSTRUCTION WORD", true), // #0000FF 
            Tuple.Create(Color.FromArgb(255, 255, 255), "INSTRUCTION WORD", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(128, 0, 255), "TYPE WORD", true), // #8000FF 
            Tuple.Create(Color.FromArgb(255, 255, 255), "TYPE WORD", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(255, 128, 0), "NUMBER", true), // #FF8000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "NUMBER", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(128, 128, 128), "STRING", true), // #808080 
            Tuple.Create(Color.FromArgb(255, 255, 255), "STRING", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(128, 128, 128), "CHARACTER", true), // #808080 
            Tuple.Create(Color.FromArgb(255, 255, 255), "CHARACTER", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 128), "OPERATOR", true), // #000080 
            Tuple.Create(Color.FromArgb(255, 255, 255), "OPERATOR", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 0), "VERBATIM", true), // #000000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "VERBATIM", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 0), "REGEX", true), // #000000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "REGEX", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT LINE", true), // #008000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT LINE", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT DOC", true), // #008080 
            Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT DOC", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT LINE DOC", true), // #008080 
            Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT LINE DOC", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT DOC KEYWORD", true), // #008080 
            Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT DOC KEYWORD", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT DOC KEYWORD ERROR", true), // #008080 
            Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT DOC KEYWORD ERROR", false) // #FFFFFF 
        });

    private List<Tuple<Color, string, bool>> javascriptColors = new List<Tuple<Color, string, bool>>(
        new[]
        {
            Tuple.Create(Color.FromArgb(0, 0, 0), "DEFAULT", true), // #000000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 255), "INSTRUCTION WORD", true), // #0000FF 
            Tuple.Create(Color.FromArgb(255, 255, 255), "INSTRUCTION WORD", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(128, 0, 255), "TYPE WORD", true), // #8000FF 
            Tuple.Create(Color.FromArgb(255, 255, 255), "TYPE WORD", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(128, 64, 0), "WINDOW INSTRUCTION", true), // #804000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "WINDOW INSTRUCTION", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(255, 128, 0), "NUMBER", true), // #FF8000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "NUMBER", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(128, 128, 128), "STRING", true), // #808080 
            Tuple.Create(Color.FromArgb(255, 255, 255), "STRING", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 128), "STRINGRAW", true), // #000080 
            Tuple.Create(Color.FromArgb(192, 192, 192), "STRINGRAW", false), // #C0C0C0 
            Tuple.Create(Color.FromArgb(128, 128, 128), "CHARACTER", true), // #808080 
            Tuple.Create(Color.FromArgb(255, 255, 255), "CHARACTER", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 128), "OPERATOR", true), // #000080 
            Tuple.Create(Color.FromArgb(255, 255, 255), "OPERATOR", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 0), "VERBATIM", true), // #000000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "VERBATIM", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 0), "REGEX", true), // #000000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "REGEX", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT LINE", true), // #008000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT LINE", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT DOC", true), // #008080 
            Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT DOC", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT LINE DOC", true), // #008080 
            Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT LINE DOC", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT DOC KEYWORD", true), // #008080 
            Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT DOC KEYWORD", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 128, 128), "COMMENT DOC KEYWORD ERROR", true), // #008080 
            Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT DOC KEYWORD ERROR", false) // #FFFFFF 
        });

    private List<Tuple<Color, string, bool>> cssColors = new List<Tuple<Color, string, bool>>(
        new[]
        {
            Tuple.Create(Color.FromArgb(0, 0, 0), "DEFAULT", true), // #000000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 255), "TAG", true), // #0000FF 
            Tuple.Create(Color.FromArgb(255, 255, 255), "TAG", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(255, 0, 0), "CLASS", true), // #FF0000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "CLASS", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(255, 128, 0), "PSEUDOCLASS", true), // #FF8000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "PSEUDOCLASS", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(255, 128, 128), "UNKNOWN_PSEUDOCLASS", true), // #FF8080 
            Tuple.Create(Color.FromArgb(255, 255, 255), "UNKNOWN_PSEUDOCLASS", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 0), "OPERATOR", true), // #000000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "OPERATOR", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(128, 128, 192), "IDENTIFIER", true), // #8080C0 
            Tuple.Create(Color.FromArgb(255, 255, 255), "IDENTIFIER", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 0), "UNKNOWN_IDENTIFIER", true), // #000000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "UNKNOWN_IDENTIFIER", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 0), "VALUE", true), // #000000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "VALUE", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 128, 255), "ID", true), // #0080FF 
            Tuple.Create(Color.FromArgb(255, 255, 255), "ID", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(255, 0, 0), "IMPORTANT", true), // #FF0000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "IMPORTANT", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 128, 255), "DIRECTIVE", true), // #0080FF 
            Tuple.Create(Color.FromArgb(255, 255, 255), "DIRECTIVE", false) // #FFFFFF 
        });

    private List<Tuple<Color, string, bool>> vbDotNetColors = new List<Tuple<Color, string, bool>>(
        new[]
        {
            Tuple.Create(Color.FromArgb(0, 0, 0), "DEFAULT", true), // #000000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 128, 0), "COMMENT", true), // #008000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "COMMENT", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(255, 0, 0), "NUMBER", true), // #FF0000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "NUMBER", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 255), "WORD", true), // #0000FF 
            Tuple.Create(Color.FromArgb(255, 255, 255), "WORD", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 255), "WORD2", true), // #0000FF 
            Tuple.Create(Color.FromArgb(255, 255, 255), "WORD2", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(128, 128, 128), "STRING", true), // #808080 
            Tuple.Create(Color.FromArgb(255, 255, 255), "STRING", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(255, 0, 0), "PREPROCESSOR", true), // #FF0000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "PREPROCESSOR", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 0, 0), "OPERATOR", true), // #000000 
            Tuple.Create(Color.FromArgb(255, 255, 255), "OPERATOR", false), // #FFFFFF 
            Tuple.Create(Color.FromArgb(0, 255, 0), "DATE", true), // #00FF00 
            Tuple.Create(Color.FromArgb(255, 255, 255), "DATE", false), // #FFFFFF 
        });

    List<Tuple<Color, string, bool>> jsonColors = new List<Tuple<Color, string, bool>>(new Tuple<Color, string, bool>[] 
    { 
        Tuple.Create(Color.FromArgb(0, 0, 0), "DEFAULT", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "DEFAULT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0xFF, 0x80, 0), "NUMBER", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "NUMBER", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0x80, 0x80, 0x80), "STRING", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "STRING", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0x80, 0x80, 0x80), "UNCLOSED STRING", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "UNCLOSED STRING", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0x88, 0x0A, 0xE8), "PROPERTY NAME", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "PROPERTY NAME", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0xA5, 0x2A, 0x2A), "ESCAPE SEQUENCE", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "ESCAPE SEQUENCE", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0x80, 0), "LINE COMMENT", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "LINE COMMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0x80, 0), "BLOCK COMMENT", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "BLOCK COMMENT", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0x80, 0, 0xFF), "OPERATOR", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "OPERATOR", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0xC7, 0x15, 0x85), "URI", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "URI", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0xD9, 0x22, 0x99), "JSON-LD COMPACT IRI", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "JSON-LD COMPACT IRI", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0x80), "JSON KEYWORD", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "JSON KEYWORD", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0, 0x89), "JSON-LD KEYWORD", true), // #000000 
        Tuple.Create(Color.FromArgb(255, 255, 255), "JSON-LD KEYWORD", false), // #FFFFFF 
        Tuple.Create(Color.FromArgb(0, 0x8B, 0x8B), "PARSING ERROR", true), // #000000 
        Tuple.Create(Color.FromArgb(0xFF, 0X45, 255), "PARSING ERROR", false), // #FFFFFF 
    });
    #endregion

    #region InteralColorIndexList
    private List<KeyValuePair<int, string>> CsColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
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
                new KeyValuePair<int, string>(35, "PreprocessorCommentDocBack")
            }
        );

    private List<KeyValuePair<int, string>> CppColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
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
                new KeyValuePair<int, string>(35, "PreprocessorCommentDocBack")
            }
        );

    private List<KeyValuePair<int, string>> XmlColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
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
                new KeyValuePair<int, string>(29, "EntityBack")
            }
        );

    private List<KeyValuePair<int, string>> YamlColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
            {
                new KeyValuePair<int, string>(0, "DefaultFore"),
                new KeyValuePair<int, string>(1, "DefaultBack"),

                new KeyValuePair<int, string>(2, "IdentifierFore"),
                new KeyValuePair<int, string>(3, "IdentifierBack"),

                new KeyValuePair<int, string>(4, "CommentFore"),
                new KeyValuePair<int, string>(5, "CommentBack"),

                new KeyValuePair<int, string>(6, "InstructionWordFore"),
                new KeyValuePair<int, string>(7, "InstructionWordBack"),

                new KeyValuePair<int, string>(8, "NumberFore"),
                new KeyValuePair<int, string>(9, "NumberBack"),

                new KeyValuePair<int, string>(10, "ReferenceFore"),
                new KeyValuePair<int, string>(11, "ReferenceBack"),

                new KeyValuePair<int, string>(12, "DocumentFore"),
                new KeyValuePair<int, string>(13, "DocumentBack"),

                new KeyValuePair<int, string>(14, "TextFore"),
                new KeyValuePair<int, string>(15, "TextBack"),

                new KeyValuePair<int, string>(16, "ErrorFore"),
                new KeyValuePair<int, string>(17, "ErrortBack")
            });


    private List<KeyValuePair<int, string>> NsisColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
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
                new KeyValuePair<int, string>(37, "CommentBack")
            }
        );

    private List<KeyValuePair<int, string>> InnoSetupColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
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
                new KeyValuePair<int, string>(27, "ForeColorBack")
            }
        );

    private List<KeyValuePair<int, string>> SqlColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
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
                new KeyValuePair<int, string>(13, "CommentLineBack")
            }
        );

    private List<KeyValuePair<int, string>> BatchColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
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
                new KeyValuePair<int, string>(15, "OperatorBack")
            }
        );

    private List<KeyValuePair<int, string>> PascalColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
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
                new KeyValuePair<int, string>(27, "ForeColorBack")
            }
        );

    private List<KeyValuePair<int, string>> PhpColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
            {
                new KeyValuePair<int, string>(0, "HQuestionFore"),
                new KeyValuePair<int, string>(1, "HQuestionBack"),

                new KeyValuePair<int, string>(2, "DefaultFore"),
                new KeyValuePair<int, string>(3, "DefaultBack"),

                new KeyValuePair<int, string>(4, "HStringFore"),
                new KeyValuePair<int, string>(5, "HStringBack"),

                new KeyValuePair<int, string>(6, "HStringVariableFore"),
                new KeyValuePair<int, string>(7, "HStringVariableBack"),

                new KeyValuePair<int, string>(8, "SimpleStringFore"),
                new KeyValuePair<int, string>(9, "SimpleStringBack"),

                new KeyValuePair<int, string>(10, "WordFore"),
                new KeyValuePair<int, string>(11, "WordBack"),

                new KeyValuePair<int, string>(12, "NumberFore"),
                new KeyValuePair<int, string>(13, "NumberBack"),

                new KeyValuePair<int, string>(14, "VariableFore"),
                new KeyValuePair<int, string>(15, "VariableBack"),

                new KeyValuePair<int, string>(16, "CommentFore"),
                new KeyValuePair<int, string>(17, "CommentBack"),

                new KeyValuePair<int, string>(18, "CommentLineFore"),
                new KeyValuePair<int, string>(19, "CommentLineBack"),

                new KeyValuePair<int, string>(20, "OperatorFore"),
                new KeyValuePair<int, string>(21, "OperatorBack")
            }
        );

    private List<KeyValuePair<int, string>> HtmlColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
            {
                new KeyValuePair<int, string>(0, "DefaultFore"),
                new KeyValuePair<int, string>(1, "DefaultBack"),

                new KeyValuePair<int, string>(2, "CommentFore"),
                new KeyValuePair<int, string>(3, "CommentBack"),

                new KeyValuePair<int, string>(4, "NumberFore"),
                new KeyValuePair<int, string>(5, "NumberBack"),

                new KeyValuePair<int, string>(6, "DoubleStringFore"),
                new KeyValuePair<int, string>(7, "DoubleStringBack"),

                new KeyValuePair<int, string>(8, "SingleStringFore"),
                new KeyValuePair<int, string>(9, "SingleStringBack"),

                new KeyValuePair<int, string>(10, "TagFore"),
                new KeyValuePair<int, string>(11, "TagBack"),

                new KeyValuePair<int, string>(12, "TagEndFore"),
                new KeyValuePair<int, string>(13, "TagEndBack"),

                new KeyValuePair<int, string>(14, "TagUnknownFore"),
                new KeyValuePair<int, string>(15, "TagUnknownBack"),

                new KeyValuePair<int, string>(16, "AttributeFore"),
                new KeyValuePair<int, string>(17, "AttributeBack"),

                new KeyValuePair<int, string>(18, "AttributeUnknownFore"),
                new KeyValuePair<int, string>(19, "AttributeUnknownBack"),

                new KeyValuePair<int, string>(20, "SGMDefaultFore"),
                new KeyValuePair<int, string>(21, "SGMDefaultBack"),

                new KeyValuePair<int, string>(22, "CDataFore"),
                new KeyValuePair<int, string>(23, "CDataBack"),

                new KeyValuePair<int, string>(24, "ValueFore"),
                new KeyValuePair<int, string>(25, "ValueBack"),

                new KeyValuePair<int, string>(26, "EntityFore"),
                new KeyValuePair<int, string>(27, "EntityBack"),

                new KeyValuePair<int, string>(28, "HQuestionFore"),
                new KeyValuePair<int, string>(29, "HQuestionBack")

            });

    private List<KeyValuePair<int, string>> PowerShellColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
            {
                new KeyValuePair<int, string>(0, "DefaultFore"),
                new KeyValuePair<int, string>(1, "DefaultBack"),

                new KeyValuePair<int, string>(2, "CommentFore"),
                new KeyValuePair<int, string>(3, "CommentBack"),

                new KeyValuePair<int, string>(4, "StringFore"),
                new KeyValuePair<int, string>(5, "StringBack"),

                new KeyValuePair<int, string>(6, "CharacterFore"),
                new KeyValuePair<int, string>(7, "CharacterBack"),

                new KeyValuePair<int, string>(8, "NumberFore"),
                new KeyValuePair<int, string>(9, "NumberBack"),

                new KeyValuePair<int, string>(10, "VariableFore"),
                new KeyValuePair<int, string>(11, "VariableBack"),

                new KeyValuePair<int, string>(12, "OperatorFore"),
                new KeyValuePair<int, string>(13, "OperatorBack"),

                new KeyValuePair<int, string>(14, "InstructionWordFore"),
                new KeyValuePair<int, string>(15, "InstructionWordBack"),

                new KeyValuePair<int, string>(16, "CommandletFore"),
                new KeyValuePair<int, string>(17, "CommandletBack"),

                new KeyValuePair<int, string>(18, "AliasFore"),
                new KeyValuePair<int, string>(19, "AliasBack"),

                new KeyValuePair<int, string>(20, "CommentStreamFore"),
                new KeyValuePair<int, string>(21, "CommentStreamBack"),

                new KeyValuePair<int, string>(22, "HereStringFore"),
                new KeyValuePair<int, string>(23, "HereStringBack"),

                new KeyValuePair<int, string>(24, "HereCharacterFore"),
                new KeyValuePair<int, string>(25, "HereCharacterBack"),

                new KeyValuePair<int, string>(26, "CommentDocKeywordFore"),
                new KeyValuePair<int, string>(27, "CommentDocKeywordBack")
            }
        );

    private List<KeyValuePair<int, string>> IniColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
            {
                new KeyValuePair<int, string>(0, "DefaultFore"),
                new KeyValuePair<int, string>(1, "DefaultBack"),

                new KeyValuePair<int, string>(2, "CommentFore"),
                new KeyValuePair<int, string>(3, "CommentBack"),

                new KeyValuePair<int, string>(4, "SectionFore"),
                new KeyValuePair<int, string>(5, "SectionBack"),

                new KeyValuePair<int, string>(6, "AssignmentFore"),
                new KeyValuePair<int, string>(7, "AssignmentBack"),

                new KeyValuePair<int, string>(8, "DefValFore"),
                new KeyValuePair<int, string>(9, "DefValBack")
            });

    private List<KeyValuePair<int, string>> PythonColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
            {
                new KeyValuePair<int, string>(0, "DefaultFore"),
                new KeyValuePair<int, string>(1, "DefaultBack"),

                new KeyValuePair<int, string>(2, "CommentLineFore"),
                new KeyValuePair<int, string>(3, "CommentLineBack"),

                new KeyValuePair<int, string>(4, "NumberFore"),
                new KeyValuePair<int, string>(5, "NumberBack"),

                new KeyValuePair<int, string>(6, "StringFore"),
                new KeyValuePair<int, string>(7, "StringBack"),

                new KeyValuePair<int, string>(8, "CharacterFore"),
                new KeyValuePair<int, string>(9, "CharacterBack"),

                new KeyValuePair<int, string>(10, "WordFore"),
                new KeyValuePair<int, string>(11, "WordBack"),

                new KeyValuePair<int, string>(12, "TripleFore"),
                new KeyValuePair<int, string>(13, "TripleBack"),

                new KeyValuePair<int, string>(14, "TripleDoubleFore"),
                new KeyValuePair<int, string>(15, "TripleDoubleBack"),

                new KeyValuePair<int, string>(16, "ClassNameFore"),
                new KeyValuePair<int, string>(17, "ClassNameBack"),

                new KeyValuePair<int, string>(18, "DefNameFore"),
                new KeyValuePair<int, string>(19, "DefNameBack"),

                new KeyValuePair<int, string>(20, "OperatorFore"),
                new KeyValuePair<int, string>(21, "OperatorBack"),

                new KeyValuePair<int, string>(22, "IdentifierFore"),
                new KeyValuePair<int, string>(23, "IdentifierBack"),

                new KeyValuePair<int, string>(24, "CommentBlockFore"),
                new KeyValuePair<int, string>(25, "CommentBlockBack"),

                new KeyValuePair<int, string>(26, "DecoratorFore"),
                new KeyValuePair<int, string>(27, "DecoratorBack")
            });


    private List<KeyValuePair<int, string>> JavaColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
            {
                new KeyValuePair<int, string>(0, "PreprocessorFore"),
                new KeyValuePair<int, string>(1, "PreprocessorBack"),

                new KeyValuePair<int, string>(2, "DefaultFore"),
                new KeyValuePair<int, string>(3, "DefaultBack"),

                new KeyValuePair<int, string>(4, "InstructionWordFore"),
                new KeyValuePair<int, string>(5, "InstructionWordBack"),

                new KeyValuePair<int, string>(6, "TypeWordFore"),
                new KeyValuePair<int, string>(7, "TypeWordBack"),

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
                new KeyValuePair<int, string>(31, "CommentDocKeywordErrorBack")
            });

    private List<KeyValuePair<int, string>> JavaScriptColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
            {
                new KeyValuePair<int, string>(0, "DefaultFore"),
                new KeyValuePair<int, string>(1, "DefaultBack"),

                new KeyValuePair<int, string>(2, "InstructionWordFore"),
                new KeyValuePair<int, string>(3, "InstructionWordBack"),

                new KeyValuePair<int, string>(4, "TypeWordFore"),
                new KeyValuePair<int, string>(5, "TypeWordBack"),

                new KeyValuePair<int, string>(6, "WindowInstructionFore"),
                new KeyValuePair<int, string>(7, "WindowInstructionBack"),

                new KeyValuePair<int, string>(8, "NumberFore"),
                new KeyValuePair<int, string>(9, "NumberBack"),

                new KeyValuePair<int, string>(10, "StringFore"),
                new KeyValuePair<int, string>(11, "StringBack"),

                new KeyValuePair<int, string>(12, "StringRawFore"),
                new KeyValuePair<int, string>(13, "StringRawBack"),

                new KeyValuePair<int, string>(14, "CharacterFore"),
                new KeyValuePair<int, string>(15, "CharacterBack"),

                new KeyValuePair<int, string>(16, "OperatorFore"),
                new KeyValuePair<int, string>(17, "OperatorBack"),

                new KeyValuePair<int, string>(18, "VerbatimFore"),
                new KeyValuePair<int, string>(19, "VerbatimBack"),

                new KeyValuePair<int, string>(20, "RegexFore"),
                new KeyValuePair<int, string>(21, "RegexBack"),

                new KeyValuePair<int, string>(22, "CommentFore"),
                new KeyValuePair<int, string>(23, "CommentBack"),

                new KeyValuePair<int, string>(24, "CommentLineFore"),
                new KeyValuePair<int, string>(25, "CommentLineBack"),

                new KeyValuePair<int, string>(26, "CommentDocFore"),
                new KeyValuePair<int, string>(27, "CommentDocBack"),

                new KeyValuePair<int, string>(28, "CommentLineDocFore"),
                new KeyValuePair<int, string>(29, "CommentLineDocBack"),

                new KeyValuePair<int, string>(30, "CommentDocKeywordFore"),
                new KeyValuePair<int, string>(31, "CommentDocKeywordBack"),

                new KeyValuePair<int, string>(32, "CommentDocKeywordErrorFore"),
                new KeyValuePair<int, string>(33, "CommentDocKeywordErrorBack")
            });

    private List<KeyValuePair<int, string>> CssColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
            {
                new KeyValuePair<int, string>(0, "DefaultFore"),
                new KeyValuePair<int, string>(1, "DefaultBack"),

                new KeyValuePair<int, string>(2, "TagFore"),
                new KeyValuePair<int, string>(3, "TagBack"),

                new KeyValuePair<int, string>(4, "ClassFore"),
                new KeyValuePair<int, string>(5, "ClassBack"),

                new KeyValuePair<int, string>(6, "PseudoClassFore"),
                new KeyValuePair<int, string>(7, "PseudoClassBack"),

                new KeyValuePair<int, string>(8, "UnknownPseudoClassFore"),
                new KeyValuePair<int, string>(9, "UnknownPseudoClassBack"),

                new KeyValuePair<int, string>(10, "OperatorFore"),
                new KeyValuePair<int, string>(11, "OperatorBack"),

                new KeyValuePair<int, string>(12, "IdentifierFore"),
                new KeyValuePair<int, string>(13, "IdentifierBack"),

                new KeyValuePair<int, string>(14, "UnknownIdentifierFore"),
                new KeyValuePair<int, string>(15, "UnknownIdentifierBack"),

                new KeyValuePair<int, string>(16, "ValueFore"),
                new KeyValuePair<int, string>(17, "ValueBack"),

                new KeyValuePair<int, string>(18, "CommentFore"),
                new KeyValuePair<int, string>(19, "CommentBack"),

                new KeyValuePair<int, string>(20, "IdFore"),
                new KeyValuePair<int, string>(21, "IdBack"),

                new KeyValuePair<int, string>(22, "ImportantFore"),
                new KeyValuePair<int, string>(23, "ImportantBack"),

                new KeyValuePair<int, string>(24, "DirectiveFore"),
                new KeyValuePair<int, string>(25, "DirectiveBack")
            });

    private List<KeyValuePair<int, string>> VbDotNetColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
            {
                new KeyValuePair<int, string>(0, "DefaultFore"),
                new KeyValuePair<int, string>(1, "DefaultBack"),

                new KeyValuePair<int, string>(2, "CommentFore"),
                new KeyValuePair<int, string>(3, "CommentBack"),

                new KeyValuePair<int, string>(4, "NumberFore"),
                new KeyValuePair<int, string>(5, "NumberBack"),

                new KeyValuePair<int, string>(6, "WordFore"),
                new KeyValuePair<int, string>(7, "WordBack"),

                new KeyValuePair<int, string>(8, "Word2Fore"),
                new KeyValuePair<int, string>(9, "Word2Back"),

                new KeyValuePair<int, string>(10, "StringFore"),
                new KeyValuePair<int, string>(11, "StringBack"),

                new KeyValuePair<int, string>(12, "PreprocessorFore"),
                new KeyValuePair<int, string>(13, "PreprocessorBack"),

                new KeyValuePair<int, string>(14, "OperatorFore"),
                new KeyValuePair<int, string>(15, "OperatorBack"),

                new KeyValuePair<int, string>(16, "DateFore"),
                new KeyValuePair<int, string>(17, "DateBack"),
            });

    private List<KeyValuePair<int, string>> JsonColorIndexes { get; } =
        new List<KeyValuePair<int, string>>
        (
            new[]
            {
                new KeyValuePair<int, string>(0, "JsonDefaultFore"),
                new KeyValuePair<int, string>(1, "JsonDefaultBack"),
                    
                new KeyValuePair<int, string>(2, "JsonNumberFore"),
                new KeyValuePair<int, string>(3, "JsonNumberBack"),
                    
                new KeyValuePair<int, string>(4, "JsonStringFore"),
                new KeyValuePair<int, string>(5, "JsonStringBack"),
                    
                new KeyValuePair<int, string>(6, "JsonUnclosedStringFore"),
                new KeyValuePair<int, string>(7, "JsonUnclosedStringBack"),
                    
                new KeyValuePair<int, string>(8, "JsonPropertyFore"),
                new KeyValuePair<int, string>(9, "JsonPropertyBack"),
                    
                new KeyValuePair<int, string>(10, "JsonEscapeSequenceFore"),
                new KeyValuePair<int, string>(11, "JsonEscapeSequenceBack"),
                    
                new KeyValuePair<int, string>(12, "JsonLineCommentFore"),
                new KeyValuePair<int, string>(13, "JsonLineCommentBack"),
                    
                new KeyValuePair<int, string>(14, "JsonBlockCommentFore"),
                new KeyValuePair<int, string>(15, "JsonBlockCommentBack"),
                    
                new KeyValuePair<int, string>(16, "JsonOperatorFore"),
                new KeyValuePair<int, string>(17, "JsonOperatorBack"),
                    
                new KeyValuePair<int, string>(18, "JsonUriFore"),
                new KeyValuePair<int, string>(19, "JsonUriBack"),
                    
                new KeyValuePair<int, string>(20, "JsonCompactIRIFore"),
                new KeyValuePair<int, string>(21, "JsonCompactIRIBack"),
                    
                new KeyValuePair<int, string>(22, "JsonKeywordFore"),
                new KeyValuePair<int, string>(23, "JsonKeywordBack"),
                    
                new KeyValuePair<int, string>(24, "JsonLdKeywordFore"),
                new KeyValuePair<int, string>(25, "JsonLdKeywordBack"),
                    
                new KeyValuePair<int, string>(26, "JsonErrorFore"),
                new KeyValuePair<int, string>(27, "JsonErrorBack"),
            });
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
    /// Loads the lexer color definition from a XDocument class instance.
    /// </summary>
    /// <param name="document">The document containing the lexer's color definitions.</param>
    /// <param name="lexerType">Type of the lexer.</param>
    /// <returns>True if the operation was successful; otherwise false.</returns>
    public bool LoadDescribedLexerColorsFromXml(XDocument document, LexerType lexerType)
    {
        try
        {
            // loop through the color definition elements..
            if (document.Root != null)
            {
                foreach (XElement element in document.Root.Elements("Color"))
                {
                    if (element.Attribute("Name").Value != null)
                    {
                        // assign the color for lexer..
                        this[lexerType, element.Attribute("Name").Value] =
                            Color.FromArgb(int.Parse(element.Attribute("HexARGB").Value, NumberStyles.HexNumber));
                    }
                }
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Loads the lexer color definition from a XML file.
    /// </summary>
    /// <param name="fileName">Name of the file from where to load the lexer color definitions.</param>
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

        // the file wasn't found..
        return false;
    }

    /// <summary>
    /// Gets the color uses by the SciTE color name and a value indicating whether a foreground or a background color is requested.
    /// <note type="note">URL: https://www.scintilla.org/SciTE.html</note>
    /// </summary>
    /// <param name="name">The name of the color (SciTE).</param>
    /// <param name="lexerType">Type of the lexer.</param>
    /// <param name="isForeground">A flag indicating whether a foreground or a background color is requested.</param>
    /// <returns>An index >= 0 if successful; otherwise -1.</returns>
    // ReSharper disable once InconsistentNaming
    public int GetColorIndexBySciTEName(string name, LexerType lexerType, bool isForeground)
    {
        if (lexerType == LexerType.Cs)
        {
            int idx = csColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }

        if (lexerType == LexerType.Cpp)
        {
            int idx = cppColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }

        if (lexerType == LexerType.Xml)
        {
            int idx = xmlColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }

        if (lexerType == LexerType.Nsis)
        {
            int idx = nsisColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }

        if (lexerType == LexerType.InnoSetup)
        {
            int idx = innoSetupColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }

        if (lexerType == LexerType.SQL)
        {
            int idx = sqlColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }

        if (lexerType == LexerType.Batch)
        {
            int idx = batchColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }

        if (lexerType == LexerType.Pascal)
        {
            int idx = pascalColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }

        if (lexerType == LexerType.PHP)
        {
            int idx = phpColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }

        if (lexerType == LexerType.HTML)
        {
            int idx = htmlColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }

        if (lexerType == LexerType.WindowsPowerShell)
        {
            int idx = powerShellColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }

        if (lexerType == LexerType.INI)
        {
            int idx = iniColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }

        if (lexerType == LexerType.Python)
        {
            int idx = pythonColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }

        if (lexerType == LexerType.YAML)
        {
            int idx = yamlColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }

        if (lexerType == LexerType.Java)
        {
            int idx = javaColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }            

        if (lexerType == LexerType.JavaScript)
        {
            int idx = javascriptColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }           

        if (lexerType == LexerType.Css)
        {
            int idx = cssColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }           

        if (lexerType == LexerType.VbDotNet)
        {
            int idx = vbDotNetColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }                  
            
        if (lexerType == LexerType.Json)
        {
            int idx = jsonColors.FindIndex(f => f.Item2 == name && f.Item3 == isForeground);
            return idx;
        }

        return -1;
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

        if (lexerType == LexerType.Cpp)
        {
            int idx = CppColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.Xml)
        {
            int idx = XmlColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.Nsis)
        {
            int idx = NsisColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.InnoSetup)
        {
            int idx = InnoSetupColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.SQL)
        {
            int idx = SqlColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.Batch)
        {
            int idx = BatchColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.Pascal)
        {
            int idx = PascalColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.PHP)
        {
            int idx = PhpColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.HTML)
        {
            int idx = HtmlColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.WindowsPowerShell)
        {
            int idx = PowerShellColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.INI)
        {
            int idx = IniColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.Python)
        {
            int idx = PythonColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.YAML)
        {
            int idx = YamlColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.Java)
        {
            int idx = JavaColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.JavaScript)
        {
            int idx = JavaScriptColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.Css)
        {
            int idx = CssColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.VbDotNet)
        {
            int idx = VbDotNetColorIndexes.FindIndex(f => f.Value == name);
            return idx;
        }

        if (lexerType == LexerType.Json)
        {
            int idx = JsonColorIndexes.FindIndex(f => f.Value == name);
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

        if (lexerType == LexerType.Cpp)
        {
            return CppColorIndexes.Select(f => f.Value);
        }

        if (lexerType == LexerType.Xml)
        {
            return XmlColorIndexes.Select(f => f.Value);
        }

        if (lexerType == LexerType.Nsis)
        {
            return NsisColorIndexes.Select(f => f.Value);
        }

        if (lexerType == LexerType.InnoSetup)
        {
            return InnoSetupColorIndexes.Select(f => f.Value);
        }

        if (lexerType == LexerType.SQL)
        {
            return SqlColorIndexes.Select(f => f.Value);
        }

        if (lexerType == LexerType.Batch)
        {
            return BatchColorIndexes.Select(f => f.Value);
        }

        if (lexerType == LexerType.Pascal)
        {
            return PascalColorIndexes.Select(f => f.Value);
        }

        if (lexerType == LexerType.PHP)
        {
            return PhpColorIndexes.Select(f => f.Value);
        }

        if (lexerType == LexerType.HTML)
        {
            return HtmlColorIndexes.Select(f => f.Value);
        }

        if (lexerType == LexerType.WindowsPowerShell)
        {
            return PowerShellColorIndexes.Select(f => f.Value);
        }

        if (lexerType == LexerType.INI)
        {
            return IniColorIndexes.Select(f => f.Value);
        }

        if (lexerType == LexerType.Python)
        {
            return PythonColorIndexes.Select(f => f.Value);
        }

        if (lexerType == LexerType.YAML)
        {
            return YamlColorIndexes.Select(f => f.Value);
        }

        if (lexerType == LexerType.Java)
        {
            return JavaColorIndexes.Select(f => f.Value);
        }            

        if (lexerType == LexerType.JavaScript)
        {
            return JavaScriptColorIndexes.Select(f => f.Value);
        }   

        if (lexerType == LexerType.Css)
        {
            return CssColorIndexes.Select(f => f.Value);
        }   

        if (lexerType == LexerType.VbDotNet)
        {
            return VbDotNetColorIndexes.Select(f => f.Value);
        }   

        if (lexerType == LexerType.Json)
        {
            return JsonColorIndexes.Select(f => f.Value);
        }   

        return new List<string>();
    }
}