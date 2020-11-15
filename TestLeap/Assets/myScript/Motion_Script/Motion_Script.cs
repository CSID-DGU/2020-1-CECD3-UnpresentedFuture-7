using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion_Script : MonoBehaviour
{
    [SerializeField] GameObject menu;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "palm")
        {
            Debug.Log("Pale Collision");
            if (menu.activeSelf == true)
            {
                menu.SetActive(false);
            }
            else
            {
                menu.SetActive(true);
            }
        }
    }
}
