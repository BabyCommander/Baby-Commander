using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int life;
	public GameObject Loot;
    public GameObject ms2;


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
			{
                Vector2 pp2 = new Vector2(coll.transform.position.x, coll.transform.position.y + 4.5f);
				Instantiate(Loot, transform.position, transform.rotation);
				Destroy(this.gameObject);
                Instantiate(this.ms2, pp2, coll.transform.rotation);
                
			}
				



			life--;
		}

	}

}
