using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb; // bat rigidbody
    [SerializeField] private float minSwingSpeed = 5f;// min bat velocity to check for a swing
    [SerializeField] private float ballSpeedMultiplier = 2f;//multiply the ball speed when hit by the bat for a more realistic effect


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))//check if the bat hit the ball
        {
            if(rb.velocity.magnitude > minSwingSpeed)//check if the player is swinging the bat fast enough
            {
                Debug.Log("Hit");
                collision.gameObject.GetComponent<Rigidbody>().AddForce(rb.velocity * ballSpeedMultiplier, ForceMode.Impulse);//return the ball at a greater speed
            }
        }
    }

}
