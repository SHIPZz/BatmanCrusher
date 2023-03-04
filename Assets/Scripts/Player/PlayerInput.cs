using System;
using UnityEngine;

[RequireComponent(typeof(PhysicalObject), typeof(Animator))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GrapplingHook _hook;

    private Animator _animator;
    private PhysicalObject _physicalObject;

    public static event Action MouseButtonDown;
    public static event Action MouseButtonUp;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _physicalObject = GetComponent<PhysicalObject>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Мышь нажата");
            _hook.CreateHook();
            _animator.enabled = false;
            _physicalObject.MakePhysical();
            MouseButtonDown?.Invoke();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _hook.DisableHook();
            MouseButtonUp?.Invoke();
        }
    }
}