using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private GameObject secondDialogue;

    public bool doorActive = false;

    //lineas de dialogos, min y max
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    private KeyCode Key = KeyCode.E;
    private float typingTime = 0.02f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    


    private void Start()
    {
        enabled = false;
        
    }


    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(Key))
        {

            if (!didDialogueStart)
            {

                StartDialogue();

            }

            else if (dialogueText.text == dialogueLines[lineIndex])
            {

                NextDialogueLine();
            }

            else
            {

                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];

            }

        }

        if (lineIndex == 10)
        {
            //primer dialogo
            doorActive = true;
            gameObject.SetActive(false);
            secondDialogue.SetActive(true);
            
        }
    }

    private void StartDialogue()
    {

        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        playerMovement.StopMovement();
 

        StartCoroutine(ShowLine());


    }

    private void NextDialogueLine()
    {

        lineIndex++;

        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {

            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;

            playerMovement.ResumeMovement();
        }

    }
    private IEnumerator ShowLine()
    {

        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            isPlayerInRange = true;
            dialogueMark.SetActive(true);
            enabled = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            isPlayerInRange = false;
            dialogueMark.SetActive(false);
            enabled = false;

        }
    }

}
