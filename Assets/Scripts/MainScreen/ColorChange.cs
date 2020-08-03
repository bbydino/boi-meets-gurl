using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public TMP_Text myTMP;
    public const int FRAMES_TO_CHANGE = 20;
    public int frames = 0;

    // Start is called before the first frame update
    void Start()
    {
        myTMP = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (frames == FRAMES_TO_CHANGE)
        {
            var color1 = new Color(
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f)
            );
            var color2 = new Color(
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f)
            );

            myTMP.colorGradient = new VertexGradient(color1, color2, color1, color2);

            frames = 0;
        }
        else frames++;
    }
}
