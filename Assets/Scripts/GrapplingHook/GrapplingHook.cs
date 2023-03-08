using System;
using UnityEngine;

[RequireComponent(typeof(SpringJointController), typeof(PhysicalObject))]
public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private HookRenderer _hookRenderer;
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _hookTransform;
    [SerializeField] private Rigidbody _hook;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _maxDistance;

    private RopeRenderer ropeRenderer;

    private Vector3 _target;
    private SpringJointController _springJointController;
    private PhysicalObject _physicalObject;
    private RaycastHit _hit;

    public static event Action<bool> HookCreated;

    public RaycastHit Hit => _hit;

    public bool HasGrappled { get; private set; }

    private void Awake()
    {
        _springJointController = GetComponent<SpringJointController>();
        _physicalObject = GetComponent<PhysicalObject>();
        ropeRenderer = GetComponent<RopeRenderer>();
    }

    public void CreateHook()
    {
        _hit = GetRaycastHit();

        if (_hit.point == new Vector3(0, 0, 0))
            return;

        if (_hit.point != null)
        {
            _hookTransform.position = _hit.point;
            HasGrappled = true;
            _hookRenderer.DrawRope(_target);
            _springJointController.StartIncreasingSpring(_springJoint);
            _physicalObject.MakeNotPhysical();
        }
    }

    public void DisableHook()
    {
        HasGrappled = false;
        _hookRenderer.Disable();
        _physicalObject.MakePhysical();
    }

    private RaycastHit GetRaycastHit()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));

        if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _layerMask))
        {
            _target = hit.point;
        }

        return hit;
    }
}
