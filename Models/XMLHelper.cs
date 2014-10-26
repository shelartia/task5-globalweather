using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace WorkWithWCF.Models
{
    public class XMLHelper
    {
        public static string GetWeatherFromXMLNode(XmlNode node, string tag_name, string helpText)
        {
            string result = helpText;
            if (node[tag_name]!=null && !node[tag_name].IsEmpty)
            {
                result += node[tag_name].InnerText;
            }
            return result;
        }
    }
}