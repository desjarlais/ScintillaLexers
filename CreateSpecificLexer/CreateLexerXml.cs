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

using ScintillaNET;
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace VPKSoft.ScintillaLexers.CreateSpecificLexer
{
    /// <summary>
    /// A class for the XML lexer.
    /// Implements the <see cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    /// </summary>
    /// <seealso cref="VPKSoft.ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
    public class CreateLexerXml: CreateLexerCommon
    {
        /// <summary>
        /// Creates the lexer for a given Scintilla class instance for the XML (The eXtensible Markup Language).
        /// </summary>
        /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
        /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool CreateXmlLexer(Scintilla scintilla, LexerColors lexerColors)
        {
            ClearStyle(scintilla);

            // XMLSTART, fontStyle = 0 
            scintilla.Styles[Style.Xml.XmlStart].ForeColor =
                lexerColors[LexerType.Xml, "XmlStartFore"];
            scintilla.Styles[Style.Xml.XmlStart].BackColor =
                lexerColors[LexerType.Xml, "XmlStartBack"];

            // XMLEND, fontStyle = 0 
            scintilla.Styles[Style.Xml.XmlEnd].ForeColor = lexerColors[LexerType.Xml, "XmlEndFore"];
            scintilla.Styles[Style.Xml.XmlEnd].BackColor = lexerColors[LexerType.Xml, "XmlEndBack"];

            // DEFAULT, fontStyle = 1 
            scintilla.Styles[Style.Xml.Default].Bold = true;
            scintilla.Styles[Style.Xml.Default].ForeColor = lexerColors[LexerType.Xml, "DefaultFore"];
            scintilla.Styles[Style.Xml.Default].BackColor = lexerColors[LexerType.Xml, "DefaultBack"];

            // COMMENT, fontStyle = 0 
            scintilla.Styles[Style.Xml.Comment].ForeColor = lexerColors[LexerType.Xml, "CommentFore"];
            scintilla.Styles[Style.Xml.Comment].BackColor = lexerColors[LexerType.Xml, "CommentBack"];

            // NUMBER, fontStyle = 0 
            scintilla.Styles[Style.Xml.Number].ForeColor = lexerColors[LexerType.Xml, "NumberFore"];
            scintilla.Styles[Style.Xml.Number].BackColor = lexerColors[LexerType.Xml, "NumberBack"];

            // DOUBLESTRING, fontStyle = 1 
            scintilla.Styles[Style.Xml.DoubleString].Bold = true;
            scintilla.Styles[Style.Xml.DoubleString].ForeColor =
                lexerColors[LexerType.Xml, "DoubleStringFore"];
            scintilla.Styles[Style.Xml.DoubleString].BackColor =
                lexerColors[LexerType.Xml, "DoubleStringBack"];

            // SINGLESTRING, fontStyle = 1 
            scintilla.Styles[Style.Xml.SingleString].Bold = true;
            scintilla.Styles[Style.Xml.SingleString].ForeColor =
                lexerColors[LexerType.Xml, "SingleStringFore"];
            scintilla.Styles[Style.Xml.SingleString].BackColor =
                lexerColors[LexerType.Xml, "SingleStringBack"];

            // TAG, fontStyle = 0 
            scintilla.Styles[Style.Xml.Tag].ForeColor = lexerColors[LexerType.Xml, "TagFore"];
            scintilla.Styles[Style.Xml.Tag].BackColor = lexerColors[LexerType.Xml, "TagBack"];

            // TAGEND, fontStyle = 0 
            scintilla.Styles[Style.Xml.TagEnd].ForeColor = lexerColors[LexerType.Xml, "TagEndFore"];
            scintilla.Styles[Style.Xml.TagEnd].BackColor = lexerColors[LexerType.Xml, "TagEndBack"];

            // TAGUNKNOWN, fontStyle = 0 
            scintilla.Styles[Style.Xml.TagUnknown].ForeColor =
                lexerColors[LexerType.Xml, "TagUnknownFore"];
            scintilla.Styles[Style.Xml.TagUnknown].BackColor =
                lexerColors[LexerType.Xml, "TagUnknownBack"];

            // ATTRIBUTE, fontStyle = 0 
            scintilla.Styles[Style.Xml.Attribute].ForeColor =
                lexerColors[LexerType.Xml, "AttributeFore"];
            scintilla.Styles[Style.Xml.Attribute].BackColor =
                lexerColors[LexerType.Xml, "AttributeBack"];

            // ATTRIBUTEUNKNOWN, fontStyle = 0 
            scintilla.Styles[Style.Xml.AttributeUnknown].ForeColor =
                lexerColors[LexerType.Xml, "AttributeUnknownFore"];
            scintilla.Styles[Style.Xml.AttributeUnknown].BackColor =
                lexerColors[LexerType.Xml, "AttributeUnknownBack"];

            // SGMLDEFAULT, fontStyle = 0 
            scintilla.Styles[21].ForeColor = lexerColors[LexerType.Xml, "SgmlDefaultFore"];
            scintilla.Styles[21].BackColor = lexerColors[LexerType.Xml, "SgmlDefaultBack"];

            // CDATA, fontStyle = 0 
            scintilla.Styles[Style.Xml.CData].ForeColor = lexerColors[LexerType.Xml, "CDataFore"];
            scintilla.Styles[Style.Xml.CData].BackColor = lexerColors[LexerType.Xml, "CDataBack"];

            // ENTITY, fontStyle = 2 
            scintilla.Styles[Style.Xml.Entity].Italic = true;
            scintilla.Styles[Style.Xml.Entity].ForeColor = lexerColors[LexerType.Xml, "EntityFore"];
            scintilla.Styles[Style.Xml.Entity].BackColor = lexerColors[LexerType.Xml, "EntityBack"];

            scintilla.Lexer = Lexer.Xml;

            // folding for a XML lexer..
            LexerFoldProperties.SetScintillaProperties(scintilla, LexerFoldProperties.XmlFolding);

            AddFolding(scintilla);
            return true;
        }
    }
}
