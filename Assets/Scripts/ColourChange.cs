using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour {


    // put this script on your camera
    // it's great for a Canvas for your UI

    private Camera cam;
    private float cycleSeconds = 0.5f; // set to say 0.5f to test

    void Awake()
    {

        cam = GetComponent<Camera>();
    }

    public void ChangeColor()
    {

        cam.backgroundColor = Color.HSVToRGB(
            Mathf.Repeat(Time.time / cycleSeconds, 1f),
            0.3f,     // set to a pleasing value. 0f to 1f
            0.7f      // set to a pleasing value. 0f to 1f
        );
    }
    /*
    public Camera cam;
    public float duration = 3.0F;

    private void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    public void ChangeColour()
    {
        Color[] colors = { Color.black,Color.blue,Color.green,Color.cyan};

        int randomColour = Random.Range(0, 3);

      //  Camera.main.backgroundColor = new Color(Random.Range(0,100), Random.Range(0, 100), Random.Range(0, 100));

        float t = Mathf.PingPong(Time.time, duration) / duration;
        cam.backgroundColor = Color.Lerp(colors[randomColour], colors[randomColour], t);
    }*/
}
