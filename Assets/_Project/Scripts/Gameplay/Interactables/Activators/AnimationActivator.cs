using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public class AnimationActivator : PuzzleActivator
    {
        [SerializeField] private Animation _animation;

        public override void Activate() => _animation.Play();
    }
}