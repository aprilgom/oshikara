using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Win32;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    private static string vtsModelParentPath = null;
    public static Dictionary<string, string> vtsModelPath = new Dictionary<string, string>();
    public static string currentModelName = null;
    // Start is called before the first frame update
    void Start()
    {
        initVtsModelPath();
    }

    public string getVtsModelParentPath() {
        if (vtsModelParentPath == null) {
            initVtsModelParentPath();
        }
        return vtsModelParentPath;
    }
    private void initVtsModelParentPath(){
        string steamPath = (string)Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Valve\\Steam").GetValue("InstallPath");
        vtsModelParentPath = steamPath + "\\steamapps\\common\\VTube Studio\\VTube Studio_Data\\StreamingAssets\\Live2DModels";
    }

    private void initVtsModelPath() {
        initVtsModelParentPath();
        foreach (var directory in Directory.GetDirectories(vtsModelParentPath)) {
            var path = makeVtsModelPath(directory);
            var tmp = Directory.GetFiles(path,"*.vtube.json")[0];
            var name = tmp.Substring(path.Length + 1, tmp.Length - path.Length - 12);
            vtsModelPath.Add(name,path);
        }
    }

    private string makeVtsModelPath(string path) {
        if (Directory.GetDirectories(path,"runtime").Length != 0) {
            path = path + "\\runtime";
        }
        return path;
    }

    public JObject readJson(string path) {
        string jsonString = System.IO.File.ReadAllText(path);
        return JsonConvert.DeserializeObject<JObject>(jsonString);
    }
}
