using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardItemManager : MonoBehaviour
{
    [SerializeField]
    public List<RewardItemClass> rewardItems;

    TradeManager tradeMgr;

    public Text itemNameTXT;
    public Text itemDescriptionTXT;
    public Image itemIMG;
    public Text itemCostTXT;

    public int currentItemIndex = 0;

    public Transform itemSpawnPoint;

    private void Awake()
    {
        tradeMgr = FindObjectOfType<TradeManager>();
    }

    private void Start()
    {
        DisplayItemInformation();
    }

    public void NextItem()
    {
        currentItemIndex++;
        if(currentItemIndex > rewardItems.Count - 1)
        {
            currentItemIndex = 0;
        }
        DisplayItemInformation();
    }

    public void PreviousItem()
    {
        currentItemIndex--;
        if(currentItemIndex < 0)
        {
            currentItemIndex = rewardItems.Count - 1;
        }
        DisplayItemInformation();
    }

    public void DisplayItemInformation()
    {
        itemNameTXT.text = rewardItems[currentItemIndex].itemName;
        itemDescriptionTXT.text = rewardItems[currentItemIndex].itemDescription;
        itemCostTXT.text = rewardItems[currentItemIndex].itemCost.ToString();
        itemIMG.sprite = rewardItems[currentItemIndex].itemImage;
    }

    public void OnTradePressed()
    {
        if (tradeMgr.totalScoreForAllGames >= rewardItems[currentItemIndex].itemCost)
        {
            tradeMgr.totalScoreForAllGames -= rewardItems[currentItemIndex].itemCost;
            if (rewardItems[currentItemIndex].itemPrefab != null)
            {
                Instantiate(rewardItems[currentItemIndex].itemPrefab, itemSpawnPoint);
            }
        }
    }
}
