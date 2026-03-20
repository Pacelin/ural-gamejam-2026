using Plugins.Audio;
using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public class PuzzleCounter : MonoBehaviour
    {
        [SerializeField] private PropsEvents _onComplete;
        [SerializeField] private int _correctCount;

        private int _currentCorrect;

        private void Awake()
        {
            _onComplete.Prepare();
        }

        public void SetCorrect()
        {
            _currentCorrect++;
            if (_currentCorrect == _correctCount)
            {
                _onComplete.Trigger();
                AudioSystem.Game_Misc_PuzzleComplete.PlayOneShot();
            }
        }

        public void SetIncorrect()
        {
            _currentCorrect--;
            if (_currentCorrect == _correctCount)
            {
                _onComplete.Trigger();
                AudioSystem.Game_Misc_PuzzleComplete.PlayOneShot();
            }
        }
    }
}