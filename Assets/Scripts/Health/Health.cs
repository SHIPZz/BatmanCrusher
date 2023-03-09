using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int CurrentValue;

    public event Action<int> ValueChanged;

    public event Action ValueZeroReached;

    public void TakeDamage(int damage)
    {
        CurrentValue = Mathf.Clamp(CurrentValue - damage, 0, CurrentValue);

        if (CurrentValue == 0)
            ValueZeroReached?.Invoke();

        ValueChanged?.Invoke(CurrentValue);
    }
}