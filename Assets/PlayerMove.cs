using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Player
{
    public class PlayerMove : MonoBehaviour
    {

        public float Velocity = 2.0f;
        public AudioClip PlayerMovingSound;

        public bool IsMoving
        {
            get
            {
                return _targetPosition.HasValue;
            }
        }

        private Vector3? _targetPosition;
        private Vector3 _startPosition;
        
        // ReSharper disable once UnusedMember.Local
        void Start()
        {
            _startPosition = transform.position;
        }

        // ReSharper disable once UnusedMember.Local
        void Update()
        {
            if (!_targetPosition.HasValue)
            {
                if (Input.GetAxis("Horizontal") > 0)
                    _targetPosition = new Vector3(transform.position.x + 1, transform.position.y, 0);
                else if (Input.GetAxis("Horizontal") < 0)
                    _targetPosition = new Vector3(transform.position.x - 1, transform.position.y, 0);

                if (Input.GetAxis("Vertical") > 0)
                    _targetPosition = new Vector3(transform.position.x, transform.position.y + 1, 0);
                else if (Input.GetAxis("Vertical") < 0)
                    _targetPosition = new Vector3(transform.position.x, transform.position.y - 1, 0);

                if (_targetPosition.HasValue)
                {
                    _startPosition = transform.position;
                    audio.PlayOneShot(PlayerMovingSound);
                }
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
