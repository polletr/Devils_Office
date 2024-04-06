public class PermaDeathState : BaseState
{
    public override void EnterState()
    {
        character.anim.SetBool("Dead", true);
    }
    public override void StopInteract(){}
}
