using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Juex.Input
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