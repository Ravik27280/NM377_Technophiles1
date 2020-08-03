
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public enum UnitType
{
    metric,imperial
}

public class FetchWeather : MonoBehaviour {


    //imperial
    //metric
    
    
    public UnitType weatherUnityType;
    public string cityName;
    public GameObject InputField;
    [SerializeField]
    private string API_KEY = "15d8db955e53953ebd82859586b3db56";
   // public GameObject ClearSky;
   // public GameObject FewClouds;
    //public GameObject ScatteredClouds;
    public GameObject brokenClouds;
    public GameObject Clouds;
    public GameObject rain;
    public GameObject showerRain;
    public GameObject thunderstorm;
    public GameObject snow;
    public GameObject mist;

    public void store()
    {
        cityName = InputField.GetComponent<Text>().text;
        GET("http://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&modejson&units=" + weatherUnityType.ToString() + "&APPID=" + API_KEY);
    }
    // Use this for initialization
    //void Start () {

      //  GET("http://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&modejson&units=" + weatherUnityType.ToString() + "&APPID=" + API_KEY);
    //}
 
    // GET JSON Response
    public WeatherResponseModel GET(string url)
    {
        WeatherResponseModel model = new WeatherResponseModel();
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        try
        {
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                model = JsonConvert.DeserializeObject<WeatherResponseModel>(reader.ReadToEnd());
                UIManager.uiManager.countryName.text = string.Format("City Name is: {0} ", model.name);
                UIManager.uiManager.countryTemperature.text = weatherUnityType == UnitType.imperial ? string.Format("Country Temperature is: {0} °F", model.main.temp.ToString()) :
                     string.Format("Country Temperature is: {0} °C", model.main.temp.ToString());
                UIManager.uiManager.countryLatitude.text = string.Format("Country latitude: {0}", model.coord.lat.ToString());
                UIManager.uiManager.countryLongitude.text = string.Format("Country Longitude {0} ", model.coord.lon.ToString());

                //country Code
                UIManager.uiManager.countryCode.text = string.Format("Country Code : {0} ", model.sys.country);
                UIManager.uiManager.countrySunrise.text = string.Format("Country Sunrise : {0}", UnixTimeStampToDateTime(model.sys.sunrise));
                UIManager.uiManager.countrySunset.text = string.Format("Country Sunset: {0}", UnixTimeStampToDateTime(model.sys.sunset));

                UIManager.uiManager.countryWeatherDescription.text = string.Format("Country Sky Status: {0} ", model.weather[0].description);

                UIManager.uiManager.countryHumidity.text = string.Format("Country Humidity: {0}% ", model.main.humidity);



               // if (model.weather[0].description == "clear sky")
             //   {
                  //  ClearSky.SetActive(true);
               // }

                if (model.weather[0].description == "few clouds")
                {
                    Clouds.SetActive(true);
                }

                if (model.weather[0].description == "scattered clouds")
                {
                    Clouds.SetActive(true);
                }

                if (model.weather[0].description == "overcast clouds")
                {
                    Clouds.SetActive(true);
                }

                if (model.weather[0].description == "'shower rain")
                {
                    rain.SetActive(true);
                }

                if (model.weather[0].description == "rain")
                {
                    rain.SetActive(true);
                }

                if (model.weather[0].description == "thunderstorm")
                {
                    thunderstorm.SetActive(true);
                }

                if (model.weather[0].description == "haze")
                {
                    thunderstorm.SetActive(true);
                }

                if (model.weather[0].description == "mist")
                {
                    thunderstorm.SetActive(true);
                }

                if (model.weather[0].description == "snow")
                {
                    snow.SetActive(true);
                }

                if (model.weather[0].description == "broken clouds")
                {
                    snow.SetActive(true);
                }


            }

        }
        catch (WebException ex)
        {
            WebResponse errorResponse = ex.Response;
            using (Stream responseStream = errorResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                string errorText = reader.ReadToEnd();
                // log errorText
            }
            throw;
        }

        return model;
    }


    // Helpers
    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        return dtDateTime;
    }
   
   
}



// Open Weather Map JSON Response
public class Coord
{
    public double lon { get; set; }
    public double lat { get; set; }
}

public class Weather
{
    public int id { get; set; }
    public string main { get; set; }
    public string description { get; set; }
    public string icon { get; set; }

}

public class Main
{
    public double temp { get; set; }
    public int pressure { get; set; }
    public int humidity { get; set; }
    public double temp_min { get; set; }
    public double temp_max { get; set; }
}

public class Wind
{
    public double speed { get; set; }
    public int deg { get; set; }
}

public class Clouds
{
    public int all { get; set; }
}

public class Sys
{
    public int type { get; set; }
    public int id { get; set; }
    public double message { get; set; }
    public string country { get; set; }
    public int sunrise { get; set; }
    public int sunset { get; set; }
}

public class WeatherResponseModel
{
    public Coord coord { get; set; }
    public List<Weather> weather { get; set; }
    public string @base { get; set; }
    public Main main { get; set; }
    public int visibility { get; set; }
    public Wind wind { get; set; }
    public Clouds clouds { get; set; }
    public int dt { get; set; }
    public Sys sys { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public int cod { get; set; }
}

