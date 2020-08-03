using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GirlBox : MonoBehaviour
{
    public TMP_Text textMesh;
    bool called = false;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = gameObject.GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
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

        textMesh.colorGradient = new VertexGradient(color1, color2, color1, color2);

        if (col.name == "Boi")
        {
            textMesh.text = "omg, boi, u saved my cute face!";

            if (!called)
            {
                called = true;

                StartCoroutine(waiter());
            }
        }
        
        if (col.name == "fireball 1(Clone)")
        {
            textMesh.text = "owwww, DON'T HURT ME!";
        }
    }

    void OnTriggerExit2D(Collider2D col)
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

        textMesh.colorGradient = new VertexGradient(color1, color2, color1, color2);

        if (col.name == "Boi")
        {
            textMesh.text = "hey boi, don't leave me!";
        }
    }

    IEnumerator waiter()
    {
        // display BOSS MESSAGE
        yield return new WaitForSeconds(5);
        TMP_Text uiText = canvas.GetComponentInChildren<TMP_Text>();
        uiText.enabled = true;

        // LOAD BOSS BATTLE
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Battle");
    }
}
