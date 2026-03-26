using Plugins.Audio;
using Project.Gameplay.Interactables;
using Project.Gameplay.Misc;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Gameplay.Basement
{
    public class BasementConsoleButton : InteractableObjectWithCursor
    {
        public bool Selected => _selected;
        
        protected override ECursorState HoverCursorState => ECursorState.HoverPointer;
        protected override ECursorState DownCursorState => ECursorState.DownPointer;

        [SerializeField] private Transform _soundPoint;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _defaultMaterial;
        [SerializeField] private Material _downMaterial;
        [SerializeField] private Material _selectedMaterial;
        [SerializeField] private SoundEvent _downSound;
        [SerializeField] private SoundEvent _upSound;

        private bool _down;
        private bool _selected;

        public void SetSelected(bool selected)
        {
            _selected = selected;
            UpdateMaterial();
        }
        
        protected override void OnInteract() { }

        protected override void OnDisable()
        {
            base.OnDisable();
            if (_down)
            {
                _down = false;
                UpdateMaterial();
            }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            _down = true;
            _selected = !_selected;
            UpdateMaterial();
            _downSound.PlayOneShotInPoint(_soundPoint.position);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            _down = false;
            UpdateMaterial();
            _upSound.PlayOneShotInPoint(_soundPoint.position);
        }

        private void UpdateMaterial()
        {
            if (_down)
                _meshRenderer.sharedMaterial = _downMaterial;
            else if (_selected)
                _meshRenderer.sharedMaterial = _selectedMaterial;
            else
                _meshRenderer.sharedMaterial = _defaultMaterial;
        }
    }
}