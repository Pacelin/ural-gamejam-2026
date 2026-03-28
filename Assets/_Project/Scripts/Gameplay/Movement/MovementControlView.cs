using Project.Gameplay.Misc;
using UnityEngine;

namespace Project.Gameplay.Movement
{
    public class MovementControlView : MonoBehaviour
    {
        [SerializeField] private GameObject _rootObject;
        [SerializeField] private MovementControlItemView _rotateLeftControl;
        [SerializeField] private MovementControlItemView _rotateRightControl;
        [SerializeField] private MovementControlItemView _moveBackControl;

        public void Setup(MovementService service, CursorService cursorService)
        {
            _rotateLeftControl.Setup(service, cursorService, MovementControlItemView.EType.RotateLeft);
            _rotateRightControl.Setup(service, cursorService, MovementControlItemView.EType.RotateRight);
            _moveBackControl.Setup(service, cursorService, MovementControlItemView.EType.MoveBack);
        }

        public void EnableControls() => _rootObject.SetActive(true);
        public void DisableControls() => _rootObject.SetActive(false);
        
        public void UpdateControlsFor(MovementPoint point)
        {
            _rotateRightControl.gameObject.SetActive(point.RightPoint);
            _rotateLeftControl.gameObject.SetActive(point.LeftPoint);
            _moveBackControl.gameObject.SetActive(point.BackPoint || point.UsePreviousPointWhenBack);
        }
    }
}