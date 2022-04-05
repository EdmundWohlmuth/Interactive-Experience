using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Text coinText;
    public Text gemText;
    public Text questText;

    public int coinCount;
    public int gemCount;
    public int completedQuests;

    // Start is called before the first frame update
    void Start()
    {
        coinCount = 0;
        gemCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // update coin display
        coinText.text = "Coins: " + coinCount;
        gemText.text = "Gems: " + gemCount;
        questText.text = completedQuests + "/5 Quests";
    }
}
