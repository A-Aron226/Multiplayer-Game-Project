using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] StartGameSO SGSO;
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject go;
    PlayerManager pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = FindFirstObjectByType<PlayerManager>();
        if (pm.GetPlayers() == 1)
        {
            SGSO.ReadyPlayers = 0;
        }
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (SGSO.Players != pm.GetPlayers())
        {
            SGSO.Players = pm.GetPlayers();
        }
    }

    public void AttemptStartGame()
    {

        SGSO.ReadyPlayers++;
        text.text = "Ready!";
        if (SGSO.ReadyPlayers >= pm.GetPlayers())
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1.0f;
            go.SetActive(false);
        }
    }
}
