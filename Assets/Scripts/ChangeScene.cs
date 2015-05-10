using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public GameObject level1; 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Return))
			Application.LoadLevel("2level");

	}



	public void ChangeSzene (string level)
	{
		//if(level == "1")
		//{
			Debug.Log("Load Level1");
			Application.LoadLevel("1tutorial");
		   // level1.LoadLevel();
		//}

	}
}
