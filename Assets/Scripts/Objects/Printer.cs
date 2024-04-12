public class Printer : InteractableObj
{
    void Start() => taskClip = AudioManager.Instance._audioClip.printer;
}
