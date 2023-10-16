using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class SearchScreenController : MonoBehaviour
{
    public TMP_InputField IDInput;
    public ScreenController sc;
    public int MAX = 10;
    int current_i = 0;
    string mode;
    SongManager sm;
    SongInfo[] result;
    public SearchResultItem[] ItemScripts;
    string keyword;
    // Start is called before the first frame update
    void Start()
    {
        sm = SongManager.GetInstance();
        //sc = ScreenController.GetInstance();
        Search("");
        setPage();
        if (result.Length > 0) {
            ItemScripts[0].SetHighlighted(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)) {
            keyword = IDInput.text;
            Search(keyword);
            ItemScripts[current_i % MAX].SetHighlighted(false);
            current_i = 0;
            if (result.Length > 0) {
                ItemScripts[0].SetHighlighted(true);
            }
            setPage();
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)) {
            if(current_i < result.Length-1) {
                ItemScripts[current_i % MAX].SetHighlighted(false);
                current_i++;
                if(current_i % MAX == 0) {
                    setPage();
                }
                ItemScripts[current_i % MAX].SetHighlighted(true);
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            if(current_i > 0) {
                ItemScripts[current_i % MAX].SetHighlighted(false);
                current_i--;
                if(current_i % MAX == MAX - 1) {
                    setPage();
                }
                ItemScripts[current_i % MAX].SetHighlighted(true);
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Space)) {
            var vp = GameObject.Find("VideoObject/Video").GetComponent<VideoPlayer>();
            var info = result[current_i];
            vp.url = 
                "Videos/" + info.ID + ".mp4";
            vp.Play();
            sc.Play(info, 2);
        }

        if(Input.GetKeyDown(KeyCode.Delete)) {
            var info = result[current_i];
            sm.removeSong(info.ID);
            Search(keyword);
            if (current_i >= result.Length) {
                ItemScripts[current_i % MAX].SetHighlighted(false);
                if(result.Length > 0) {
                    current_i = result.Length - 1;
                    ItemScripts[current_i % MAX].SetHighlighted(true);
                }
            }
            setPage();
        }
    }

    void Search(string keyword) {
        result = sm.findSongByNameOrSinger(keyword).ToArray();
    }

    void setPage() {
        int currentPage = current_i / MAX;
        for (int i = 0; i < MAX; i++) {
            if (i + currentPage * MAX >= result.Length) {
                ItemScripts[i].SetEmpty();
            } else {
                ItemScripts[i].SetInfo(result[i + currentPage * MAX]);
            }
        }
    }
}

