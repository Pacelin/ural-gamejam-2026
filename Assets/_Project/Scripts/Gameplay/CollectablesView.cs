using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Project.Editor.Gameplay
{
    public class CollectablesView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private void OnDestroy() => DOTween.Kill(_text);

        public void SetText(int current, int required) => _text.text = current + "/" + required;

        public void Ping()
        {
            DOTween.Kill(_text);
            var t = _text.transform;
            DOTween.Sequence(_text)
                .Append(t.DOScale(1.15f, 0.1f).SetEase(Ease.OutCubic))
                .Append(t.DOScale(1f, 0.1f).SetEase(Ease.InCubic));
        }
    }
}