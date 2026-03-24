using System;
using JetBrains.Annotations;
using Plugins.Audio;
using Project.Core.Audio;
using Project.Core.Pause;
using Project.Gameplay.Inventory;
using Project.Gameplay.Misc;
using Project.Gameplay.Movement;
using Unity.Cinemachine;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class LukeAnimationHandler : NotInteractableObject
    {
        [SerializeField] private Animation _animation;
        [SerializeField] private string _stateName;
        [SerializeField] private CinemachineCamera _camera;
        [Space]
        [SerializeField] private SoundEvent _firstValveSqueak;
        [SerializeField] private SoundEvent _firstValveImpact;
        [SerializeField] private Transform _firstValvePoint;
        [Space]
        [SerializeField] private SoundEvent _secondValveSqueak;
        [SerializeField] private Transform _secondValvePoint;
        [Space]
        [SerializeField] private SoundEvent _smallLukeSoundUp;
        [SerializeField] private SoundEvent _lukeSoundUp;
        [SerializeField] private GameObject _lukeSoundPoint;
        [Space]
        [SerializeField] private PropsEvents _onFinish;
        
        private IDisposable _pauseDisposable;
        private bool _animate;

        private CursorService _cursorService;
        private MovementService _movementService;
        private InventoryModel _inventory;
        private PauseController _pauseController;
        
        protected override void Initialize(IObjectResolver resolver)
        {
            _cursorService = resolver.Resolve<CursorService>();
            _movementService = resolver.Resolve<MovementService>();
            _inventory = resolver.Resolve<InventoryModel>();
            _pauseController = resolver.Resolve<PauseController>();

            _pauseDisposable = _pauseController.SubscribeAnyPause(p =>
            {
                if (_animate)
                {
                    if (p)
                    {
                        _animation[_stateName].enabled = false;
                    }
                    else
                    {
                        _animation[_stateName].enabled = true;
                    }
                }
            });
        }

        private void OnDestroy()
        {
            _pauseDisposable?.Dispose();
        }

        [UsedImplicitly]
        public void OnStartAnimation()
        {
            _camera.Priority = 10;
            _camera.Prioritize();
            _cursorService.EnableCursorState(ECursorState.Transition);
            _movementService.BlockControls();
            _inventory.DisableView();
            _animate = true;
        }

        [UsedImplicitly]
        public void OnEndAnimation()
        {
            _camera.Priority = 0;
            _cursorService.DisableCursorState(ECursorState.Transition);
            _movementService.UnblockControls();
            _animate = false;
            _onFinish.Trigger(SubtitlesService);
            Destroy(this);
            Destroy(_animation);
        }

        [UsedImplicitly]
        public void StopMusic()
        {
            MusicController.Stop();
        }

        [UsedImplicitly]
        public void PlayFirstValveSqueak()
        {
            _firstValveSqueak.PlayOneShotInPoint(_firstValvePoint.position);
        }

        [UsedImplicitly]
        public void PlayFirstValveImpact()
        {
            _firstValveImpact.PlayOneShotInPoint(_firstValvePoint.position);
        }

        [UsedImplicitly]
        public void PlaySecondValveSqueak()
        {
            _secondValveSqueak.PlayOneShotInPoint(_secondValvePoint.position);
        }

        [UsedImplicitly]
        public void PlayLukeSmallUp()
        {
            _smallLukeSoundUp.PlayOneShotAttached(_lukeSoundPoint);
        }

        [UsedImplicitly]
        public void PlayLukeUp()
        {
            _lukeSoundUp.PlayOneShotAttached(_lukeSoundPoint);
        }
    }
}