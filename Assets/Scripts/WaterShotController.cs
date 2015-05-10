using UnityEngine;
using System.Collections;

public class WaterShotController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D>().velocity = -10f * transform.right;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag=="Wall")
		{
			Destroy(this.gameObject);
			Debug.Log(coll.gameObject.tag);
		}
		
	}
}
