using UnityEngine;
using System.Collections;

public class CameraController2 : MonoBehaviour {

	public GameObject player;
 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);

	}
}
