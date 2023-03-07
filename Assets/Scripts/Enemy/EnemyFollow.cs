using DG.Tweening;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Vector3 _lastPositionTarget;

    private Tweener _tween;

    public void Chase(Transform target)
    {
        _tween = transform.DOMoveX(target.position.x, 0.5f).SetAutoKill(false);
        _lastPositionTarget = target.position;

        if (_lastPositionTarget != null)
        {
            _tween.ChangeEndValue(target.position, true).Restart();
            _lastPositionTarget = target.position;
        }
    }
}
