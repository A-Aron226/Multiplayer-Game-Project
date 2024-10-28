using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [SerializeField] TMP_Text coinText;
    [SerializeField] ItemStats coin;
    void Start()
    {
        coin.coinCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coin.coinCount.ToString();
    }
}
