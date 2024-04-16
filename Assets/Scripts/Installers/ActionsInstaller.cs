using UnityEngine;
using Zenject;

namespace aprilJam
{
  public class ActionsInstaller : MonoInstaller
  {
    [SerializeField] private bool isMenu = false;

    public override void InstallBindings()
    {
      Container
        .Bind<AprilJamInputActions>()
        .FromNew()
        .AsSingle()
        .OnInstantiated<AprilJamInputActions>
          ((context, inputActions) => { if (isMenu) inputActions.Menu.Enable();
                                        else inputActions.Player.Enable();
                                      })
        .NonLazy();
    }
  }
}