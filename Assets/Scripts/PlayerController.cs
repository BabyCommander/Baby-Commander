using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody2D player_rb;
	private float nextJump;

	// Use this for initialization
	void Start () {
		player_rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * speed,0f);

		if (Time.time >= nextJump + 1)
		{	
			//player_rb.AddForce(new Vector2(0f, Input.GetAxis("Vertical") * jumpforce));
			this.transform.Translate(new Vector2(0f, Input.GetAxis("Vertical") * 2 ));
			nextJump = Time.time;
		}


		this.transform.Translate(movement);
	}

}
