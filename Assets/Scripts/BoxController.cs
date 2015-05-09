using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour {

    public GameObject loot;

	// Use this for initialization
	void Start () {

        loot.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}



	void OnCollisionStay2D(Collision2D coll)
	{
		
		if (coll.gameObject.tag == "Player")
		{
            
			    if (Input.GetKey(KeyCode.E))
			    {
                    if(loot.tag == "Loot")
                    {
                        loot.SetActive(true);
                    }

			    }
		}
	}

}
