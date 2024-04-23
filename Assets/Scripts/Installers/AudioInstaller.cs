using UnityEngine;
using Zenject;

namespace aprilJam
{
  public class AudioInstaller : MonoInstaller
  {
    [SerializeField] private GameObject audioManagerPrefab;
    [SerializeField] private string     playAtStartClipName;

    public override void InstallBindings()
    {
      Container
        .Bind<AudioManager>()
        .FromComponentInNewPrefab(audioManagerPrefab)
        .AsSingle()
        .OnInstantiated<AudioManager>
          ((context, audioManager) => audioManager.PlayAtStartClipName = playAtStartClipName)
        .NonLazy();
    }
  }
}