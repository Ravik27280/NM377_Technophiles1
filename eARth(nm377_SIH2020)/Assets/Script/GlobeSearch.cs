using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobeSearch : MonoBehaviour
{
    public GameObject map;
    private OnlineMaps omScript;
    private string a1;
    private string a2;
    private string a3;
    private string a4;
    private string a5;
    private string a6;

    // Start is called before the first frame update
    void Start()
    {
        a1 = "arcgis";
        a2 = "google";
        a3 = "osm.mapnik";
        a4 = "cartodb";
        a5 = "openweathermap";
        a6 = "openweathermap";
        //a2.text = "google";
        omScript = map.GetComponent<OnlineMaps>();
    }

    public void ArcGIS()
    {
        Debug.Log(omScript.mapType);
        a1 += omScript.mapType.ToString();
        omScript.mapType = "arcgis.worldimagery";
        Debug.Log(omScript.mapType);

    }

    public void Google()
    {
        Debug.Log(omScript.mapType);
        a2 += omScript.mapType.ToString();
        omScript.mapType = "google.relief";
        Debug.Log(omScript.mapType);

    }
    public void Bing()
    {
        Debug.Log(omScript.mapType);
        a2 += omScript.mapType.ToString();
        omScript.mapType = "virtualearth.aerial";
        Debug.Log(omScript.mapType);

    }

    public void Street()
    {
        Debug.Log(omScript.mapType);
        a2 += omScript.mapType.ToString();
        omScript.mapType = "osm.mapnik";
        Debug.Log(omScript.mapType);

    }

    public void cartodb()
    {
        Debug.Log(omScript.mapType);
        a2 += omScript.mapType.ToString();
        omScript.mapType = "cartodb.darkmatter";
        Debug.Log(omScript.mapType);

    }

    public void temp()
    {
        Debug.Log(omScript.mapType);
        a2 += omScript.mapType.ToString();
        omScript.mapType = "openweathermap.temperature";
        Debug.Log(omScript.mapType);

    }

    public void rain()
    {
        Debug.Log(omScript.mapType);
        a2 += omScript.mapType.ToString();
        omScript.mapType = "openweathermap.rain";
        Debug.Log(omScript.mapType);

    }
}
