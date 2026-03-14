using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Achievements
{
    public class RewardView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _text;

        public void SetIcon(Sprite icon) => _icon.sprite = icon;
        public void SetText(string text) => _text.text = text;
    }
}