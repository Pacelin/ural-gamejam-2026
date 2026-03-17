using Project.Core.Audio;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Achievements
{
    public class AchievementsListItemView : MonoBehaviour
    {
        public Button SelectButton => _selectButton;
        
        [SerializeField] private Button _selectButton;
        [SerializeField] private GameObject _completedMark;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _caption;
        [SerializeField] private SelectSound _selectSound;
        [Space]
        [SerializeField] private GameObject _defaultBackground;
        [SerializeField] private GameObject _selectedBackground;
        [SerializeField] private Color _selectedTextColor;
        [SerializeField] private Color _defaultTextColor;

        public void SetIcon(Sprite icon) => _icon.sprite = icon;
        public void SetCaption(string caption) => _caption.text = caption;

        public void SetSelected(bool selected)
        {
            _defaultBackground.gameObject.SetActive(!selected);
            _selectedBackground.gameObject.SetActive(selected);
            _caption.color = selected ? _selectedTextColor : _defaultTextColor;
            _selectSound.enabled = !selected;
        }

        public void SetState(bool completed)
        {
            _completedMark.SetActive(completed);
        }
    }
}