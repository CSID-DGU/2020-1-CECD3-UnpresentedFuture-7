using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] GameObject settingMenu;

    public void closeButton()
    {
        settingMenu.SetActive(false);
    }
}
