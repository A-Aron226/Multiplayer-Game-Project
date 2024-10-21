using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] ItemStats coin;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(obj);
        coin.coinCount += 1;
    }
}
