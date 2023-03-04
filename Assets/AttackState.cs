using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.transform.LookAt(_player.transform);
        float distance = Vector3.Distance(animator.transform.position, _player.transform.position);

        if (distance > 5)
            animator.SetTrigger("IsAttacked");

    }
}
