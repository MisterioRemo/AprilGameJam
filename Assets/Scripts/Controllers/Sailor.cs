using System;
using UnityEngine;

namespace aprilJam
{
  public class Sailor : MonoBehaviour
  {
    [SerializeField] private int HealsPoint = 100;
    [SerializeField] private int stamin = 100;

    public Action OnDeath;


    public void Hit(int inputDamage)
    {
      HealsPoint -= inputDamage;

      if (HealsPoint <= 0)
        OnDeath?.Invoke();
    }
  }
}
