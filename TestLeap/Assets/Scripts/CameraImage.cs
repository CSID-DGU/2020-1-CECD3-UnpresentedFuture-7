using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraImage : MonoBehaviour {
    WebCamTexture webcamTexture;
    RawImage image;
    public Renderer display;
    private int currentIndex = 0;

    public Text Warning;
    public GameObject WarningImage;

    private float _timeout = 3f;

    bool flag = true;

    void Start() {
        //delay initialize camera
        
        webcamTexture = new WebCamTexture();
        image = GetComponent<RawImage>();
        image.texture = webcamTexture;

        WebCamDevice[] devices = WebCamTexture.devices;

        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log(i+devices[i].name);
        }
        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].name.Contains("Leap"))
            {
                currentIndex++;
            }
            else
            {
                break;
            }
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
        if ((ObjectDetection.detectedObject.Equals("person") || ObjectDetection.detectedObject.Equals("bicycle") || ObjectDetection.detectedObject.Equals("car")) && flag) {
            flag = false;
            ObjectDetection.detectedObject = "";
            StartCoroutine(BlinkText());
        }
    }

    public Color32[] ProcessImage() {
        //crop
        var cropped = TextureTools.CropTexture(webcamTexture);
        //scale
        var scaled = TextureTools.scaled(cropped, 112, 112, FilterMode.Bilinear);
        //run detection
        return scaled.GetPixels32();
    }

    public IEnumerator BlinkText() {
        int count = 0;
        while (count < 3) {
            Warning.text = "전방을 주의하세요";
            WarningImage.SetActive(true);
            yield return new WaitForSeconds (0.5f);
            Warning.text = "";
            WarningImage.SetActive(false);
            yield return new WaitForSeconds (0.5f);
            count++;
        }
        flag = true;
    }

    void OnApplicationQuit() {
        if (webcamTexture != null)
        {
            webcamTexture.Stop();
            WebCamTexture.Destroy(webcamTexture);
            webcamTexture = null;
        }
    }
}