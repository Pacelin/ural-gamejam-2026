using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Project.Editor.Gameplay
{
    public class CollectablesView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Transform _transform;

        private void OnDestroy() => DOTween.Kill(_transform);

        public void SetText(int current, int required) => _text.text = current + "/" + required;

        public void Ping()
        {
            DOTween.Kill(_transform);
            DOTween.Sequence(_transform)
                .Append(_transform.DOScale(1.15f, 0.1f).SetEase(Ease.OutCubic))
                .Append(_transform.DOScale(1f, 0.1f).SetEase(Ease.InCubic));
        }
    }
}