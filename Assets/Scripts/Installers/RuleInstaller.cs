using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace aprilJam
{
  public class RuleInstaller : MonoInstaller
  {
    [SerializeField] private GameObject combinationWindow;
    [SerializeField] private GameObject menuWindow;

    public override void InstallBindings()
    {
      Container
        .BindInterfacesAndSelfTo<Game>()
        .FromNew()
        .AsSingle()
        .NonLazy();

      Container.BindInstance(new List<GameObject>() { combinationWindow, menuWindow }).WhenInjectedInto<Game>();
    }
  }
}