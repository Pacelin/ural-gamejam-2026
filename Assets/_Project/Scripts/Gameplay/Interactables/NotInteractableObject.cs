using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public abstract class NotInteractableObject : MonoBehaviour
    {
        [SerializeField] private InteractablesManager _manager;

        protected virtual void OnValidate()
        {
            if (!_manager)
                _manager = FindFirstObjectByType<InteractablesManager>();
        }

        protected virtual void Awake() => Initialize(_manager.Resolver);
        protected abstract void Initialize(IObjectResolver resolver);
    }
}