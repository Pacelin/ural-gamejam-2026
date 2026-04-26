using System;
using DG.Tweening;
using Project.Gameplay.Interactables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Project.Editor.Gameplay
{
    public class CollectablesWindow : NotInteractableObject
    {
        [SerializeField] private Button[] _closeButtons;
        [SerializeField] private CollectableSelector[] _selectors;
        [SerializeField] private GameObject[] _contents;

        private CollectablesModel _collectablesModel;
        
        protected override void Initialize(IObjectResolver resolver)
        {
            _collectablesModel = resolver.Resolve<CollectablesModel>();
        }
        
        private void OnEnable()
        {
            foreach (var closeButton in _closeButtons)
                closeButton.onClick.AddListener(Hide);
            foreach (var )
        }

        private void OnDisable()
        {
            foreach (var closeButton in _closeButtons)
                closeButton.onClick.RemoveListener(Hide);
        }
        
        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }

    public class CollectableSelector : MonoBehaviour
    {
        public Button Button => _button;
        
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _activeWhenCollected;
        [SerializeField] private GameObject _activeWhenNotCollected;
        [SerializeField] private GameObject _activeWhenSelected;

        public void SetSelected(bool selected)
        {
            _activeWhenSelected.SetActive(selected);
        }

        public void SetCollected(bool collected)
        {
            _activeWhenCollected.SetActive(collected);
            _activeWhenNotCollected.SetActive(!collected);
        }
    }
    
    public class CollectablesView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private CollectablesWindow _window;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Transform _transform;
        
        private void OnDestroy() => DOTween.Kill(_transform);

        public void SetText(int current, int required) => _text.text = current + "/" + required;

        public void Ping()
        {
            DOTween.Kill(_transform);
            DOTween.Sequence(_transform)
                .Append(_transform.DOScale(1.15f, 0.1f).SetEase(Ease.OutCubic))
                .Append(_transform.DOScale(1f, 0.1f).SetEase(Ease.InCubic));
        }
    }
}