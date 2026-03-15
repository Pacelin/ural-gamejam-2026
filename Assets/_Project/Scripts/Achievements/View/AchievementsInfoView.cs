using TMPro;
using UnityEngine;

namespace Project.Achievements
{
    public class AchievementsInfoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _captionText;
        [SerializeField] private TMP_Text _descriptionText;
        [Space]
        [SerializeField] private RectTransform _purposesContainer;
        [SerializeField] private PurposeView _purposePrefab;
        [SerializeField] private GameObject _completedMark;

        public void SetCaption(string caption) => _captionText.text = caption;
        public void SetDescription(string description) => _descriptionText.text = description;
        public PurposeView CreatePurposeItem() => Instantiate(_purposePrefab, _purposesContainer);

        public void SetState(bool isCompleted)
        {
            _completedMark.gameObject.SetActive(isCompleted);
        }
    }
}