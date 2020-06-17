using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    
    public Text score_text;
    public static int score=0;
    Vector3 original_p;

    public GameObject firstprefab;
    // Start is called before the first frame update
    void Start()
    {
        original_p = new Vector3(-15f,-3f,-5f);
        Invoke("continueing", 1);
    }
    void Update()
    {
    }

    private void rout()
    {

    }
    private void continueing()
    {
        Instantiate(firstprefab, new Vector3(original_p.x*Random.Range(-3f,3f),original_p.y*Random.Range(-5f,5f),original_p.z*Random.Range(-5f,5f)), Quaternion.identity);

        Invoke("continueing", 1);
    }

    // Update is called once per frame
 

}
