using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int CurrentValue;

    public event Action<int> ValueChanged;

    public event Action<int> ValueZeroReached;

    public void Decrease(int damage)
    {
        CurrentValue = Mathf.Clamp(CurrentValue - damage, 0, CurrentValue);

        if (CurrentValue == 0)
            ValueZeroReached?.Invoke(CurrentValue);

        ValueChanged?.Invoke(CurrentValue);
    }
}