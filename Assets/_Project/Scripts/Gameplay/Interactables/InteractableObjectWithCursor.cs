using Project.Gameplay.Misc;
using UnityEngine.EventSystems;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public abstract class InteractableObjectWithCursor : InteractableObject, 
        IPointerEnterHandler, IPointerExitHandler,
        IPointerDownHandler, IPointerUpHandler
    {
        protected abstract ECursorState HoverCursorState { get; }
        protected abstract ECursorState DownCursorState { get; }

        public SubtitlesService SubtitlesService => _subtitlesService;
        
        private CursorService _cursorService;
        private SubtitlesService _subtitlesService;
        private ECursorState _activeCursor;
        private bool _hover;
        private bool _down;

        protected override void Initialize(IObjectResolver resolver)
        {
            _cursorService = resolver.Resolve<CursorService>();
            _subtitlesService = resolver.Resolve<SubtitlesService>();
            _activeCursor = ECursorState.None;
        }

        protected virtual void OnDisable()
        {
            _down = false;
            _hover = false;
            UpdateCursor();
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            _hover = true;
            UpdateCursor();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _hover = false;
            UpdateCursor();
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            _down = true;
            UpdateCursor();
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            _down = false;
            UpdateCursor();
        }

        protected void UpdateCursor()
        {
            var newCursor = ECursorState.None;
            if (_hover)
                newCursor = _down ? DownCursorState : HoverCursorState;

            if (_activeCursor == newCursor)
                return;
            
            _cursorService.DisableCursorState(_activeCursor);
            _activeCursor = newCursor;
            _cursorService.EnableCursorState(_activeCursor);
        }
    }
}
