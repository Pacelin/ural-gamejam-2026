using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Plugins.Extras
{
    public class RuntimeManager : MonoBehaviour
    {
        public static CancellationToken CancellationToken { get; private set; }

        private void Awake()
        {
            CancellationToken = this.GetCancellationTokenOnDestroy();
            DontDestroyOnLoad(gameObject);

            var managers = GetComponentsInChildren<ManagerBase>();
            UniTask.Void(async () =>
            {
                foreach (var manager in managers)
                    await manager.Initialize(CancellationToken);
    
                await SceneManager.LoadSceneAsync(sceneBuildIndex: 1, LoadSceneMode.Single);
            });
        }
    }
}