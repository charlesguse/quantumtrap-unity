using System;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Player
{
    public class Movement : MonoBehaviour
    {
        public float Velocity = 2.0f;
        public AudioClip PlayerMovingSound;
        public GameObject Player;
        public GameObject Lepton;

        public bool IsMoving
        {
            get { return _playerTargetPosition.HasValue; }
        }

        private Vector3? _playerTargetPosition;
        private Vector3 _playerStartPosition;
        private Vector3? _leptonTargetPosition;
        private Vector3 _leptonStartPosition;

        // ReSharper disable once UnusedMember.Local
        private void Start()
        {
            _playerStartPosition = Player.transform.position;
            _leptonStartPosition = Lepton.transform.position;
        }

        // ReSharper disable once UnusedMember.Local
        private void Update()
        {
            if (!_playerTargetPosition.HasValue && !_leptonTargetPosition.HasValue)
            {
                if (Player.transform.position != Lepton.transform.position)
                {
                    _playerTargetPosition = GetTargetPosition(Player, MirrorDirection(false));
                    _leptonTargetPosition = GetTargetPosition(Lepton, MirrorDirection(true));
                }

                if (_playerTargetPosition.HasValue)
                {
                    _playerStartPosition = Player.transform.position;
                    _leptonStartPosition = Lepton.transform.position;
                    audio.PlayOneShot(PlayerMovingSound);
                }
            }

            MoveTowardsPosition(Player, ref _playerTargetPosition, Velocity);
            MoveTowardsPosition(Lepton, ref _leptonTargetPosition, Velocity);
        }

        private static void MoveTowardsPosition(GameObject @object, ref Vector3? targetPosition, float velocity)
        {
            if (targetPosition.HasValue)
            {
                @object.transform.position = Vector3.MoveTowards(@object.transform.position, targetPosition.Value,
                    velocity * Time.deltaTime);
                if (@object.transform.position == targetPosition)
                {
                    targetPosition = null;
                }
            }
        }

        private static int MirrorDirection(bool mirror)
        {
            return mirror ? -1 : 1;
        }

        private static Vector3? GetTargetPosition(GameObject @object, int direction)
        {
            Vector3? targetPosition = null;
         
            if (Input.GetAxis("Horizontal") > 0)
                targetPosition = new Vector3(@object.transform.position.x + direction, @object.transform.position.y, 0);
            else if (Input.GetAxis("Horizontal") < 0)
                targetPosition = new Vector3(@object.transform.position.x - direction, @object.transform.position.y, 0);
            else if (Input.GetAxis("Vertical") > 0)
                targetPosition = new Vector3(@object.transform.position.x, @object.transform.position.y + direction, 0);
            else if (Input.GetAxis("Vertical") < 0)
                targetPosition = new Vector3(@object.transform.position.x, @object.transform.position.y - direction, 0);

            if (targetPosition.HasValue)
                targetPosition = RoundVector3(targetPosition.Value, 1);

            return targetPosition;
        }

        private static Vector3 RoundVector3(Vector3 value, int digits)
        {
            return new Vector3(
                (float)Math.Round(value.x, digits), 
                (float)Math.Round(value.y, digits), 
                (float)Math.Round(value.z, digits));
        }

        public void OnPlayerCollisionEnter2D(Collision2D col)
        {
            _playerTargetPosition = _playerStartPosition;
            _leptonTargetPosition = _leptonStartPosition;
        }

        public void OnLeptonCollisionEnter2D(Collision2D col)
        {
            _leptonTargetPosition = _leptonStartPosition;
        }
    }
}