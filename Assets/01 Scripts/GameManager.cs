using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : M_MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    private string currentContext;

    [SerializeField] private int countdownToDie;
    public int CountdownToDie => countdownToDie;

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

    protected override void Reset()
    {
        base.Reset();
        countdownToDie = 72;
    }

    private void Update()
    {
        if(countdownToDie < 0)
        {
            GameOver();
        }
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
        currentContext = CONSTANT.ContextID_intro; 
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(CONSTANT.SceneName_ContextScene);
    } 
    public void ContextGas1()
    {
        currentContext = CONSTANT.ContextID_gasstation1; 
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(CONSTANT.SceneName_ContextScene);
    }
    public void ContextSup()
    {
        currentContext = CONSTANT.ContextID_supermarket; 
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(CONSTANT.SceneName_ContextScene);
    }
    public void ContextGas2()
    {
        currentContext = CONSTANT.ContextID_gasstation2;
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(CONSTANT.SceneName_ContextScene);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == CONSTANT.SceneName_ContextScene && currentContext != null)
        {
            if (ContextController.Instance != null)
            {
                ContextController.Instance.StartContext(currentContext);
            }
            else
            {
                Debug.LogWarning("ContextController not found after scene load.");
            }

            currentContext = null;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    public void Sleep()
    {
        countdownToDie -= 6;
    }

    public void Refuel()
    {
        countdownToDie -= 4;
    }

    public void Drive(int hour)
    {
        countdownToDie -= hour; 
    }
}
