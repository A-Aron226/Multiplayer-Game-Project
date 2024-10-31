using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinText : MonoBehaviour
{
    [SerializeField] StartGameSO SGSO;
    [SerializeField] TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Player " + SGSO.winningPlayer + " won!";
        SGSO.winningPlayer = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
