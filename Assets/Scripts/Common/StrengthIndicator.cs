using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Common
{
    public class StrengthIndicator : MonoBehaviour
    {
        [SerializeField] private PressedTimeCalculator _pressedTime = null;
        [SerializeField] private RectTransform _rectTransform = null;
        [SerializeField] private Input _input = null;
        [SerializeField] private float _backDelay = 2;
        [SerializeField] private float _minStrenght = 300f;
        [SerializeField] private float _multiplier = 2;

        private Tween _moveTween = null;

        private Coroutine _coroutine = null;
        private Coroutine _synchRoutine = null;

        private WaitForSeconds _wait = null;
        
        private WaitForEndOfFrame _endOfFrame = null;

        private void Awake()
        {
            _endOfFrame = new WaitForEndOfFrame();
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
        
        private void OnPressed()
        {
            if(_synchRoutine != null)
                StopCoroutine(_synchRoutine);
            
            _synchRoutine = StartCoroutine(Synchronization());
        }
        
        private void OnPressedUp()
        {
            _moveTween?.Kill();

            if (transform.localPosition.y < _minStrenght)
            {
                _moveTween = _rectTransform.DOLocalMoveY(0, 0);
            }

            if(_coroutine != null)
                StopCoroutine(_coroutine);
            
            if(_synchRoutine != null)
                StopCoroutine(_synchRoutine);

            _coroutine = StartCoroutine(BackRoutine());
        }

        private IEnumerator BackRoutine()
        {
            yield return _wait;

            _moveTween?.Kill();

            _moveTween = _rectTransform.DOLocalMoveY(0, 0);
        }

        private IEnumerator Synchronization()
        {
            _pressedTime.ResetNumber();
            
            while (true)
            {
                transform.localPosition = Vector3.up * (_pressedTime.GetIncreasedNumber() * _multiplier);
                
                yield return _endOfFrame;
            }
        }
    }
}