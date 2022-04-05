using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionObject : MonoBehaviour
{
    public DialogeManager dialogeManager;
    public ItemManager itemManager;

    public enum  InteractableType
    {
        nothing,
        info,
        pickupCoin,
        pickupGem,
        dialoge
    }
    [Header("Type of Interactable")]
    public InteractableType interType;

    [Header("Simple info Message")]
    public string infoMessage;
    private Text infoText;

    [Header("Dialogue Messages")]
    public string dialogueName;
    [TextArea]

    public string[] sentances;
    public string[] sentances2;

    [Header("Quest Requirements")]
    public int coinRequirement;
    public int gemReqirement;
    public int questNumber;



    public void Start()
    {
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
    }

    public void Nothing()
    {
        Debug.LogWarning("Object " + this.gameObject.name + " has no type set.");
    }
    public void Info()
    {
        infoText.text = infoMessage;
        StartCoroutine(ShowInfo(infoMessage, 2.5f));
    }
    public void Pickup()
    {
        this.gameObject.SetActive(false);
    }
    public void Dialouge()
    {
        if (que)
        dialogeManager.StartDialogue(sentances);
    }

    IEnumerator ShowInfo(string infoMessage, float waitTime)
    {
        infoText.text = infoMessage;
        yield return new WaitForSeconds(waitTime);
        infoText.text = null;
        
    }
}
