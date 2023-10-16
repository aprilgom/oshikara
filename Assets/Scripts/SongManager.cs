using Realms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using YoutubeExplode;
using YoutubeExplode.Converter;

public class SongManager
{
    private static SongManager _instance;
    private static Realm realm;
    private static YoutubeClient youtube;
    private SongManager() {
        realm = Realm.GetInstance();
        youtube = new YoutubeClient();
    }
    public static SongManager GetInstance() {
        if (_instance == null) {
            _instance = new SongManager();
        }
        return _instance;
    }

    public void addSong(
        int id,
        string name,
        string singer,
        string songwriter,
        string lyricwriter,
        string ytblink
    ) {
        if (findSongById(id) != null) {
            //TODO
            //WARN
            return;
        }
        string path = "Videos/" + id + ".mp4";
        var info = new SongInfo(){
                ID = id,
                Name = name,
                Singer = singer,
                SongWriter = songwriter,
                LyricWriter = lyricwriter,
                Path = path
        };
        downloadSong(ytblink, path, info);
    }
    public SongInfo findSongById(int id) {
        return realm.Find<SongInfo>(id);
    }
    public List<SongInfo> findSongByNameOrSinger(string keyword) {
        var result = realm.All<SongInfo>().Where(s => s.Name.Contains(keyword) || s.Singer.Contains(keyword)).ToList();
        return result;
    }
    public void removeSong(int id) {
        var target = realm.Find<SongInfo>(id);
        realm.Write(() => {
            realm.Remove(target);
        });
        string path = "Videos/" + id + ".mp4";
        File.Delete(path);
    }
    public void modifySong(int id, string field, string value) {
        var target = realm.Find<SongInfo>(id);
        realm.Write(() => {
            target.SetAttribute(field, value);
        });
    }
    public async void downloadSong(string url, string path, SongInfo info) {
        await youtube.Videos.DownloadAsync(url, path);
        realm.Write(() =>
        {
            realm.Add(info);
        });
    }
}