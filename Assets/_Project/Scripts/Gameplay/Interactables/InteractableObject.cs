using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public abstract class InteractableObject : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
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
        protected abstract void OnInteractorEnter();
        protected abstract void OnInteractorExit();

        public void OnPointerClick(PointerEventData eventData) => OnInteract();
        public void OnPointerEnter(PointerEventData eventData) => OnInteractorEnter();
        public void OnPointerExit(PointerEventData eventData) => OnInteractorExit();
    }
}