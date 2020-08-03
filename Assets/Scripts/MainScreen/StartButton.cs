using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Button btn;

    public void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(myClickMethod);
    }

    public void myClickMethod()
    {
        print("Changing Scene...");
        SceneManager.LoadScene("WorldMap");
    }
}
