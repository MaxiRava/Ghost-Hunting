using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    public void Scene1(){

        SceneManager.LoadScene("CasaPlayer");

    }

    public void NivelScene1(){

        SceneManager.LoadScene("BattleTutorial");

    }

    public void NextScene(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
