using Project.Gameplay.Misc;
using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public class PropsCursor : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => _hover;
        protected override ECursorState DownCursorState => _down;

        [SerializeField] private ECursorState _hover = ECursorState.HoverQuestion;
        [SerializeField] private ECursorState _down = ECursorState.HoverQuestion;
        [SerializeField] private PropsEvents _onInteract;

        protected override void OnInteract()
        {
            _onInteract.Trigger(SubtitlesService);
        }
    }
}