using System;
using VContainer.Unity;

namespace Project.Achievements
{
    public class AchievementsButtonController : IInitializable, IDisposable
    {
        private readonly AchievementsButtonView _view;
        private readonly AchievementsWindowController _windowController;
        
        public AchievementsButtonController(AchievementsButtonView view, 
            AchievementsWindowController windowController)
        {
            _view = view;
            _windowController = windowController;
        }
        
        public void Initialize()
        {
            _view.Button.onClick.AddListener(OnClick);
        }

        public void Dispose()
        {
            _view.Button.onClick.RemoveListener(OnClick);
        }

        private void OnClick() => _windowController.Show();
    }
}