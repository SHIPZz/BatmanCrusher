using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartingButton : MyButton
{
    public override void OnClick()
    {
        print("OnClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1.0f;
    }
}
