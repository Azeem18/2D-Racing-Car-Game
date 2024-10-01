using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Transform transform;
    public float speed = 0.5f;
    public float rotationSpeed = 5f;
    public Score_Manager scoreValue;
    public GameObject gameOverPanel;
    public GameObject gamePauseButton;

    void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1; //It is used here to unfreeze the game when user restarts game
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        clamp();
        
    }

    void Movement(){
        //Moving player car right
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.position += new Vector3(speed*Time.deltaTime,0,0);
            //Rotating player car towards right
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0,0,-47), rotationSpeed*Time.deltaTime);
        }

        //Moving player car left
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.position -= new Vector3(speed*Time.deltaTime,0,0);
            //Rotating player car towards left
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0,0,47), rotationSpeed*Time.deltaTime);
        }

        //Changing player car rotation back to normal position when we release left or right arrow key
        if(transform.rotation.z != 90)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0,0,0), 10f*Time.deltaTime);
        }
    }

    void clamp(){
        //First Way
        //Prevent player car from going out of bounds from right side
        // if(transform.position.x < -2.55){
        //     transform.position = new Vector3(-2.55f,transform.position.y,transform.position.z);
        // }
        // //Prevent player car from going out of bounds from left side
        // if(transform.position.x > 2.69){
        //     transform.position = new Vector3(2.69f,transform.position.y,transform.position.z);
        // }

        //Second Way
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x,-2.55f,2.69f);
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "cars"){
            Time.timeScale = 0; //It is used to freeze game on collision
            gameOverPanel.SetActive(true);
            gamePauseButton.SetActive(false);
        }

        if(collision.gameObject.tag == "Coin"){
          scoreValue.score +=10; //If player gets coin score value will be added by 10 
          Destroy(collision.gameObject); //It will destroy the object onto which our player car collides
    }
}
}
