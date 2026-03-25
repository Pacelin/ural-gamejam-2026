using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Plugins.Audio;
using Project.Gameplay.Interactables;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class BasementGenerator : NotInteractableObject
    {
        [SerializeField] private float _blinkDuration = 0.5f;
        [SerializeField] private float _enableDuration = 0.2f;
        [Header("Colors")]
        [SerializeField] private MeshRenderer _renderer;
        [ColorUsage(false, hdr: true)] 
        [SerializeField] private Color _noColor;
        [ColorUsage(false, hdr: true)] 
        [SerializeField] private Color _disabledColor;
        [ColorUsage(false, hdr: true)]
        [SerializeField] private Color _enabledColor;
        [Space]
        [SerializeField] private Transform _soundPoint;
        [SerializeField] private SoundEvent _enableSound;
        [SerializeField] private SoundEvent _failedEnableSound;
        [Space] 
        [SerializeField] private PropsEvents _onEnableStart;
        [SerializeField] private PropsEvents _onEnableEnd;
        [SerializeField] private float _enableDelay = 1.5f;
        [SerializeField] private PropsEvents _onFailedEnableStart;
        [SerializeField] private PropsEvents _onFailedEnableEnd;
        [SerializeField] private float _failedEnableDelay; 
        
        private bool _hasFuel;
        private ISoundEventInstance _soundInstance;
        private Material _material;
        
        private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

        protected override void Initialize(IObjectResolver resolver)
        {
            _material = _renderer.sharedMaterial;
            _material.SetColor(EmissionColor, _noColor);
        }

        private void Start()
        {
            DOVirtual.Color(_noColor, _disabledColor, _blinkDuration,
                c => _material.SetColor(EmissionColor, c))
                .SetLoops(-1, LoopType.Yoyo)
                .SetTarget(this);
        }

        private void OnDestroy()
        {
            if (_soundInstance != null && _soundInstance.IsValid())
            {
                _soundInstance.Stop(false);
                _soundInstance.Release();
                _soundInstance = null;
            }
            DOTween.Kill(this);
        }

        public void SetFuel()
        {
            _hasFuel = true;
        }
        
        public void TryEnable()
        {
            if (_hasFuel)
            {
                _onEnableStart.Trigger(SubtitlesService);
                _soundInstance = _enableSound.CreateInstance();
                _soundInstance.SetWorldPosition(_soundPoint.position);
                _soundInstance.Start();
                UniTask.Void(async cancellationToken =>
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await UniTask.Delay(TimeSpan.FromSeconds(_enableDelay),
                        cancellationToken: cancellationToken);
                    
                    cancellationToken.ThrowIfCancellationRequested();
                    DOTween.Kill(this);
                    await DOVirtual.Color(_material.GetColor(EmissionColor), _enabledColor, _enableDuration,
                            c => _material.SetColor(EmissionColor, c))
                        .SetTarget(this)
                        .ToUniTask(cancellationToken: cancellationToken);
                    _onEnableEnd.Trigger(SubtitlesService);
                }, this.GetCancellationTokenOnDestroy());
            }
            else
            {
                _onFailedEnableStart.Trigger(SubtitlesService);
                _failedEnableSound.PlayOneShotInPoint(_soundPoint.position);
                UniTask.Void(async cancellationToken =>
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await UniTask.Delay(TimeSpan.FromSeconds(_failedEnableDelay),
                        cancellationToken: cancellationToken);
                    
                    cancellationToken.ThrowIfCancellationRequested();
                    _onFailedEnableEnd.Trigger(SubtitlesService);
                }, this.GetCancellationTokenOnDestroy());
            }
        }
    }
}