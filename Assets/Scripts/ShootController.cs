using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {

    public float speed;
	//public GameObject weapon;

	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody2D>().velocity = speed * transform.right;
	}

    //public void shoot(Vector3 position)
    //{
    //    this.transform.position = position;
       
    //}

}
