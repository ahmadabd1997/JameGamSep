using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class ThiefController :  MonoBehaviour {
    [SerializeField] public float speed;
    int lookingRight = 1;
    [SerializeField] private MMF_Player gotHitFeedback;
    [SerializeField] private MMF_Player happyFeedback;
    [SerializeField] private bool moving = true;
    [SerializeField] private Prize prize;
    [SerializeField] private Rigidbody2D rigidbody2D;

    private void FixedUpdate() {
        if(moving){
            // transform.position = new Vector2(transform.position.x + (lookingRight * speed * Time.deltaTime),transform.position.y);
            rigidbody2D.velocity = new Vector2((lookingRight * speed * Time.deltaTime), 0);
        }
        else{
            rigidbody2D.velocity = new Vector2(0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Debug.LogWarning(name + "I collided.");
        var collision = other.gameObject.GetComponent<Wall>();
        if(collision != null){
            lookingRight = -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.LogWarning(name + " I entered a trigger.");
        var collision = other.gameObject.GetComponent<Prize>();
        if(collision != null){
            if(collision.ready){
                collision.ThiefGot(this);
                prize = collision;
                lookingRight = -1;
            }
        }

        var collision2 = other.gameObject.GetComponent<OutOfRoom>();
        if(collision2 != null){
            if(prize != null){
                if(moving){
                    moving = false;
                    happyFeedback.PlayFeedbacks();
                    prize.ThiefRanAway();
                    FindObjectOfType<GameManager>().ThiefRanOut();
                }
            }
            else{
                gotHitFeedback.PlayFeedbacks();
            }
        }
    }

    public void GetHit(){
        if(moving){
            Debug.LogWarning(name + " Got Hit!!" );
            if(prize != null){
                prize.ThiefDied();
            }
            FindObjectOfType<GameManager>().ThiefOut();
            moving = false;
            gotHitFeedback.PlayFeedbacks();
        }
        
    }
}