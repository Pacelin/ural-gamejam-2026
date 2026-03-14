using System;
using VContainer.Unity;

namespace Project.Achievements
{
    public class AchievementsButtonController : IInitializable, IDisposable
    {
        private readonly AchievementsButtonView _view;
        private readonly AchievementsModel _achievements;
        private readonly AchievementsWindowController _windowController;
        
        public AchievementsButtonController(AchievementsButtonView view, AchievementsModel achievements,
            AchievementsWindowController windowController)
        {
            _view = view;
            _achievements = achievements;
            _windowController = windowController;
        }
        
        public void Initialize()
        {
            _view.Button.onClick.AddListener(OnClick);
            _achievements.OnAchievementCompleted += TryUpdateAchievement;
            _achievements.OnClaimReward += TryUpdateAchievement;
        }

        public void Dispose()
        {
            _view.Button.onClick.RemoveListener(OnClick);
            _achievements.OnAchievementCompleted -= TryUpdateAchievement;
            _achievements.OnClaimReward -= TryUpdateAchievement;
        }

        private void TryUpdateAchievement(string id)
        {
            if (_view.gameObject.activeInHierarchy)
                UpdateState();
        }

        public void UpdateState()
        {
            _view.SetHasRewards(_achievements.HasAchievementWithRewards());
        }

        private void OnClick() => _windowController.Show();
    }
}