using System;
using System.Collections.Generic;
using UnityEngine;

namespace aprilJam
{
  public class AudioManager : MonoBehaviour
  {
    [Serializable]
    private struct Sound
    {
      public string    name;
      public AudioClip clip;
    }

    #region CONSTANTS
    private const int MAX_PLAYING_SONG_COUNT = 3;
    #endregion

    #region PARAMETERS
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource songSource;
    [SerializeField] private List<Sound> musicSoundsList;
    [SerializeField] private List<Sound> sfxSoundsList;
    [SerializeField] private List<Sound> songSoundsList;

    private Dictionary<string, AudioClip> musicSounds;
    private Dictionary<string, AudioClip> sfxSounds;
    private Dictionary<string, AudioClip> songSounds;

    private int   playingSongCount   = 0;
    private float approxSongDuration = 4f;
    private float songTimer          = 0f;
    #endregion

    #region PROPERTIES
    public string PlayAtStartClipName { get; set; }
    public int    SongCount => songSounds.Count;
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      musicSounds = new Dictionary<string, AudioClip>();
      sfxSounds   = new Dictionary<string, AudioClip>();
      songSounds  = new Dictionary<string, AudioClip>();

      foreach (var sound in musicSoundsList)
        musicSounds.Add(sound.name, sound.clip);
      foreach (var sound in sfxSoundsList)
        sfxSounds.Add(sound.name, sound.clip);
      foreach (var sound in songSoundsList)
        songSounds.Add(sound.name, sound.clip);
    }

    private void Start()
    {
      musicSource.loop = true;
      PlayMusic(PlayAtStartClipName);
    }

    private void Update()
    {
      if (playingSongCount == 0)
        return;

      songTimer += Time.deltaTime;
      if (songTimer >= approxSongDuration)
      {
        playingSongCount = Mathf.Max(0, playingSongCount - 1);
        songTimer        = 0f;
      }
    }
    #endregion

    #region INTERFACE
    public void PlayMusic(string _name)
    {
      if (musicSounds.TryGetValue(_name, out AudioClip clip))
      {
        musicSource.clip = clip;
        musicSource.Play();
      }
    }

    public void PlaySFX(string _name)
    {
      if (sfxSounds.TryGetValue(_name, out AudioClip clip))
        sfxSource.PlayOneShot(clip);
    }

    public void PlaySong(string _name)
    {
      if (playingSongCount >= MAX_PLAYING_SONG_COUNT)
        return;

      if (songSounds.TryGetValue(_name, out AudioClip clip))
      {
        songSource.PlayOneShot(clip);
        playingSongCount++;
      }
    }

    public void ToggleMusic()
    {
      musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
      sfxSource.mute = !sfxSource.mute;
    }

    public void ToggleSong()
    {
      songSource.mute = !songSource.mute;
    }

    public void MusicVolume(float _volume)
    {
      musicSource.volume = _volume;
    }

    public void SFXVolume(float _volume)
    {
      sfxSource.volume = _volume;
    }

    public void SongVolume(float _volume)
    {
      songSource.volume = _volume;
    }
    #endregion
  }
}
