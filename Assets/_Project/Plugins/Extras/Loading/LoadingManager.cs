using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Plugins.Extras
{
    public class LoadingManager : ManagerBase
    {
        [SerializeField] private LoadingWindow _loadingWindowPrefab;

        private static LoadingWindow _loadingWindow;
        
        public static void ShowLoading() => _loadingWindow.gameObject.SetActive(true);
        public static void HideLoading() => _loadingWindow.gameObject.SetActive(false);
        
        internal override UniTask Initialize(CancellationToken cancellationToken)
        {
            _loadingWindow = Instantiate(_loadingWindowPrefab);
            DontDestroyOnLoad(_loadingWindow.gameObject);
            _loadingWindow.gameObject.SetActive(false);
            return UniTask.CompletedTask;
        }
    }
}