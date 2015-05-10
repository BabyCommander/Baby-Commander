using UnityEngine;
using System.Collections;

public class WaterShotController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (transform.rotation.w>0)
		{
			this.GetComponent<Rigidbody2D>().velocity = -10f * transform.right;
		  //  this.transform.rotation = new Quaternion(this.transform.rotation.x, -1* this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
		} else
			this.GetComponent<Rigidbody2D>().velocity = 10f * transform.right;
		
		

		Debug.Log(transform.rotation.x + "+++ y " + transform.rotation.y + "+++ w " + transform.rotation.w);
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity*1.01f;
	}


	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag=="Wall")
		{
			Destroy(this.gameObject);
		}
		
	}
}
