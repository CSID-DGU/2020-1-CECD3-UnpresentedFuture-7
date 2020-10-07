using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    Rigidbody rigid;
    float veloh;
    float velov;
    float jump;
    bool isjump;
    bool isbutton;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        isbutton = false;
        isjump = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal")||Input.GetButton("Vertical"))
        {
            veloh = Input.GetAxis("Horizontal");
            velov = Input.GetAxis("Vertical");
           
            rigid.AddForce(new Vector3(veloh,0, velov), ForceMode.Impulse);
           
        }
        if (Input.GetButtonDown("Jump"))
        {
            jump = Input.GetAxis("Jump")*2;
            Debug.Log(isjump);
            if (!isjump)
            {
                rigid.AddForce(Vector3.up * jump, ForceMode.Impulse);
                isjump = true;
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "back")
        {
            isjump = false;
        }
        if (collision.gameObject.name != "back")
        {
            collision.gameObject.SetActive(false);
        }
    }
    public void Jump()
    {
        jump = 3;
        Debug.Log(isjump);
        if (!isjump)
        {
            rigid.AddForce(Vector3.up * jump*2, ForceMode.Impulse);
            isjump = true;
        }
    }
    public void front()
    {
        rigid.AddForce(new Vector3(0, 0, 3), ForceMode.Impulse);
    }
    public void rear()
    {
        rigid.AddForce(new Vector3(0, 0, -3), ForceMode.Impulse);
    }
    public void left()
    {
        rigid.AddForce(new Vector3(-3, 0, 0), ForceMode.Impulse);
    }
    public void right()
    {
        rigid.AddForce(new Vector3(3, 0, 0), ForceMode.Impulse);
       // Invoke("right",1);

    }
    public void isdown()
    {
        Debug.Log("isdown");
        rigid.AddForce(new Vector3(3, 0, 0), ForceMode.Impulse);
    }
    public void isdown2()
    {
        Debug.Log("isdown2");
        rigid.AddForce(new Vector3(-3, 0, 0), ForceMode.Impulse);
    }

}
