using DG.Tweening;
using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public class OpenTrigger : PuzzleTrigger
    {
        [SerializeField] private Transform _doorOrigin;
        [SerializeField] private Transform _openedPoint;
        [SerializeField] private GameObject[] _activateWhenTriggered;

        private void Awake()
        {
            foreach (var obj in _activateWhenTriggered)
                obj.SetActive(false);
        }

        public override void OnComplete()
        {
            _doorOrigin.DORotateQuaternion(_openedPoint.rotation, 0.4f);
            foreach (var obj in _activateWhenTriggered)
                obj.SetActive(true);
        }
    }
}