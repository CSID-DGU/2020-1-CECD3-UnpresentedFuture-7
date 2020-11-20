using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mocker : MonoBehaviour
{
    [SerializeField] private bool fire;
    [SerializeField] private bool fire2;
    [SerializeField] private bool reset;
    [SerializeField] private bool dataAdd;

    [SerializeField] API data;

    private User[] users;
    [SerializeField] Text[] userNick;
    [SerializeField] Text[] userScore;

    void Start()
    {
        users = new User[5];
        for (int i = 0; i < users.Length; i++)
        {
            users[i] = new User();
        }

        getUserDatabyScore();
    }

    void Update()
    {
        printRanking(users);
    }

    void OnValidate()
    {
        if (fire)
        {
            getUserData();
        }
        else if (fire2)
        {
            getUserDatabyScore();
        }
        else if (reset)
        {
            Debug.Log("데이터베이스 리셋!!!");
            reset = false;

            data.Reset();
        }
        else if (dataAdd)
        {
            Debug.Log("데이터 추가");
            dataAdd = false;

            data.addNewUser("이현재", 10, 1);
            data.addNewUser("리윤우", 320, 2);
            data.addNewUser("윤기철", 210, 3);
            data.addNewUser("륜승규", 40, 4);
        }
    }

    private void getUserData()
    {
        Debug.Log("데이터베이스 호출");
        fire = false;

        data.getUser((User[] users2) =>
        {
            users = users2;
        });
    }

    private void getUserDatabyScore()
    {
        Debug.Log("데이터베이스 호출 _ 점수 정렬");
        fire2 = false;

        data.getUserByScore((User[] users2) =>
        {
            for (int i = 0; i < users.Length; i++)
            {
                users = users2;
            }
        });
    }

    public void printRanking(User[] users)
    {
        for (int i = 0; i < userNick.Length; i++)
        {
            userNick[i].text = users[i].userName;
            userScore[i].text = users[i].score.ToString();
        }
    }
}
