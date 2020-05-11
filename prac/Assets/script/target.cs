using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    Rigidbody r;
    public Transform box;
    public Transform box2;
   // public controller ct;
    Vector3 target_b;
    Vector3 original_p;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        target_b = (box.position + box2.position) / 2;
        original_p = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,target_b , 0.1f);
        if (transform.position == target_b)
        {
            Invoke("f", 2f);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        controller.score++;
        Debug.Log("a: " + controller.score);
        if (collision.gameObject.tag=="target")
        { this.gameObject.SetActive(false);
            Invoke("f",2f);
           
        }
        Debug.Log("colli : " + collision.gameObject.name);
    }
    private void f()
    {
        this.transform.position = original_p;
        this.gameObject.SetActive(true);
    }
}
