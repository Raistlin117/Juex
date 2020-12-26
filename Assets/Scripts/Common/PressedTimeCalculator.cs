using System;
using System.Collections;
using UnityEngine;

namespace Common
{
    public class PressedTimeCalculator : MonoBehaviour
    {
        public event Action NumberIncreased = delegate { };
        
        [SerializeField] private Input _input = null;
        [SerializeField] private float _increase = 1f;
        [SerializeField] private float _minNumber = 100f;
        [SerializeField] private float _maxNumber = 350f;
        
        private Coroutine _coroutine = null;

        private WaitForEndOfFrame _endOfFrame = null;

        private float _number = 0;

        private void Awake()
        {
            _endOfFrame = new WaitForEndOfFrame();
        }

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
            _coroutine = StartCoroutine(IncreaserRoutine());
        }
        
        private void OnPressedUp()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            
            if (_number < _minNumber) return;

            NumberIncreased.Invoke();
        }

        public float GetIncreasedNumber()
        {
            return _number;
        }

        private IEnumerator IncreaserRoutine()
        {
            _number = 0;
            
            while (_number < _maxNumber)
            {
                _number += _increase;

                Debug.Log(_number);
                
                yield return _endOfFrame;
            }
            
            NumberIncreased.Invoke();
        }
    }
}