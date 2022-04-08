using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionObject : MonoBehaviour
{
    public DialogeManager dialogeManager;
    public ItemManager itemManager;
    public GameObject objectiveItem;
    public enum QuestRequirmentType
    {
        coin,
        gem,
        questNum
    }
    public enum  InteractableType
    {
        nothing,
        info,
        pickupCoin,
        pickupGem,
        dialoge
    }

    [Header("Quest Requirements")]
    public QuestRequirmentType questRequirment;
    public int RequirementNum;
    public int currentNum;
    public bool isCompleted;
    public bool isActive;

    [Header("Type of Interactable")]
    public InteractableType interType;

    [Header("Simple info Message")]
    public string infoMessage;
    private Text infoText;

    [Header("Dialogue Messages")]
    public string dialogueName;
    [TextArea]
    public string[] sentances;
    [TextArea]
    public string[] sentances2;
    [TextArea]
    public string[] sentances3;


    public void Start()
    {
        infoText = GameObject.Find("InfoText").GetComponent<Text>();

        isCompleted = false;
    }

    public void Update()
    {
        // keep required item updated
        if (questRequirment == QuestRequirmentType.coin)
        {
            currentNum = itemManager.coinCount;
        }
        else if (questRequirment == QuestRequirmentType.gem)
        {
            currentNum = itemManager.gemCount;
        }
        else if (questRequirment == QuestRequirmentType.questNum)
        {
            currentNum = itemManager.completedQuests;
        }

        // establish if isCompleted is true
        if (currentNum >= RequirementNum)
        {
           // Debug.Log("Gottem");
            isCompleted = true;
        }
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
        dialogeManager.StartDialogue(sentances, sentances2, sentances3, isCompleted);
    }

    IEnumerator ShowInfo(string infoMessage, float waitTime)
    {
        infoText.text = infoMessage;
        yield return new WaitForSeconds(waitTime);
        infoText.text = null;
        
    }

    // removing coins / spawning/despawning items
    public void ObjectiveItem()
    {
        //currentNum = currentNum - RequirementNum;

        dialogeManager.StartDialogue(sentances, sentances2, sentances3, isCompleted);
        if (objectiveItem.active == false)
        {
            objectiveItem.active = true;
            isActive = true;
        }
        else if (objectiveItem.active == true && isActive == false)
        {
            objectiveItem.active = false;
        }
        gameObject.GetComponent<Collider2D>().enabled = false;
        itemManager.completedQuests++;
    }
}
