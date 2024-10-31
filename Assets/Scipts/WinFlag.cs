using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinFlag : MonoBehaviour
{
    public bool canWin = false;
    [SerializeField] ItemStats stat;
    [SerializeField] StartGameSO SGSO;

    private void Update()
    {
        if (stat.coinCount >= stat.maxItem)
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
            Debug.Log("You Won");
            SceneManager.LoadScene("WinScene");
            Transform otherParent = other.gameObject.transform.parent;
            int playerNum = otherParent.GetComponentInChildren<CinemachineInputProvider>().PlayerIndex + 1;
            SGSO.winningPlayer = playerNum;
        }
    }
}
