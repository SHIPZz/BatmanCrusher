using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class SceneTransition : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _loadingPercentage;
    [SerializeField] private Image _loadingProgressBar;

    private static SceneTransition _instance;
    private static bool _needPlayOpeningAnimation = false;

    private Animator _animator;
    private AsyncOperation _loadingSceneOperation;

    private void Start()
    {
        _instance = this;

        _animator = GetComponent<Animator>();

        if (_needPlayOpeningAnimation)
            _animator.SetTrigger("IsOpened");
    }

    private void Update()
    {
        if (_loadingSceneOperation != null)
        {
            _loadingPercentage.text = Mathf.RoundToInt(_loadingSceneOperation.progress * 100) + "%";
            _loadingProgressBar.fillAmount = Mathf.Lerp(_loadingProgressBar.fillAmount, _loadingSceneOperation.progress,
                Time.deltaTime * 5);
        }
    }

    public static void SwitchToScene(string sceneName)
    {
        _instance._animator.SetTrigger("IsClosed");

        _instance._loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        _instance._loadingSceneOperation.allowSceneActivation = false;

        _instance._loadingProgressBar.fillAmount = 0;
    }

    public void OnAnimationOver()
    {
        _needPlayOpeningAnimation = true;

        _loadingSceneOperation.allowSceneActivation = true;
    }
}