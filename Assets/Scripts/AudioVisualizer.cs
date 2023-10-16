using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class AudioVisualizer : MonoBehaviour {
	public float minHeight = 15.0f;
	public float maxHeight = 425.0f;
	public float updateSentivity = 10.0f;
	public Color visualizerColor = Color.gray;
	[Space (15), Range (1, 8192)]
	public int visualizerSimples = 64;
	public float magnitude = 500f;

	AudioVisualizerBar[] bars;
	public AudioSource audioSource;

	// Use this for initialization
	void Start () {
		bars = GetComponentsInChildren<AudioVisualizerBar> ();
		audioSource = GameObject.Find ("AS").GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float[] spectrumData = new float[64];
		audioSource.GetSpectrumData (spectrumData, 0, FFTWindow.Rectangular);
		for (int i = 0; i < bars.Length; i++) {
            Vector2 newSize = bars [i].GetComponent<RectTransform> ().rect.size;
            newSize.x = Mathf.Clamp (Mathf.Lerp (newSize.x, minHeight + ((maxHeight - minHeight) * magnitude * math.tanh(spectrumData[i])), updateSentivity * 0.5f), minHeight, maxHeight);
            bars [i].GetComponent<RectTransform> ().sizeDelta = newSize;
            bars [i].GetComponent<Image> ().color = visualizerColor;
		}
	}
}