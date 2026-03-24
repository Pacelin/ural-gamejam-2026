using System.Linq;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class CodePuzzle : NotInteractableObject
    {
        [SerializeField] private PropsCodeText[] _codeTexts;
        [SerializeField] private string _correctResult;
        [SerializeField] private PropsEvents _onComplete;

        protected override void Initialize(IObjectResolver resolver)
        {
            _onComplete.Prepare();
        }

        public void CheckCompletion()
        {
            var chars = _codeTexts.Select(ct => ct.CurrentValue);
            var str = string.Join("", chars);
            if (str == _correctResult)
                _onComplete.Trigger(SubtitlesService);
        }
    }
}