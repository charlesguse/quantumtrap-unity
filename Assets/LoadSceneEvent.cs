using UnityEngine;

public class LoadSceneEvent : MonoBehaviour {

	public void LoadScene (string name)
	{
		//Debug.Log ("UP IN HURRR");
		Application.LoadLevel (name);
	}
}
