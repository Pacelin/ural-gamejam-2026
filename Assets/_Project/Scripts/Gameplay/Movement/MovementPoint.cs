using System.Collections.Generic;
using Plugins.Audio;
using Project.Gameplay.Misc;
using UnityEngine;

namespace Project.Gameplay.Movement
{
    public class MovementPoint : MonoBehaviour
    {
        public MovementPoint RightPoint => _rightPoint;
        public MovementPoint LeftPoint => _leftPoint;
        public MovementPoint BackPoint => _backPoint;
        public bool UsePreviousPointWhenBack => _usePreviousPointWhenBack;
        public IReadOnlyList<GameObject> ActiveWhenOnPoint => _activeWhenOnPoint;
        public bool UseSoundWhenBack => _useSoundWhenBack;

        public bool HaveCustomMoveSound => _haveCustomMoveSound;
        public SoundEvent CustomMoveSound => _customMoveSound;
        
        [SerializeField] private MovementPoint _rightPoint;
        [SerializeField] private MovementPoint _leftPoint;
        [SerializeField] private MovementPoint _backPoint;
        [SerializeField] private bool _useSoundWhenBack = false;
        [SerializeField] private bool _usePreviousPointWhenBack = false;
        [SerializeField] private GameObject[] _activeWhenOnPoint;
        [SerializeField] private SubtitleTrigger _subtitleTrigger;
        [Space]
        [SerializeField] private bool _haveCustomMoveSound = false;
        [SerializeField] private SoundEvent _customMoveSound;

        private void Awake()
        {
            foreach (var go in _activeWhenOnPoint)
                go.SetActive(false);
            gameObject.SetActive(false);
        }

        public void TriggerSubtitles(SubtitlesService service)
        {
            if (_subtitleTrigger)
                _subtitleTrigger.Trigger(service);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var selectedGo = UnityEditor.Selection.activeGameObject;
            if (selectedGo)
            {
                var selectedPoint = selectedGo.GetComponent<MovementPoint>();
                if (selectedPoint &&
                    (selectedPoint._leftPoint == this ||
                     selectedPoint._rightPoint == this ||
                     selectedPoint._backPoint == this))
                {
                    Gizmos.color = Color.yellow;
                }
            }
            
            var t = transform;
            var p = t.position;
            Gizmos.DrawSphere(p, 0.05f);
            Gizmos.DrawLine(p, p + t.forward);
        }

        private void OnDrawGizmosSelected()
        {
            var t = transform;
            var p = t.position;
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(p, 0.05f);
            Gizmos.DrawLine(p, p + t.forward);
        }
#endif
    }
}