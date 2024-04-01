using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PermaDeathState : BaseState
{
    public override void EnterState()
    {
        character.anim.SetBool("Dead", true);

    }
    public override void StopInteract()
    {

    }


}
