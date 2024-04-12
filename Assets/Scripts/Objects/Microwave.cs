public class Microwave : InteractableObj
{
    void Start()
    {
        taskClip = AudioManager.Instance._audioClip.microwave;
    }
}
