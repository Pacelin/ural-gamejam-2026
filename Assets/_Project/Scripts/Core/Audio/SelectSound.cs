using Plugins.Audio;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Core.Audio
{
    public class SelectSound : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
    {
        public void OnPointerEnter(PointerEventData eventData) => AudioSystem.UI_Hover.PlayOneShot();
        public void OnPointerDown(PointerEventData eventData) => AudioSystem.UI_Select.PlayOneShot();
    }
}