using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class SubtitleInteractableObject : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverQuestion;
        protected override ECursorState DownCursorState => ECursorState.HoverQuestion;

        [SerializeField] private string _text;

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
    }
}