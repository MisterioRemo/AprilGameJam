using UnityEngine;
using Zenject;

namespace aprilJam
{
  public class Siren : MonoBehaviour
  {
    private enum AnimTrigger : byte
    {
      Sad,
      Anger,
      Song,
      Love
    }

    #region PROPERTIES
    private Animator animator;

    [Inject] private Sailor       sailor;
    [Inject] private SirenSong    sirenSong;
    [Inject] private Game         gameCtrl;
    [Inject] private AudioManager audioCtrl;
    #endregion

    #region LIFECYCLE
    private void Start()
    {
      animator = GetComponentInChildren<Animator>();

      sailor.OnTakingDamage += PlayDamageAnimation;
      sirenSong.OnSinging   += PlaySong;

      InvokeRepeating("PlayLoveAnimation", 0f, 30f);
    }

    private void OnDestroy()
    {
      sailor.OnTakingDamage -= PlayDamageAnimation;
      sirenSong.OnSinging   -= PlaySong;
    }

    private void OnTriggerEnter(Collider _other)
    {
      GameObject obj = _other.transform.root.gameObject;

      if (obj.CompareTag("Sailor") && obj.GetComponentInChildren<SailorSkin>() is SailorSkin skin)
        gameCtrl.LoadEndingScene(skin.SailorProfession == Profession.Sailor ? EndingType.Happy : EndingType.Sad);
    }
    #endregion

    #region METHODS
    private void PlayAnimation(AnimTrigger _trigger, int _index = -1)
    {
      if (_index != -1)
        animator.SetInteger(_trigger.ToString() + "Index", _index);
      animator.SetTrigger(_trigger.ToString());
    }

    private void PlayDamageAnimation(int _health)
    {
      if (Random.value > 0.5f)
        PlayAnimation(AnimTrigger.Sad, Random.Range(0, 3));
      else
        PlayAnimation(AnimTrigger.Anger, Random.Range(0, 2));
    }

    private void PlaySongAnimation()
    {
      PlayAnimation(AnimTrigger.Song, Random.Range(0, 3));
    }

    private void PlayLoveAnimation()
    {
      PlayAnimation(AnimTrigger.Love);
    }

    private void PlaySong(System.Collections.Generic.List<Note> _notes)
    {
      PlaySongAnimation();
      audioCtrl.PlaySong("Song" + Random.Range(0, audioCtrl.SongCount));
    }
    #endregion
  }
}
