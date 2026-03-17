using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Achievements
{
    public class PurposeView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _shortDescriptionText;
        [SerializeField] private TMP_Text _progressText;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _completedAlpha;
        [SerializeField] private GameObject _completedMark;

        public void SetIcon(Sprite icon) => _icon.sprite = icon;
        public void SetShortDescription(string text) => _shortDescriptionText.text = text;
        
        public void SetProgress(int current, int target)
        {
            if (current < target)
            {
                _progressText.text = current + " <size=32>из</size> " + target;
                _canvasGroup.alpha = 1;
                _progressText.gameObject.SetActive(true);
                _completedMark.gameObject.SetActive(false);
            }
            else
            {
                _canvasGroup.alpha = _completedAlpha;
                _progressText.gameObject.SetActive(false);
                _completedMark.gameObject.SetActive(true);
            }
        } 
    }
}