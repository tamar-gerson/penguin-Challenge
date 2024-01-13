using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setRatio : MonoBehaviour
{
    private const float landscapeRatio =  1920 / 1080;
    
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Resolution, width: " + Screen.width + ", height: " + Screen.height);
    
            // Get the real ratio
            float ratio = (float)Screen.width / (float)Screen.height;
    
            // Cammera settings to landscape
            if (ratio >= landscapeRatio)
            {
                Camera.main.orthographicSize = 1080f / 200f;
            }
            else
            {
                float scaledHeight = 1920f / ratio;
                Camera.main.orthographicSize = scaledHeight / 200f;
            }
        }
}
