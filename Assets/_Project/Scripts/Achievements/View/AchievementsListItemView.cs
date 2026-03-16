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
        [SerializeField] private GameObject _selectedMark;
        [SerializeField] private GameObject _completedMark;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _caption;
        [SerializeField] private SelectSound _selectSound;

        public void SetIcon(Sprite icon) => _icon.sprite = icon;
        public void SetCaption(string caption) => _caption.text = caption;

        public void SetSelected(bool selected)
        {
            _selectedMark.gameObject.SetActive(selected);
            _selectSound.enabled = !selected;
        }

        public void SetState(bool completed)
        {
            _completedMark.SetActive(completed);
        }
    }
}