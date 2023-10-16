using System.Collections;
using System.Collections.Generic;
using System.Timers;
//using System.Threading.Tasks;
using UnityEngine;

public class MicSetting : MonoBehaviour
{

    // Start is called before the first frame update
    string dev;
    AudioSource aud;
    static Timer micTimer;
    private IEnumerator coroutine;
    void Start()
    {
        aud = GetComponent<AudioSource>();
        dev = Microphone.devices[0].ToString();
        coroutine = MicTimer(5);
        StartCoroutine(coroutine);
    }
    //void Update() {
    //}
    IEnumerator MicTimer(int waitTime) {
        while(true) {
            aud.clip = Microphone.Start(dev, false, waitTime, AudioSettings.outputSampleRate);
            aud.Play();
            Debug.Log("fdsafds");
            yield return new WaitForSeconds(waitTime);
            //aud.Stop();
            //aud.clip = null;
            //Microphone.End(dev);
            Destroy(aud.clip);
            //yield return new WaitForSeconds(1);
        }
    }
}
