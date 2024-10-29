using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] ItemStats coin;


    private void OnTriggerEnter(Collider other) //Adds count to SO then destroys obejct
    {
        if (other.gameObject.tag == "Player")
        {
            coin.coinCount += 1;
            Destroy(obj);
        }
    }
}
