using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfCannon : MonoBehaviour
{
	public Camera cam;
	public GameObject golfBallPrefab;

	static List<GolfCannon> allPlayers = new List<GolfCannon>();
	static int currentPlayerID;
	int myID;
	bool canshoot = true;
	int CountClones = 0;
	public static float shootCooldown = 0;
	public static int turnCount = 0;

	public BallType[] ammonitionType;

	// Use this for initialization
	void Start()
	{
		myID = allPlayers.Count;
		allPlayers.Add(this);
	}

	// Update is called once per frame
	void Update()
	{

		if (currentPlayerID == myID)
		{
			if (shootCooldown <= 0)
			{
				Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
				transform.rotation = Quaternion.Euler(0, 0, -Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg);

				if (Input.GetKeyDown(KeyCode.Mouse0))
				{
					if (canshoot == true)
					{
						GameObject Ball = Instantiate(golfBallPrefab, transform.position, transform.rotation);
						Ball.GetComponent<Rigidbody2D>().velocity = transform.rotation * Vector2.up * 5;
						Ball.GetComponent<BallStuff>().Initialize(ammonitionType[0], 0, turnCount + 1);

						shootCooldown = 10;
						EndTurn();
					}
					else
					{
						Debug.Log("You can not shoot right now!");
					}
				}
			}
			else
			{
				shootCooldown -= Time.deltaTime;
			}
		}

	}
	void EndTurn()
	{
		turnCount++;
		currentPlayerID++;

		if (currentPlayerID >= allPlayers.Count)
		{
			currentPlayerID = 0;
		}

		print(currentPlayerID);
	}
}
