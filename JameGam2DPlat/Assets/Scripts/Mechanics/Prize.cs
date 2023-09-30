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
    private float cooldownTimer;

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

     private void FixedUpdate(){
        if(cooldownTimer > 0){
            cooldownTimer -= Time.deltaTime;
            if(cooldownTimer <= 0){
                ready = true;
            }
        }
    }
}
