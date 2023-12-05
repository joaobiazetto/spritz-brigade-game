using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Character _character;

    public GameObject playerRig;

    private Rigidbody playerRigRb;

    private void Start()
    {
        if (TryGetComponent<Character>(out var character))
        {
            _character = character;
        }

        playerRigRb = playerRig.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * _character.moveSpeed;

        playerRigRb.velocity = movement;
    }
}
