using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life_point : MonoBehaviour
{
    private GameObject[] hearts;
    [SerializeField]
    private API api;
    // Start is called before the first frame update
    void Start()
    {
        //하트 이미지 호출
        if (hearts == null) {
            hearts = GameObject.FindGameObjectsWithTag("heart");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.heart < 0.5) {
            hearts[0].SetActive(false);
            hearts[1].SetActive(false);
            hearts[2].SetActive(false);
            hearts[3].SetActive(false);
            hearts[4].SetActive(false);
        } 
        else if (controller.heart < 5) {
            hearts[0].SetActive(true);
            hearts[1].SetActive(false);
            hearts[2].SetActive(false);
            hearts[3].SetActive(false);
            hearts[4].SetActive(false);
        } 
        else if (controller.heart < 10) {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(false);
            hearts[3].SetActive(false);
            hearts[4].SetActive(false);
        } 
        else if (controller.heart < 15) {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(true);
            hearts[3].SetActive(false);
            hearts[4].SetActive(false);
        } 
        else if (controller.heart < 20) {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(true);
            hearts[3].SetActive(true);
            hearts[4].SetActive(false);
        } 
        else {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(true);
            hearts[3].SetActive(true);
            hearts[4].SetActive(true);
        }
    }

    public void GetUser()
    {

        Debug.Log("asd");
        User user = api.getUserById(4);
        print("NAME: " + user.userName + "SCORE: " + user.score + "ID: " + user.id);
        print("nono");
    }
}
