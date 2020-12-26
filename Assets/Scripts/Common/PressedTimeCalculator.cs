﻿using System;
using System.Collections;
using UnityEngine;

namespace Common
{
    public class PressedTimeCalculator : MonoBehaviour
    {
        public event Action NumberIncreased = delegate { };
        
        [SerializeField] private Input _input = null;
        [SerializeField] private float _increase = 0.2f;
        [SerializeField] private float _minNumber = 100f;
        [SerializeField] private float _maxNumber = 500;
        
        private Coroutine _coroutine = null;

        private float _number = 0;
        
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
                
                yield return null;
            }
            
            NumberIncreased.Invoke();
        }
    }
}