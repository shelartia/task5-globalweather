using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkWithWCF.Models
{
    public class WeatherModel
    {
        
        public string CountryName;
        
        public string CityName;
        public List<SelectListItem> Cities;

        public string Location;
        public string Time;
        public string Wind;
        public string Visibility;
        public string SkyConditions;
        public string Temperature;
        public string DewPoint;
        public string RelativeHumidity;
        public string Pressure;

    }
    public class City
    {
        public string Name;
        public string ZipCode;
    }
}