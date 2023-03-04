using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Rigidbody _rigidBody;

    private GrapplingHook _hook;
    private float _additionalGravity = 1.5f;

    private void Awake()
    {
        _hook = FindObjectOfType<GrapplingHook>();
    }

    //private void FixedUpdate()
    //{
    //    if (GrapplingHook.HasTarget)
    //        _rigidBody.transform.position = new Vector3(0, -3, 0);
    //}


    public void ChangeGravity()
    {
        //_rigidBody.velocity = new Vector3(0, _speed * -1 * Time.deltaTime, 0);

        //transform.position = transform.position + Vector3.down * _speed * Time.deltaTime;
    }

    //private bool CanUseGravity()
    //    => !_hook.HasJoint;
}
