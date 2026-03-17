using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Project.Gameplay.Movement
{
    public class MovementFadeView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        private void OnDestroy()
        {
            _canvasGroup.DOKill();
        }

        public UniTask FadeIn()
        {
            return _canvasGroup.DOFade(1, 0.4f)
                .From(0)
                .OnStart(() => gameObject.SetActive(true))
                .ToUniTask(cancellationToken: gameObject.GetCancellationTokenOnDestroy());
        }

        public UniTask FadeOut()
        {
            return _canvasGroup.DOFade(0, 0.4f)
                .From(1)
                .OnComplete(() => gameObject.SetActive(false))
                .ToUniTask(cancellationToken: gameObject.GetCancellationTokenOnDestroy());
        }
    }
}