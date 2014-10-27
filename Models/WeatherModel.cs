using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkWithWCF.Models
{
    [Serializable()]
    [System.Xml.Serialization.XmlRootAttribute("CurrentWeather")]
    public class WeatherModel
    {
        
        public string CountryName;
        
        public string CityName;
        public List<SelectListItem> Cities;

        [System.Xml.Serialization.XmlElement("Location")]
        public string Location { get; set; }
        [System.Xml.Serialization.XmlElement("Time")]
        public string Time { get; set; }
        [System.Xml.Serialization.XmlElement("Wind")]
        public string Wind { get; set; }
        [System.Xml.Serialization.XmlElement("Visibility")]
        public string Visibility { get; set; }
        [System.Xml.Serialization.XmlElement("SkyConditions")]
        public string SkyConditions { get; set; }
        [System.Xml.Serialization.XmlElement("Temperature")]
        public string Temperature { get; set; }
        [System.Xml.Serialization.XmlElement("DewPoint")]
        public string DewPoint { get; set; }
        [System.Xml.Serialization.XmlElement("RelativeHumidity")]
        public string RelativeHumidity { get; set; }
        [System.Xml.Serialization.XmlElement("Pressure")]
        public string Pressure { get; set; }

    }
    public class City
    {
        public string Name;
        public string Country;
    }
}