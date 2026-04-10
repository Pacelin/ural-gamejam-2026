using System;
using Project.Gameplay.Misc;
using Project.Gameplay.Movement;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Project.Gameplay.Interactables
{
    [System.Serializable]
    public class PropsEvents
    {
        [SerializeField] private GameObject[] _activate;
        [SerializeField] private GameObject[] _deactivate;
        [SerializeField] private GameObject[] _destroy;
        [SerializeField] private PropsLock[] _locks;
        [SerializeField] private PuzzleActivator[] _activators;
        [SerializeField] private SubtitleTrigger _subtitleTrigger;

        public void Prepare()
        {
            foreach (var obj in _activate)
                if (obj)
                    obj.SetActive(false);
            foreach (var obj in _deactivate)
                if (obj)
                    obj.SetActive(true);
        }

        public void Trigger(SubtitlesService subtitlesService)
        {
            if (_subtitleTrigger)
                _subtitleTrigger.Trigger(subtitlesService);
            
            foreach (var obj in _activate)
                if (obj)
                    obj.SetActive(true);
            foreach (var obj in _deactivate)
                if (obj)
                    obj.SetActive(false);
            foreach (var obj in _destroy)
                if (obj)
                    Object.Destroy(obj);
            foreach (var obj in _locks)
                if (obj)
                    obj.Unlock();
            foreach (var activator in _activators)
                if (activator)
                    activator.Activate();
        }
    }
}