public class ExtinguishBody : InteractableObj
{
      void Start()
    {
        taskClip = AudioManager.Instance._audioClip.fire;
        visualIndicator.SetActive(false);
    }


}
