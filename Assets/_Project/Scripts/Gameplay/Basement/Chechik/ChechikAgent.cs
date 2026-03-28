using System;
using UnityEngine;

namespace Project.Gameplay.Basement
{
    [ExecuteInEditMode]
    public class ChechikAgent : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Animator _animator;

        private void OnAnimatorMove()
        {
            _transform.position += _animator.deltaPosition;
//            _transform.position += _animator.velocity * Time.deltaTime;
            Debug.Log(_animator.deltaPosition);
        }
    }
}