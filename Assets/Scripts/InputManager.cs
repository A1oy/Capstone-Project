using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager
{
    public static GameControls input =new GameControls();
    
    public static void ToggleActionMap(InputActionMap actionMap)
    {
        if (actionMap.enabled) {
            return;
        }
        else {
            input.Disable();
            actionMap.Enable();
        }
    }
}
