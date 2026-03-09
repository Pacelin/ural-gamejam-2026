using System;
using Plugins.Audio;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Plugins.Extras
{
    public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
    {
        public void OnPointerEnter(PointerEventData eventData) => AudioSystem.UI_Hover.PlayOneShot();
        public void OnPointerDown(PointerEventData eventData) => AudioSystem.UI_Click.PlayOneShot();
    }
}