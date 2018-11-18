using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoTypes : MonoBehaviour {

	public List<string> Ammotypes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			foreach (string BallType in Ammotypes) ;
			{
				Debug.Log("New type");
			}
		}
	}
}
