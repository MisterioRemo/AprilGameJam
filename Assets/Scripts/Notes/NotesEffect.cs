using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace aprilJam
{
  public class NotesEffect : MonoBehaviour
  {
    #region PARAMETERS
    [SerializeField] private NotePrefabs notePrefabs;
    [SerializeField] private GameObject  noteContainer;

    private Dictionary<Note, GameObject> noteToPrefab;

    [Inject] private AudioManager audioCtrl;
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      noteToPrefab = new Dictionary<Note, GameObject>();

      foreach (var elem in notePrefabs.Value)
        noteToPrefab.Add(elem.note, elem.prefab);
    }
    #endregion

    #region INTERFACE
    public void PlayEffect(Note _note)
    {
      if (noteToPrefab.TryGetValue(_note, out GameObject prefab))
      {
        var note = Instantiate(prefab, noteContainer.transform);
        LeanTween.scale(note, new Vector3(1.2f, 1.2f, 1.2f), 0.3f).setEase(LeanTweenType.easeOutQuint);
        audioCtrl.PlaySFX("Note");
      }
    }

    public void ResetAll()
    {
      foreach (Transform child in noteContainer.transform)
        Destroy(child.gameObject);
    }
    #endregion
  }
}
