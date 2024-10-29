using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinFlag : MonoBehaviour
{
    bool canWin = false;
    [SerializeField] ItemStats stat;

    private void Update()
    {
        if (stat.coinCount == stat.maxItem)
        {
            canWin = true;
        }

        else
        {
            canWin = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && canWin)
        {
            //SceneManager.LoadScene("WinScene");
            Debug.Log("You Win!");
        }
    }
}
