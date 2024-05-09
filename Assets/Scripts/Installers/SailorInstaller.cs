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
        .FromComponentOn(sailor)
        .AsSingle()
        .NonLazy();

      Container
        .Bind<SailorMovement>()
        .FromNewComponentOn(sailor)
        .AsSingle()
        .NonLazy();
    }
  }
}