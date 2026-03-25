using Project.Gameplay.Interactables;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementLightActivator : PuzzleActivator
    {
        [SerializeField] private BasementLight[] _lights;
        
        public override void Activate()
        {
            foreach (var l in _lights)
                l.Activate();
        }
    }
}