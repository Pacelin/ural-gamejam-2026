using Plugins.Audio;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class StackingPuzzleItemInteractableObject : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverPickup;
        protected override ECursorState DownCursorState => ECursorState.HoverPickup;

        [SerializeField] private PropsEvents _onTake;
        [SerializeField] private StackingPuzzleStack _stack;
        [SerializeField] private SoundEvent takeSound;

        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _onTake.Prepare();
        }

        protected override void OnInteract()
        {
            takeSound.PlayOneShotInPoint(transform.position);
            _onTake.Trigger(SubtitlesService);
            _stack.Stack();
        }
    }
}