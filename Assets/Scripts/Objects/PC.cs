public class PC : InteractableObj
{
    void Start() => taskClip = AudioManager.Instance._audioClip.ComputerTask;
}
