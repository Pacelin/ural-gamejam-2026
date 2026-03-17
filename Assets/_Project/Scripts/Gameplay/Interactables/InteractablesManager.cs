using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class InteractablesManager : MonoBehaviour
    {
        public IObjectResolver Resolver => _resolver;
        
        [Inject] private IObjectResolver _resolver;
    }
}