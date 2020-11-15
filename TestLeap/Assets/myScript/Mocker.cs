using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mocker : MonoBehaviour
{
    [SerializeField] private bool fire;

    [SerializeField] API data;
    [SerializeField] UnityEngine.Events.UnityEvent Todo, BeforeLoad, AfterLoad;

    public Text username1;
    public Text username2;
    public Text username3;
    public Text userScore1;
    public Text userScore2;
    public Text userScore3;


    void OnValidate()
    {
        if (fire)
        {
            Debug.Log("데이터베이스 호출");
            fire = false;

            // maruta.addNewUser("제임스", 54, 1);
            User[] users;
            data.getUser((User[] users2) =>
            {
                users = users2;
                print(users[0].userName);
                print(users[1].userName);
                print(users[2].userName);

                AfterLoad.Invoke();

            });
            BeforeLoad.Invoke();

            //print(maruta.getUserById(4).userName);
            Todo.Invoke();
            //print( maruta.getUserById(4).userName);

            // username1.text = users[0].userName;
            // username2.text = users[1].userName;
            // username3.text = users[2].userName;
            // userScore1.text = users[0].score.ToString();
            // userScore2.text = users[1].score.ToString();
            // userScore3.text = users[2].score.ToString();
        }
    }
}
