using UnityEngine;
using System.Collections;


public class BabyController : MonoBehaviour
{

    public float speed;

    public GameObject WeaponSpawn;
    public GameObject helmetSpawn;
    public GameObject gun;
    public Weapon weapon;
    public GameObject WaterShot;
    public GameObject helmet;
    public GameObject doodle;
    public GameObject msuccess1;
    private bool ms1, ms2;

    public Sprite helmetSprite;
    public Sprite WeaponSprite;

    private bool facingRight = true;


    private Animator anim;

    private float nextJump;

    private GameObject gun2;
    private bool drawable;

    private SpriteRenderer[] bag;
    private bool hasWeapon;

    // Use this for initialization
    void Start()
    {
        bag = new SpriteRenderer[2];
        hasWeapon = false;
        weapon = new Weapon();
        anim = GetComponent<Animator>();
        drawable = false;
        ms1 = false;
        ms2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * -1 * speed, 0f);

        if (Time.time >= nextJump + 0.75)
        {
            this.transform.Translate(new Vector2(0f, Input.GetAxis("Vertical") * 2));
            nextJump = Time.time;
        }

        int dir = 1;
        if (!facingRight)
        {
            dir = -1;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (hasWeapon)
            {
                if (weapon.ammo != 0)
                {

                    Quaternion g = WeaponSpawn.transform.rotation;
                    Quaternion h = new Quaternion(WeaponSpawn.transform.rotation.x, WeaponSpawn.transform.rotation.y, WeaponSpawn.transform.rotation.z, dir * WeaponSpawn.transform.rotation.w);
                    Instantiate(this.WaterShot, WeaponSpawn.transform.position, h);
                    this.weapon.ammo--;
                }
            }
            else if (drawable)
            {
                if (!ms1)
                {
                    Vector2 pp = new Vector2(transform.position.x, transform.position.y + 0.5f);
                    Vector2 pp2 = new Vector2(transform.position.x, transform.position.y + 4.5f);
                    Instantiate(this.doodle, pp, transform.rotation);
                    Instantiate(this.msuccess1, pp2, transform.rotation);
                    ms1 = true;
                }
            }
        }

        this.transform.Translate(movement);
    }


    public void Draw()
    {

        drawable = true;

    }

    void FixedUpdate()
    {
        float move = Mathf.Abs(Input.GetAxis("Horizontal")),
            moveX = Input.GetAxis("Horizontal");

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

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    public void setWeapon(string Bez)
    {
        if (Bez == "Watergun")
        {
            drawable = false;
            Destroy(weapon.weapon);

            if (!hasWeapon)
            {
                if (bag != null)
                    bag = this.gameObject.GetComponentsInChildren<SpriteRenderer>();

                for (int i = 0; i < 3; i++)
                {
                    Debug.Log("Fuck Weapon Spawn");
                    if (((SpriteRenderer)bag[i]).tag == "WeaponSpawn")
                    {
                        Debug.Log(bag[i].gameObject.tag);

                        bag[i].GetComponent<SpriteRenderer>().sprite = WeaponSprite;
                        hasWeapon = true;
                    }
                }
            }

            weapon.ammo = 50;
        }
        else if (Bez == "Crayon")
        {
            drawable = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Present")
        {
            Instantiate(helmet, coll.transform.position, coll.transform.rotation);
            Destroy(coll.gameObject);
            Application.LoadLevel("Menue");
        }

        Debug.Log("Collision: " + coll.gameObject.tag);
        if (coll.gameObject.tag == "Helmet")
        {
            Debug.Log("Helmet found ");
            Destroy(coll.gameObject);

            if (bag != null)
                bag = this.gameObject.GetComponentsInChildren<SpriteRenderer>();

            for (int i = 0; i < 3; i++)
            {
                Debug.Log(bag[i].gameObject.tag);
                if (((SpriteRenderer)bag[i]).tag == "HelmetSpawn")
                {
                    Debug.Log("HelmetSprite");
                    bag[i].GetComponent<SpriteRenderer>().sprite = helmetSprite;

                }
            }
        }

    }

}
