using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sound : MonoBehaviour
{
  private AudioSource audioSource;
  public static Sound Instance;
  


  private void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }

  
    private void Awake(){

        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void ExecuteSound(AudioClip sonido){
        
        audioSource.PlayOneShot(sonido);
    }

}