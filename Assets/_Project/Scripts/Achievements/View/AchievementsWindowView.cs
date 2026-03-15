using Project.Core.Misc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Achievements
{
    public class AchievementsWindowView : MonoBehaviour, IEscapeWindow
    {
        public Button CloseButton => _closeButton;
        public AchievementsListView ListView => _listView;
        public AchievementsInfoView InfoView => _infoView;

        [SerializeField] private Button _closeButton;
        [SerializeField] private TMP_Text _achievementsText;
        [SerializeField] private AchievementsListView _listView;
        [SerializeField] private AchievementsInfoView _infoView;

        public void SetAchievementsCount(int current, int max)
        {
            _achievementsText.text = $"Достижения ({current}/{max})";
        }

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