using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mocker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    [SerializeField]
    private bool fire;

    [SerializeField]
    API maruta;
    [SerializeField]
    UnityEngine.Events.UnityEvent Todo,BeforeLoad,AfterLoad;

    void OnValidate()
    {
        if (fire)
        {
            Debug.Log("북괴 리윤우!");
            fire = false;

            // maruta.addNewUser("리윤우", 54, 4);
            // maruta.addNewUser("제임스", 54, 1);
            User[] users;
            maruta.getUser((User[] users2) =>
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
        }
    }
}
