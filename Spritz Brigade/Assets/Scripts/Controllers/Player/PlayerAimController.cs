using UnityEngine;

public class PlayerAimController : MonoBehaviour
{
    Vector3 lookPosition;
    Camera mainCamera;

    public Transform playerRigTransform;
    public LayerMask groundLayer;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Aim();
    }

    private void Aim()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100, groundLayer))
        {
            lookPosition = hit.point;
        }

        var direction = lookPosition - playerRigTransform.position;
        direction.y = 0;

        playerRigTransform.LookAt(playerRigTransform.position + direction, Vector3.up);
    }
}
