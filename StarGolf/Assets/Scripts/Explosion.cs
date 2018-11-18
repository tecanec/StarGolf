using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cool guys don't look at explosions!

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DestroySurroundings()
    {
        print("Pizza");
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        print("Cheese");
    }
}
