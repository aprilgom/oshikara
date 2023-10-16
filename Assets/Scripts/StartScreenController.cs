using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenController : MonoBehaviour
{
    public Bar titleBar;
    public Bar lyricWriterBar;
    public Bar songWriterBar;
    public Bar singerBar;
    void Start()
    {
    }

    public void SetText(string title, string singer, string songWriter, string lyricWriter) {
        titleBar.SetText(title);
        singerBar.SetText(singer);
        songWriterBar.SetText(songWriter);
        lyricWriterBar.SetText(lyricWriter);
    }
}
