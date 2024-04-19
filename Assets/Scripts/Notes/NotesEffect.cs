using System;
using System.Collections.Generic;
using UnityEngine;

namespace aprilJam
{
  [RequireComponent(typeof(AudioSource))]
  public class NotesEffect : MonoBehaviour
  {
    [Serializable]
    private struct Effects
    {
      public GameObject uiElement;
      public AudioClip  sound;
    }

    [Serializable]
    private struct NoteEffect
    {
      public Note    note;
      public Effects effects;
    }

    #region PARAMETERS
    [SerializeField] private List<NoteEffect> effectList;

    private AudioSource               audioSource;
    private Dictionary<Note, Effects> effectMap;
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      audioSource = GetComponent<AudioSource>();
      effectMap   = new Dictionary<Note, Effects>();

      foreach (var elem in effectList)
        effectMap.Add(elem.note, elem.effects);
    }
    #endregion

    #region INTERFACE
    public void PlayEffect(Note _note)
    {
      Effects effects;

      if (!effectMap.TryGetValue(_note, out effects))
        return;

      LeanTween.scale(effects.uiElement, new Vector3(1.2f, 1.2f, 1.2f), 0.3f).setEase(LeanTweenType.easeOutQuint);
      // audioSource.PlayOneShot(effects.sound, volume);
    }

    public void ResetAll()
    {
      foreach (var effect in effectMap)
        LeanTween.scale(effect.Value.uiElement, new Vector3(1f, 1f, 1f), 0.3f).setEase(LeanTweenType.easeOutQuint);
    }
    #endregion
  }
}
