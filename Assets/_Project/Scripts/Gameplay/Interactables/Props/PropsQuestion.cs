using Plugins.Audio;
using Project.Gameplay.Misc;
using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public class PropsQuestion : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverQuestion;
        protected override ECursorState DownCursorState => ECursorState.HoverQuestion;

        [SerializeField] private string _text;
        [SerializeField] private bool _playSoundOnQuestion;
        [SerializeField] private SoundEvent _sound;

        protected override void OnInteract()
        {
            if (_playSoundOnQuestion)
                _sound.PlayOneShotInPoint(transform.position);
            SubtitlesService.Show(_text);
        }
    }
}