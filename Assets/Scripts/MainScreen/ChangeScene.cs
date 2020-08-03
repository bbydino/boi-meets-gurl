using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    public void changeMenuScene(string name)
    {
        StartCoroutine(waiter(name));
    }

    IEnumerator waiter(string name)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(name);
    }
}
