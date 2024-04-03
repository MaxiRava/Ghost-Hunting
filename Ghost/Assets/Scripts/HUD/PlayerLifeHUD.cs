using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
   
   public GameObject[] lifes;


   public void DesactiveLifes(int indice){

    lifes[indice].SetActive(false);
   }

//    public void ActiveLifes(int indice){

//     lifes[indice].SetActive(true);
//    }

}
