using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Player
{
    public class PreventMovementOnBlockCollision : MonoBehaviour
    {
        private static Movement _movement;

        // ReSharper disable once UnusedMember.Local
        void Start()
        {
            if (_movement == null)
                _movement = GameObject.Find("GlobalScripts").GetComponent<Movement>();
        }

        // ReSharper disable once UnusedMember.Local
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.name == "Player")
                _movement.OnPlayerCollisionEnter2D(col);
            else if (col.gameObject.name == "Lepton")
                _movement.OnLeptonCollisionEnter2D(col);
        }
    }

}

