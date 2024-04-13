using UnityEngine;
using Zenject;

namespace aprilJam
{
  public class SirenInstaller : MonoInstaller
  {
    [SerializeField] private GameObject siren;

    public override void InstallBindings()
    {
      Container
        .Bind<SirenSong>()
        .FromNewComponentOn(siren)
        .AsSingle()
        .NonLazy();

      Container
        .BindInterfacesAndSelfTo<NoteCombination>()
        .FromNew()
        .AsSingle()
        .NonLazy();
    }
  }
}