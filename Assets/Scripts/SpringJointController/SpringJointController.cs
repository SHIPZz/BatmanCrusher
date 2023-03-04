using System.Collections;
using UnityEngine;

public class SpringJointController : MonoBehaviour
{
    private readonly float _initialSpring = 0;
    private readonly float _maxSpring = 9000;
    private Coroutine _spring;

    public void StartIncreasingSpring(SpringJoint springJoint)
    {
        StopIncreasingSpring();

        _spring = StartCoroutine(IncreaseSpringCoroutine(springJoint));
    }

    private void ResetSpring(SpringJoint springJoint) => springJoint.spring = _initialSpring;

    private void StopIncreasingSpring()
    {
        if (_spring != null)
        {
            StopCoroutine(_spring);
        }
    }

    private IEnumerator IncreaseSpringCoroutine(SpringJoint springJoint)
    {
        ResetSpring(springJoint);

        yield return null;

        springJoint.spring = _maxSpring;
    }
}