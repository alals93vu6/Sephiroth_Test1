using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneSet : MonoBehaviour
{
    [Tooltip("載入畫面編號")]
    [Header("載入畫面編號")]
    [SerializeField] private int Scene00Idex;

    [Tooltip("載入畫面編號")]
    [Header("載入畫面編號")]
    [SerializeField] private int Scene01Idex;
    
    [Tooltip("載入畫面編號")]
    [Header("載入畫面編號")]
    [SerializeField] private int Scene02Idex;

    public void LoadScene_Scene00()
    {
        SceneManager.LoadScene(Scene00Idex);
    }
    public void LoadScene_Scene01()
    {
        SceneManager.LoadScene(Scene01Idex);
    }

    public void LoadScene_Scene02()
    {
        SceneManager.LoadScene(Scene02Idex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
