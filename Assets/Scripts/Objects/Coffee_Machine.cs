using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee_Machine : InteractableObj
{
    private void Awake()
    {
        taskClip = AudioManager.Instance._audioClip.coffee;
    }
}
