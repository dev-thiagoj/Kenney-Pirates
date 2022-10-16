using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [Header("References")]
    public List<MusicSetup> musicSetups;
    public List<SFXSetup> sfxSetups;
    public AudioSource musicSource;

    /*[Header("Sound On/Off")]
    public GameObject buttonSoundOff;
    public GameObject buttonSoundOn;*/

    private void OnValidate()
    {
        if (musicSource == null) musicSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        //buttonSoundOff.SetActive(false);
        //buttonSoundOn.SetActive(true);
    }

    public void PlayMusicbyType(MusicType musicType)
    {
        var music = GetMusicByType(musicType);

        musicSource.clip = music.audioClip;
        musicSource.Play();
    }

    public MusicSetup GetMusicByType(MusicType musicType)
    {
        return musicSetups.Find(i => i.musicType == musicType);
    }

    public SFXSetup GetSFXByType(SFXType sfxType)
    {
        return sfxSetups.Find(i => i.sfxType == sfxType);
    }

    public void TurnMusicOff()
    {
        musicSource.enabled = false;
        musicSource.Pause();
        //buttonSoundOn.SetActive(false);
        //buttonSoundOff.SetActive(true);
    }

    public void TurnMusicOn()
    {
        musicSource.enabled = true;
        musicSource.Play();
        //buttonSoundOff.SetActive(false);
        //buttonSoundOn.SetActive(true);
    }
}

public enum MusicType
{
    NONE,
    AMBIENCE,
    LEVEL_WIN,
    LEVEL_LOSE,
}

[System.Serializable]
public class MusicSetup
{
    public MusicType musicType;
    public AudioClip audioClip;
}

public enum SFXType
{
    NONE,
    CLICK_BUTTON,
    CANNON_SHOOT,
    SHOOT_HIT,
    DEATH_EXPLOSION,
}

[System.Serializable]
public class SFXSetup
{
    public SFXType sfxType;
    public AudioClip audioClip;
}
