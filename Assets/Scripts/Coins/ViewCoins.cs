using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewCoins : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    void Update()
    {
        coinText.text = $"{Coins.Instance.GetCoinsInfo()}";
    }
}
