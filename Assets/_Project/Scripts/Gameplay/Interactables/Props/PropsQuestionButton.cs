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
        [SerializeField] private SoundEvent _sound;

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
            _sound.PlayOneShotInPoint(transform.position);
        }
    }
}