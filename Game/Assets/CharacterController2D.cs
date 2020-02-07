using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed = 4;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float walkAcceleration = 75;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    float airAcceleration = 30;

    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    float groundDeceleration = 150;

    [SerializeField, Tooltip("Max height the character will jump regardless of gravity")]
    float jumpHeight = 4;

    private BoxCollider2D boxCollider;

    private Rigidbody2D rbody;

    float moveInputx;

    float moveInputy;

    private void Awake()
    {      
        // initialize boxcollider and rigidbody
        boxCollider = GetComponent<BoxCollider2D>();
        rbody = GetComponent<Rigidbody2D>();
        rbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rbody.interpolation = RigidbodyInterpolation2D.Extrapolate;
    }

    private void FixedUpdate()
    {
        // Update velocity of the player
        rbody.velocity = new Vector2(moveInputx * speed, moveInputy * speed);
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
        Debug.Log("Player collided");
    }
}
