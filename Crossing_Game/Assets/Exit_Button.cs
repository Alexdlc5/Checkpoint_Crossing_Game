using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit_Button : MonoBehaviour
{
    public Button button;
    // Update is called once per frame
    void Update()
    {
        button.onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
