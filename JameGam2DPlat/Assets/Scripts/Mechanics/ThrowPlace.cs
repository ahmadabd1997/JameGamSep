using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using MoreMountains.Feedbacks;

public class ThrowPlace : MonoBehaviour
{
    [SerializeField] private ThrowableToy throwableToyPrefab;
    [SerializeField] private float cooldownAmount;
    private float cooldownTimer;
    [SerializeField] private MMF_Player readyFeedback;
    [SerializeField] private MMF_Player cooldownFeedback;
    [SerializeField] private MMF_Player notReadyYetFeedback;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate(){
        if(cooldownTimer > 0){
            cooldownTimer -= Time.deltaTime;
            cooldownFeedback.PlayFeedbacks();
            if(cooldownTimer <= 0){
                readyFeedback.PlayFeedbacks();
            }
        }
    }

    public void ThrowToy(){
        Debug.LogWarning(name + " Try to throw!!");
        if(cooldownTimer <= 0){
            Debug.LogWarning("Throwing time!!!");
            cooldownTimer = cooldownAmount;
            readyFeedback.PlayFeedbacks();
            Instantiate(throwableToyPrefab, transform.position, transform.rotation);
        }
        else
        {
            notReadyYetFeedback.PlayFeedbacks();
            Debug.LogWarning("Could't Timer!!");
        }
    }

}
