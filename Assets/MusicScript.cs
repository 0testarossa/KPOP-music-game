using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public AudioSource music;
    public float musicTime;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        //music.time = 30f;
        music.time = musicTime;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
