using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Gun playerGun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerGun.ammo > 0)
        {
            text.text = "Ammo: " + playerGun.ammo;
        }
        else if (playerGun.ammo == 0)
        {
            text.text = "Press R to Reload!";
        }
    }
}
