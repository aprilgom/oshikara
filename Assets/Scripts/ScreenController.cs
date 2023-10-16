using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class ScreenController : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject PlayingScreen;
    public GameObject PlayingEffect;
    public GameObject SearchScreen;
    public GameObject RegisterScreen;
    public GameObject VideoObject;
    //private static ScreenController _instance;

    //private ScreenController(){}
    /*
    public static ScreenController GetInstance() {
        if (_instance == null) {
            _instance = new ScreenController();
            _instance.StartScreen = GameObject.Find("SongStartScreen");
            _instance.PlayingScreen = GameObject.Find("SongPlayingScreen");
            _instance.SearchScreen = GameObject.Find("SongSearchScreen");
            _instance.RegisterScreen = GameObject.Find("SongRegisterScreen");
            _instance.VideoObject = GameObject.Find("VideoObject");
            _instance.VideoObject.transform.Find("Video").GetComponent<VideoPlayer>().loopPointReached += _instance.WhenSongEnd;
            _instance.SetActiveAll(false);
            _instance.SearchScreen.SetActive(true);
        }
        return _instance;
    }
    */
    void Start() {
        VideoObject.transform.Find("Video").GetComponent<VideoPlayer>().loopPointReached += WhenSongEnd;
    }
    public void SetActiveAll(bool b) {
        StartScreen.SetActive(b);
        PlayingScreen.SetActive(b);
        SearchScreen.SetActive(b);
        RegisterScreen.SetActive(b);
    }
    public async void Play(SongInfo info, int startScreenTime) {
        var startScreenController = StartScreen.GetComponent<StartScreenController>();
        startScreenController.SetText(info.Name, info.Singer, info.SongWriter, info.LyricWriter);
        SearchScreen.SetActive(false);
        StartScreen.SetActive(true);
        await Task.Delay(startScreenTime*1000);
        StartScreen.SetActive(false);
        var playingScreenController = PlayingScreen.GetComponent<PlayingScreenController>();
        playingScreenController.SetText(info.ID.ToString(), info.Name);
        PlayingScreen.SetActive(true);
        PlayingEffect.SetActive(true);
    }
    void WhenSongEnd(VideoPlayer vp){
        PlayingScreen.SetActive(false);
        SearchScreen.SetActive(true);
        PlayingEffect.SetActive(false);
    }
    public void SetActiveRegisterScreen() {
        if(!RegisterScreen.activeSelf){
            SetActiveAll(false);
            RegisterScreen.SetActive(true);
        }else{
            RegisterScreen.SetActive(false);
        }
    }
    public void SetActiveSearchScreen() {
        if(!SearchScreen.activeSelf){
            SetActiveAll(false);
            SearchScreen.SetActive(true);
        }else{
            SearchScreen.SetActive(false);
        }
    }
}
