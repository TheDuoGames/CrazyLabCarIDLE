using System;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public Sound[] sounds;
    public override void Awake()
    {
        base.Awake();
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.ShouldLoop;
            s.volumeHolder = s.volume;
        }
    }
    public void Play(string name, bool playOneShot = true)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null) return;
        if (playOneShot) s.source.PlayOneShot(s.source.clip);
        else s.source.Play();

    }
    public void ResetPitch(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null) return;
        else s.pitch = 1;

    }
    public void PitchUp(string name, float value)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null) return;
        else s.pitch += value;
    }
    [System.Serializable]
    public class Sound
    {
        [HideInInspector] public float volumeHolder;
        public string Name;
        public AudioClip Clip;
        [Range(0f, 1f)] public float volume = 1;
        [Range(0.1f, 3f)] public float pitch = 1;
        public bool ShouldLoop;
        [HideInInspector] public AudioSource source;
    }
}