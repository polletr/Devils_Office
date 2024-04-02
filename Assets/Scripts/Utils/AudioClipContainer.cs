using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class AudioClipContainer : ScriptableObject
{
    // public List<AudioPair> audioPairs;   // Might add later
    [Header("BGMusic")]

    public AudioClip MainMenu;
    public AudioClip BGMusic;
    public AudioClip WinBGMusic;

    [Header("TaskSFX")]

    public AudioClip TaskComplete;

    /*
        public AudioClip cleaning;
        public AudioClip coffee;
        public AudioClip lightSwitch;
        public AudioClip microwave;
        public AudioClip pc;
        public AudioClip phone;
        public AudioClip printer;
        public AudioClip pitchFork;
        public AudioClip stamp;
        public AudioClip whiteBoard;
        public AudioClip extinguishBody;
    */



    [Header("PlayerSFX")]

    public AudioClip kill;
    public AudioClip closeEyes;
    public AudioClip walk;
    public AudioClip turn;

    [Header("UISFX")]
    public AudioClip timer;
    public AudioClip buttonClick;
    public AudioClip gameOver;

    
}

//code f0or using modular audio container with types    
/*[Serializable]
    public struct AudioPair
    {
        public AudioType Key;
        public AudioClip Value;
    }

[Serializable]
public enum AudioType
{
    BGMusic,
    WorldSFX,
    PlayerSFX,
    EnemySFX
}*/