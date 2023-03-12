using LayerLab;
using UnityEngine;

public abstract class MyButton : MonoBehaviour
{
    [SerializeField] protected GameObject MenuPanel;

    public abstract void OnClick();
}
