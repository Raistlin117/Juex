using System;
using System.Collections;
using UnityEngine;
using Input = Juex.Input.Input;

namespace Common
{
    public class PressedTimeCalculator : MonoBehaviour
    {
        public event Action NumberIncreased = delegate { };
        
        [SerializeField] private Input _input = null;
        [SerializeField] private float _increase = 0.2f;
        
        private Coroutine _coroutine = null;

        private float _number = 0;

        // prevent second tap until player grounded
        private bool _allowed = true;

        private void OnEnable()
        {
            _input.Pressed += OnPressed;
            _input.PressedUp += OnPressedUp;
        }
        
        private void OnDisable()
        {
            _input.Pressed -= OnPressed;
            _input.PressedUp -= OnPressedUp;
        }

        private void OnPressed()
        {
            if (!_allowed) return;
            
            _coroutine = StartCoroutine(IncreaserRoutine());
        }
        
        private void OnPressedUp()
        {
            if (!_allowed) return;

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            NumberIncreased.Invoke();
        }

        public float GetIncreasedNumber()
        {
            return _number;
        }

        private IEnumerator IncreaserRoutine()
        {
            _number = 0;
            
            while (true)
            {
                _number += _increase;
                
                yield return null;
            }
        }
    }
}