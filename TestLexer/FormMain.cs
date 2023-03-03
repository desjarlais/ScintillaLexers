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
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VPKSoft.ScintillaLexers;
using VPKSoft.ScintillaLexers.CreateSpecificLexer;
using VPKSoft.ScintillaLexers.ScintillaNotepadPlusPlus;
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace TestLexer;

public partial class FormMain : Form
{
    public FormMain()
    {
        InitializeComponent();
        scintilla.Tag = -1; // a null reference will occur otherwise..
        scintilla.TextChanged += scintilla_TextChanged; // this will adjust the line numbering on the left side..
    }

    private void mnuOpen_Click(object sender, EventArgs e)
    {
        if (odFile.ShowDialog() == DialogResult.OK)
        {                
            ScintillaLexers.CreateLexer(scintilla, odFile.FileName);
            scintilla.Text = File.ReadAllText(odFile.FileName);
        }
    }

    #region https://github.com/jacobslusser/ScintillaNET/wiki/Displaying-Line-Numbers
    private void scintilla_TextChanged(object sender, EventArgs e)
    {
        // save the time when the document was changed..
        DateTime timeStamp = DateTime.Now;
        Scintilla scintilla = (Scintilla)sender;

        int maxLineNumberCharLengthFromTag = (int)scintilla.Tag;

        // Did the number of characters in the line number display change?
        // i.e. nnn VS nn, or nnnn VS nn, etc...
        var maxLineNumberCharLength = scintilla.Lines.Count.ToString().Length;
        if (maxLineNumberCharLength == maxLineNumberCharLengthFromTag)
            return;

        // Calculate the width required to display the last line number
        // and include some padding for good measure.
        const int padding = 2;
        scintilla.Margins[0].Width = scintilla.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
        scintilla.Tag = maxLineNumberCharLength;
    }
    #endregion

    private void Scintilla_LocationChanged(object sender, EventArgs e)
    {
        //MessageBox.Show(scintilla.GetStyleAt(scintilla.CurrentPosition).ToString());
    }

    private void MnuTestMarkLoad_Click(object sender, EventArgs e)
    {
        string fileName = @"C:\Program Files (x86)\Notepad++\themes\Black board.xml";
        var markColors = MarkColors.FromFile(fileName);
        MessageBox.Show(markColors.SmartHighLightingForeground.ToString());
    }

    private void JSonCustom()
    {
        scintilla.StyleResetDefault();
        scintilla.Styles[Style.Default].Font = "Consolas";
        scintilla.Styles[Style.Default].Size = 8;
        scintilla.StyleClearAll();

        // Default..
        scintilla.Styles[Style.Json.Default].ForeColor = Color.Black;
        scintilla.Styles[Style.Json.Default].BackColor = Color.White;

        // Number..
        scintilla.Styles[Style.Json.Number].ForeColor = ColorTranslator.FromHtml("#FF8000");
        scintilla.Styles[Style.Json.Number].BackColor = Color.White;

        // String..
        scintilla.Styles[Style.Json.String].ForeColor = ColorTranslator.FromHtml("#808080");
        scintilla.Styles[Style.Json.String].BackColor = Color.White;

        // Unclosed string..
        scintilla.Styles[Style.Json.StringEol].ForeColor = ColorTranslator.FromHtml("#808080");
        scintilla.Styles[Style.Json.StringEol].BackColor = Color.White;

        // Property name..
        scintilla.Styles[Style.Json.PropertyName].ForeColor = ColorTranslator.FromHtml("#880AE8");
        scintilla.Styles[Style.Json.PropertyName].BackColor = Color.White;

        // Escape sequence..
        scintilla.Styles[Style.Json.EscapeSequence].ForeColor = ColorTranslator.FromHtml("#A52A2A");
        scintilla.Styles[Style.Json.EscapeSequence].BackColor = Color.White;
        scintilla.Styles[Style.Json.EscapeSequence].Bold = true;

        // Line comment..
        scintilla.Styles[Style.Json.LineComment].ForeColor = ColorTranslator.FromHtml("#008000");
        scintilla.Styles[Style.Json.LineComment].BackColor = Color.White;
        scintilla.Styles[Style.Json.LineComment].Italic = true;

        // Block comment..
        scintilla.Styles[Style.Json.BlockComment].ForeColor = ColorTranslator.FromHtml("#008000");
        scintilla.Styles[Style.Json.BlockComment].BackColor = Color.White;

        // Operator..
        scintilla.Styles[Style.Json.Operator].ForeColor = ColorTranslator.FromHtml("#8000FF");
        scintilla.Styles[Style.Json.Operator].BackColor = Color.White;

        // URL/IRI..
        scintilla.Styles[Style.Json.Uri].ForeColor = ColorTranslator.FromHtml("#C71585");
        scintilla.Styles[Style.Json.Uri].BackColor = Color.White;

        // JSON-LD compact IRI..
        scintilla.Styles[Style.Json.CompactIRI].ForeColor = ColorTranslator.FromHtml("#8B0000");
        scintilla.Styles[Style.Json.CompactIRI].BackColor = Color.White;

        // JSON keyword..
        scintilla.Styles[Style.Json.Keyword].ForeColor = ColorTranslator.FromHtml("#000080");
        scintilla.Styles[Style.Json.Keyword].BackColor = Color.White;

        // JSON-LD keyword..
        scintilla.Styles[Style.Json.LdKeyword].ForeColor = ColorTranslator.FromHtml("#000089");
        scintilla.Styles[Style.Json.LdKeyword].BackColor = Color.White;

        // Parsing error..
        scintilla.Styles[Style.Json.Error].ForeColor = ColorTranslator.FromHtml("#008B8B");
        scintilla.Styles[Style.Json.Error].BackColor = ColorTranslator.FromHtml("#FF4500");

        scintilla.LexerName = "json";

        scintilla.SetKeywords(0, "false null true");     
        scintilla.SetKeywords(1, "@id @context @type @value @language @container @list @set @reverse @index @base @vocab @graph");     

        scintilla.SetProperty("lexer.json.allow.comments", "1");
        scintilla.SetProperty("lexer.json.escape.sequence", "1");

        CreateLexerCommon.AddFolding(scintilla);
    }
}