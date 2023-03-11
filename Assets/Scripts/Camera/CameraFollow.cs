using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private UnityEngine.Transform _target;
    [SerializeField] private float _smoothSpeed;
    [SerializeField] private Vector3 _offset;

    private void FixedUpdate()
    {
        Vector3 wantedPosition = _target.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, wantedPosition, _smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}