using System;
using JetBrains.Annotations;
using VContainer.Unity;

namespace Project.Editor.Gameplay
{
    [UsedImplicitly]
    public class CollectablesController : IInitializable, IDisposable
    {
        private readonly CollectablesView _view;
        private readonly CollectablesModel _model;
        
        public CollectablesController(CollectablesView view, CollectablesModel model)
        {
            _view = view;
            _model = model;
        }

        public void Initialize()
        {
            _model.OnChanged += OnModelChanged;
            _view.SetText(_model.Current, _model.Required);
            _view.gameObject.SetActive(_model.Current > 0);
        }

        public void Dispose()
        {
            _model.OnChanged -= OnModelChanged;
        }

        private void OnModelChanged()
        {
            _view.gameObject.SetActive(_model.Current > 0);
            _view.SetText(_model.Current, _model.Required);
            _view.Ping();
        }
    }
}