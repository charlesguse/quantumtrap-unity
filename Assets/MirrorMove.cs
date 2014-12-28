using System;
using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Player
{
    public class MirrorMove : MonoBehaviour
    {
        private Vector3 _mirrorPosition;
        private Vector3? _targetPosition;
        private Vector3 _startPosition;
        
        public GameObject ObjectToMirror;
        public float Velocity = 2.0f;

        // ReSharper disable once UnusedMember.Local
        void Start()
        {
            _mirrorPosition = ObjectToMirror.transform.position;
        }

        // ReSharper disable once UnusedMember.Local
        void Update()
        {
            var delta = ObjectToMirror.transform.position - _mirrorPosition;
            _mirrorPosition = ObjectToMirror.transform.position;

            //transform.position -= delta;

            //if (delta == Vector3.zero)
            //{
            //    transform.position = new Vector3(Mathf.Round(transform.position.x),
            //        Mathf.Round(transform.position.y),
            //        Mathf.Round(transform.position.z));
            //}

            if (!_targetPosition.HasValue && delta != Vector3.zero)
            {
                var direction = new Vector3(Mathf.Ceil(delta.x), Mathf.Ceil(delta.y), Mathf.Ceil(delta.z));
                _targetPosition = transform.position - direction;
                _startPosition = transform.position;
            }

            if (_targetPosition.HasValue)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition.Value, Velocity * Time.deltaTime);
                if (transform.position == _targetPosition.Value)
                {
                    _targetPosition = null;
                }
            }
        }

        // ReSharper disable once UnusedMember.Local
        // ReSharper disable once UnusedParameter.Local
        void OnCollisionEnter2D(Collision2D col)
        {
            _targetPosition = _startPosition;
        }
    }
}
