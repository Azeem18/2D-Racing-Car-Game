using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoinSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CoinSpawn(){
        float CoinPos = Random.Range(-2.55f,2.69f);
        Instantiate(coinPrefab,new Vector3(CoinPos,transform.position.y,transform.position.z),Quaternion.identity);
    }

    IEnumerator CoinSpawner(){
        int time = Random.Range(1,3);
        while(true){
            yield return new WaitForSeconds(time);
            CoinSpawn();
        }
    }
}
