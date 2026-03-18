using Plugins.UnityEditorHelpers;
using UnityEngine;

namespace Project.Gameplay.Movement
{
    [CreateResourceAsset("SO_MovementConfig")]
    public class MovementConfig : ScriptableObject
    {
        public float MoveDurationPerMeter = 0.5f;
        public float MinMoveDuration = 0.5f;
        public float MaxMoveDuration = 1.5f;
    }
}