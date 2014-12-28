using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Player
{
    public class MirrorMove : MonoBehaviour
    {
        private Vector3 _mirrorPosition;
        public GameObject ObjectToMirror;

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

            transform.position -= delta;

            if (delta == Vector3.zero)
            {
                transform.position = new Vector3(Mathf.Round(transform.position.x),
                    Mathf.Round(transform.position.y),
                    Mathf.Round(transform.position.z));
            }
        }
    }
}
