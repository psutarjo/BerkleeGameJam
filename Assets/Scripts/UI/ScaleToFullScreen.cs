using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// on load, scale the background image sprite to fit full screen
public class ScaleToFullScreen : MonoBehaviour {
    void Start() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        Vector2 scale = transform.localScale;
        if (cameraSize.x >= cameraSize.y) { // Landscape (or equal)
            scale *= cameraSize.x / spriteSize.x;
        }
        else { // Portrait
            scale *= cameraSize.y / spriteSize.y;
        }

        scale *= 0.5f;

        transform.position = Camera.main.transform.position; // Optional
        transform.Translate(new Vector3(0, 0, 5));
        transform.localScale = scale;
    }
}
