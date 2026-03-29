using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Plugins.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Project.Core
{
    [UsedImplicitly]
    public class BootstrapStarter : IInitializable
    {
        public void Initialize()
        {
            UniTask.Void(async () =>
            {
                await AudioSystem.Initialize(Application.exitCancellationToken);
                await SceneManager.LoadSceneAsync(sceneBuildIndex: 1, LoadSceneMode.Single);
            });
        }
    }
}