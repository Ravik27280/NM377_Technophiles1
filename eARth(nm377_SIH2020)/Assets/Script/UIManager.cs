using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

    public static UIManager uiManager;

    //public Text countryName;
    //public Text countryTemperature;
    //public Text countryLatitude, countryLongitude;
    //public Text countryCode;
    //public Text countrySunrise;
    //public Text countrySunset;
    //public Text countryWeatherDescription;
    //public Text countryHumidity;


    public TextMeshProUGUI countryName;
    public TextMeshProUGUI countryTemperature;
    public TextMeshProUGUI countryLatitude, countryLongitude;
    public TextMeshProUGUI countryCode;
    public TextMeshProUGUI countrySunrise;
    public TextMeshProUGUI countrySunset;
    public TextMeshProUGUI countryWeatherDescription;
    public TextMeshProUGUI countryHumidity;
     

    void Awake()
    {
       
        uiManager = this;
        
    }
    




}
