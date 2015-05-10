using UnityEngine;
using System.Collections;

public class Spinne : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("kommt nicht an");
        if (coll.gameObject.tag == "Player")
        {

            Application.LoadLevel("level-3");

        }
    }

	
	
}
