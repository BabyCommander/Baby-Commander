using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {

	public float speed;
	//public GameObject weapon;

	// Use this for initialization
	void Start ()
	{
		speed = 10000;
		this.GetComponent<Rigidbody2D>().velocity = speed *transform.right;
	}
	

	void FixedUpdate()
	{
		//this.GetComponent<Rigidbody2D>().transform.Translate(new Vector2(2f * speed, 0f));
	}

	//public void shoot(Vector3 position)
	//{
	//    this.transform.position = position;
	   
	//}

}
