using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Physics2D
{
    public class IgnoreCollision : MonoBehaviour
    {
        public GameObject ObjectToIgnore;

        // ReSharper disable once UnusedMember.Local
        void Start()
        {
            UnityEngine.Physics2D.IgnoreCollision(ObjectToIgnore.collider2D, collider2D);
        }
    }
}
