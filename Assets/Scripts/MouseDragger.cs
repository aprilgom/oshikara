using System.Collections;
using System.Collections.Generic;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseDragger : MonoBehaviour
{
    private float maxScale = 10f;
    private float magnitude = 0.3f;
    private bool isDragging;
    Vector3 diff;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    public void OnMouseDown() {
        isDragging = true;
        diff = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public void OnMouseUp() {
        isDragging = false;
    }
    void Update()
    {
        Vector3 scale = transform.localScale;
        var scrollDelta = Input.mouseScrollDelta.y * magnitude;
        if (scale.x + scrollDelta > 0 && scale.x + scrollDelta < 50) {
            scale.x += scrollDelta;
            scale.y += scrollDelta;
            scale.z += scrollDelta;
        }
        transform.localScale = scale;
        if (isDragging) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position + diff;
            transform.Translate(mousePosition);
        }
    }
    void FixedUpdate() {
    }
}
