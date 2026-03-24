using Plugins.Audio;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Interactables
{
    public class PuzzleCounter : NotInteractableObject
    {
        [SerializeField] private PropsEvents _onComplete;
        [SerializeField] private int _correctCount;

        private int _currentCorrect;

        protected override void Initialize(IObjectResolver resolver)
        {
            _onComplete.Prepare();
        }

        public void SetCorrect()
        {
            _currentCorrect++;
            if (_currentCorrect == _correctCount)
            {
                _onComplete.Trigger(SubtitlesService);
                AudioSystem.Game_Misc_PuzzleComplete.PlayOneShot();
            }
        }

        public void SetIncorrect()
        {
            _currentCorrect--;
            if (_currentCorrect == _correctCount)
            {
                _onComplete.Trigger(SubtitlesService);
                AudioSystem.Game_Misc_PuzzleComplete.PlayOneShot();
            }
        }
    }
}