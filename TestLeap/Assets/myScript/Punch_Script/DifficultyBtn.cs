using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyBtn : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject difficultyMenu;

    public void DifficultyMenu()
    {
        menu.SetActive(false);
        difficultyMenu.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "hand")
        {
            DifficultyMenu();
        }
    }
}
