using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Player
{
    public class PlayerMove : MonoBehaviour
    {

        public float Velocity = 1.0f;
        public bool InvertMovement = false;
        public AudioClip PlayerMovingSound;

        public bool IsMoving
        {
            get
            {
                return _targetPosition.HasValue;
            }
        }

        private int _positionChange = 1;
        private Vector3? _targetPosition;
        private Vector3 _startPosition;
        
        // ReSharper disable once UnusedMember.Local
        void Start()
        {
            _positionChange = (InvertMovement) ? -1 : 1;
        }

        // ReSharper disable once UnusedMember.Local
        void Update()
        {
            if (_targetPosition == null)
            {
                if (Input.GetAxis("Horizontal") > 0)
                    _targetPosition = new Vector3(transform.position.x + _positionChange, transform.position.y, 0);
                else if (Input.GetAxis("Horizontal") < 0)
                    _targetPosition = new Vector3(transform.position.x - _positionChange, transform.position.y, 0);

                if (Input.GetAxis("Vertical") > 0)
                    _targetPosition = new Vector3(transform.position.x, transform.position.y + _positionChange, 0);
                else if (Input.GetAxis("Vertical") < 0)
                    _targetPosition = new Vector3(transform.position.x, transform.position.y - _positionChange, 0);

                if (_targetPosition.HasValue)
                {
                    _startPosition = transform.position;
                    audio.PlayOneShot(PlayerMovingSound);
                }
            }

            if (_targetPosition != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition.Value, Velocity * Time.deltaTime);
                if (transform.position == _targetPosition.Value)
                {
                    _targetPosition = null;
                    transform.position = new Vector3(Mathf.Round(transform.position.x),
                        Mathf.Round(transform.position.y),
                        Mathf.Round(transform.position.z));
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
