using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Core.Misc
{
    public class CoolButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private CanvasRenderer _renderer;
        [SerializeField] private CanvasRenderer _backgroundRenderer;
        [SerializeField] private Color _defaultColor = new Color(0.7411765f, 0.7882353f, 1, 1);
        [SerializeField] private Color _hoverColor = new Color(0.7019608f, 0.5058824f, 0.07843138f, 1);
        [SerializeField] private Color _downColor = new Color(0.7411765f, 0.7882353f, 1, 1);

        private bool _hover;
        private bool _down;

        private void OnValidate()
        {
            if (!_renderer)
                _renderer = GetComponent<CanvasRenderer>();
            if (_renderer)
                _renderer.SetColor(_defaultColor);
        }

        private void OnEnable()
        {
            _hover = _down = false;
            UpdateState(true);
        } 

        private void OnDisable() => DOTween.Kill(this);

        private void UpdateState(bool immediate)
        {
            DOTween.Kill(this);
            var color = _defaultColor;
            var backgroundAlpha = 0;
            if (_hover)
            {
                color = _down ? _downColor : _hoverColor;
                backgroundAlpha = 1;
            }
            
            if (immediate)
            {
                _renderer.SetColor(color);
                _backgroundRenderer.SetAlpha(backgroundAlpha);
            }
            else
            {
                DOVirtual.Float(_backgroundRenderer.GetAlpha(), backgroundAlpha,
                        0.1f, c => _backgroundRenderer.SetAlpha(c))
                    .SetTarget(this);
                DOVirtual.Color(_renderer.GetColor(), color, 
                        0.1f, c => _renderer.SetColor(c))
                    .SetTarget(this);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _hover = true;
            UpdateState(false);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _hover = false;
            _down = false;
            UpdateState(false);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _down = true;
            UpdateState(false);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _down = false;
            UpdateState(false);
        }
    }
}