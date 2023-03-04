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


    private readonly float _maxDistance = 30;

    private RopeRenderer ropeRenderer;

    private Vector3 _target;
    private SpringJointController _springJointController;
    private PhysicalObject _physicalObject;
    private RaycastHit _hit;

    public RaycastHit Hit => _hit;

    public bool HasGrappled { get; private set; } = false;

    private void Awake()
    {
        _springJointController = GetComponent<SpringJointController>();
        _physicalObject = GetComponent<PhysicalObject>();
        ropeRenderer = GetComponent<RopeRenderer>();
    }

    public void CreateHook()
    {
        GetRaycastHit();

        if (_hit.collider != null)
        {
            HasGrappled= true;
            _hookRenderer.DrawRope(_target);
            _hookTransform.position = _hit.point;
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

        if (Physics.Raycast(ray, out _hit, _maxDistance))
        {
            _target = _hit.point;
        }

        return _hit;
    }
}
