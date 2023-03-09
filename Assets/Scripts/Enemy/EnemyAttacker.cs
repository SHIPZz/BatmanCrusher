using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[RequireComponent(typeof(EnemyFollowing), typeof(Animator))]
public class EnemyAttacker : MonoBehaviour, IEnemyAttacker
{
    [SerializeField] private Player _player;

    private static readonly int _isAttacked = Animator.StringToHash("IsAttacked");
    private static readonly int _isWalking = Animator.StringToHash("IsWalking");

    private Coroutine _animation;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Attack(Transform target)
    {
        //if(_animation != null)
        //    StopCoroutine(_animation);

        //_animation = StartCoroutine(StartAnimation());


        //_/*animator.SetBool(_isWalking, false);*/
        _animator.SetBool(_isAttacked, true);
        //_player.TakeDamage(10);
    }

    public void StopAttack()
    {
        //print("stop");
        //_animator.SetBool(_isWalking, false);
        _animator.SetBool(_isAttacked, false);
    }

    //private IEnumerator StartAnimation()
    //{
    //    //_animator.SetBool(_isWalking, false);
    //    ////yield return new WaitForSeconds(1);
    //    //yield return new WaitForSeconds(1);
    //    //_animator.SetBool(_isAttacked, true);
    //    //_player.TakeDamage(10);
    //    //yield return new WaitForSeconds(1);
    //    //_animator.SetBool(_isAttacked, false);

    //}
}