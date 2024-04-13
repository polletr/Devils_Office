public class Phone : InteractableObj
{
    void Start() => taskClip = AudioManager.Instance._audioClip.TelephoneDial;
}
