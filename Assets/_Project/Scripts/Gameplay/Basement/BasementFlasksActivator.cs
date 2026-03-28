using Plugins.Audio;
using Project.Gameplay.Interactables;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementFlasksActivator : PuzzleActivator
    {
        [SerializeField] private GameObject[] _deactivateObjects;
        [SerializeField] private GameObject[] _activateObjects;
        [SerializeField] private Transform[] _flasksCaps;
        [SerializeField] private Transform[] _flasksOpenPoints;
        [Space]
        [SerializeField] private Transform _soundPoint;
        [SerializeField] private SoundEvent _activateSound;

        private bool _activated = false;
        
        public override void Activate()
        {
            if (_activated)
                return;
            foreach (var obj in _deactivateObjects)
                obj.SetActive(false);
            foreach (var obj in _activateObjects)
                obj.SetActive(true);

            for (int i = 0; i < _flasksCaps.Length; i++)
            {
                _flasksCaps[i].position = _flasksOpenPoints[i].position;
                _flasksCaps[i].rotation = _flasksOpenPoints[i].rotation;
            }
            
            _activateSound.PlayOneShotInPoint(_soundPoint.position);
            _activated = true;
        }
    }
}