using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStuff : MonoBehaviour {
    float timeWhenFirstGrounded = -1;
    float timeWhenLastGrounded = -1;

    BallType type;
    int FromTurn;
    int FromPlayer;

    public void Initialize(BallType myType, int fromPlayer, int fromTurn)
    {
        type = myType;
        FromTurn = fromTurn;
        FromPlayer = fromPlayer;
        GetComponent<SpriteRenderer>().sprite = type.ballSprite[fromPlayer];
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

            Instantiate(type.result, transform.position, Quaternion.Euler(0, 0, -Mathf.Atan2(collision.contacts[0].normal.x, collision.contacts[0].normal.y) * Mathf.Rad2Deg))
                .GetComponent<SpriteRenderer>().sprite = type.resultSprite[FromPlayer];
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        timeWhenLastGrounded = Time.time;
    }
}
