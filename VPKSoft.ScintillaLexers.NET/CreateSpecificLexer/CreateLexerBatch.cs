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
/// A class for the Batch lexer.
/// Implements the <see cref="ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
/// </summary>
/// <seealso cref="ScintillaLexers.CreateSpecificLexer.CreateLexerCommon" />
public abstract class CreateLexerBatch: CreateLexerCommon
{
    /// <summary>
    /// Creates the lexer for a given Scintilla class instance for the batch script file.
    /// </summary>
    /// <param name="scintilla">A Scintilla class instance to set the lexer style for.</param>
    /// <param name="lexerColors">A <see cref="LexerColors"/> class instance for the lexer coloring.</param>
    /// <returns>True if the operation was successful; otherwise false.</returns>
    public static bool CreateBatchLexer(Scintilla scintilla, LexerColors.LexerColors lexerColors)
    {
        ClearStyle(scintilla);

        // DEFAULT, fontStyle = 0 
        scintilla.Styles[Style.Batch.Default].ForeColor = lexerColors[LexerType.Batch, "DefaultFore"];
        scintilla.Styles[Style.Batch.Default].BackColor = lexerColors[LexerType.Batch, "DefaultBack"];

        // COMMENT, fontStyle = 0 
        scintilla.Styles[Style.Batch.Comment].ForeColor = lexerColors[LexerType.Batch, "CommentFore"];
        scintilla.Styles[Style.Batch.Comment].BackColor = lexerColors[LexerType.Batch, "CommentBack"];

        // KEYWORDS, fontStyle = 1 
        scintilla.Styles[Style.Batch.Word].Bold = true;
        scintilla.Styles[Style.Batch.Word].ForeColor = lexerColors[LexerType.Batch, "WordFore"];
        scintilla.Styles[Style.Batch.Word].BackColor = lexerColors[LexerType.Batch, "WordBack"];

        // LABEL, fontStyle = 1 
        scintilla.Styles[Style.Batch.Label].Bold = true;
        scintilla.Styles[Style.Batch.Label].ForeColor = lexerColors[LexerType.Batch, "LabelFore"];
        scintilla.Styles[Style.Batch.Label].BackColor = lexerColors[LexerType.Batch, "LabelBack"];

        // HIDE SYBOL, fontStyle = 0 
        scintilla.Styles[Style.Batch.Hide].ForeColor = lexerColors[LexerType.Batch, "HideFore"];
        scintilla.Styles[Style.Batch.Hide].BackColor = lexerColors[LexerType.Batch, "HideBack"];

        // COMMAND, fontStyle = 0 
        scintilla.Styles[Style.Batch.Command].ForeColor = lexerColors[LexerType.Batch, "CommandFore"];
        scintilla.Styles[Style.Batch.Command].BackColor = lexerColors[LexerType.Batch, "CommandBack"];

        // VARIABLE, fontStyle = 1 
        scintilla.Styles[Style.Batch.Identifier].Bold = true;
        scintilla.Styles[Style.Batch.Identifier].ForeColor = lexerColors[LexerType.Batch, "IdentifierFore"];
        scintilla.Styles[Style.Batch.Identifier].BackColor = lexerColors[LexerType.Batch, "IdentifierBack"];

        // OPERATOR, fontStyle = 1 
        scintilla.Styles[Style.Batch.Operator].Bold = true;
        scintilla.Styles[Style.Batch.Operator].ForeColor = lexerColors[LexerType.Batch, "OperatorFore"];
        scintilla.Styles[Style.Batch.Operator].BackColor = lexerColors[LexerType.Batch, "OperatorBack"];

        scintilla.LexerName = "batch";
            
        ScintillaKeyWords.SetKeywords(scintilla, LexerType.Batch);

        AddFolding(scintilla);
        return true;
    }
}