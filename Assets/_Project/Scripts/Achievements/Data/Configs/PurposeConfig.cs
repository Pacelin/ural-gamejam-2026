using UnityEngine;

namespace Project.Achievements
{
    [CreateAssetMenu(menuName = "Achievements/Create Purpose Config")]
    public class PurposeConfig : ScriptableObject
    {
        public EPurpose Id => _id;
        public Sprite Icon => _icon;
        
        [SerializeField] private EPurpose _id;
        [SerializeField] private Sprite _icon;
    }
}