using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {


	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.tag != "Shot")
			Destroy(coll.gameObject.GetComponent<Rigidbody2D>());
	}
}
