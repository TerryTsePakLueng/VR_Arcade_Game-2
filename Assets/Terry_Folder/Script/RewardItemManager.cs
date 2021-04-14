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
    public Image titleImage;
    public Sprite creditSprite;

    public int currentItemIndex = 0;

    public Transform particleSpawnPoint;

    public GameObject candyExplosionParticle;

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
        if (tradeMgr.totalCyberShards >= rewardItems[currentItemIndex].itemCost)
        {
            tradeMgr.totalCyberShards -= rewardItems[currentItemIndex].itemCost;
            tradeMgr.totalCyberShardsTXT.text = tradeMgr.totalCyberShards.ToString();
            if (rewardItems[currentItemIndex].itemPrefab != null)
            {
                Instantiate(candyExplosionParticle, particleSpawnPoint);
                GameObject rewardGO = Instantiate(rewardItems[currentItemIndex].itemPrefab, new Vector3(8.992345f, 1.565153f, -1.372867f), 
                    Quaternion.Euler(new Vector3(0, -90, 0)));
            }
            else
            {
                Instantiate(candyExplosionParticle, particleSpawnPoint);
                titleImage.sprite = creditSprite;
                Debug.Log("No Physical Item For That Item!");
            }
        }
    }
}
