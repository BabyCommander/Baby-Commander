using UnityEngine;
using System.Collections;

public class WaterShotController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody2D>().velocity = 10f * transform.right;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
