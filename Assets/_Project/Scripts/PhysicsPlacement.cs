#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
#endif

namespace Project.Editor
{
    public class PhysicsPlacement : MonoBehaviour
    {
        [SerializeField] private Rigidbody[] _rigidbodies;
        [SerializeField] private float _timeStep = 0.1f;

        [SerializeField] private Vector3 _velocity;
        
        [SerializeField] private Vector3[] _originalPositions;
        [SerializeField] private Quaternion[] _originalRotations;
        
#if UNITY_EDITOR
        [ContextMenu("Start Simulation")]
        private void StartSimulation()
        {
            Physics.simulationMode = SimulationMode.Script;
            EditorApplication.update += SimulateUpdate;

            _originalPositions = new Vector3[_rigidbodies.Length];
            _originalRotations = new Quaternion[_rigidbodies.Length];
            for (int i = 0; i < _rigidbodies.Length; i++)
            {
                _originalPositions[i] = _rigidbodies[i].transform.position;
                _originalRotations[i] = _rigidbodies[i].transform.rotation;
                _rigidbodies[i].linearVelocity = _velocity;
                _rigidbodies[i].angularVelocity = Random.insideUnitSphere;
            }
        }

        [ContextMenu("Cancel Simulation")]
        private void CancelSimulation()
        {
            Physics.simulationMode = SimulationMode.FixedUpdate;
            EditorApplication.update -= SimulateUpdate;

            for (int i = 0; i < _rigidbodies.Length; i++)
            {
                _rigidbodies[i].transform.position = _originalPositions[i];
                _rigidbodies[i].transform.rotation = _originalRotations[i];
            }
        }
        
        [ContextMenu("Stop Simulation")]
        private void StopSimulation()
        {
            Physics.simulationMode = SimulationMode.FixedUpdate;
            EditorApplication.update -= SimulateUpdate;
        }

        private void SimulateUpdate()
        {
            Physics.Simulate(_timeStep);
            SceneView.RepaintAll();
        }
#endif
    }
}