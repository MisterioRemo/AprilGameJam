using UnityEngine;
using Zenject;

namespace aprilJam
{
  public class SirenInstaller : MonoInstaller
  {
    [SerializeField] private GameObject  siren;
    [SerializeField] private NotesEffect notesEffect;

    public override void InstallBindings()
    {
      Container
        .Bind<SirenSong>()
        .FromNewComponentOn(siren)
        .AsSingle()
        .NonLazy();

      Container.BindInstance(notesEffect).WhenInjectedInto<SirenSong>();

      Container
        .BindInterfacesAndSelfTo<NoteCombination>()
        .FromNew()
        .AsSingle()
        .NonLazy();
    }
  }
}