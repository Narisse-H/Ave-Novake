using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPlayer : MonoBehaviour
{
    public AudioSource music_player;
    public AudioClip new_music;
    public AudioClip idle_music;
    private bool waiting;

    void OnMouseDown()
    {
        if (!waiting && new_music != null)
        {
            music_player.clip = new_music;
            music_player.loop = false;
            music_player.Play();
            waiting = true;
        }
    }

    void Return_loop_music()
    {
        if (!music_player.isPlaying)
        {
            music_player.clip = idle_music;
            music_player.loop = true;
            music_player.Play();
            waiting = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        music_player = GetComponent<AudioSource>();
        waiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (waiting)
        {
            Return_loop_music();
        }
    }
}
