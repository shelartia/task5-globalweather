using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WorkWithWCF.Models;

namespace WorkWithWCF.Controllers
{
    public class WeatherController : Controller
    {
        private weather.GlobalWeather wcf_weather;
        private net.restfulwebservices.www.WeatherForecastService wcf_weather2;
        public WeatherController()
        {
            wcf_weather = new weather.GlobalWeather();
            wcf_weather2 = new net.restfulwebservices.www.WeatherForecastService();
        }

        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult GetCities(string countryName)
        {
            try
            {
                string xmlString = wcf_weather.GetCitiesByCountry(countryName);
                //using LINQ
                List<string> cities = XElement.Parse(xmlString).Descendants("City").Select(x => x.Value).OrderBy(x => x).ToList();
                
                WeatherModel model = new WeatherModel();
                
                model.CountryName = countryName;
                model.Cities = cities.Select(x =>
                    new SelectListItem()
                    {
                        Text = x,
                        Value = x
                    }).ToList();
                return View("Index",model);
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = "Error:" + e.Message;
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult GetWeather(string countryName, string cityName)
        {
            try
            {
                string xmlString = wcf_weather.GetWeather(cityName, countryName);
                WeatherModel model = new WeatherModel();
                //deserialize
                model = xmlString.XMLDesirializeWeather();

                List<SelectListItem> city = new List<SelectListItem>();
                city.Add(new SelectListItem { Text = cityName, Value = cityName });
                model.Cities=city;

                return View("Index", model);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Error:" + e.Message;
            }
            return View("Index");
        }

    }
}
