using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExtinguishBody : InteractableObj
{
    void Start()
    {
        visualIndicator.SetActive(false);
        taskClip = AudioManager.Instance._audioClip.fire;
    }


}
