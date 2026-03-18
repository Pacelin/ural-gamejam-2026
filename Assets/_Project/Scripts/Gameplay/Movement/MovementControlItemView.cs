using Project.Gameplay.Misc;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Gameplay.Movement
{
    public class MovementControlItemView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public enum EType
        {
            RotateRight,
            RotateLeft,
            MoveBack
        }

        private MovementService _service;
        private CursorService _cursorService;
        private EType _type;
        private ECursorState _cursor;
        private bool _hover;
        
        public void Setup(MovementService service, CursorService cursorService, EType type)
        {
            _service = service;
            _cursorService = cursorService;
            _type = type;
            
            if (_type == EType.RotateLeft)
                _cursor = ECursorState.RotateLeft;
            else if (_type == EType.RotateRight)
                _cursor = ECursorState.RotateRight;
            else
                _cursor = ECursorState.MoveBack;
        }

        private void OnDisable()
        {
            if (_hover)
            {
                _cursorService.DisableCursorState(_cursor);
                _hover = false;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _cursorService.EnableCursorState(_cursor);
            _hover = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _cursorService.DisableCursorState(_cursor);
            _hover = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_type == EType.RotateLeft)
                _service.RotateLeft();
            else if (_type == EType.RotateRight)
                _service.RotateRight();
            else
                _service.MoveBack();
        }
    }
}