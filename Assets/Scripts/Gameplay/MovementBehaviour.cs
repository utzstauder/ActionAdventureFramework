using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MovementBehaviour : MonoBehaviour
{
    [SerializeField] float movementSpeed = 2f;
    [SerializeField] float rotationSpeed = 5f;

    IMovementInput inputRef;

    float rotationAngle;
    Quaternion inputOrientation;

    Rigidbody rb;

    bool canMove;

    private void OnEnable()
    {
        HealthBehaviour healthBehaviour = GetComponent<HealthBehaviour>();
        if (healthBehaviour != null)
        {
            healthBehaviour.OnDeath -= HandleOnDeath;
            healthBehaviour.OnDeath += HandleOnDeath;
        }
    }

    private void OnDisable()
    {
        HealthBehaviour healthBehaviour = GetComponent<HealthBehaviour>();
        if (healthBehaviour != null)
        {
            healthBehaviour.OnDeath -= HandleOnDeath;
        }
    }

    private void Awake()
    {
        inputRef = GetComponent<IMovementInput>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inputRef == null) return;
        if (canMove == false) return;

        rb.MovePosition(rb.position +
            (Vector3.right * inputRef.InputVector.x +
            Vector3.forward * inputRef.InputVector.y)
            * movementSpeed * Time.fixedDeltaTime);

        // rotate towards movement direction
        inputOrientation = Quaternion.FromToRotation(
            transform.forward,
            (Vector3.right * inputRef.InputVector.x +
            Vector3.forward * inputRef.InputVector.y)
            );

        rb.MoveRotation(
            Quaternion.Lerp(
                rb.rotation,
                rb.rotation * inputOrientation,
                Time.fixedDeltaTime * rotationSpeed
            )
        );
    }

    void LateUpdate()
    {
        // manually freeze x- and z-rotation
        transform.localEulerAngles = Vector3.up * transform.localEulerAngles.y;
    }

    void HandleOnDeath()
    {
        Debug.Log("Received death event notification");
        canMove = false;
    }
}
