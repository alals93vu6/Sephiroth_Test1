using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneSet : MonoBehaviour
{
    [Tooltip("載入畫面編號")]
    [Header("載入畫面編號")]
    [SerializeField] private List<int> SceneIdex = new List<int>();

    [Header("按鈕當前位置")]
    [Range(0, 10)][SerializeField] public int MainSceneNum;
    [Header("提示提示位置")]
    [SerializeField] public List<Vector3> TipRectTransform = new List<Vector3>();
    [Header("提示物件")]
    [SerializeField] public RectTransform TipGameObject;

    private void Start()
    {
        MainSceneNum = 0;
    }
    private void Update()
    {
        Debug.Log(TipGameObject.localPosition);
        Chang_TipTransform(TipGameObject.localPosition,5);
    }
    public void LoadScene_Scene00()
    {
        SceneManager.LoadScene(SceneIdex[0]);
        Cursor.visible = false;
        SetAudio.audioNum = 1;
    }
    public void LoadScene_Scene01()
    {
        SceneManager.LoadScene(SceneIdex[1]);
    }

    public void LoadScene_Scene02()
    {
        SceneManager.LoadScene(SceneIdex[2]);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void Chang_TipTransform(Vector3 now_vect3, float speed)
    {
        now_vect3 = TipGameObject.localPosition;
        
        TipGameObject.localPosition = Vector3.Lerp(now_vect3, TipRectTransform[MainSceneNum], speed * Time.deltaTime);


        if (MainSceneNum > TipRectTransform.Count)
        {
            MainSceneNum = 0;
        }
        if (MainSceneNum < 0)
        {
            MainSceneNum = 0;
        }
    }
}
