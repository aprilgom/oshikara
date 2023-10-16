using Microsoft.Win32;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework.Json;
using UnityEngine;

public class ModelLoader : MonoBehaviour
{
    public Shader _customShader;
    public void loadLive2DModel(string name) {
        var path = Directory.GetFiles(GameManager.vtsModelPath[name], "*.model3.json")[0];
        var model3Json = CubismModel3Json.LoadAtPath(path, builtInLoadAssetAtPath);
        //var model = model3Json.ToModel();
        var model = model3Json.ToModel(CustomizeMaterial, CubismBuiltinPickers.TexturePicker, false);
    }

    public static object builtInLoadAssetAtPath(Type assetType, string absolutePath) {
        if (assetType == typeof(byte[])) {
            return File.ReadAllBytes(absolutePath); 
        }
        else if (assetType == typeof(string)) {
            return File.ReadAllText(absolutePath); 
        }
        else if (assetType == typeof(Texture2D)) {
            var texture = new Texture2D(1,1); 
            texture.LoadImage(File.ReadAllBytes(absolutePath)); 
            return texture; 
        }
        throw new NotSupportedException(); 
    }

    private Material CustomizeMaterial(CubismModel3Json sender, CubismDrawable drawable) {
        var customMaterial = CubismBuiltinPickers.MaterialPicker(sender, drawable);
        customMaterial.shader = _customShader;
        //if (customMaterial.HasFloat("cubism_MaskOn") && customMaterial.GetFloat("cubism_MaskOn") == 0) {
        //}
        return customMaterial;
    }
}
