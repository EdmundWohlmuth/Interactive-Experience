using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogeManager : MonoBehaviour
{
    public GameObject dialogueUi;
    public Text dialogueText;
    public GameObject player;
    public Animator animator;

    private Queue<string> dialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = new Queue<string>();
    }

    public void StartDialogue(string[] sentances)
    {
        dialogue.Clear();
        dialogueUi.SetActive(true);

        player.GetComponent<PlayerMovement_2D>().enabled = false;
        player.GetComponent<PlayerInteraction>().enabled = false;

        animator.SetFloat("Speed", 0);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        foreach (var currentLine in sentances)
        {
            dialogue.Enqueue(currentLine);           
        }
        DisplayNextSentance();
    }

    public void DisplayNextSentance()
    {
        if (dialogue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string currentLine = dialogue.Dequeue();
        dialogueText.text = currentLine;
    }

    public void EndDialogue()
    {
        dialogueUi.SetActive(false);

        player.GetComponent<PlayerMovement_2D>().enabled = true;
        player.GetComponent<PlayerInteraction>().enabled = true;
    }
}
