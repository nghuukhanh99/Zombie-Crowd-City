using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Citizen : MonoBehaviour
{
    public static Citizen Instance;

    public GameObject[] WayPoints;

    NavMeshAgent agent;

    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();

        int direction = Random.Range(0, WayPoints.Length);

        agent.SetDestination(WayPoints[direction].transform.position);

       
    }

    
    void Update()
    {
        if(agent.remainingDistance < 0.5)
        {
            int direction = Random.Range(0, WayPoints.Length);

            agent.SetDestination(WayPoints[direction].transform.position);
        }
    }

   

    
}
