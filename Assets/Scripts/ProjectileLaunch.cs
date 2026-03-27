using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    public GameObject projectile;
    public float spawnTime;
    public Transform launchPoint;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        if(timer>spawnTime)
        {
            Instantiate(projectile, launchPoint.position, launchPoint.rotation);
            timer = 0f;
        }
    }
}
