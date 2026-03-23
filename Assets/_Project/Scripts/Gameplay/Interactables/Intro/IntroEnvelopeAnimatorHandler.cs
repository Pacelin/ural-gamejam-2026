using System;
using Cysharp.Threading.Tasks;
using Plugins.Audio;
using Project.Core.Audio;
using UnityEngine;

namespace Project.Gameplay.Interactables.Intro
{
    public class IntroEnvelopeAnimatorHandler : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private float _buttonActivationDelay = 1f;
        [SerializeField] private IntroEnvelopeInteractable _interactable;
        [SerializeField] private IntroEnvelopeButton _button;
        [SerializeField] private GameObject _soundPoint;
        [SerializeField] private SoundEvent _envelopeOpenSound;
        
        private static readonly int OPEN_TRIGGER = Animator.StringToHash("open");

        private void Awake()
        {
            MusicController.SetMusic(AudioSystem.Music_Menu);
            MusicController.SetRoomTone(AudioSystem.Game_Misc_RoomTone);
        }

        public void Open()
        {
            _animator.SetTrigger(OPEN_TRIGGER);
            UniTask.Void(async cancellationToken =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                await UniTask.Delay(TimeSpan.FromSeconds(_buttonActivationDelay), cancellationToken: cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
                _button.gameObject.SetActive(true);
            }, this.GetCancellationTokenOnDestroy());
        }

        public void ActivateOpen()
        {
            _interactable.gameObject.SetActive(true);
        }

        public void OpenSound()
        {
            _envelopeOpenSound.PlayOneShotAttached(_soundPoint);
        }
    }
}