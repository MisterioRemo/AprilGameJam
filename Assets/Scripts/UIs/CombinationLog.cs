using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace aprilJam
{
  public class CombinationLog : MonoBehaviour
  {
    #region PARAMETERS
    [Inject] private SirenSong sirenSong;

    [SerializeField] private NotesColor colorPalette;
    [SerializeField] private GameObject loglinePrefab;

    [SerializeField]
    private int   maxLoglineCount;
    private int   loglineCount;
    private Color transparentColor;

    private Dictionary<Note, Color> paletteMap;
    private Queue<LogLine>          loglinesQueue;
    #endregion

    #region LIFECYCLE
    private void Awake()
    {
      loglinesQueue    = new Queue<LogLine>();
      loglineCount     = 0;
      paletteMap       = new Dictionary<Note, Color>();
      transparentColor = new Color(1f, 1f, 1f, 0f);

      foreach (var elem in colorPalette.Value)
        paletteMap.Add(elem.note, elem.color);
    }
    private void Start()
    {
      sirenSong.OnSinging += AddLoglineToUI;
    }

    private void OnDestroy()
    {
      sirenSong.OnSinging -= AddLoglineToUI;
    }
    #endregion

    #region METHODS
    private void AddLoglineToUI(List<Note> _notes)
    {
      var log = Instantiate(loglinePrefab, transform).GetComponent<LogLine>();
      int i = 0;

      for (; i < _notes.Count; ++i)
        log.Images[i].color = paletteMap[_notes[i]];
      for (; i < log.Images.Length; ++i)
        log.Images[i].color = transparentColor;

      EnqueueLogline(log);
    }

    private void EnqueueLogline(LogLine _logline)
    {
      if (loglineCount == maxLoglineCount)
      {
        var log = loglinesQueue.Dequeue();
        Destroy(log.gameObject);
        loglineCount--;
      }

      loglinesQueue.Enqueue(_logline);
      loglineCount++;
    }
    #endregion
  }
}
