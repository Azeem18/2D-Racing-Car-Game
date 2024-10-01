using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Car_Spawner : MonoBehaviour
{
    public GameObject[] car;

    void Start()
    {
        StartCoroutine(SpawnCars());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Cars(){
        //To create copies of car
        int randomCarIndex = Random.Range(0,car.Length);
        float randomxPos = Random.Range(-2.55f,2.69f); //For spawning new cars from random positions on screen
        Instantiate(car[randomCarIndex],new Vector3(randomxPos,transform.position.y,transform.position.z),Quaternion.Euler(0,0,0));
    }
    
    //To create copies of car after specific time
    IEnumerator SpawnCars(){
     while(true){
         yield return new WaitForSeconds(1);
         Cars();
     }
    }
}
