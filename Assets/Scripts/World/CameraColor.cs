using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColor : MonoBehaviour
{
    public int frames = 0;
    public int FRAMES_TO_CHANGE = 100;

    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        colorChange();
    }

    void colorChange()
    {
        if (frames == FRAMES_TO_CHANGE)
        {
            var color1 = new Color(
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f)
            );

            camera.backgroundColor = color1;

            frames = 0;
        }
        else frames++;
    }
}
