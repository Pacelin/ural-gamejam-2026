using Plugins.Audio;
using Project.Gameplay.Misc;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Gameplay.Interactables
{
    public class PropsInteractionSound : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverPointer;
        protected override ECursorState DownCursorState => ECursorState.DownPointer;

        [SerializeField] private Transform _soundPoint;
        [SerializeField] private bool _useDownSound;
        [SerializeField] private SoundEvent _downSound;
        [SerializeField] private bool _useUpSound;
        [SerializeField] private SoundEvent _upSound;

        protected override void OnInteract() { }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            if (_useDownSound)
                _downSound.PlayOneShotInPoint(_soundPoint.position);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            if (_useUpSound)
                _upSound.PlayOneShotInPoint(_soundPoint.position);
        }
    }
}