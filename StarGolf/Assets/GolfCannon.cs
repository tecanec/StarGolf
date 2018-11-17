﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfCannon : MonoBehaviour {
	public Camera cam;
	public GameObject golfBallPrefab;

    static List<GolfCannon> allPlayers = new List<GolfCannon>();
    static int currentPlayerID;
    int myID;
    static int lastDoneFrame;

    public List<Transform> allObjectsInRange; // GameObjects to enclose into calculations, basically all which ever entered the sphere collider.
    public List<float> relatedDistances;

    // Use this for initialization
    void Start () {
        myID = allPlayers.Count;
        allPlayers.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
        if (currentPlayerID == myID && lastDoneFrame != Time.frameCount)
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.rotation = Quaternion.Euler(0, 0, -Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg);
    
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject Ball = Instantiate(golfBallPrefab, transform.position, transform.rotation);
                Ball.GetComponent<Rigidbody2D>().velocity = transform.rotation * Vector2.up * 5;
                    
                EndTurn();
            }

            for (int cnt = 0; cnt < allObjectsInRange.Count; cnt++)
            {
                relatedDistances[cnt] = Vector2.Distance(transform.position, allObjectsInRange[cnt].position);
                Debug.Log(allObjectsInRange);
            }
        }
	}

    void EndTurn()
    {
        currentPlayerID++;

        if (currentPlayerID >= allPlayers.Count)
        {
            currentPlayerID = 0;
        }

        lastDoneFrame = Time.frameCount;

        print(currentPlayerID);
    }
}
