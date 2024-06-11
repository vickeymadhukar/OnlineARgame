using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public string menuname;
    public bool op;
    public void open()
    {
        op = true;
        gameObject.SetActive(true);
    }
    public void close()
    {
        op = false;
        gameObject.SetActive(false);
    }
}
