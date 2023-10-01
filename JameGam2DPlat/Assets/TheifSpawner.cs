using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheifSpawner : MonoBehaviour
{
    [SerializeField] private ThiefController theifPrefab;
    [SerializeField] private float minTimeToWait;
    [SerializeField] private float maxTimeToWait;
    
    [SerializeField] private int minSpeed = 50;
    [SerializeField] private int maxSpeed = 70;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(Random.Range(minTimeToWait, maxTimeToWait)));
    }

    private IEnumerator Spawn(float waitTime)
    {
        while (true)
        {
            var thief = Instantiate(theifPrefab, transform.position, transform.rotation);
            thief.speed = Random.Range(minSpeed, maxSpeed);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
