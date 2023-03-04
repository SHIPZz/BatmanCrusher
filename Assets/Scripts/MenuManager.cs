using UnityEngine;
using UnityEngine.SceneManagement;
using IJunior.TypedScenes;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "GameScene")
        {
            MenuScene.Load();
        }
    }

    public void GoToGameScene()
    {
        GameScene.Load();
    }

    
}
