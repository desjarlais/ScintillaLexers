#region License
/*
MIT License

Copyright(c) 2019 Petteri Kautonen

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
using System.Text;
using System.Threading.Tasks;
using ScintillaNET;
using VPKSoft.ScintillaLexers.HelperClasses;
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace VPKSoft.ScintillaLexers.CreateSpecificLexer
{
    /// <summary>
    /// A class for the YAML lexer.
    /// Implements the <see cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    /// </summary>
    /// <seealso cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    public class CreateLexerYaml: CreateLexerCommon
    {
        /// <summary>
        /// Creates the lexer for a given Scintilla class instance for the YAML (YAML Ain't Markup Language).
        /// </summary>
        /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
        /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool CreateYamlLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
        {
            ClearStyle(scintilla);

            #region YAML_CONSTANTS
            const int SCE_YAML_DEFAULT = 0;
            const int SCE_YAML_COMMENT = 1;
            const int SCE_YAML_IDENTIFIER = 2;
            const int SCE_YAML_KEYWORD = 3;
            const int SCE_YAML_NUMBER = 4;
            const int SCE_YAML_REFERENCE = 5;
            const int SCE_YAML_DOCUMENT = 6;
            const int SCE_YAML_TEXT = 7;
            const int SCE_YAML_ERROR = 8;
            const int SCE_YAML_OPERATOR = 9;
            #endregion

            // DEFAULT, fontStyle = 0
            scintilla.Styles[SCE_YAML_DEFAULT].ForeColor = lexerColors[LexerType.YAML, "YamlDefaultFore"];
            scintilla.Styles[SCE_YAML_DEFAULT].BackColor = lexerColors[LexerType.YAML, "YamlDefaultBack"];

            // COMMENT, fontStyle = 1
            scintilla.Styles[SCE_YAML_COMMENT].ForeColor = lexerColors[LexerType.YAML, "CommentFore"];
            scintilla.Styles[SCE_YAML_COMMENT].BackColor = lexerColors[LexerType.YAML, "CommentBack"];

            // IDENTIFIER, fontStyle = 2 
            scintilla.Styles[SCE_YAML_IDENTIFIER].Bold = true;
            scintilla.Styles[SCE_YAML_IDENTIFIER].ForeColor = lexerColors[LexerType.YAML, "IdentifierFore"];
            scintilla.Styles[SCE_YAML_IDENTIFIER].BackColor = lexerColors[LexerType.YAML, "IdentifierBack"];

            // KEYWORD, fontStyle = 3 
            scintilla.Styles[SCE_YAML_KEYWORD].Bold = true;
            scintilla.Styles[SCE_YAML_KEYWORD].ForeColor = lexerColors[LexerType.YAML, "KeywordFore"];
            scintilla.Styles[SCE_YAML_KEYWORD].BackColor = lexerColors[LexerType.YAML, "KeywordBack"];

            // NUMBER, fontStyle = 4 
            scintilla.Styles[SCE_YAML_NUMBER].ForeColor = lexerColors[LexerType.YAML, "NumberFore"];
            scintilla.Styles[SCE_YAML_NUMBER].BackColor = lexerColors[LexerType.YAML, "NumberBack"];

            // REFERENCE, fontStyle = 5 
            scintilla.Styles[SCE_YAML_REFERENCE].ForeColor = lexerColors[LexerType.YAML, "ReferenceFore"];
            scintilla.Styles[SCE_YAML_REFERENCE].BackColor = lexerColors[LexerType.YAML, "ReferenceBack"];

            // DOCUMENT, fontStyle = 6 
            scintilla.Styles[SCE_YAML_DOCUMENT].ForeColor = lexerColors[LexerType.YAML, "DocumentFore"];
            scintilla.Styles[SCE_YAML_DOCUMENT].BackColor = lexerColors[LexerType.YAML, "DocumentBack"];

            // TEXT, fontStyle = 7
            scintilla.Styles[SCE_YAML_TEXT].Bold = true;
            scintilla.Styles[SCE_YAML_TEXT].ForeColor = lexerColors[LexerType.YAML, "TextFore"];
            scintilla.Styles[SCE_YAML_TEXT].BackColor = lexerColors[LexerType.YAML, "TextBack"];

            // ERROR, fontStyle = 8 
            scintilla.Styles[SCE_YAML_ERROR].ForeColor = lexerColors[LexerType.YAML, "ErrorFore"];
            scintilla.Styles[SCE_YAML_ERROR].BackColor = lexerColors[LexerType.YAML, "ErrorBack"];

            // OPERATOR, fontStyle = 9
            scintilla.Styles[SCE_YAML_OPERATOR].ForeColor = lexerColors[LexerType.YAML, "OperatorFore"];
            scintilla.Styles[SCE_YAML_OPERATOR].BackColor = lexerColors[LexerType.YAML, "OperatorBack"];

            scintilla.Lexer = (Lexer)LexerTypeName.SCLEX_YAML;

            ScintillaKeyWords.SetKeywords(scintilla, LexerType.YAML);

            AddFolding(scintilla);
            return true;
        }

    }
}
