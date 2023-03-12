using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MyButton
{
    public override void OnClick()
    {
        MenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
