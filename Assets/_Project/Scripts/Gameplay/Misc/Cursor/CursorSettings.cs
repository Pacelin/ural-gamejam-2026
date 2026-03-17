using Plugins.UnityEditorHelpers;
using UnityEngine;

namespace Project.Gameplay.Misc
{
    [CreateResourceAsset("SO_CursorSettings")]
    public class CursorSettings : ScriptableObject
    {
        public CursorData GrabItem;
        public CursorData HoldItem;
        public CursorData Walk;
        public CursorData Question;
        public CursorData Pointer;
    }
}