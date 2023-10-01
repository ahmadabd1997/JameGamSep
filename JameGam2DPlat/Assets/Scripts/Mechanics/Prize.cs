using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Prize : MonoBehaviour
{
    [SerializeField] private ThiefController thief;
    [SerializeField] private GameObject prizesParent;
    [SerializeField] private MMF_Player dropFeedback;
    public bool ready = true;
    private Vector3 startPoint;
    private float cooldownTimer;

    private void Awake() {
        startPoint = transform.position;
    }

    public void ThiefGot(ThiefController other){
        thief = other;
        transform.parent = other.transform;
        ready = false;
    }

    public void ThiefDied(){
        Debug.LogWarning("the thief died!!");
        cooldownTimer = 1;
        thief = null;
        transform.parent = prizesParent.transform;
        dropFeedback.PlayFeedbacks();
    }

    public void ThiefRanAway(){
        Debug.LogWarning("the thief Ran!!");
        cooldownTimer = 1;
        thief = null;
        transform.parent = prizesParent.transform;
        dropFeedback.PlayFeedbacks();
        transform.position = startPoint;
    }

     private void FixedUpdate(){
        if(cooldownTimer > 0){
            cooldownTimer -= Time.deltaTime;
            if(cooldownTimer <= 0){
                ready = true;
            }
        }
    }
}
