using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour, InteractiveButton
{
    // implements the interface
    public void ButtonClick()
    {
        GameManager.instance.GameRestart();
    }
}