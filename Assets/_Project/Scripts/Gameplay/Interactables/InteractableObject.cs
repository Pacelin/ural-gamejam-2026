using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public abstract class InteractableObject : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private InteractablesManager _manager;

        protected virtual void OnValidate()
        {
            if (!_manager)
                _manager = FindFirstObjectByType<InteractablesManager>();
        }

        protected virtual void Awake() => Initialize(_manager.Resolver);

        protected abstract void Initialize(IObjectResolver resolver);

        protected abstract void OnInteract();

        public void OnPointerClick(PointerEventData eventData) => OnInteract();
    }
}