using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Achievements
{
    public class AchievementsNotificationWindowView : MonoBehaviour
    {
        public Button GoToButton => _goToButton;
        public string ActiveAchievementId => _activeAchievementId;
        
        [SerializeField] private Image _blinkImage;
        [SerializeField] private Button _goToButton;
        [SerializeField] private CanvasGroup _canvasGroup;
        
        private Tween _notifyTween;
        private string _activeAchievementId;

        private void OnDisable()
        {
            if (_notifyTween is { active: true })
                _notifyTween.Kill();
        }

        public void Notify(string id)
        {
            _activeAchievementId = id;
            if (_notifyTween is not { active: true })
            {
                _notifyTween = DOTween.Sequence()
                    .AppendCallback(() =>
                    {
                        gameObject.SetActive(true);
                        _blinkImage.color = Color.white;
                        _canvasGroup.alpha = 1;
                    })
                    .Append(_blinkImage.DOFade(0, 0.1f))
                    .AppendInterval(1f)
                    .Append(_canvasGroup.DOFade(0, 0.3f))
                    .AppendCallback(() =>
                    {
                        gameObject.SetActive(false);
                    });
            }
        }
    }
}