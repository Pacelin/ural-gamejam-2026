using System.Linq;
using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public class CodePuzzle : MonoBehaviour
    {
        [SerializeField] private PropsCodeText[] _codeTexts;
        [SerializeField] private string _correctResult;
        [SerializeField] private PropsEvents _onComplete;

        private void Awake()
        {
            _onComplete.Prepare();
        }

        public void CheckCompletion()
        {
            var chars = _codeTexts.Select(ct => ct.CurrentValue);
            var str = string.Join("", chars);
            if (str == _correctResult)
                _onComplete.Trigger();
        }
    }
}