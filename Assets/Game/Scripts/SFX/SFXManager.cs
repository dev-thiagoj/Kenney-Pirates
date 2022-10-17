using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [Header("References")]
    public List<MusicSetup> musicSetups;
    public List<SFXSetup> sfxSetups;
    [SerializeField] AudioSource musicSource;

    private void OnValidate()
    {
        if (musicSource == null) 
            musicSource = GetComponent<AudioSource>();
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
