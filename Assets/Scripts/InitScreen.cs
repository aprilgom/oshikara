using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScreen : MonoBehaviour
{
    public int width = 1920;
    public int height = 1080;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(width, height, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
