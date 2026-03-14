using UnityEngine;
using UnityEngine.UI;

namespace Project.Achievements
{
    public class AchievementsButtonView : MonoBehaviour
    {
        public Button Button => _button;
        
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _hasRewardsMark;

        public void SetHasRewards(bool hasRewards) => _hasRewardsMark.SetActive(hasRewards);
    }
}