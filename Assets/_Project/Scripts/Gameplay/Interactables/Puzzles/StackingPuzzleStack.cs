using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public class StackingPuzzleStack : MonoBehaviour
    {
        [SerializeField] private GameObject[] _stacks;

        private int _current;

        private void Awake()
        {
            foreach (var obj in _stacks)
                obj.SetActive(false);
        }

        public void Stack()
        {
            _stacks[_current].SetActive(true);
            _current++;
        }
    }
}