using System.Threading;
using Cysharp.Threading.Tasks;
using Plugins.Audio;

namespace Plugins.Extras
{
    public class AudioManager : ManagerBase
    {
        internal override UniTask Initialize(CancellationToken cancellationToken) =>
            AudioSystem.Initialize(cancellationToken);
    }
}