using Plugins.Audio;
using Project.Gameplay.Misc;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class PropsCodeButton : InteractableObjectWithCursor
    {
        private enum EBehaviour
        {
            Increase,
            Decrease
        }

        protected override ECursorState HoverCursorState => ECursorState.HoverPointer;
        protected override ECursorState DownCursorState => ECursorState.DownPointer;

        [SerializeField] private Transform _soundPoint;
        [SerializeField] private EBehaviour _behaviour;
        [SerializeField] private PropsCodeText _target;
        [SerializeField] private SoundEvent _downSound;
        [SerializeField] private SoundEvent _upSound;
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private Material _defaultMaterial;
        [SerializeField] private Material _downMaterial;

        private bool _isDown;
        
        protected override void OnInteract()
        {
            if (_behaviour == EBehaviour.Increase)
                _target.Increase();
            else
                _target.Decrease();
        }

        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _renderer.sharedMaterial = _defaultMaterial;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            if (_isDown)
                _renderer.sharedMaterial = _defaultMaterial;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            _isDown = true;
            _downSound.PlayOneShotInPoint(_soundPoint.position);
            _renderer.sharedMaterial = _downMaterial;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            _isDown = false;
            _upSound.PlayOneShotInPoint(_soundPoint.position);
            _renderer.sharedMaterial = _defaultMaterial;
        }
    }
}