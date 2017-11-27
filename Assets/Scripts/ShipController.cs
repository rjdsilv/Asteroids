using UnityEngine;

public class ShipController : MonoBehaviour {
    const float MAX_SPEED = 10f;
    const float MIN_SPEED = 0f;

    private Rigidbody2D shipRigidBody2D;
    private Animator shipAnimator;
    private AudioSource shipThrotleAudio;

    /// <summary>
    /// Starts the ship game processament.
    /// </summary>
    private void Start()
    {
        shipRigidBody2D = GetComponent<Rigidbody2D>();
        shipAnimator = GetComponent<Animator>();
        shipThrotleAudio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// This method is called once per frame for physics. It will make the ship move through the screen.
    /// </summary>
    void FixedUpdate ()
    {
        float acceleration = Input.GetAxis("Accelerate");
        float rotation = Input.GetAxis("Rotate");

        // Accelerate the ship ntil a maximum speed.
        if (acceleration > 0)
        {
            shipRigidBody2D.AddForce(transform.up * 3f * acceleration);
            if (shipRigidBody2D.velocity.magnitude > MAX_SPEED)
            {
                shipRigidBody2D.velocity = shipRigidBody2D.velocity.normalized * MAX_SPEED;
            }
        }

        // Rotate the ship in the z axis.
        transform.Rotate(0, 0, -rotation * 5f);
	}

    /// <summary>
    /// Method called once per frame. Let's play and stop the ship animation.
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (!shipThrotleAudio.isPlaying)
            {
                shipThrotleAudio.Play();
            }
            shipAnimator.Play("ShipFlying");
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            shipAnimator.Play("ShipIdle");
        }
    }
}
