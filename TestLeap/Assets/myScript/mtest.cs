using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mtest : MonoBehaviour
{

    private AudioSource musicPlayer;
    public AudioClip backgroudMusic;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer=GetComponent<AudioSource>();
        playSound(backgroudMusic,musicPlayer);
    }
    public static void playSound(AudioClip clip,AudioSource aduioPlayer){

        aduioPlayer.Stop();
        aduioPlayer.clip=clip;
        aduioPlayer.loop=true;
        aduioPlayer.time=0;
        aduioPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
