using UnityEngine;
using Luminosity.IO;
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerMovementInput input;

    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    public float startingSpeed = 4;

    public float speed;

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

        speed = startingSpeed;
    }

    private void FixedUpdate()
    {
        Vector2 currDirection = input.UpdateVelocity(moveInputx, moveInputy, speed);

        // Update velocity of the player
        UpdateVelocity(currDirection);

        // Update sprite direction
        if (currDirection != Vector2.zero)
        {
             float angle = Mathf.Atan2(currDirection.y, currDirection.x) * Mathf.Rad2Deg;
             transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
   

    private void Update()
    {
        // Update movement inputs
        moveInputx = InputManager.GetAxis("Horizontal");
        moveInputy = InputManager.GetAxis("Vertical");
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

    public void wakeUp()
    {
        Awake();
    }
}

public class PlayerMovementInput
{
    public Vector2 UpdateVelocity(float moveInputx, float moveInputy, float speed)
    {
        return new Vector2(moveInputx * speed, moveInputy * speed);
    }

}