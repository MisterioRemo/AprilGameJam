using UnityEngine;
using Zenject;

namespace aprilJam
{
  public class RuleInstaller : MonoInstaller
  {
    [SerializeField] private GameObject game;

    public override void InstallBindings()
    {
      Container
        .Bind<Game>()
        .FromComponentOn(game)
        .AsSingle()
        .NonLazy();
    }
  }
}