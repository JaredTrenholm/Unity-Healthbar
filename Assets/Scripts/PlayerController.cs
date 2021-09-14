using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseSpeed;
    public HealthSystem playerHealth;
    private float currentSpeed;
    public CharacterController player;
    private void Update()
    {
        if (playerHealth.isAlive)
        {
            currentSpeed = baseSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.W))
            {
                player.Move(new Vector3(0, 0, currentSpeed));
            } else if (Input.GetKey(KeyCode.UpArrow))
            {
                player.Move(new Vector3(0, 0, currentSpeed));
            }
            if (Input.GetKey(KeyCode.S))
            {
                player.Move(new Vector3(0, 0, -currentSpeed));
            } else if (Input.GetKey(KeyCode.DownArrow))
            {
                player.Move(new Vector3(0, 0, -currentSpeed));
            }
            if (Input.GetKey(KeyCode.A))
            {
                player.Move(new Vector3(-currentSpeed, 0, 0));
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                player.Move(new Vector3(-currentSpeed, 0, 0));
            }
            if (Input.GetKey(KeyCode.D))
            {
                player.Move(new Vector3(currentSpeed, 0, 0));
            } else if (Input.GetKey(KeyCode.RightArrow))
            {
                player.Move(new Vector3(currentSpeed, 0, 0));
            }
        }
    }
}
