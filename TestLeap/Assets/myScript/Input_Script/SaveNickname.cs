using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveNickname : MonoBehaviour
{
    [SerializeField] Text nickname;
    private string copyNick;

    // Start is called before the first frame update
    void Start()
    {
        copyNick = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveNickName()
    {
        copyNick = nickname.text;
        this.GetComponent<Text>().text = copyNick;
        DontDestroyOnLoad(this.gameObject);
    }
}
