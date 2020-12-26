﻿using System.Collections;
using DG.Tweening;
using UnityEngine;
using Input = Juex.Input.Input;

namespace DefaultNamespace
{
    public class StrengthIndicator : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform = null;
        [SerializeField] private Input _input = null;
        [SerializeField] private float _maxYPosition = 1500f;
        [SerializeField] private float _maxReachTime = 2f;
        [SerializeField] private float _backDelay = 2;

        private Tween _moveTween = null;

        private Coroutine _coroutine = null;

        private WaitForSeconds _wait = null;

        private void Awake()
        {
            _wait = new WaitForSeconds(_backDelay);
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
        
        private void OnPressedUp()
        {
            _moveTween?.Kill();

            if (transform.localPosition.y < 280)
            {
                _moveTween = _rectTransform.DOLocalMoveY(0, 0);
            }

            if(_coroutine != null)
                StopCoroutine(_coroutine);
            
            _coroutine = StartCoroutine(BackRoutine());
        }

        private void OnPressed()
        {
            _moveTween?.Kill();

            _moveTween = _rectTransform.DOLocalMoveY(_maxYPosition, _maxReachTime)
                .SetEase(Ease.Linear);
        }

        private IEnumerator BackRoutine()
        {
            yield return _wait;

            _moveTween?.Kill();

            _moveTween = _rectTransform.DOLocalMoveY(0, 0);
        }
    }
}