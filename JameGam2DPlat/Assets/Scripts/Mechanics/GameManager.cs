using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int NumOfThiefsToKill;
    [SerializeField] private int levelNum;
    [SerializeField] private int PlayerHealth;
    [SerializeField] private Slider slider;
    private int maxHealth;

    private void Awake() {
        // NumOfThiefsToKill = FindObjectsOfType<ThiefController>().Length;
        maxHealth = PlayerHealth;
    }

    public void ThiefOut(){
        Debug.LogWarning("Thief is out!");
        NumOfThiefsToKill--;
        if(NumOfThiefsToKill <= 0){
            NextLevel();
        }
    }

    public void ThiefRanOut(){
        PlayerHealth--;
        slider.value = (PlayerHealth * 1.0f) / maxHealth;
        if(PlayerHealth <= 0){
            Lose();
        }
    }

    private void Lose(){
        SceneManager.LoadScene(4);
    }

    public void NextLevel(){
        SceneManager.LoadScene(levelNum+1);
    }
}
