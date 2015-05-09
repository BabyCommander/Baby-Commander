using UnityEngine;
using System.Collections;

public class BabyController : MonoBehaviour {

    private Rigidbody2D baby;
    private bool facingRight = true;

    public Animator anim;
    public float speed;


	// Use this for initialization
	void Start () {

        baby = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal")*speed*-1, Input.GetAxis("Vertical")*speed);
        this.transform.Translate(movement);
 
	}

    void FixedUpdate()
    {

        float move = Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")),
            moveX = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", move);

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


}
