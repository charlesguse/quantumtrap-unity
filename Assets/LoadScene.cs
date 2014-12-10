using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
	GameObject Scene;
	// Use this for initialization
	void Select(string name) {
		Application.LoadLevel(name);
	}
}
