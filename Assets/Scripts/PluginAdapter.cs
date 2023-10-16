using VTS.Networking.Impl;
using VTS.Models.Impl;
using VTS.Models;
using VTS;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework;
using UnityEngine;

public class PluginAdapter : VTSPlugin
{
    // Start is called before the first frame update
    public CubismModel _model;
    private Boolean initialized;
    public VTSParameter[] vts_parameters;
    void Start() {
        // Everything you need to get started!
        Initialize(
            new WebSocketSharpImpl(),
            new JsonUtilityImpl(),
            new TokenStorageImpl(),
            onSuccess,
            () => {Debug.LogWarning("Disconnected!");},
            () => {Debug.LogError("Error!");});
    }
    void LateUpdate() {
        if (vts_parameters != null) {
            for (int i = 0; i < vts_parameters.Length; i++) {
                _model.Parameters[i].Value = vts_parameters[i].value;
            }
        }
    }
    void FixedUpdate() {
        if (initialized) {
            this.GetLive2DParameterList(
                (msg) => {
                    vts_parameters = msg.data.parameters;
                }, (b) => {Debug.Log("live2d parameter load failed");}
            );
        }
    }
    void onSuccess() {
        Debug.Log("Connected!");
        this.GetCurrentModel((msg) => {
            var name = msg.data.modelName;
            GameManager.currentModelName = name;
            var modelLoader = GameObject.Find("ModelLoader").GetComponent<ModelLoader>();
            modelLoader.loadLive2DModel(name);
            _model = GameObject.Find(name).FindCubismModel();
            var gobject = GameObject.Find(name);
            gobject.AddComponent<MouseDragger>();
            gobject.AddComponent<BoxCollider2D>();
            initialized = true;
            }, (b) => {Debug.Log("model load failed");}
        );
    }
}
