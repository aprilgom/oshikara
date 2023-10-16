using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class PlaySong : MonoBehaviour
{
    public GameObject VideoObject;
    public GameObject IDInput;
    public ScreenController sc;
    SongManager sm;
    // Start is called before the first frame update
    void Start()
    {
        //sc = ScreenController.GetInstance();
        sm = SongManager.GetInstance();   
    }
    public void play(){
        var vp = GameObject.Find("VideoObject/Video").GetComponent<VideoPlayer>();
        var id = Int32.Parse(IDInput.GetComponent<TMP_InputField>().text);
        vp.url = 
            "Videos/" + id + ".mp4";
        vp.Play();
        var info = sm.findSongById(id);
        sc.Play(info, 2);
    }

}
