using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddSong : MonoBehaviour
{
    SongManager sm;
    public GameObject IDInput;
    public GameObject NameInput;
    public GameObject SingerInput;
    public GameObject SongWriterInput;
    public GameObject LyricWriterInput;
    public GameObject YoutubeLinkInput;
    void Start()
    {
        sm = SongManager.GetInstance();   
    }
    public void add() {
        sm.addSong(
            Int32.Parse(IDInput.GetComponent<TMP_InputField>().text),
            NameInput.GetComponent<TMP_InputField>().text,
            SingerInput.GetComponent<TMP_InputField>().text,
            SongWriterInput.GetComponent<TMP_InputField>().text,
            LyricWriterInput.GetComponent<TMP_InputField>().text,
            YoutubeLinkInput.GetComponent<TMP_InputField>().text
        );
    }
}
