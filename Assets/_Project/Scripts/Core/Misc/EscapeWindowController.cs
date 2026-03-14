using UnityEngine;

namespace Project.Core.Misc
{
    public abstract class EscapeWindowController<T> : IEscapeWindowController
        where T : MonoBehaviour, IEscapeWindow
    {
        protected readonly T Window;
        protected readonly EscapeController EscapeController;
        
        public EscapeWindowController(T window, EscapeController escapeController)
        {
            Window = window;
            EscapeController = escapeController;
        }
        
        public virtual void Show()
        {
            Window.Show();
            EscapeController.PushWindow(Window.gameObject, this);
        }

        public virtual void Hide()
        {
            Window.Hide();
            EscapeController.PopWindow();
        }
    }
}