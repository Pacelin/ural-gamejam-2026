using Project.Core.Misc;
using Project.Editor.Gameplay;
using Project.Gameplay.Misc;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class GoToBasementInteractable : InteractableObjectWithCursor
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverWalkObject;
        protected override ECursorState DownCursorState => ECursorState.HoverWalkObject;

        private SceneLoader _sceneLoader;
        private CollectablesModel _collectables;
        
        protected override void Initialize(IObjectResolver resolver)
        {
            base.Initialize(resolver);
            _sceneLoader = resolver.Resolve<SceneLoader>();
            _collectables = resolver.Resolve<CollectablesModel>();
        }

        protected override void OnInteract()
        {
            _sceneLoader.Load(4, builder => builder.RegisterInstance(_collectables), 3);
        }
    }
}