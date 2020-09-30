using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class CameraImage : MonoBehaviour {
    WebCamTexture webcamTexture;
    RawImage image;
    public Renderer display;
    private int currentIndex = 0;

    public Text Warning;

    void Start() {
        //delay initialize camera
        
        webcamTexture = new WebCamTexture();
        image = GetComponent<RawImage>();
        image.texture = webcamTexture;
        //webcamTexture.Play();

        WebCamDevice[] devices = WebCamTexture.devices;

        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log(i+devices[i].name);
        }


        if (webcamTexture != null)
        {
            display.material.mainTexture = null;
            webcamTexture.Stop();
            webcamTexture = null;
        }

        WebCamDevice device = WebCamTexture.devices[currentIndex];
        webcamTexture = new WebCamTexture(device.name);
        display.material.mainTexture = webcamTexture;
        webcamTexture.Play();

        Warning.text = "";
    }

    void Update()
    {
        if (ObjectDetection.detectedObject.Equals("person"))
            Warning.text = "전방을 주의하세요";
        else
            Warning.text = "";
    }

    public Color32[] ProcessImage() {
        //crop
        var cropped = TextureTools.CropTexture(webcamTexture);
        //scale
        var scaled = TextureTools.scaled(cropped, 112, 112, FilterMode.Bilinear);
        //run detection
        return scaled.GetPixels32();
    }
}