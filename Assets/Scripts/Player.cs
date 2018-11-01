using UnityEngine;

[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationTime;
    [SerializeField]
    private string horizontalAxis = "Horizontal";
    [SerializeField]
    private string verticalAxis = "Vertical";
    [SerializeField]
    private KeyCode headbuttKey = KeyCode.Mouse0;

    [Header("References")]
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private CharacterController controller;

    private float rotation = 0f;
    private float currentRotationVelocity;

    private void Update()
    {
        Vector2 movementInput;
        movementInput.x = Input.GetAxisRaw(horizontalAxis);
        movementInput.y = Input.GetAxisRaw(verticalAxis);
        movementInput.Normalize();

        bool running = movementInput != Vector2.zero;
        bool headbutt = Input.GetKeyDown(headbuttKey);

        if (running)
        {
            Vector3 movementInput3D = new Vector3(movementInput.x, 0, movementInput.y);
            controller.SimpleMove(movementInput3D * movementSpeed);
            rotation = Mathf.SmoothDampAngle(rotation, -Vector2.SignedAngle(Vector2.up, movementInput), ref currentRotationVelocity, rotationTime);
            transform.rotation = Quaternion.AngleAxis(rotation, Vector3.up);
        }

        if (headbutt)
        {
            animator.SetTrigger("Hit");
        }

        animator.SetBool("Running", movementInput != Vector2.zero);
    }

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    Rigidbody body = hit.collider.attachedRigidbody;
    //    if (body != null && !body.isKinematic && body.gameObject.tag == "Physics")
    //    {
    //        body.velocity += new Vector3(hit.controller.velocity.x, 0f, hit.controller.velocity.z);
    //    }
    //}
}
