using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class GameSetting : BaseSingleton<GameSetting>
{
    [Header("Audio Mixer Settings")]
    [SerializeField] private AudioMixer audioMixer;
    private const string MasterKey = "MasterVolume";
    private const string MusicKey = "MusicVolume";
    private const string SFXKey = "SFXVolume";


    [Header("Audio Normal Settings")]
    private const string AudioToggleKey = "AudioToggle";
    private const string AudioValueKey = "AudioValue";


    [Header("Performance Settings")]
    private const string TargetFPSKey = "TargetFPS";

    
    protected override void Start()
    {
        SetTargetFPS(60);
        ApplyAllVolume();
    }
    
    #region AudioMixer
    public void SetMasterVolume(float value)
    {
        SetVolume(MasterKey, "MasterVolume", value);
    }
    // Music
    public void SetMusicVolume(float value)
    {
        SetVolume(MusicKey, "MusicVolume", value);
    }
    // SFX
    public void SetSFXVolume(float value)
    {
        SetVolume(SFXKey, "SFXVolume", value);
    }



    
    // Common method to set volume
    /// <summary>
    /// Sets the volume for a specific audio category and saves it to PlayerPrefs.
    /// </summary>
    /// <param name="key">The PlayerPrefs key to store the volume value.</param>
    /// <param name="exposedParam">The exposed parameter name in the AudioMixer.</param>
    /// <param name="value">The volume value to set (0 to 1).</param>
    private void SetVolume(string key, string exposedParam, float value)
    {
        if(audioMixer == null)
        {
            Debug.LogError("AudioMixer is not assigned!");
            return;
        }

        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat(exposedParam, dB);

        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
        Debug.Log($"Set {exposedParam} to {value} ({dB} dB)");
    }
    public float GetMusicVolume() => PlayerPrefs.GetFloat(MusicKey, 1f);
    public float GetSFXVolume() => PlayerPrefs.GetFloat(SFXKey, 1f);
    public float GetMasterVolume() => PlayerPrefs.GetFloat(MasterKey, 1f);
    
    public void ApplyAllVolume()
    {
        //SetMasterVolume(GetMasterVolume());
        SetMusicVolume(GetMusicVolume());
        SetSFXVolume(GetSFXVolume());
    }
    #endregion
    #region AudioNormal
    public void SetAudioWithToggle(bool isOn)
    {
        AudioListener.volume = isOn ? 1 : 0;
        PlayerPrefs.SetInt(AudioToggleKey, isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void SetAudioWithSlider(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat(AudioValueKey, value);
        PlayerPrefs.Save();
    }
    public int GetAudioWithToggle() => PlayerPrefs.GetInt(AudioToggleKey, 1);
    public float GetAudioWithSlider() => PlayerPrefs.GetFloat(AudioValueKey, 1); 
    #endregion

    #region Performance
    public int GetTargetFPS()
    {
        return PlayerPrefs.GetInt(TargetFPSKey, 60);
    }

    public void SetTargetFPS(int fps)
    {
        Application.targetFrameRate = fps;
        PlayerPrefs.SetInt(TargetFPSKey, fps);
        PlayerPrefs.Save();
    }
    #endregion
}
