using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public abstract class NotInteractableObject : MonoBehaviour
    {
        [SerializeField] private InteractablesManager _manager;

        protected SubtitlesService SubtitlesService => _subtitlesService;
        
        private SubtitlesService _subtitlesService;
        
        protected virtual void OnValidate()
        {
            if (!_manager)
                _manager = FindFirstObjectByType<InteractablesManager>();
        }

        protected virtual void Awake()
        {
            _subtitlesService = _manager.Resolver.Resolve<SubtitlesService>();
            Initialize(_manager.Resolver);
        } 
        protected abstract void Initialize(IObjectResolver resolver);
    }
}