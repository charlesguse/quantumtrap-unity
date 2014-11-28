using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float Velocity = 1.0f;
	public bool InvertMovement = false;
	
	private int positionChange = 1;
	private Vector3? targetPosition = null;

	// Use this for initialization
	void Start () {
		this.positionChange = (InvertMovement) ? -1 : 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (targetPosition == null) {
			if (Input.GetAxis ("Horizontal") > 0)
				targetPosition = new Vector3 (this.transform.position.x + this.positionChange, this.transform.position.y, 0);
			else if (Input.GetAxis ("Horizontal") < 0)
				targetPosition = new Vector3 (this.transform.position.x - this.positionChange, this.transform.position.y, 0);

			if (Input.GetAxis ("Vertical") > 0)
				targetPosition = new Vector3 (this.transform.position.x, this.transform.position.y + this.positionChange, 0);
			else if (Input.GetAxis ("Vertical") < 0)
				targetPosition = new Vector3 (this.transform.position.x, this.transform.position.y - this.positionChange, 0);
		}

		if (targetPosition != null) {
			this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition.Value, this.Velocity*Time.deltaTime);
			if (this.transform.position == targetPosition.Value)
				targetPosition = null;
		}
	}
}
