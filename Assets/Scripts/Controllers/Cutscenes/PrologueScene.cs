using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using Zenject;

namespace aprilJam
{
  public class PrologueScene : MonoBehaviour
  {
    private enum PrologueStage : byte
    {
      NotStarted,
      FirstIntro,
      UserInput,
      SecondIntro
    }

    #region PARAMETERS
    [Header("Video")]
    [SerializeField] private VideoPlayer     videoPlayer;
    [SerializeField] private List<VideoClip> videos;

    [Header("Canvas")]
    [SerializeField] private NotePrefabs notePrefabs;
    [SerializeField] private GameObject  btnContainer;
    [SerializeField] private GameObject  tooltip;

    [Space(16)]

    [Tooltip("Note combination for sailor possessing.")]
    [SerializeField] private Note[] noteCombination;

    [Tooltip("Scene that will be loaded after cutscene.")]
    [SerializeField] private string gameSceneName;

    private IEnumerator<VideoClip>       videoEnumerator;
    private PrologueStage                stage;
    private IDisposable                  inputListener;
    private int                          noteIndex;
    private Dictionary<Note, GameObject> noteToPrefab;
    private List<GameObject>             notesInGrid;

    [Inject] private AudioManager audioCtrl;
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      notesInGrid                   = new List<GameObject>();
      noteToPrefab                  = new Dictionary<Note, GameObject>();
      stage                         = PrologueStage.NotStarted;
      videoEnumerator               = videos.Skip(2 * GameState.Instance.DeathCount).GetEnumerator();
      videoPlayer.loopPointReached += OnVideoEnded;

      foreach (var elem in notePrefabs.Value)
        noteToPrefab.Add(elem.note, elem.prefab);

      PrepareVideo();
    }

    private void Start()
    {
      stage = PrologueStage.FirstIntro;
      StartVideo();
    }

    private void OnDestroy()
    {
      videoPlayer.loopPointReached -= OnVideoEnded;
      inputListener?.Dispose();
    }
    #endregion

    #region CALLBACKS
    private void OnVideoEnded(VideoPlayer _player)
    {
      if (stage == PrologueStage.FirstIntro)
      {
        ClearVideo();
        PrepareVideo();

        stage         = PrologueStage.UserInput;
        inputListener = InputSystem.onAnyButtonPress.Call(ProcessingUserInput);
        ShowButtons();
      }
      else if (stage == PrologueStage.SecondIntro)
      {
        ClearVideo();
        SceneManager.LoadScene(gameSceneName);
      }
    }

    private void ProcessingUserInput(InputControl _button)
    {
      if (_button is KeyControl key)
      {
        if (KeyToNote.Map.TryGetValue(key.keyCode, out Note note) &&
            noteIndex < noteCombination.Length                    &&
            note == noteCombination[noteIndex])
        {
          LeanTween.scale(notesInGrid[noteIndex], new Vector3(1.2f, 1.2f, 1.2f), 0.3f).setEase(LeanTweenType.easeOutQuint);
          audioCtrl.PlaySFX("Note");
          if (++noteIndex == noteCombination.Length)
            ShowTooltip();
        }
        else if (noteIndex == noteCombination.Length &&
                 (key.keyCode == Key.Space || key.keyCode == Key.Enter))
        {
          stage = PrologueStage.SecondIntro;
          inputListener.Dispose();
          HideButtons();
          StartVideo();
        }
        else if (noteIndex != noteCombination.Length)
        {
          noteIndex = 0;
          foreach(var elem in notesInGrid)
            LeanTween.scale(elem, new Vector3(1f, 1f, 1f), 0.3f).setEase(LeanTweenType.easeOutQuint);
        }
      }
    }
    #endregion

    #region VIDEO CONTROL
    private void PrepareVideo()
    {
      if (videoEnumerator.MoveNext())
      {
        videoPlayer.clip = videoEnumerator.Current;
        videoPlayer.Prepare();
        videoPlayer.Stop();
      }
    }

    private void StartVideo()
    {
      videoPlayer.Play();
    }

    private void ClearVideo()
    {
      videoPlayer.Stop();
      videoPlayer.clip = null;
    }
    #endregion

    #region CANVAS
    private void ShowButtons()
    {
      btnContainer.SetActive(true);

      var grid             = btnContainer.GetComponentInChildren<GridLayoutGroup>();
      grid.constraintCount = noteCombination.Length;

      foreach(var note in noteCombination)
        notesInGrid.Add(Instantiate(noteToPrefab[note], grid.transform));
    }

    private void HideButtons()
    {
      btnContainer.SetActive(false);
    }

    private void ShowTooltip()
    {
      tooltip.SetActive(true);
    }
    #endregion

    #region INTERFACE
    public void ResetVideo(List<VideoClip> _videos)
    {
      videos          = _videos;
      videoEnumerator = videos.GetEnumerator();
    }
    #endregion
  }
}
