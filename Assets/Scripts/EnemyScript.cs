using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int life;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Shot")
		{   

			if(life < 1)
			    Destroy(this.gameObject);



			life--;
		}

	}

}
