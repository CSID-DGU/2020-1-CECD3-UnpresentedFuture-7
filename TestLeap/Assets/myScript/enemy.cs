using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody rigid;
    float a, b, c;
    MeshRenderer mesh;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
        //changemove();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player")
        {
            mat.color = new Color(0, 0, 0);
            

        }
    }

    void changemove()
    {
        a = Random.Range(-5, 6);
        b = Random.Range(-0.5f, 0.6f);
        c = Random.Range(-5, 6);
        rigid.AddForce(new Vector3(a, b, c), ForceMode.Impulse);
        Invoke("changemove", 1);

    }
}
