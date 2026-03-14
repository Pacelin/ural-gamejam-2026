using Project.Core;
using UnityEngine;

namespace Project.Achievements
{
    [System.Serializable]
    public abstract class RewardConfig
    {
        public Sprite Icon => _icon;
        public string Text => _text;
        
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _text;
        
        public abstract void OnClaim(GameModel gameModel);
    }
}