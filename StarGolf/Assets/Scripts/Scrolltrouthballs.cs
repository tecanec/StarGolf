using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolltrouthballs : MonoBehaviour {

	public List<Transform> allObjectsInRange;
	public List<float> relatedDistances;
	public List<string> Balls;
	private List<string> Ballimages;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int cnt = 0; cnt < allObjectsInRange.Count; cnt++)
		{
			relatedDistances[cnt] = Vector2.Distance(transform.position, allObjectsInRange[cnt].position);
			Debug.Log(allObjectsInRange);
		}

		for (int ImagesinBalls = 0; ImagesinBalls < Balls.Count; ImagesinBalls++)
		{
			if (Input.GetKeyDown("Mouse ScrollWheel")) ;
		}
	}
}
