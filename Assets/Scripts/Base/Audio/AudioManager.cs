using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NameMusic
{
    Theme1,
    Theme2,
    Theme3,

}
public enum NameSFX
{
    Click,
    Win,
    Lose,

    MoveItem,
    PlaceItem,
    MergeItem,
}
public class AudioManager : BaseSingleton<AudioManager>
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public Sound[] musicSounds;
    public Sound[] sfxSounds;
    protected override void LoadComponents()
    {
        if (musicSource == null) musicSource = GameObject.Find("Music").GetComponent<AudioSource>();
        if (sfxSource == null) sfxSource = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    #region Test Play Audio
    //[Button("Test Play Music")]
    private void TestPlayMusic(NameMusic name)
    {
        PlayMusic(name);
    }
    //[Button("Test Play SFX")]
    private void TestPlaySFX(NameSFX name)
    {
        PlaySFX(name);
    }
    #endregion
    protected override void Start()
    {
        PlayMusic(NameMusic.Theme1);
    }

    public void PlayMusic(NameMusic name)
    {
        Sound s = Array.Find(musicSounds, sound => sound.name == name.ToString());

        musicSource.clip = s.clip;
        musicSource.volume = s.volume;
        musicSource.pitch = s.pitch;
        musicSource.loop = s.loop;
        musicSource.Play();
    }
    public void StopMusic(NameMusic name)
    {
        Sound s = Array.Find(musicSounds, sound => sound.name == name.ToString());
        musicSource.Stop();
    }
    public void PlaySFX(NameSFX name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name.ToString());
        if (s == null) return;

        sfxSource.PlayOneShot(s.clip, s.volume);
    }
    public void PlaySFX2(NameSFX name)
    {
        Sound s = Array.Find(sfxSounds, sound => sound.name == name.ToString());
        sfxSource.clip = s.clip;
        sfxSource.volume = s.volume;
        sfxSource.pitch = s.pitch;
        sfxSource.loop = s.loop;
        sfxSource.Play();
    }
}
