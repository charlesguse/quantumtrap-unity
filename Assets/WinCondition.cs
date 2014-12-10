using UnityEngine;
using System.Collections;

//[RequireComponent  (typeof(PlayerMove))]
public class WinCondition : MonoBehaviour {
	public string NextLevel;
	public GameObject GoalObject;
	public AudioClip WinSound;

	private PlayerMove playerMove;
	private bool won;

	// Use this for initialization
	void Start () {
		won = false;
		playerMove = (PlayerMove)this.GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!won && transform.position == GoalObject.transform.position && !playerMove.IsMoving) {
			won = true;
			Destroy(playerMove);
			StartCoroutine(TriggerWin());
		}
	}

	IEnumerator TriggerWin() {
		audio.PlayOneShot(WinSound);
		yield return new WaitForSeconds(2);
		Application.LoadLevel (NextLevel);
	}
}
