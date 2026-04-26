using System;
using Project.Gameplay.Interactables;
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
            
            for (int i = 0; i < _selectors.Length; i++)
            {
                _selectors[i].OnClickEvent += OnSelectorClick;
                _selectors[i].SetCollected(_collectablesModel.IsCollected(i));
                _selectors[i].SetSelected(false);
                _contents[i].SetActive(false);
            }

            _selectors[_collectablesModel.LastSelected].SetSelected(true);
            _contents[_collectablesModel.LastSelected].SetActive(true);
        }

        private void OnDisable()
        {
            foreach (var closeButton in _closeButtons)
                closeButton.onClick.RemoveListener(Hide);
            foreach (var selector in _selectors)
                selector.OnClickEvent -= OnSelectorClick;
        }
        
        private void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnSelectorClick(CollectableSelector obj)
        {
            var index = Array.IndexOf(_selectors, obj);
            if (index == _collectablesModel.LastSelected)
                return;
            
            _selectors[_collectablesModel.LastSelected].SetSelected(false);
            _contents[_collectablesModel.LastSelected].SetActive(false);
            
            _collectablesModel.LastSelected = index;
            
            _selectors[_collectablesModel.LastSelected].SetSelected(true);
            _contents[_collectablesModel.LastSelected].SetActive(true);
        }
    }
}