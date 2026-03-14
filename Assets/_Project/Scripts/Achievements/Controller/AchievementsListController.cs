using System;
using System.Collections.Generic;
using Project.Core.Misc;
using VContainer.Unity;

namespace Project.Achievements
{
    public class AchievementsListController : IInitializable, IDisposable
    {
        public event Action<int> OnSelect;

        public AchievementConfig SelectedAchievement => _activeAchievements[_selectedIndex];
        
        private int _selectedIndex;

        private readonly AchievementsListView _listView;
        private readonly AchievementsModel _achievements;
        private readonly List<AchievementConfig> _activeAchievements;
        private readonly List<AchievementsListItemView> _activeItems;
        private readonly List<IDisposable> _itemsDisposables;

        public AchievementsListController(AchievementsListView listView, AchievementsModel achievements)
        {
            _listView = listView;
            _achievements = achievements;
            _activeAchievements = new List<AchievementConfig>();
            _activeItems = new List<AchievementsListItemView>();
            _itemsDisposables = new List<IDisposable>();
        }

        public void Initialize()
        {
            _achievements.OnAchievementBecomeAvailable += OnAchievementBecomeAvailable;
            _achievements.OnAchievementCompleted += OnAchievementCompleted;
            _achievements.OnClaimReward += OnClaimReward;
        }

        public void Dispose()
        {
            _achievements.OnAchievementBecomeAvailable -= OnAchievementBecomeAvailable;
            _achievements.OnAchievementCompleted -= OnAchievementCompleted;
            _achievements.OnClaimReward -= OnClaimReward;
            
            foreach (var itemDisposable in _itemsDisposables)
                itemDisposable.Dispose();
        }

        public void SetSelectedAchievement(AchievementConfig achievement)
        {
            var index = _activeAchievements.IndexOf(achievement);
            SetSelectedIndex(index);
        }
        
        public void SetSelectedIndex(int selectedIndex)
        {
            if (_selectedIndex == selectedIndex)
                return;
            
            _activeItems[_selectedIndex].SetSelected(false);
            _selectedIndex = selectedIndex;
            _activeItems[_selectedIndex].SetSelected(true);
            OnSelect?.Invoke(_selectedIndex);
        }
        
        public void UpdateList(bool force)
        {
            if (!force && !_listView.gameObject.activeInHierarchy)
                return;
            
            FetchActiveAchievements();
            CreateRequiredItems();
            FillItems();
        }

        private void FetchActiveAchievements()
        {
            foreach (var achievement in _achievements.GetAvailableAchievements())
                if (!_activeAchievements.Contains(achievement))
                    _activeAchievements.Add(achievement);
        }
        
        private void CreateRequiredItems()
        {
            var requiredCount = _activeAchievements.Count;
            while (_activeItems.Count != requiredCount)
            {
                var index = _activeItems.Count;
                var item = _listView.CreateItem();
                _activeItems.Add(item);
                item.SetSelected(false);
                
                _itemsDisposables.Add(item.SelectButton.SubscribeOnClick(() => 
                    SetSelectedIndex(index)));
            }
        }

        private void FillItems()
        {
            for (int i = 0; i < _activeItems.Count; i++)
            {
                if (_activeAchievements.Count <= i)
                {
                    _activeItems[i].gameObject.SetActive(false);
                    continue;
                }

                var item = _activeItems[i];
                var achievement = _activeAchievements[i];
                item.gameObject.SetActive(true);
                item.SetSelected(i == _selectedIndex);
                item.SetCaption(achievement.Caption);
                item.SetIcon(achievement.Icon);
                item.SetState(
                    _achievements.IsAchievementCompleted(achievement.Id), 
                    _achievements.IsRewardsClaimed(achievement.Id));
            }
        }

        private void OnClaimReward(string id) => UpdateList(false);
        private void OnAchievementCompleted(string id) => UpdateList(false);
        private void OnAchievementBecomeAvailable(string id) => UpdateList(false);
    }
}