using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
public class API : MonoBehaviour
{
    private static API instance = null;
    public static API Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new API();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://arboxing-d5812.firebaseio.com/");

        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        addNewUser("이현재", 250, 3);
        getUserById(1);
    }

    public DatabaseReference reference { get; set; }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void addNewUser(string userName, double score, double id)
    {
        User user = new User(userName, score, id);
        string json = JsonUtility.ToJson(user);

        string key = reference.Child("Users").Push().Key;

        reference.Child("Users").Child(key).SetRawJsonValueAsync(json);
    }

    private void getUserById(double id)
    {
        FirebaseDatabase.DefaultInstance.GetReference("Users")
            .EqualTo(id).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapShot = task.Result;

                foreach(DataSnapshot data in snapShot.Children)
                {
                    IDictionary user = (IDictionary)data.Value;
                    Debug.Log("NAME: " + user["userName"] + "SCORE: " + user["score"] + "ID: " + user["id"]);
                    print("NAME: " + user["userName"] + "SCORE: " + user["score"] + "ID: " + user["id"]);
                }
            } else
            {
                Debug.Log("false");
                print("false");
            }
        });
    }
}

public class User
{
    public string userName;
    public double score;
    public double id;

    public User()
    {

    }

    public User(string userName, double score, double id)
    {
        this.userName = userName;
        this.score = score;
        this.id = id;
    }
}