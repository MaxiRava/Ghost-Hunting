using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[System.Serializable]

public class Texts1 : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI dialogueText;

    private bool didDialogueStart;

    private int lineIndex;

    [SerializeField] private GameObject lifes;

    [SerializeField] private PlayerMovement playerMovement;

    [TextArea (2,6)]

    public string[] arrayTexts;
 
    
    //private int countText = 0; 

    void Start()
    {
        playerMovement.StopMovement();
        Time.timeScale = 0;

        StartDialogue();
        
        
    }

    private void StartDialogue(){

        didDialogueStart = true;
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine(){

        lineIndex++;

        if(lineIndex < arrayTexts.Length){

            StartCoroutine(ShowLine());
        }
        else{
            didDialogueStart = false;

            this.gameObject.SetActive(false);

        }

    }

    private IEnumerator ShowLine (){

        dialogueText.text = "";
        foreach(char caracter in arrayTexts[lineIndex]){

            dialogueText.text += caracter;
            yield return new WaitForSecondsRealtime(0.02f);
        }
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){

            

              if (!didDialogueStart){

                
                StartDialogue();

            }
            else if(dialogueText.text == arrayTexts[lineIndex]){
                NextDialogueLine();
                
            }
            else{
                StopAllCoroutines();
                dialogueText.text = arrayTexts[lineIndex];
            }
        }

        if (lineIndex == 8)
        {
            lifes.SetActive(true);
            playerMovement.ResumeMovement();
            Time.timeScale = 1;
        }

    }
}
