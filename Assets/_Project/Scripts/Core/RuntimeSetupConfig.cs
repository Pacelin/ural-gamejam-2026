using Plugins.UnityEditorHelpers;
using Project.Achievements;
using UnityEngine;

namespace Project.Core
{
    [CreateResourceAsset("SO_RuntimeSetup")]
    public class RuntimeSetupConfig : ScriptableObject
    {
        public AchievementConfig[] InitialAchievements => _initialAchievements;
        
        [SerializeField] private AchievementConfig[] _initialAchievements;
    }
}