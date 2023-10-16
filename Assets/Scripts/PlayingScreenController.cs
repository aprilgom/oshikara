using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayingScreenController : MonoBehaviour
{
    public TMP_Text ID;
    public TMP_Text SongName;

    public void SetText(string id, string text){
        ID.SetText(id);
        SongName.SetText(text);
    }
}
