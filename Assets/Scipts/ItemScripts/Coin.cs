using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] ItemStats coin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            coin.coinCount += 1;
            Destroy(obj);
        }
    }
}
