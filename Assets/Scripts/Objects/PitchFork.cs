public class PitchFork : InteractableObj
{
    void Start() => taskClip = AudioManager.Instance._audioClip.pitchFork;
}
