using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer.Unity;

namespace Project.Achievements
{
    public class AchievementsInfoController : IInitializable, IDisposable
    {
        private readonly AchievementsListController _listController;
        private readonly AchievementsInfoView _infoView;
        private readonly AchievementsModel _achievements;
        private readonly PurposesModel _purposes;
        private readonly List<PurposeView> _purposeViews;
        private readonly List<RewardView> _rewardViews;
        
        public AchievementsInfoController(
            AchievementsListController listController, 
            AchievementsInfoView infoView,
            AchievementsModel achievements,
            PurposesModel purposes)
        {
            _listController = listController;
            _infoView = infoView;
            _achievements = achievements;
            _purposes = purposes;

            _purposeViews = new List<PurposeView>();
            _rewardViews = new List<RewardView>();
        }
        
        public void Initialize()
        {
            _infoView.ClaimRewardsButton.onClick.AddListener(OnClaimClick);
            
            _listController.OnSelect += OnSelect;
            
            _achievements.OnClaimReward += UpdateAchievement;
            _achievements.OnAchievementCompleted += UpdateAchievement;
            _purposes.OnPurposeUpdate += OnPurposeUpdate;
        }

        public void Dispose()
        {
            _infoView.ClaimRewardsButton.onClick.RemoveListener(OnClaimClick);
            
            _listController.OnSelect -= OnSelect;
            
            _achievements.OnClaimReward -= UpdateAchievement;
            _achievements.OnAchievementCompleted -= UpdateAchievement;
        }

        public void UpdateSelection(bool force)
        {
            if (!force && !_infoView.gameObject.activeInHierarchy)
                return;
            
            var achievement = _listController.SelectedAchievement;
            _infoView.SetCaption(achievement.Caption);
            _infoView.SetDescription(achievement.Description);
            _infoView.SetRewardsBlockActive(achievement.Rewards.Count > 0);
            _infoView.SetState(
                _achievements.IsAchievementCompleted(achievement.Id),
                _achievements.IsRewardsClaimed(achievement.Id));
            
            FillPurposes(achievement);
            FillRewards(achievement);
        }

        private void FillPurposes(AchievementConfig achievement)
        {
            var purposes = achievement.PurposeTargets;
            while (_purposeViews.Count < purposes.Count)
                _purposeViews.Add(_infoView.CreatePurposeItem());

            for (int i = 0; i < _purposeViews.Count; i++)
            {
                if (purposes.Count <= i)
                {
                    _purposeViews[i].gameObject.SetActive(false);
                    continue;
                }

                var purposeView = _purposeViews[i];
                purposeView.gameObject.SetActive(true);
                purposeView.SetIcon(purposes[i].Purpose.Icon);
                purposeView.SetShortDescription(purposes[i].Text);

                var targetProgress = purposes[i].Target;
                var purposeProgress = Mathf.Min(_purposes.GetPurposeProgress(purposes[i].Purpose.Id), targetProgress);
                purposeView.SetProgress(purposeProgress, targetProgress);
            }
        }

        private void FillRewards(AchievementConfig achievement)
        {
            var rewards = achievement.Rewards;
            while (_rewardViews.Count < rewards.Count)
                _rewardViews.Add(_infoView.CreateRewardItem());
            
            for (int i = 0; i < _rewardViews.Count; i++)
            {
                if (rewards.Count <= i)
                {
                    _purposeViews[i].gameObject.SetActive(false);
                    continue;
                }

                var rewardView = _rewardViews[i];
                rewardView.gameObject.SetActive(true);
                rewardView.SetIcon(rewards[i].Icon);
                rewardView.SetText(rewards[i].Text);
            }
        }
        
        private void UpdateAchievement(string id) => UpdateSelection(false);

        private void OnPurposeUpdate(EPurpose purpose, int current)
        {
            if (_infoView.gameObject.activeInHierarchy)
            {
                var selectedAchievement = _listController.SelectedAchievement;
                if (selectedAchievement.PurposeTargets.Any(t => t.Purpose.Id == purpose))
                    UpdateAchievement(selectedAchievement.Id);
            }
        }
        
        private void OnClaimClick() => _achievements.ClaimRewards(_listController.SelectedAchievement.Id);
        private void OnSelect(int index) => UpdateSelection(false);
    }
}