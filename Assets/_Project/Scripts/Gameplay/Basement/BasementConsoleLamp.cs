using DG.Tweening;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementConsoleLamp : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [ColorUsage(false, true)]
        [SerializeField] public Color _lightColor;
        [ColorUsage(false, true)]
        [SerializeField] private Color _darkColor;
        [SerializeField] public float _delay;
        [Space]
        [SerializeField] private float _lightFadeIn;
        [SerializeField] private float _lightSustain;
        [SerializeField] private float _lightFadeOut;
        [SerializeField] private float _darkSustain;
        
        private Material _material;
        private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

        private void OnValidate()
        {
            if (!_meshRenderer)
                _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Awake()
        {
            _material = new Material(_meshRenderer.sharedMaterial);
            _meshRenderer.sharedMaterial = _material;
            Tween();
        }

        private void OnDestroy()
        {
            DOTween.Kill(this);
            Destroy(_material);
        }

        [ContextMenu("Restart")]
        private void RestartTween()
        {
            DOTween.Kill(this);
            Tween();
        }
        
        private void Tween()
        {
            DOVirtual.DelayedCall(_delay, () =>
            {
                DOTween.Sequence(this)
                    .Append(_material.DOColor(_lightColor, EmissionColor, _lightFadeIn).From(_darkColor))
                    .AppendInterval(_lightSustain)
                    .Append(_material.DOColor(_darkColor, EmissionColor, _lightFadeOut))
                    .AppendInterval(_darkSustain)
                    .SetLoops(-1);
            }).SetTarget(this);
        }
    }
}