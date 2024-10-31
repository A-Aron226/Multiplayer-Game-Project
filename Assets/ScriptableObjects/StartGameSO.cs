using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create start game object")]
public class StartGameSO : ScriptableObject
{
    public int Players;
    public int ReadyPlayers;
}
