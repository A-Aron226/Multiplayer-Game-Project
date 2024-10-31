using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [SerializeField] TMP_Text coinText;
    [SerializeField] ItemStats coin;

    private void OnEnable()
    {
        coin.coinCount = 0;
    }

    private void OnDisable()
    {
        coin.coinCount = 0;
    }

    // Update is called once per frame
    void Update() //Updates count count in HUD
    {
        coinText.text = coin.coinCount.ToString() + "/4";
    }
}
