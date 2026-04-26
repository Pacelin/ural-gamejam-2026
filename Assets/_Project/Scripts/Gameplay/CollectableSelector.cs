using System;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Editor.Gameplay
{
    public class CollectableSelector : MonoBehaviour
    {
        public event Action<CollectableSelector> OnClickEvent;
        
        [SerializeField] private Button _button;
        [SerializeField] private GameObject[] _activeWhenCollected;
        [SerializeField] private GameObject[] _activeWhenNotCollected;
        [SerializeField] private GameObject[] _activeWhenSelected;
        [SerializeField] private GameObject[] _activeWhenNotSelected;

        private void OnEnable() => _button.onClick.AddListener(OnClick);
        private void OnDisable() => _button.onClick.RemoveListener(OnClick);

        public void SetSelected(bool selected)
        {
            foreach (var o in _activeWhenSelected)
                o.SetActive(selected);
            foreach (var o in _activeWhenNotSelected)
                o.SetActive(!selected);
        }

        public void SetCollected(bool collected)
        {
            foreach (var o in _activeWhenCollected)
                o.SetActive(collected);
            foreach (var o in _activeWhenNotCollected)
                o.SetActive(!collected);
        }

        private void OnClick() => OnClickEvent?.Invoke(this);
    }
}