using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Gameplay.Movement
{
    public class MovementBlockView : MonoBehaviour
    {
        [SerializeField] private Image _fadeImage;

        private void OnDestroy()
        {
            _fadeImage.DOKill();
        }

        public UniTask FadeIn()
        {
            return _fadeImage.DOFade(1, 0.3f).From(0)
                .OnStart(() => _fadeImage.gameObject.SetActive(true))
                .ToUniTask();
        }

        public UniTask FadeOut()
        {
            return _fadeImage.DOFade(0, 0.2f)
                .OnComplete(() => _fadeImage.gameObject.SetActive(false))
                .ToUniTask();
        }

        public void Block()
        {
            _fadeImage.gameObject.SetActive(false);
            gameObject.SetActive(true);
        }

        public void Unblock()
        {
            gameObject.SetActive(false);
        }
    }
}