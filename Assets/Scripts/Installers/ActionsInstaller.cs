using UnityEngine;
using Zenject;

namespace aprilJam
{
  public class ActionsInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container
        .Bind<AprilJamInputActions>()
        .FromNew()
        .AsSingle()
        .OnInstantiated<AprilJamInputActions>
          ((context, inputActions) => inputActions.Player.Enable())
        .NonLazy();
    }
  }
}