using Project.Achievements;
using Project.Core.Misc;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Core.Pause
{
    public class PauseWindow : MonoBehaviour, IEscapeWindow
    {
        public Button ResumeButton => _resumeButton;
        public Button MainMenuButton => _mainMenuButton;
        public AchievementsButtonView AchievementsButton => _achievementsButton;
        
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private AchievementsButtonView _achievementsButton;

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);

    }
}