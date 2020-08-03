using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public GameObject map;
    private OnlineMaps omScript;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
        omScript = map.GetComponent<OnlineMaps>();
    }

    public void Update()
    {
        Debug.Log(Vector3.Magnitude(map.transform.position - Camera.main.transform.position));
        omScript.floatZoom = Vector3.Magnitude(map.transform.position - Camera.main.transform.position);
        Mathf.Clamp(omScript.floatZoom, 2f, 20f);
    }

    public void ChangetoOpenStreet()
    {
        //testing purpose
        omScript.floatZoom += Time.deltaTime;
    }
}
