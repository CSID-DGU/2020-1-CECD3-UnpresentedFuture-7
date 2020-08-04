using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistSpeed : MonoBehaviour
{
    private Vector3 LastPos;
    public Vector3 CurrentSpeed;// { get; private set; }
                                // Start is called before the first frame update

    public GameObject ex;
    void Start()
    {
        ex = GetComponent<GameObject>();
        LastPos = transform.position;
        ex.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = transform.position - LastPos;
        CurrentSpeed = displacement / Time.deltaTime;
       // Debug.Log(CurrentSpeed.magnitude);
        LastPos = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("coll speed : "+CurrentSpeed.magnitude);
        ex.SetActive(true);
        Invoke("f", 2f);
    }
    void f()
    {
        ex.SetActive(false);
    }
}
