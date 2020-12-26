using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    public class Input : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action Pressed = delegate { };
        public event Action PressedUp = delegate { };

        public void OnPointerDown(PointerEventData eventData)
        {
            Pressed.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            PressedUp.Invoke();
        }
    }
}