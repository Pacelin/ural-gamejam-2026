using UnityEngine;

namespace Project.Achievements
{
    [System.Serializable]
    public class PurposeTarget
    {
        public PurposeConfig Purpose => _purpose;
        public int Target => _target;
        public string Text => _text;
        
        [SerializeField] private PurposeConfig _purpose;
        [SerializeField] private int _target;
        [SerializeField] private string _text;
    }
}