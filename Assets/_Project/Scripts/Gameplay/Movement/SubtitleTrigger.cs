using System;
using Cysharp.Threading.Tasks;
using Project.Gameplay.Misc;
using UnityEngine;

namespace Project.Gameplay.Movement
{
    public class SubtitleTrigger : MonoBehaviour
    {
        [SerializeField] private float _delay;
        [TextArea]
        [SerializeField] private string[] _queue;
        [SerializeField] private bool _destroyAfterTrigger = true;

        private bool _destroyed = false;
        
        public void Trigger(SubtitlesService service)
        {
            if (_destroyed)
                return;
            if (_destroyAfterTrigger)
                _destroyed = true;
            UniTask.Void(async cancellationToken =>
            {
                if (_delay > 0)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken: cancellationToken);
                }
                
                cancellationToken.ThrowIfCancellationRequested();
                service.Show(_queue);
                
                if (_destroyAfterTrigger)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    Destroy(this);
                }
            }, service.CancellationToken);
        }
    }
}