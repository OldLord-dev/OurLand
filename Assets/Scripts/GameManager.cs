using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static int playerHealth = 3;
    public static int actualSceneIndex;
    public static int waterCollected;
    public InGameUI gameUI;
    private void Awake()
    {
        if (Instance == null) { Instance = this; } else if (Instance != this) { Destroy(this); }
        DontDestroyOnLoad(gameObject);
        actualSceneIndex = 0;
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("Game Over Screen", LoadSceneMode.Single);
    }
    public static void NextLevel()
    {
        SceneManager.LoadScene(actualSceneIndex++, LoadSceneMode.Single);
    }
    public static void WaterCollected()
    {
        waterCollected++;
        Instance.gameUI.SetDroplets(waterCollected,5);
    }

}