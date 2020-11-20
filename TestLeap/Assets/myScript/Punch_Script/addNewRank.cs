using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addNewRank : MonoBehaviour
{
    [SerializeField] private bool reset;
    [SerializeField] private bool dataAdd;

    [SerializeField] API data;

    private User[] users;
    private int lastUserId;
    [SerializeField] Text scoreText;
    private int score;
    private GameObject nickName;
    private string userNickName;

    private bool inputDataCheck = false;

    void Start()
    {
        nickName = GameObject.Find("NickName_Text");
        userNickName = nickName.GetComponent<Text>().text;
        
        getUserData();
    }

    void Update()
    {
        if (inputDataCheck == true)
        {
            foreach (User user in users)
            {
                lastUserId = user.id;
            }
            lastUserId = lastUserId + 1;

            int.TryParse(scoreText.text, out score);
            data.addNewUser(userNickName, score, lastUserId);

            inputDataCheck = false;
        }
    }

    void OnValidate()
    {
        if (reset)
        {
            Debug.Log("데이터베이스 리셋!!!");
            reset = false;

            data.Reset();
        }
        else if (dataAdd)
        {
            Debug.Log("데이터 추가");
            dataAdd = false;

            addNew();
        }
    }

    public void addNew()
    {
        getUserData();
        inputDataCheck = true;
    }

    private void getUserData()
    {
        Debug.Log("데이터베이스 호출");

        data.getUser((User[] users2) =>
        {
            users = users2;
        });
    }
}
