using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemasta : MonoBehaviour
{

	private Rigidbody2D bruteRigidBody;
	private float DistanceToNearislands;
	private Vector2 center;
	public float radius;
	bool gamerunning;

	List<string> Player1ownedislands;
	List<string> Player2ownedislands;

	// Use this for initialization
	void Start()
	{
		gamerunning = true;
	}

	// Update is called once per frame
	void Update()
	{
		center = transform.position;
		PathFinder(center, radius);
	}

	void PathFinder(Vector2 center, float radius)
	{
		Collider2D[] PlanetsNear = Physics2D.OverlapCircle(center, radius, Owned);
		int i = 0;
		while (i < PlanetsNear.Length)
		{
			if (PlanetsNear[i].gameObject.tag == "FreeIsland")
			{
				DistanceToNearislands = Vector3.Distance(center, PlanetsNear[i].transform.position);
			}
			if (PlanetsNear[i].gameObject.tag == "EnemyIsland")
			{
				DistanceToNearislands = Vector3.Distance(center, PlanetsNear[i].transform.position);
			}
			i++;
		}
	}
}