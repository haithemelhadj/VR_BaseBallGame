using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrowingScript : MonoBehaviour
{
    //[Tooltip("")]
    //note that this object's x and y position should be the same as the target's x and y position for the code to work properly
    //remember to give the ball prefab "ball" tag for it's collision with the bat
    [Tooltip("this is the ball prefab to spawn(or pull) and then is thrown at the player direction")]
    [SerializeField] private GameObject ballPrefab;
    [Tooltip("this is the centre of the 'hitting zone' where the player is going to hit the balls")]
    [SerializeField] private Transform targetCenter;
    [Tooltip("this is the redius of the 'hitting zone'")]
    [SerializeField] private float zoneRadius = 2f;//2 is realistic


    [Tooltip("the ball is thrown every 'timer' period")]
    [SerializeField] private float throwTimer = 5f;//5 seconds seems enough
    [Tooltip("the cooldown to throw the ball every 'timer' period")]
    private float cooldown;




    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            ThrowBalls();
        }

        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            ThrowBalls();
            cooldown = throwTimer;
        }
    }

    public void ThrowBalls()
    {
        float randomX = Random.Range(0, zoneRadius) * GetRandomSign();//pick a random position in the targetCenter zone
        float randomY = Random.Range(0, zoneRadius / 2) * GetRandomSign();//pick a random position in the targetCenter zone
        Vector3 randomTarget = new Vector3(targetCenter.position.x + randomX, targetCenter.position.y + randomY, targetCenter.position.z);//the targetCenter of where the ball is going

        GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);//spawn the ball at the location of the spawner
        //instead of spawning the ball you can just use the pulling system:
        //ballPrefab.transform.position = transform.position;
        //ballPrefab.transform.rotation = transform.rotation;
        //rb.velocity = Vector3.zero;

        Rigidbody rb = ball.GetComponent<Rigidbody>();//get the rigidbody of the ball// put this in start if using the pulling system

        //throwing the ball at the direction of the of the picked targetCenter and add gravity to it to add realism to the throw:
        Vector3 direction = randomTarget - ball.transform.position;
        Vector3 gravity = -Physics.gravity * 0.5f;
        Vector3 throwDirection = direction + gravity;

        //throw the ball with addforce
        rb.AddForce(throwDirection, ForceMode.Impulse);

    }

    private int GetRandomSign()
    {
        return (Random.value < 0.5f) ? -1 : 1;
    }




}
