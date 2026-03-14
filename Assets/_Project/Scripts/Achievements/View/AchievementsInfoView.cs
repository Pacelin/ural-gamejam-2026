using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Achievements
{
    public class AchievementsInfoView : MonoBehaviour
    {
        public Button ClaimRewardsButton => _claimRewardsButton;
        
        [SerializeField] private TMP_Text _captionText;
        [SerializeField] private TMP_Text _descriptionText;
        [Space]
        [SerializeField] private RectTransform _purposesContainer;
        [SerializeField] private PurposeView _purposePrefab;
        [SerializeField] private GameObject _rewardsBlock;
        [SerializeField] private RectTransform _rewardsContainer;
        [SerializeField] private RewardView _rewardPrefab;
        [Space]
        [SerializeField] private Button _claimRewardsButton;
        [SerializeField] private GameObject _rewardsClaimedMark;

        public void SetRewardsBlockActive(bool isActive) => _rewardsBlock.SetActive(isActive);
        public void SetCaption(string caption) => _captionText.text = caption;
        public void SetDescription(string description) => _descriptionText.text = description;
        public PurposeView CreatePurposeItem() => Instantiate(_purposePrefab, _purposesContainer);
        public RewardView CreateRewardItem() => Instantiate(_rewardPrefab, _rewardsContainer);

        public void SetState(bool isCompleted, bool rewardsClaimed)
        {
            _claimRewardsButton.gameObject.SetActive(isCompleted && !rewardsClaimed);
            _rewardsClaimedMark.gameObject.SetActive(isCompleted && rewardsClaimed);
        }
    }
}