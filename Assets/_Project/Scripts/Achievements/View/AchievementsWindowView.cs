using System;
using Project.Core.Misc;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Achievements
{
    public class AchievementsWindowView : MonoBehaviour, IEscapeWindow
    {
        public Button BackButton => _backButton;
        public AchievementsListView ListView => _listView;
        public AchievementsInfoView InfoView => _infoView;
        
        [SerializeField] private Button _backButton;
        [SerializeField] private AchievementsListView _listView;
        [SerializeField] private AchievementsInfoView _infoView;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}