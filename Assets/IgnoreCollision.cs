using UnityEngine;
using System.Collections;

public class IgnoreCollision : MonoBehaviour {
    public GameObject ObjectToIgnore;

	void Start () {
        Physics2D.IgnoreCollision(ObjectToIgnore.collider2D, collider2D);
	}
}
