using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerMovementInput input;

    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed = 4;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float walkAcceleration = 75;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    float airAcceleration = 30;

    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    float groundDeceleration = 150;

    private BoxCollider2D boxCollider;

    private Rigidbody2D rbody;

    float moveInputx;

    float moveInputy;

    private void Awake()
    {      
        // initialize boxcollider and rigidbody
        boxCollider = GetComponent<BoxCollider2D>();
        InitializeRigidBody();
        input = new PlayerMovementInput();
    }

    private void FixedUpdate()
    {
        // Update velocity of the player
        UpdateVelocity(input.UpdateVelocity(moveInputx, moveInputy, speed));
    }

    private void Update()
    {
        // Update movement inputs
        moveInputx = Input.GetAxis("Horizontal");
        moveInputy = Input.GetAxis("Vertical");
    }

    // Called when the player collides with another collidable object
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Player collided with " + col.gameObject.name, col.gameObject);
    }

    public float GetSpeed()
    {
        return speed;
    }

    public Rigidbody2D GetRigidBody()
    {
        return rbody;
    }

    public void UpdateVelocity(Vector2 input)
    {
        rbody.velocity = input;
    }

    public void InitializeRigidBody()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rbody.interpolation = RigidbodyInterpolation2D.Extrapolate;
    }
}

public class PlayerMovementInput
{
    public Vector2 UpdateVelocity(float moveInputx, float moveInputy, float speed)
    {
        return new Vector2(moveInputx * speed, moveInputy * speed);
    }

}