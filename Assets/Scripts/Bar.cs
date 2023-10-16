using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bar : MonoBehaviour
{
    public void SetText(string text) {
        gameObject.transform.Find("text").GetComponent<TMP_Text>().SetText(text);
    }
}
