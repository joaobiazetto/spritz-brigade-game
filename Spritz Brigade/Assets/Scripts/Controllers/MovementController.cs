using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public PlayerCharacter playerCharacter;

    public GameObject playerRig;

    private Rigidbody playerRigRb;

    private void Start()
    {
        playerRigRb = playerRig.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * playerCharacter.moveSpeed;

        playerRigRb.velocity = movement;
    }
}
