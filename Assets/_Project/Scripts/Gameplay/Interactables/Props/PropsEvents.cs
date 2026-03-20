using UnityEngine;

namespace Project.Gameplay.Interactables
{
    [System.Serializable]
    public class PropsEvents
    {
        [SerializeField] private GameObject[] _activate;
        [SerializeField] private GameObject[] _deactivate;
        [SerializeField] private GameObject[] _destroy;
        [SerializeField] private PropsLock[] _locks;

        public void Prepare()
        {
            foreach (var obj in _activate)
                if (obj)
                    obj.SetActive(false);
            foreach (var obj in _deactivate)
                if (obj)
                    obj.SetActive(true);
        }

        public void Trigger()
        {
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
        }
    }
}