using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlinkText : MonoBehaviour
{
    public TMP_Text textMesh;
    public float animSpeedInSec = 1f;
    bool keepAnimating = false;

    private IEnumerator anim()
    {
        Color currentColor = textMesh.color;

        Color invisibleColor = textMesh.color;
        invisibleColor.a = 0;  // set alpha to 0

        float oldAnimSpeedInSec = animSpeedInSec;
        float counter = 0;

        while (keepAnimating)
        {
            // hide slowly
            while (counter < oldAnimSpeedInSec)
            {
                if (!keepAnimating) yield break;

                // reset counter when speed is changed
                if (oldAnimSpeedInSec != animSpeedInSec)
                {
                    counter = 0;
                    oldAnimSpeedInSec = animSpeedInSec;
                }

                counter += Time.deltaTime;
                textMesh.color = Color.Lerp(currentColor, invisibleColor, counter / oldAnimSpeedInSec);
                yield return null;
            }

            yield return null;

            // show slowly
            while (counter > 0)
            {
                if (!keepAnimating) yield break;

                // reset counter when speed is changed
                if (oldAnimSpeedInSec != animSpeedInSec)
                {
                    counter = 0;
                    oldAnimSpeedInSec = animSpeedInSec;
                }

                counter -= Time.deltaTime;
                textMesh.color = Color.Lerp(currentColor, invisibleColor, counter / oldAnimSpeedInSec);
                yield return null;
            }
        }
    }

    // call to start animation
    void startTextMeshAnimation()
    {
        if (keepAnimating) return;
        keepAnimating = true;
        StartCoroutine(anim());
    }

    // call to change anim speed
    void changeTextMeshAnimationSpeed(float animSpeed)
    {
        animSpeedInSec = animSpeed;
    }

    // call to stop animation
    void stopTextMeshAnimation()
    {
        keepAnimating = false;
    }

    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    void Update()
    {
        startTextMeshAnimation();
    }
}
