using Plugins.Audio;
using Project.Gameplay.Misc;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class PropsQuestionButton : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverPointer;
        protected override ECursorState DownCursorState => ECursorState.DownPointer;

        [SerializeField] private string _text;
        [SerializeField] private SoundEvent _downSound;
        [SerializeField] private SoundEvent _upSound;

        private SubtitlesService _service;
        
        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _service = resolver.Resolve<SubtitlesService>();
        }

        protected override void OnInteract()
        {
            _service.Show(_text);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            _downSound.PlayOneShotInPoint(transform.position);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            _upSound.PlayOneShotInPoint(transform.position);
        }
    }
}