using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewCoins : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private bool onTheGame = false;
    void Update()
    {
        if (onTheGame)
            coinText.text = $"{Coins.Instance.GetCoinsLvlInfo()}";
        else 
            coinText.text = $"{Coins.Instance.GetCoinsInfo()}";
    }
}
