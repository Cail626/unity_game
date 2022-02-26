using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;

    public List<Item> content = new List<Item>();
    public int contentCurrentIndex = 0;
    public Image itemImageUI;
    public Text itemNameUI;
    public Sprite emptyItemImage;

    //create singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("il y a plus d'une instance de Inventory" +
                "dans la scène");
        }
        instance = this;
    }

    private void Start()
    {
        UpdateInventoryUI();
        coinsCountText.text = coinsCount.ToString();
    }

    public void ConsumeItem()
    {
        if(content.Count == 0)
        {
            return;
        }

        Item currentItem = content[contentCurrentIndex];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
    }

    public void GetNextItem()
    {
        if(content.Count == 0)
        {
            return;
        }

        contentCurrentIndex += 1;
        if(contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex = 0;
        }
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {
        if(content.Count == 0)
        {
            return;
        }

        contentCurrentIndex -= 1;
        if(contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if (content.Count == 0)
        {
            itemImageUI.sprite = emptyItemImage;
            itemNameUI.text = "";
        }
        else
        {
            itemImageUI.sprite = content[contentCurrentIndex].image;
            itemNameUI.text = content[contentCurrentIndex].name;
        }
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }

    public void UpdateCoinsUI()
    {
        coinsCountText.text = coinsCount.ToString();
    }
}