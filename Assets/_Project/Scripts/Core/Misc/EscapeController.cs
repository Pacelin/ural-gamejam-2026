using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace Project.Core.Misc
{
    public class EscapeController : ITickable
    {
        public event Action OnEscapeWithEmptyStack;

        private readonly Stack<(GameObject Go, IEscapeWindowController Window)> _stack = new();

        public void PushWindow(GameObject gameObject, IEscapeWindowController escapeWindow)
        {
            _stack.Push((gameObject, escapeWindow));
        }

        public void PopWindow()
        {
            _stack.Pop();
        }
        
        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                bool success = false;
                while (_stack.TryPeek(out var tuple))
                {
                    if (!tuple.Go)
                    {
                        _stack.Pop();
                        continue;
                    }
                    
                    tuple.Window.Hide();
                    success = true;
                    break;
                }

                if (!success)
                    OnEscapeWithEmptyStack?.Invoke();
            }
        }
    }
}