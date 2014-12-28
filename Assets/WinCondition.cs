using System.Collections;
using UnityEngine;

//[RequireComponent  (typeof(PlayerMove))]
// ReSharper disable once CheckNamespace
namespace Player
{
    public class WinCondition : MonoBehaviour
    {
        public string NextLevel;
        public GameObject GoalObject;
        public AudioClip WinSound;

        private PlayerMove _playerMove;
        private bool _won;

        // ReSharper disable once UnusedMember.Local
        void Start()
        {
            _won = false;
            _playerMove = GetComponent<PlayerMove>();
        }

        // ReSharper disable once UnusedMember.Local
        void Update()
        {
            if (!_won && transform.position == GoalObject.transform.position && !_playerMove.IsMoving)
            {
                _won = true;
                Destroy(_playerMove);
                StartCoroutine(TriggerWin());
            }
        }

        IEnumerator TriggerWin()
        {
            audio.PlayOneShot(WinSound);
            yield return new WaitForSeconds(2);
            Application.LoadLevel(NextLevel);
        }
    }
}
