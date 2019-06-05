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

using ScintillaNET;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VPKSoft.ScintillaLexers;
using VPKSoft.ScintillaLexers.ScintillaNotepadPlusPlus;
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace TestLexer
{
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
                scintilla.Text = File.ReadAllText(odFile.FileName);

//                string fileName = @"C:\Program Files (x86)\Notepad++\themes\Black board.xml";
                string fileName = @"C:\Program Files (x86)\Notepad++\stylers.model.xml";
//                string fileName = @"C:\Program Files (x86)\Notepad++\themes\Hello Kitty.xml";

                ScintillaLexers.CreateLexerFromFile(scintilla, odFile.FileName, fileName);
//                ScintillaLexers.CreateLexer(scintilla, odFile.FileName);
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
    }
}
