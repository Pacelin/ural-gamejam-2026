using Plugins.Audio;
using Project.Editor.Gameplay;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class PropsCollectable : InteractableObjectWithCursor
    {
        [SerializeField] private SoundEvent _pickupSound;
        [SerializeField] private PropsEvents _afterPickup;
        
        private CollectablesModel _collectables;

        protected override ECursorState HoverCursorState => ECursorState.HoverPickup;
        protected override ECursorState DownCursorState => ECursorState.HoverPickup;

        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _collectables = resolver.Resolve<CollectablesModel>();
            _afterPickup.Prepare();
        }

        protected override void OnInteract()
        {
            _collectables.Add();
            _pickupSound.PlayOneShot();
            _afterPickup.Trigger();
        }
    }
}