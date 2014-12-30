using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Player
{
    public class HandleCollisionWithNonPlayer : MonoBehaviour
    {
        private Movement _movement;

        // ReSharper disable once UnusedMember.Local
        void Start()
        {
            _movement = GameObject.Find("GlobalScripts").GetComponent<Movement>();
        }

        // ReSharper disable once UnusedMember.Local
        void OnCollisionEnter2D(Collision2D col)
        {
            if (name == "Player")
                _movement.OnPlayerCollisionEnter2D(col);
            else if (name == "Lepton")
                _movement.OnLeptonCollisionEnter2D(col);
        }
    }

}

