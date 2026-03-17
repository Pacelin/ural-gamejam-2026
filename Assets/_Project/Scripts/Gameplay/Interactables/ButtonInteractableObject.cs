using Project.Gameplay.Misc;

namespace Project.Gameplay.Interactables
{
    public class ButtonInteractableObject : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverPointer;
        protected override ECursorState DownCursorState => ECursorState.DownPointer;

        protected override void OnInteract()
        {
        }
    }
}