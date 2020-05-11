using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    Rigidbody r;
    public Transform box;
    public Transform box2;
    int a=0;
    Vector3 target_b;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        target_b = (box.position + box2.position) / 2;


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,target_b , 0.5f);

    }
    private void OnCollisionEnter(Collision collision)
    {
        a++;
        Debug.Log("a: " + a);
        if (collision.gameObject.name == "Sphere" || collision.gameObject.name == "Sphere(1)")
        { this.gameObject.SetActive(false);
            Invoke("f",3f);
           
        }
        Debug.Log("colli : " + collision.gameObject.name);
    }
    private void f()
    {
        this.transform.position = new Vector3(-29.7f, 0, 0);
        this.gameObject.SetActive(true);
    }
}
