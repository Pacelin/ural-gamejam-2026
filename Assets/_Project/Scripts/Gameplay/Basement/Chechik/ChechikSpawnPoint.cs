using UnityEngine;

namespace Project.Gameplay.Basement
{
    public class ChechikSpawnPoint : MonoBehaviour
    {
        [SerializeField] private ChechikAgent _agent;
        [SerializeField] private GameObject[] _destroyObjectsWhenSpawn;

        private void Awake()
        {
            var agentTransform = _agent.transform;
            var pointTransform = transform;
            agentTransform.position = pointTransform.position;
            agentTransform.rotation = pointTransform.rotation;
            _agent.gameObject.SetActive(true);
            foreach (var obj in _destroyObjectsWhenSpawn)
                Destroy(obj);
        }
    }
}