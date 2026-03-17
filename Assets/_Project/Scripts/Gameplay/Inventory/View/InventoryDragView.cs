using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Gameplay.Inventory
{
    public class InventoryDragView : MonoBehaviour
    {
        public event Action OnUpdate;
        public float CentricSpeed => _centricSpeed;
        public Canvas Canvas => _canvas;
        
        [SerializeField] private Image _image;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private float _centricSpeed = 50f;

        public void SetImage(Sprite image) => _image.sprite = image;
        private void Update() => OnUpdate?.Invoke();
    }
}