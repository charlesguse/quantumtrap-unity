using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {
	public string NextLevel;
	public GameObject GoalObject;
	public AudioClip WinSound;

	private PlayerMove playerObject;
	private bool won;

	// Use this for initialization
	void Start () {
		won = false;
		playerObject = (PlayerMove)this.GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!won && playerObject.transform.position == GoalObject.transform.position && !playerObject.IsMoving) {
			won = true;
			Destroy(playerObject);
			StartCoroutine(TriggerWin());
		}
	}

	IEnumerator TriggerWin() {
		audio.PlayOneShot(WinSound);
		yield return new WaitForSeconds(2);
		Application.LoadLevel (NextLevel);
	}
}
