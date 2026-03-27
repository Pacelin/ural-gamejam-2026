using Plugins.Audio;
using Project.Gameplay.Interactables;
using Project.Gameplay.Misc;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Gameplay.Basement
{
    public class BasementConsoleEnterButton : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => 
            _blocked ? ECursorState.None : ECursorState.HoverPointer;
        protected override ECursorState DownCursorState => 
            _blocked ? ECursorState.None : ECursorState.DownPointer;
        
        [SerializeField] private BasementConsole _console;
        [SerializeField] private Transform _soundPoint;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _defaultMaterial;
        [SerializeField] private Material _downMaterial;
        [SerializeField] private Material _blockedMaterial;
        [SerializeField] private SoundEvent _downSound;
        [SerializeField] private SoundEvent _upSound;

        private bool _down;
        private bool _blocked;

        public void SetBlock(bool block)
        {
            if (_blocked == block)
                return;
            
            _blocked = block;
            UpdateCursor();
            if (_down)
                _down = false;
            
            _meshRenderer.sharedMaterial = block ? _blockedMaterial : _defaultMaterial;
        }
        
        protected override void OnInteract()
        {
            if (_blocked)
                return;
            _console.EnterCommand();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            if (_down)
            {
                _down = false;
                _meshRenderer.sharedMaterial = _defaultMaterial;
            }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            
            if (_blocked)
                return;
            
            _down = true;
            _meshRenderer.sharedMaterial = _downMaterial;
            _downSound.PlayOneShotInPoint(_soundPoint.position);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            
            if (_blocked)
                return;
            
            _down = false;
            _meshRenderer.sharedMaterial = _defaultMaterial;
            _upSound.PlayOneShotInPoint(_soundPoint.position);
        }
    }
}