using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using MoreMountains.Feedbacks;

public class ThrowableToy : MonoBehaviour
{
    [SerializeField] private LayerMask thiefLayerMask;

    [SerializeField] private MMF_Player hitFeedback;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.LogWarning(name + " I hit something!");
        var thief = other.gameObject.GetComponent<EnemyController>();
        if(thief != null){
            thief.GetHit();
            hitFeedback.PlayFeedbacks();
        }
        
    }

}
