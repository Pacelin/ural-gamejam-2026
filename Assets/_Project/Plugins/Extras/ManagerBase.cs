using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Plugins.Extras
{
    public abstract class ManagerBase : MonoBehaviour
    {
        internal abstract UniTask Initialize(CancellationToken cancellationToken);
    }
}