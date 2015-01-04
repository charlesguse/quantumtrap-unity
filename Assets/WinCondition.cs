using System.Collections;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Player
{
    public class WinCondition : MonoBehaviour
    {
        public string NextLevel;
        public GameObject GoalObject1;
        public GameObject GoalObject2;
        public AudioClip WinSound;

        private Movement _movement;
        private bool _won;

        // ReSharper disable once UnusedMember.Local
        void Start()
        {
            _won = false;
            _movement = GetComponent<Movement>();
        }

        // ReSharper disable once UnusedMember.Local
        void Update()
        {
            if (!_won && GoalObject1.transform.position == GoalObject2.transform.position && !_movement.IsMoving)
            {
                _won = true;
                //Destroy(_movement);
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
