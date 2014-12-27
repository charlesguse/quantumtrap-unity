using UnityEngine;

public class LoadSceneEvent : MonoBehaviour {

	public void LoadScene (string name)
	{
		Application.LoadLevel (name);
	}
}
