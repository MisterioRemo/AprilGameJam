using ModestTree;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

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

    #region PARAMETERS
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private List<Sound> musicSoundsList;
    [SerializeField] private List<Sound> sfxSoundsList;

    private Dictionary<string, AudioClip> musicSounds;
    private Dictionary<string, AudioClip> sfxSounds;
    #endregion

    #region PROPERTIES
    public string PlayAtStartClipName { get; set; }
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      musicSounds = new Dictionary<string, AudioClip>();
      sfxSounds   = new Dictionary<string, AudioClip>();

      foreach (var sound in musicSoundsList)
        musicSounds.Add(sound.name, sound.clip);
      foreach (var sound in sfxSoundsList)
        sfxSounds.Add(sound.name, sound.clip);
    }

    private void Start()
    {
      musicSource.loop = true;
      PlayMusic(PlayAtStartClipName);
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
    #endregion
  }
}
