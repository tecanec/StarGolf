using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfCannon : MonoBehaviour {
    public Camera cam;

    public GameObject golfBallPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, -Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject Ball = Instantiate(golfBallPrefab, transform.position, transform.rotation);
            Ball.GetComponent<Rigidbody2D>().velocity = transform.rotation * Vector2.up * 5;
        }
	}
}
