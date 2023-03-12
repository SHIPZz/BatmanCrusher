using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using UnityEngine;

public class EnemyHitEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bloodEffect;
    [SerializeField] private ParticleSystem _angryEffect;
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _delayDestroy;

    private void OnTriggerEnter(Collider other)
    {
        if (_delayDestroy != null)
            StopCoroutine(_delayDestroy);

        _delayDestroy = StartCoroutine(DestroyWithDelay());
        
        _bloodEffect.Play();
        _audioSource.Play();
    }

   private IEnumerator DestroyWithDelay()
    {
        _angryEffect.Play();
        yield return new WaitForSeconds(0.5f);
        _angryEffect.gameObject.SetActive(false);
        yield return new WaitForSeconds(10f);
        Destroy(_angryEffect.gameObject);
    }
}