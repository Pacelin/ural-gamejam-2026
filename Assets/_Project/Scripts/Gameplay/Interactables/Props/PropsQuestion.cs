using Plugins.Audio;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class PropsQuestion : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverQuestion;
        protected override ECursorState DownCursorState => ECursorState.HoverQuestion;

        [SerializeField] private string _text;
        [SerializeField] private bool _playSoundOnQuestion;
        [SerializeField] private SoundEvent _sound;

        private SubtitlesService _service;
        
        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _service = resolver.Resolve<SubtitlesService>();
        }

        protected override void OnInteract()
        {
            if (_playSoundOnQuestion)
                _sound.PlayOneShotInPoint(transform.position);
            _service.Show(_text);
        }
    }
}