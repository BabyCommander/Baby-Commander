using UnityEngine;
using System.Collections;


public class Weapon
{
	public GameObject weapon;
	public int ammo = 0;
	public float fireRate = 1; 

	void shoot()
	{
		if(ammo >0)
			ammo--;
	}

}


public class PlayerController : MonoBehaviour {

	public float speed;

	public GameObject WeaponSpawn;
	public GameObject gun;
	public Weapon weapon;

	private bool facingRight = true;
	public Animator anim;

	private float nextJump;

	private GameObject gun2;

	// Use this for initialization
	void Start () {
		weapon = new Weapon();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * -1 * speed, 0f);


		if (Time.time >= nextJump + 0.75)
		{
			this.transform.Translate(new Vector2(0f, Input.GetAxis("Vertical") * 2));
			nextJump = Time.time;
		}

		if (Input.GetMouseButtonDown(0) )
		{   
			if(weapon.weapon != null)
			{
				if (this.weapon.weapon != null & WeaponSpawn != null) {
					if (weapon.ammo != 0)
					{
						Instantiate(this.weapon.weapon.gameObject.GetComponent<WeaponController>().ammotype, WeaponSpawn.transform.position, WeaponSpawn.transform.rotation);
						this.weapon.ammo--;
					}
					
				}
			}
				//fire
		}


		float move = Mathf.Abs(Input.GetAxis("Horizontal")),
			moveX = Input.GetAxis("Horizontal");

		if (moveX > 0 && !facingRight)
		{
			Flip();

			if (weapon != null)
				if (weapon.weapon != null)
					weapon.weapon.transform.Translate(new Vector2(movement.x + 8*20, movement.y));
		}
		else if (moveX < 0 && facingRight)
		{
			Flip();

			if (weapon != null)
				if (weapon.weapon != null)
					weapon.weapon.transform.Translate(new Vector2(movement.x - 8*20, movement.y));
		}



		this.transform.Translate(movement);
	}


	void FixedUpdate()
	{

		//Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * -1 * speed, 0f);

		float move = Mathf.Abs(Input.GetAxis("Horizontal")),
			moveX = Input.GetAxis("Horizontal");

		//if (Time.time >= nextJump + 0.75)
		//{
		//    this.transform.Translate(new Vector2(0f, Input.GetAxis("Vertical") * 2));
		//    nextJump = Time.time;
		//}

		if (Input.GetMouseButtonDown(0))
		{
			//Instantiate()
			//fire
		}
		
		anim.SetFloat("speed", move);

		anim.SetBool("haveItem", false);
		 
		
		if (weapon.ammo == 0)
		 {
			 anim.SetBool("haveItem", false);
		 }
		 else
		 {
			 anim.SetBool("haveItem", true);
		 }

		if (moveX > 0 && !facingRight)
		{
			Flip();
		}
		else if (moveX < 0 && facingRight)
		{
			Flip();
		}


		if (weapon != null)
			if (weapon.weapon != null)
			{
				weapon.weapon.transform.position = WeaponSpawn.transform.position;
			}

	   // this.transform.Translate(movement);


	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		theScale = weapon.weapon.transform.localScale;
		theScale.x *= -1;
	   // theScale.y *= -1;
		weapon.weapon.transform.localScale = theScale;
		
	}


	public void setWeapon(string Bez)
	{
		if(Bez == "Watergun")
		{
			Debug.Log(gun);
			Debug.Log(WeaponSpawn);
			Destroy(weapon.weapon);
			weapon.weapon = (GameObject)Instantiate(gun, WeaponSpawn.transform.position, WeaponSpawn.transform.rotation);
			weapon.weapon.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);


			if (facingRight) { 
				Vector2 theScale;
				theScale = weapon.weapon.transform.localScale;
				theScale.x *= -1;
				weapon.weapon.transform.localScale = theScale;
			}

			//gun.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			weapon.ammo = 5;
		}
	}


}
