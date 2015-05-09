using UnityEngine;
using System.Collections;


public class Weapon
{
	public GameObject weapon;
	public int ammo = 5;
	public float fireRate = 1; 

	void shoot()
	{
		ammo--;
	}

}


public class PlayerController : MonoBehaviour {

	public float speed;

	public GameObject WeaponSpawn;
	public Weapon weapon;
	public GameObject gun;

	private bool facingRight = true;
	private float offset_weaponplayer;
	public Animator anim;

	private Rigidbody2D player_rb;
	private float nextJump;

	// Use this for initialization
	void Start () {
		player_rb = this.GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		offset_weaponplayer = this.transform.position.x - WeaponSpawn.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * -1 * speed,0f);


		if (Time.time >= nextJump + 0.75)
		{	
			//player_rb.AddForce(new Vector2(0f, Input.GetAxis("Vertical") * jumpforce));
			this.transform.Translate(new Vector2(0f, Input.GetAxis("Vertical") * 2 ));
			nextJump = Time.time;
		}

		if(Input.GetMouseButtonDown(0))
		{
			//fire
		}


		this.transform.Translate(movement);
	}


	void FixedUpdate()
	{

		float move = Mathf.Abs(Input.GetAxis("Horizontal")),
			moveX = Input.GetAxis("Horizontal");
		anim.SetFloat("speed", move);

		 anim.SetBool("haveItem", false);
		//if(weapon.ammo == 0)
		//    anim.SetBool("haveItem", false);
		//else
		//    anim.SetBool("haveItem", true);

		if (moveX > 0 && !facingRight)
		{
			Flip();
		}
		else if (moveX < 0 && facingRight)
		{
			Flip();
		}

	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	//gun.transform.localScale = theScale * -1;
		
	}


	public void setWeapon(string Bez)
	{
		if(Bez == "Watergun")
		{
			Debug.Log(gun);
			Debug.Log(WeaponSpawn);
		//	 gun = (GameObject)Instantiate(gun, WeaponSpawn.transform.position, WeaponSpawn.transform.rotation);
			//gun.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			weapon.ammo = 5;
		}
	}


}
