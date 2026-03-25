using System;
using Cysharp.Threading.Tasks;
using Plugins.Audio;
using Project.Gameplay.Interactables;
using Project.Gameplay.Inventory;
using Project.Gameplay.Misc;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class BasementFuelPoint : InteractableObjectWithCursor, IInventoryItemDropTarget
    {
        protected override ECursorState HoverCursorState => ECursorState.HoverQuestion;
        protected override ECursorState DownCursorState => ECursorState.HoverQuestion;

        [SerializeField] private string _text;
        [SerializeField] private InventoryItemConfig _requireItem;
        [Space]
        [SerializeField] private Transform _soundPoint;
        [SerializeField] private SoundEvent _fuelSound;
        [SerializeField] private float _fuelDuration;
        [SerializeField] private PropsEvents _onBeginFuel;
        [SerializeField] private PropsEvents _onEndFuel;
        [SerializeField] private BasementGenerator _generator;
        
        protected override void OnInteract()
        {
            SubtitlesService.Show(_text);
        }

        public bool CanDrop(InventoryItemEntry item)
        {
            return item.Config == _requireItem;
        }

        public void OnDrop(InventoryItemEntry item)
        {
            _fuelSound.PlayOneShotInPoint(_soundPoint.position);
            _onBeginFuel.Trigger(SubtitlesService);
            UniTask.Void(async cancellationToken =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                await UniTask.Delay(TimeSpan.FromSeconds(_fuelDuration), 
                    cancellationToken: cancellationToken);
                
                cancellationToken.ThrowIfCancellationRequested();
                _onEndFuel.Trigger(SubtitlesService);
                _generator.SetFuel();
            }, this.GetCancellationTokenOnDestroy());
        }
    }
}