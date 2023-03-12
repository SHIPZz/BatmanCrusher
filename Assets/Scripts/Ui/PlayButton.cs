using LayerLab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MyButton
{
    public override void OnClick()
    {
        MenuPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
