using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour {

    private int a;

	// Use this for initialization
	void Start () {

        a = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
        a++;
        if (a > 50)

        Destroy(this.gameObject);
	
	}
}
