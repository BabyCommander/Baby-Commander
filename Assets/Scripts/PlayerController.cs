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
	public Weapon weapon;
	public GameObject gun;

	private bool facingRight = true;
	private float offset_weaponplayer;
	public Animator anim;

	private Rigidbody2D player_rb;
	private float nextJump;

	private GameObject gun2;

	// Use this for initialization
	void Start () {
		player_rb = this.GetComponent<Rigidbody2D>();
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

		if (Input.GetMouseButtonDown(0))
		{
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
			weapon.weapon = (GameObject)Instantiate(gun, WeaponSpawn.transform.position, WeaponSpawn.transform.rotation);
            weapon.weapon.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            Vector2 theScale;
            theScale = weapon.weapon.transform.localScale;
            theScale.x *= -1;
            weapon.weapon.transform.localScale = theScale;

			//gun.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			weapon.ammo = 5;
		}
	}


}
