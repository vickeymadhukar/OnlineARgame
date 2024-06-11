using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menumanger : MonoBehaviour
{
    public static menumanger Instance;
    [SerializeField] menu[] menus;


    private void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string menuname)
    {
        for(int i=0; i<menus.Length; i++)
        {
            if (menus[i].menuname == menuname)
            {
                OpenMenu(menus[i]);
            }
            else if (menus[i].op)
            {
                CloseMenu(menus[i]);
            }
        }
    }

    public void OpenMenu(menu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
             if (menus[i].op)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.open();
    }
    public void CloseMenu(menu menu)
    {
        menu.close();
    }
}
