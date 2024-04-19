using UnityEngine;
using Zenject;

namespace aprilJam
{
  public class SailorInstaller : MonoInstaller
  {
    [SerializeField] private GameObject sailor;
    public override void InstallBindings()
    {
      Container
        .Bind<Sailor>()
        .FromNewComponentOn(sailor)
        .AsSingle()
        .NonLazy();

      Container
        .Bind<Movement>()
        .FromNewComponentOn(sailor)
        .AsSingle()
        .NonLazy();
    }
  }
}