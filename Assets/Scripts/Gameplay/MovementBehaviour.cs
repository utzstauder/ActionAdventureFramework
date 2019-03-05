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

    private void Awake()
    {
        inputRef = GetComponent<IMovementInput>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputRef == null) return;

        rb.MovePosition(rb.position +
            (Vector3.right * inputRef.InputVector.x +
            Vector3.forward * inputRef.InputVector.y)
            * movementSpeed * Time.deltaTime);

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
                Time.deltaTime * rotationSpeed
            )
        );
    }
}
