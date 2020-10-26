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
    private float _timeout = 3f;

    bool flag = true;
WebCamDevice[] devices ;
    void Start() {  
        //delay initialize camera
        
        webcamTexture = new WebCamTexture();
        image = GetComponent<RawImage>();
        image.texture = webcamTexture;
        //webcamTexture.Play();

         devices = WebCamTexture.devices;
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
        // WebCamDevice device = WebCamTexture.devices[1];
     
        // webcamTexture = new WebCamTexture(device.name);
        // display.material.mainTexture = webcamTexture;

        // webcamTexture.Play();
        // Warning.text = "";

      for(int i=0;i<devices.Length;i++){

            Debug.Log(i+devices[i].name);
        WebCamDevice device = WebCamTexture.devices[1];
        webcamTexture = new WebCamTexture(device.name);
        display.material.mainTexture = webcamTexture;
        webcamTexture.Play();
        Warning.text = "";
            }
    }

    void Update()
    {
      

        
        if (ObjectDetection.detectedObject.Equals("person") || ObjectDetection.detectedObject.Equals("bicycle") || ObjectDetection.detectedObject.Equals("car")) {
            if (flag) {
                flag = false;
                StartCoroutine(BlinkText());
            }
        }
        else {
            Warning.text = "";
        }

        // if (ObjectDetection.detectedObject.Equals("person") || ObjectDetection.detectedObject.Equals("bicycle") || ObjectDetection.detectedObject.Equals("car")) {
        //     flag = true;
        // }

        // if (_timeout > 2f && flag) {
        //     Warning.text = "전방을 주의하세요";
        //     _timeout -= Time.deltaTime;
        // }

        // if (ObjectDetection.detectedObject.Equals("person") || ObjectDetection.detectedObject.Equals("bicycle") || ObjectDetection.detectedObject.Equals("car")) {
        //     if (_timeout == 3f) {
        //         Warning.text = "전방을 주의하세요";
                
        //     }
        // }
        // else {
        //     Warning.text = "";
        // }
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
            yield return new WaitForSeconds (0.5f);
            Warning.text = "";
            yield return new WaitForSeconds (0.5f);
            count++;
        }
        flag = true;
    }

}