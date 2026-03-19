using Cysharp.Threading.Tasks;
using Plugins.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Project.Core
{
    public class RuntimeEntryPoint : IInitializable
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