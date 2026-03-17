using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Project.Gameplay.Misc
{
    public class SubtitlesView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _minDuration = 1.5f;
        [SerializeField] private float _maxDuration = 5f;
        [SerializeField] private float _durationPerSymbol = 0.075f;
        [SerializeField] private float _delay = 0.2f;

        private void OnDestroy()
        {
            DOTween.Kill(this);
        }

        public void Setup() => _text.gameObject.SetActive(false);
        
        public void Stop()
        {
            DOTween.Kill(this);
            _text.gameObject.SetActive(false);
        }

        public void Show(SubtitleData[] datas)
        {
            Stop();
            var sequence = DOTween.Sequence(this);
            for (int i = 0; i < datas.Length; i++)
            {
                if (i > 0)
                    sequence.AppendInterval(_delay);
                sequence.Append(ShowTween(datas[i]));
            }
        }

        private Tween ShowTween(SubtitleData data)
        {
            if (data.Duration <= 0)
                data.Duration = Mathf.Clamp(data.Text.Length * _durationPerSymbol, _minDuration, _maxDuration);
            return DOTween.Sequence()
                .AppendCallback(() =>
                {
                    _text.text = data.Text;
                    _text.gameObject.SetActive(true);
                    _text.alpha = 0;
                })
                .Append(_text.DOFade(1, 0.15f))
                .AppendInterval(data.Duration)
                .Append(_text.DOFade(0, 0.15f))
                .AppendCallback(() =>
                {
                    _text.gameObject.SetActive(false);
                });
        }
    }
}