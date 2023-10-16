using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTester : MonoBehaviour
{
    SongManager sm;
    void Start()
    {
        sm = SongManager.GetInstance();   
    }

    public void addSongTest() {
        sm.addSong(
            1,
            "test",
            "test",
            "test",
            "test",
            "https://www.youtube.com/watch?v=Kiy2JRK-L0M"
        );
    }
    public void findSongTest() {
        Debug.Log(sm.findSongByNameOrSinger("test")[0].ID);
    }
    public void removeSongTest() {
        sm.removeSong(1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
