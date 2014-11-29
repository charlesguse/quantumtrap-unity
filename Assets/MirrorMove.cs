using UnityEngine;
using System.Collections;
using System;

public class MirrorMove : MonoBehaviour {
	private Vector3 mirrorPosition;
	public GameObject ObjectToMirror;
	// Use this for initialization
	void Start () {
		mirrorPosition = ObjectToMirror.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		var delta = ObjectToMirror.transform.position - mirrorPosition;
		mirrorPosition = ObjectToMirror.transform.position;

		this.transform.position -= delta;

        if (delta == Vector3.zero)
        {
            this.transform.position = new Vector3(Mathf.Round(this.transform.position.x),
                                                       Mathf.Round(this.transform.position.y),
                                                       Mathf.Round(this.transform.position.z));
        }
	}
}
