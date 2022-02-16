using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenSpawn : MonoBehaviour
{
    public static CitizenSpawn Instance;

    public List<GameObject> CitizenObject = new List<GameObject>();

 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }

    void Start()
    {
        
    }

    
    void Update()
    {
        SpawnCitizen();
        
    }

    public void SpawnCitizen()
    {
        if(this.CitizenObject.Count >= 10)
        {
            return;
        }

        int index = this.CitizenObject.Count + 1;

        Vector3 spawnPos = new Vector3(transform.position.x, 22f, transform.position.z);

        GameObject citizen = Instantiate(CitizenObject[0], spawnPos, Quaternion.identity);

        this.CitizenObject.Add(citizen);
       
    }

    

    
}
