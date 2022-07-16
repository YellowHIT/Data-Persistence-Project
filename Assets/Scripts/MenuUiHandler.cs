using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUiHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartNew()
    {
        
        SceneManager.LoadScene(1);
        SaveManager.Instance.SaveName(-1);
    }
    
     public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        #if UNITY_EDITOR

            EditorApplication.ExitPlaymode();
    
        #else
        
            Application.Quit();

        #endif
    
    }

}
