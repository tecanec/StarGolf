using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStuff : MonoBehaviour {
    float timeWhenFirstGrounded = -1;
    float timeWhenLastGrounded = -1;

    GameObject result;
    int FromTurn;

    public void Initialize(BallType type, int fromPlayer, int fromTurn)
    {
        GetComponent<SpriteRenderer>().sprite = type.sprite[fromPlayer];
        result = type.result;
        FromTurn = fromTurn;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (timeWhenLastGrounded < Time.time - 1)
        {
            timeWhenFirstGrounded = Time.time;
        }

        if (timeWhenFirstGrounded < Time.time - 3)
        {
            if (FromTurn == GolfCannon.turnCount)
            {
                GolfCannon.shootCooldown = -1;
            }

            Instantiate(result, transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(collision.contacts[0].normal.y, -collision.contacts[0].normal.x)));
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        timeWhenLastGrounded = Time.time;
    }
}
