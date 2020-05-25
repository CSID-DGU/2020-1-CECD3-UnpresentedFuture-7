using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{

    public static int score=0;

    public GameObject firstprefab;
    // Start is called before the first frame update
    void Start()
    {

        Invoke("continueing", 2);
    }
    void Update()
    {
    }

    private void rout()
    {
        while (true)
        {
            
        }
    }
    private void continueing()
    {
        Instantiate(firstprefab, new Vector3(-20,-3,-5), Quaternion.identity);

        Invoke("continueing", 2);
    }

    // Update is called once per frame
  
}
