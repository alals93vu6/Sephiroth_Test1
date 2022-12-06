using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneSet : MonoBehaviour
{
    [Tooltip("主要畫面編號")]
    [Header("主要畫面編號")]
    [SerializeField] private int MainSceneIdex;

    [Tooltip("遊戲畫面編號")]
    [Header("遊戲畫面編號")]
    [SerializeField] private int GameSceneIdex;

    public void LoadScene_MainScene()
    {
        SceneManager.LoadScene(MainSceneIdex);
    }
    public void LoadScene_GameScene()
    {
        SceneManager.LoadScene(GameSceneIdex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
