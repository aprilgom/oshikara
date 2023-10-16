using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioTargetSetter : MonoBehaviour
{
    //public AudioSource audioSource;
    // Start is called before the first frame update
    VideoPlayer vp;
    void Start()
    {
        var audioSource = GameObject.Find("AS").GetComponent<AudioSource>();
        vp = GameObject.Find("Video").GetComponent<VideoPlayer>();
        vp.SetTargetAudioSource(0,audioSource);
    }
}
