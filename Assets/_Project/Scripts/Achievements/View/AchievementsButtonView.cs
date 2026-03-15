using UnityEngine;
using UnityEngine.UI;

namespace Project.Achievements
{
    public class AchievementsButtonView : MonoBehaviour
    {
        public Button Button => _button;
        
        [SerializeField] private Button _button;
    }
}