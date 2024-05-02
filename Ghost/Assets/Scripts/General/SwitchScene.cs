using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    public void Menu(){

        SceneManager.LoadScene("Menu");

    }
    public void Home(){

        SceneManager.LoadScene("CasaPlayer");

    }

    public void Tutorial(){

        SceneManager.LoadScene("Tutorial");

    }

    public void NivelScene1(){

        SceneManager.LoadScene("BattleNivel1");

    }

    public void NivelScene2(){

        SceneManager.LoadScene("BattleNivel2");

    }

    public void NextScene(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

     public void Finish(){

        SceneManager.LoadScene("Victory");

    }

}
