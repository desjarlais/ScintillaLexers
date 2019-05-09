using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScintillaNET;

namespace VPKSoft.ScintillaLexers
{
    /// <summary>
    /// A class to set the basic font style for the <see cref="Scintilla"/>.
    /// </summary>
    public static class GlobalScintillaFont
    {
        /// <summary>
        /// Gets or sets the size of the font for the <see cref="Scintilla"/> controls.
        /// </summary>
        public static int FontSize { get; set; } = 10;

        /// <summary>
        /// Gets or sets the name of the font family for the <see cref="Scintilla"/> controls.
        /// </summary>
        public static string FontFamilyName { get; set; } = "Consolas";
    }
}
