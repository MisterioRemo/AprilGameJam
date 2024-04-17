using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace aprilJam
{
    public class Sailor : MonoBehaviour
    {
       [SerializeField] private int HealsPoint = 100;
       [SerializeField] private int stamin = 100;

        private int damage;


        public void Hit(int inputDamage)
        {
            HealsPoint -= inputDamage;

        }
    }

   
}
