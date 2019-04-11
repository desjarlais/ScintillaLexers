using System.Drawing;
using System.Xml.Linq;

namespace VPKSoft.ScintillaLexers.ScintillaNotepadPlusPlus
{
    /// <summary>
    /// A helper class for Notepad++ XML style definition files.
    /// </summary>
    public class XmlStyleNotepadPlusPlusHelper
    {
        /// <summary>
        /// Gets or sets the name of the style definition.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the style definition defines a fond as bold.
        /// </summary>
        public bool Bold { get; set;}

        /// <summary>
        /// Gets or sets a value indicating whether the style definition defines a fond as italic.
        /// </summary>
        public  bool Italic { get; set;}

        /// <summary>
        /// Gets or sets the style identifier from a style definition.
        /// </summary>
        public int StyleId { get; set; }

        /// <summary>
        /// Gets or sets the foreground color of a font from a style definition.
        /// </summary>
        public Color ColorForeground { get; set; }

        /// <summary>
        /// Gets or sets the background color of a font from a style definition.
        /// </summary>
        public Color ColorBackground { get; set; }

        /// <summary>
        /// Gets or sets the name of the font from a style definition.
        /// </summary>
        public string FontName { get; set; }

        /// <summary>
        /// Gets or sets the size of the font from a style definition.
        /// </summary>
        public int FontSize { get; set; }

        /// <summary>
        /// Gets the attribute value of a given <see cref="XElement"/>.
        /// </summary>
        /// <param name="element">The element to get the attribute from.</param>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <param name="defaultValue">The default value for the attribute in case the attribute is null or the value is empty.</param>
        /// <returns>The <see cref="XAttribute"/> value based on given parameters if successful; otherwise <paramref name="defaultValue"/>.</returns>
        private static string GetAttributeValue(XElement element, string attributeName, string defaultValue = "")
        {
            var attribute = element.Attribute(attributeName);
            if (attribute == null)
            {
                return defaultValue;
            }
            
            if (attribute.Value.Trim() != string.Empty)
            {
                return attribute.Value.Trim();
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the attribute value of a given <see cref="XElement"/> as a <see cref="Color"/>.
        /// </summary>
        /// <param name="element">The element to get the color attribute from.</param>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns>A color if the operation was successful; otherwise Color.Empty.</returns>
        private static Color GetAttributeAsColor(XElement element, string attributeName)
        {
            var attribute = element.Attribute(attributeName);
            if (attribute == null)
            {
                return Color.Empty;
            }
            
            if (attribute.Value.Trim() == string.Empty)
            {
                return Color.Empty;
            }

            try
            {
                return ColorTranslator.FromHtml("#" + element.Attribute(attributeName)?.Value);
            }
            catch
            {
                return Color.Empty;
            } 
        }

        /// <summary>
        /// Creates a new instance of this class based on the given <see cref="XElement"/>
        /// </summary>
        /// <param name="element">The element to get the style definition from.</param>
        /// <returns>A <see cref="XmlStyleNotepadPlusPlusHelper"/> class instance filled with the style definition data.</returns>
        public static XmlStyleNotepadPlusPlusHelper FromXElement(XElement element)
        {
            return new XmlStyleNotepadPlusPlusHelper
            {
                Name = GetAttributeValue(element, "name", "None"),
                Bold = int.Parse(GetAttributeValue(element, "fontStyle", "0")) == 1,
                Italic = int.Parse(GetAttributeValue(element, "fontStyle", "0")) == 2,
                StyleId = int.Parse(GetAttributeValue(element, "styleID", "0")),
                ColorForeground = GetAttributeAsColor(element, "fgColor"),
                ColorBackground = GetAttributeAsColor(element, "bgColor"),
                FontName = GetAttributeValue(element, "fontName", "Consolas"),
                FontSize = int.Parse(GetAttributeValue(element, "fontSize", "10")),
            };
        }
    }
}
