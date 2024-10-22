using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinFlag : MonoBehaviour
{
    bool canWin;
    [SerializeField] ItemStats stat;

    public void CanWin()
    {
        if (stat.coinCount == stat.maxItem)
        {
            canWin = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<> != null) //Waiting for name of the player script component
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
