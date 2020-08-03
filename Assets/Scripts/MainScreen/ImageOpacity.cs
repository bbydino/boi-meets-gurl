using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageOpacity : MonoBehaviour
{
    public RawImage img;
    public float animSpeedInSec = 1f;
    public float alpha = 0;
    bool keepAnimating = false;

    private IEnumerator anim()
    {
        Color currentColor = img.color;

        Color invisibleColor = img.color;
        invisibleColor.a = alpha;  // set alpha to 0

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
                img.color = Color.Lerp(currentColor, invisibleColor, counter / oldAnimSpeedInSec);
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
                img.color = Color.Lerp(currentColor, invisibleColor, counter / oldAnimSpeedInSec);
                yield return null;
            }
        }
    }

    // call to start animation
    void startImageAnimation()
    {
        if (keepAnimating) return;
        keepAnimating = true;
        StartCoroutine(anim());
    }

    // call to change anim speed
    void changeImageAnimationSpeed(float animSpeed)
    {
        animSpeedInSec = animSpeed;
    }

    // call to stop animation
    void stopImageAnimation()
    {
        keepAnimating = false;
    }

    void Start()
    {
        img = GetComponent<RawImage>();
    }

    void Update()
    {
        startImageAnimation();
    }
}
