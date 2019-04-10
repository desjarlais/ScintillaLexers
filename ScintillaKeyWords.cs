using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScintillaNET;
using static VPKSoft.ScintillaLexers.LexerEnumerations;

namespace VPKSoft.ScintillaLexers
{
    /// <summary>
    /// A class for <see cref="Scintilla"/> keywords for different lexers.
    /// </summary>
    public class ScintillaKeyWords
    {
        public int KeyWordSetIndex { get; set; }

        public  string KeyWords { get; set; }

        public LexerType LexerType { get; set; }

        public static void SetKeywords(Scintilla scintilla, LexerType lexerType)
        {
            var keyWords = KeyWordList.Where(f => f.LexerType == lexerType).OrderBy(f => f.KeyWordSetIndex);

            foreach (var keyWord in keyWords)
            {
                scintilla.SetKeywords( keyWord.KeyWordSetIndex, keyWord.KeyWords);                
            }
        }

        public static List<ScintillaKeyWords> KeyWordList = new List<ScintillaKeyWords>(new []
        {
            new ScintillaKeyWords {KeyWordSetIndex = 0, LexerType = LexerType.Cs, KeyWords = "abstract add alias as ascending async await base break case catch checked continue default delegate descending do dynamic else event explicit extern false finally fixed for foreach from get global goto group if implicit in interface internal into is join let lock namespace new null object operator orderby out override params partial private protected public readonly ref remove return sealed select set sizeof stackalloc switch this throw true try typeof unchecked unsafe using value virtual where while yield"},
            new ScintillaKeyWords {KeyWordSetIndex = 1, LexerType = LexerType.Cs, KeyWords = "bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort var void"}
        });
    }
}
