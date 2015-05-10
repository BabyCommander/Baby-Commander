using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int health;
	public GameObject Loot;


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
			if(health < 1)
			{
				Instantiate(Loot, transform.position, transform.rotation);
				Destroy(this.gameObject);

			}
			health--;
		}
        else if (coll.gameObject.tag == "Player")
        {
            PlayerController tmp = coll.gameObject.GetComponent<PlayerController>();
            tmp.health --;

            if (tmp.health < 0)
                Application.LoadLevel("Menue");

            

        }

	}

}
