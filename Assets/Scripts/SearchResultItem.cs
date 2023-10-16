using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchResultItem : MonoBehaviour
{
    public TMP_Text ID;
    public TMP_Text SongName;
    public TMP_Text Singer;
    public TMP_FontAsset normalfont;
    public TMP_FontAsset outlinefont;
    public Image bg;
    public Color bluecolor;
    public Color yellowcolor;
    public Color highlightedBgColor;
    Color transparentcolor = new Color(0,0,0,0);

    public void SetInfo(SongInfo info) {
        ID.text = info.ID.ToString();
        SongName.text = info.Name;
        Singer.text = info.Singer;
    }

    public void SetEmpty() {
        ID.text = "";
        SongName.text = "";
        Singer.text = "";
    }

    public void SetHighlighted(bool b) {
        if(b) {
            bg.color = highlightedBgColor;
            ID.font = outlinefont;
            ID.color = bluecolor;
            SongName.font = normalfont;
            SongName.color = Color.black;
            Singer.font = outlinefont;
        } else {
            bg.color = transparentcolor;
            ID.font = normalfont;
            ID.color = yellowcolor;
            SongName.font = outlinefont;
            SongName.color = Color.white;
            Singer.font = normalfont;
        }
    }
}
