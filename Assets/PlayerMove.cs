using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float Velocity = 1.0f;
	public bool InvertMovement = false;

	public bool IsMoving {
		get {
			return targetPosition.HasValue;
		}
	}

	private int positionChange = 1;
	private Vector3? targetPosition = null;
    private Vector3 startPosition;
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

            if (targetPosition.HasValue)
            {
                startPosition = this.transform.position;
            }
		}

		if (targetPosition != null) {
			this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition.Value, this.Velocity*Time.deltaTime);
			if (this.transform.position == targetPosition.Value)
            {
                targetPosition = null;
                this.transform.position =new Vector3(Mathf.Round(this.transform.position.x), 
                                                       Mathf.Round(this.transform.position.y),
                                                       Mathf.Round(this.transform.position.z));
            }
		}
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        targetPosition = startPosition;
    }
}
