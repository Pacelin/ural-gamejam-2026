using Project.Core.Misc;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Project.Gameplay.Interactables.Intro
{
    public class IntroEnvelopeButton : NotInteractableObject
    {
        [SerializeField] private Button _button;

        private SceneLoader _sceneLoader;
        
        protected override void Initialize(IObjectResolver resolver)
        {
            _sceneLoader = resolver.Resolve<SceneLoader>();
        }
        
        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            _sceneLoader.Load(3, 2);
        }
    }
}