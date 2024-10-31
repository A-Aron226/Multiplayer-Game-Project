using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.iOS;

public class WinText : MonoBehaviour
{
    [SerializeField] StartGameSO SGSO;
    [SerializeField] TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Player " + SGSO.winningPlayer + " won!";
        SGSO.winningPlayer = 0;
    }

}
