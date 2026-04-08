using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Plugins.Audio;
using Project.Core.Misc;
using UnityEngine;
using VContainer;

namespace Project.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _fadeCanvasGroup;
        [SerializeField] private float _delay = 0.5f;
        [SerializeField] private float _startScale = 0.8f;
        [SerializeField] private float _endScale = 1f;
        [SerializeField] private float _fadeInDuration = 0.5f;
        [SerializeField] private float _suspendDuration = 3f;
        [SerializeField] private float _fadeOutDuration = 0.5f;
        [SerializeField] private float _loadDelay = 0.3f;

        [Inject] private SceneLoader _sceneLoader;
        
        private void Awake()
        {
            UniTask.Void(async cancellationToken =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                await AudioSystem.Initialize(cancellationToken);
                
                cancellationToken.ThrowIfCancellationRequested();

                _fadeCanvasGroup.alpha = 0;
                var t = _fadeCanvasGroup.transform;
                t.localScale = Vector3.one * _startScale;
                await DOTween.Sequence(_fadeCanvasGroup)
                    .AppendInterval(_delay)
                    .Append(_fadeCanvasGroup.DOFade(1, _fadeInDuration))
                    .Join(t.DOScale(_endScale, _fadeInDuration))
                    .AppendInterval(_suspendDuration)
                    .Append(_fadeCanvasGroup.DOFade(0, _fadeOutDuration))
                    .Join(t.DOScale(_startScale, _fadeOutDuration).SetEase(Ease.InQuad))
                    .ToUniTask(TweenCancelBehaviour.KillAndCancelAwait, cancellationToken);
                
                await UniTask.Delay(TimeSpan.FromSeconds(_loadDelay), 
                    cancellationToken: cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();
          
                _sceneLoader.Load(1);
            }, this.GetCancellationTokenOnDestroy());
        }

        private void OnDestroy()
        {
            DOTween.Kill(_fadeCanvasGroup);
        }
    }
}