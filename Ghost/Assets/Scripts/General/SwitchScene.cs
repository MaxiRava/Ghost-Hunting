using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    public void Escena1(){

        SceneManager.LoadScene("CasaPlayer");

    }

    public void EscenaNivel1(){

        SceneManager.LoadScene("BattleTutorial");

    }

}
