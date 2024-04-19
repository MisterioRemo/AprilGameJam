using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static aprilJam.KayCombinations;

namespace aprilJam
{
    public class KayCombinations
    {
        public interface IKeyInput
        {
            bool Performed { get; }
        }
    }
    [Serializable]
    public class KeyCombination : IKeyInput
    {
        [SerializeField] private KeyCode _first;
        [SerializeField] private KeyCode _second;
       

        public KeyCombination(KeyCode first, KeyCode second)
        {
            _first = first;
            _second = second;
        }

        public bool Performed => (Input.GetKey(_first) && Input.GetKeyDown(_second));
    }
    public class Test : MonoBehaviour
    {

        [SerializeField] private KeyCombination _keyInput;


        private void Update()
        {
            if (_keyInput.Performed)
            {
                Debug.Log("Combination performed");
            }
        }
    }

}
