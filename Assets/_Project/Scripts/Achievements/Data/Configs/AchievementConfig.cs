using System.Collections.Generic;
using UnityEngine;

namespace Project.Achievements
{
    [CreateAssetMenu(menuName = "Achievements/Create Achievement")]
    public class AchievementConfig : ScriptableObject
    {
        public string Id => _id;
        public Sprite Icon => _icon;
        public string Caption => _caption;
        public string Description => _description;
        public IReadOnlyList<PurposeTarget> PurposeTargets => _purposeTargets;

        [SerializeField] private string _id;
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _caption;
        [SerializeField] private string _description;
        [SerializeField] private PurposeTarget[] _purposeTargets;
    }
}