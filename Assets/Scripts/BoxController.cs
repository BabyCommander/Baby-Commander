using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour {

    public GameObject lootWindow;

	// Use this for initialization
	void Start () {

        lootWindow.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}



	void OnTriggerStay2D(Collider2D other)
	{




        if (other.tag == "Player")
        {

            if (Input.GetKey(KeyCode.E))
            {
                if (lootWindow.tag == "Loot")
                {
                    lootWindow.SetActive(!lootWindow.activeSelf);
                }

            }
        }

   //     other.attachedRigidbody.AddForce(new Vector2(200, 200));


	}

}
