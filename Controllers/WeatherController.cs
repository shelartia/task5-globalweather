using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
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
                string xml_string = wcf_weather.GetCitiesByCountry(countryName);
                //using LINQ
                List<string> cities = XElement.Parse(xml_string).Descendants("City").Select(x => x.Value).OrderBy(x => x).ToList();

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
                string xml_string = wcf_weather.GetWeather(cityName, countryName);
                WeatherModel model = new WeatherModel();
                //using LINQ
                XmlDocument xml_doc = new XmlDocument();
                xml_doc.LoadXml(xml_string);
                model.Wind = XMLHelper.GetWeatherFromXMLNode(xml_doc.SelectSingleNode("CurrentWeather"),"Wind","Wind: ");
                model.DewPoint = XMLHelper.GetWeatherFromXMLNode(xml_doc.SelectSingleNode("CurrentWeather"),"DewPoint","DewPoint: ");
                model.Location = XMLHelper.GetWeatherFromXMLNode(xml_doc.SelectSingleNode("CurrentWeather"),"Location","Location: ");
                model.Pressure = XMLHelper.GetWeatherFromXMLNode(xml_doc.SelectSingleNode("CurrentWeather"),"Pressure","Pressure: ");
                model.RelativeHumidity = XMLHelper.GetWeatherFromXMLNode(xml_doc.SelectSingleNode("CurrentWeather"),"RelativeHumidity","RelativeHumidity: ");
                model.SkyConditions = XMLHelper.GetWeatherFromXMLNode(xml_doc.SelectSingleNode("CurrentWeather"), "SkyConditions", "SkyConditions: ");
                model.Temperature = XMLHelper.GetWeatherFromXMLNode(xml_doc.SelectSingleNode("CurrentWeather"),"Temperature","Temperature: ");
                model.Time = XMLHelper.GetWeatherFromXMLNode(xml_doc.SelectSingleNode("CurrentWeather"),"Time","Time: ");
                model.Visibility = XMLHelper.GetWeatherFromXMLNode(xml_doc.SelectSingleNode("CurrentWeather"),"Visibility","Visibility: ");
                
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
