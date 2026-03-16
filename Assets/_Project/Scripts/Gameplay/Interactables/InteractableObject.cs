using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public abstract class InteractableObject : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        protected IObjectResolver Resolver => _resolver;
        
        [Inject] private IObjectResolver _resolver;
        
        protected abstract void OnInteract();
        protected abstract void OnInteractorEnter();
        protected abstract void OnInteractorExit();

        public void OnPointerClick(PointerEventData eventData) => OnInteract();
        public void OnPointerEnter(PointerEventData eventData) => OnInteractorEnter();
        public void OnPointerExit(PointerEventData eventData) => OnInteractorExit();
    }
}