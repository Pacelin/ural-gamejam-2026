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

        public void Setup() => _text.alpha = 0;
        public void SetText(int current, int required) => _text.text = current + "/" + required;

        public void Ping()
        {
            DOTween.Kill(_text);
            DOTween.Sequence(_text)
                .Append(_text.DOFade(1, 0.2f))
                .AppendInterval(2f)
                .Append(_text.DOFade(0, 0.2f));
        }
    }
}