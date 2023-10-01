using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenCanvas : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void ExitGame(){
        Application.Quit();
    }
}
