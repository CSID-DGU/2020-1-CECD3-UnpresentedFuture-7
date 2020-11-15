using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitsound_start : MonoBehaviour
{
        public static AudioClip soundExplosion; 
public static AudioSource myAudio; 
    // Start is called before the first frame update
    void Start()
    {
    myAudio = this.gameObject.GetComponent<AudioSource>();
    myAudio.Stop();
        
    }

    // Update is called once per frame
    public static void hitSound()
    {
        myAudio.Play(); 
    }
}
