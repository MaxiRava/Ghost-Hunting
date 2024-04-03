using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Hud hud;
    [SerializeField] private GameObject defeatPanel;

    private int lifes = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("mas de un GameManager en escena");
        }
    }

    public void PauseGame(){

        Time.timeScale = 0f;
    }

    public void ResumeGame(){

        Time.timeScale = 1f;
    }

    public void LoseLife()
    {

        lifes -= 1;


        if (lifes == 0)
        {
            PauseGame();
            defeatPanel.SetActive(true);
        }

        hud.DesactiveLifes(lifes);
    }
}
