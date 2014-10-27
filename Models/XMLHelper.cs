using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace WorkWithWCF.Models
{
    
    public static class XMLHelperExtension {
        public static string GetWeatherByTagName(this XmlNode node, string tagName, string helpText)
        {
            string result = helpText;
            if (node[tagName] != null && !node[tagName].IsEmpty)
            {
                result += node[tagName].InnerText;
            }
            return result;
        }
    }

    [Serializable()]
    [System.Xml.Serialization.XmlRootAttribute("Table")]
    public class XMLCity
    {
        [System.Xml.Serialization.XmlElement("Country")]
        public string CountryName { get; set; }

        [System.Xml.Serialization.XmlElement("City")]
        public string Name { get; set; }

    }

    [Serializable()]
    [System.Xml.Serialization.XmlRootAttribute("NewDataSet")]
    public class XMLCities
    {
        
        [XmlElement("Table")]
        public XMLCity[] XMLCity { get; set; }

    }

    public static class XMLGetCitiesWeatherExtension
    {
        public static XMLCities XMLDesirializeCities(this string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XMLCities));
            XMLCities xmlCities;

            using (TextReader reader = new StringReader(xmlString))
            {
                xmlCities = (XMLCities)serializer.Deserialize(reader);
                
            }
            return xmlCities;
        }

        public static WeatherModel XMLDesirializeWeather(this string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(WeatherModel));
            WeatherModel xmlWeather;

            using (TextReader reader = new StringReader(xmlString))
            {
                xmlWeather = (WeatherModel)serializer.Deserialize(reader);

            }
            return xmlWeather;
        }
    }

    
}