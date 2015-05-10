using UnityEngine;
using System.Collections;

public class Pampas : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}