using Plugins.Audio;
using Project.Gameplay.Interactables;
using Project.Gameplay.Misc;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class BasementConsoleFloppyEjectButton : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => 
            _blocked ? ECursorState.None : ECursorState.HoverPointer;
        protected override ECursorState DownCursorState => 
            _blocked ? ECursorState.None : ECursorState.DownPointer;
        
        [SerializeField] private BasementConsoleFloppy _consoleFloppy;
        [SerializeField] private Transform _soundPoint;
        [SerializeField] private GameObject _defaultObject;
        [SerializeField] private GameObject _downObject;
        [SerializeField] private GameObject _blockedObject;
        [SerializeField] private SoundEvent _downSound;
        [SerializeField] private SoundEvent _upSound;
        [SerializeField] private bool _blockedOnAwake;

        private bool _down;
        private bool _blocked;

        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _blocked = _blockedOnAwake;
        }

        public void SetBlock(bool block)
        {
            if (_blocked == block)
                return;
            
            _blocked = block;
            UpdateCursor();
            if (_down)
                _down = false;
            
            _defaultObject.SetActive(!block);
            _downObject.SetActive(false);
            _blockedObject.SetActive(block);
        }
        
        protected override void OnInteract()
        {
            if (_blocked)
                return;
            _consoleFloppy.Eject();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            if (_down)
            {
                _down = false;
                _defaultObject.SetActive(true);
                _downObject.SetActive(false);
                _blockedObject.SetActive(false);
            }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            
            if (_blocked)
                return;
            
            _down = true;
            _defaultObject.SetActive(false);
            _downObject.SetActive(true);
            _blockedObject.SetActive(false);
            _downSound.PlayOneShotInPoint(_soundPoint.position);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            
            if (_blocked)
                return;
            
            _down = false;
            _defaultObject.SetActive(true);
            _downObject.SetActive(false);
            _blockedObject.SetActive(false);
            _upSound.PlayOneShotInPoint(_soundPoint.position);
        }
    }
}