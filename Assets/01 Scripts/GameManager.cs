using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : M_MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    private string contextToStart;

    protected override void Awake()
    {
        base.Awake();
        if( _instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        if(_instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(CONSTANT.SceneName_GameOverScene,LoadSceneMode.Additive);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void MoveToDriveGame()
    {
        SceneManager.LoadScene(CONSTANT.SceneName_DriveGameScene);
    }
    public void MoveToContextGame()
    {
        SceneManager.LoadScene(CONSTANT.SceneName_ContextScene);
    }
    public void MoveToMainMenu()
    {
        SceneManager.LoadScene(CONSTANT.SceneName_MainMenuScene);
    }
    public void StartGame()
    {
        contextToStart = CONSTANT.ContextID_intro; 
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(CONSTANT.SceneName_ContextScene);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == CONSTANT.SceneName_ContextScene && contextToStart != null)
        {
            if (ContextController.Instance != null)
            {
                ContextController.Instance.StartContext(contextToStart);
            }
            else
            {
                Debug.LogWarning("ContextController not found after scene load.");
            }

            contextToStart = null;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
