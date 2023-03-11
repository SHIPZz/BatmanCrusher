using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int CurrentValue;

    public event Action<float> ValueChanged;

    public event Action ValueZeroReached;

    public void TakeDamage(float damage)
    {
        CurrentValue = Mathf.Clamp(CurrentValue - (int)damage, 0, CurrentValue);

        if (CurrentValue == 0)
            ValueZeroReached?.Invoke();

        ValueChanged?.Invoke(CurrentValue);
    }
}