using System;
using Cysharp.Threading.Tasks;
using Plugins.Audio;
using Project.Gameplay.Interactables;
using Project.Gameplay.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class PureBloodMachine : PuzzleActivator
    {
        [SerializeField] private InteractablesManager _interactablesManager;
        [SerializeField] private GameObject _activeWhenLock;
        [SerializeField] private GameObject _activeWhenUnlock;
        [SerializeField] private SoundEvent _unlockSound;
        [SerializeField] private float _unlockDuration;
        [SerializeField] private SoundEvent _afterUnlockSound;
        [SerializeField] private PropsEvents _afterUnlock;

        private void OnValidate()
        {
            if (!_interactablesManager)
                _interactablesManager = FindFirstObjectByType<InteractablesManager>();
        }

        public override void Activate()
        {
            UniTask.Void(async cancellationToken =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                _unlockSound.PlayOneShotInPoint(transform.position);
                await UniTask.Delay(System.TimeSpan.FromSeconds(_unlockDuration),
                    cancellationToken: cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();
                _afterUnlockSound.PlayOneShotInPoint(transform.position);
                _activeWhenUnlock.SetActive(true);
                _activeWhenLock.SetActive(false);
                _afterUnlock.Trigger(_interactablesManager.Resolver.Resolve<SubtitlesService>());
            }, this.GetCancellationTokenOnDestroy());
        }
    }
}