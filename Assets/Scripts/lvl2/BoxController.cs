using UnityEngine;
using System.Collections;

public class BoxController2 : MonoBehaviour {

	public GameObject lootWindow;
	public Sprite Item;//GameObject Item;
	
	//sonst zu schnell mit der steuerung
	private float nextOpenTime;

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
				if (lootWindow.tag == "Loot" && (Time.time >= nextOpenTime + 0.5))
				{
					lootWindow.SetActive(!lootWindow.activeSelf);
					nextOpenTime = Time.time;
				}

			}
		}

	}


	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{     
					lootWindow.SetActive(false); 
		}
	}


}
