using UnityEngine;
using System.Collections;


public class Item
{
    public GameObject weapon;
    public int ammo = 0;
    public float fireRate = 1;

    void shoot()
    {
        if (ammo > 0)
            ammo--;
    }

}


public class BabyController2 : MonoBehaviour
{

    private Animator thebabyAnimator;

    public float speed;

    public GameObject WeaponSpawn;
    public Weapon weapon;
    public GameObject gun;

    private bool facingRight = true;
    private float offset_weaponplayer;
   

    private Rigidbody2D thebaby;
    private float nextJump;

    private GameObject gun2;

    // Use this for initialization
    void Start()
    {
        thebaby = this.GetComponent<Rigidbody2D>();
        thebabyAnimator = GetComponent<Animator>();

        weapon = new Weapon();

        thebabyAnimator.SetBool("haveItem", false);
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * -1 * speed, 0f);

        if (Input.GetAxis("Vertical")>0 && this.transform.position.y < -2f
            )
        {
            this.transform.Translate(new Vector2(0f, 1.5f));
        }

        //if (Time.time >= nextJump + 0.75)
        //{
        //    this.transform.Translate(new Vector2(0f, Input.GetAxis("Vertical") * 2));
        //    nextJump = Time.time;
        //}

        //if (Input.GetMouseButtonDown(0))
        //{
        //    //fire
        //}


        float move = Input.GetAxis("Horizontal");

        if (move > 0 && !facingRight)
        {
            Flip();

            if (weapon != null)
                if (weapon.weapon != null)
                    weapon.weapon.transform.Translate(new Vector2(movement.x + 8 * 20, movement.y));
        }
        else if (move < 0 && facingRight)
        {
            Flip();

            if (weapon != null)
                if (weapon.weapon != null)
                    weapon.weapon.transform.Translate(new Vector2(movement.x - 8 * 20, movement.y));
        }

        this.transform.Translate(movement);

    }


    void FixedUpdate()
    {


        //if (Input.GetMouseButtonDown(0))
        //{
        //    //fire
        //}

        thebabyAnimator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));


        //if (weapon.ammo == 0)
        //{
        //    thebabyAnimator.SetBool("haveItem", false);
        //}
        //else
        //{
        //    thebabyAnimator.SetBool("haveItem", true);
        //}

        //if (weapon != null)
        //    if (weapon.weapon != null)
        //    {
        //        weapon.weapon.transform.position = WeaponSpawn.transform.position;
        //    }

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

        weapon.weapon.transform.localScale = theScale;

    }


    public void setWeapon(string Bez)
    {
        if (Bez == "Watergun")
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
