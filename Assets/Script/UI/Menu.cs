using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void Open(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Close(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }
}
