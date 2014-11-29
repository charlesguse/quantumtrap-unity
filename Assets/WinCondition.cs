using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {
	public string NextLevel;
	public string PlayerObjectName = "Player";
	public string GoalObjectName = "Lepton";

	private PlayerMove playerObject;
	private PlayerMove goalObject;

	// Use this for initialization
	void Start () {
		playerObject = (PlayerMove)GameObject.Find (PlayerObjectName).GetComponent<PlayerMove>();
		goalObject = (PlayerMove)GameObject.Find (GoalObjectName).GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerObject.transform.position == goalObject.transform.position && !playerObject.IsMoving && !goalObject.IsMoving) {
			TriggerWin();
		}
	}

	private void TriggerWin() {
		Application.LoadLevel (NextLevel);
	}
}
