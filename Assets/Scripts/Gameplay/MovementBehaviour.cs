using UnityEngine;
using System.Collections;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField] float movementSpeed = 2f;

    IMovementInput inputRef;

    private void Awake()
    {
        inputRef = GetComponent<IMovementInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputRef == null) return;

        // move transform
        transform.Translate(
            (Vector3.right * inputRef.InputVector.x +
            Vector3.forward * inputRef.InputVector.y)
            * movementSpeed * Time.deltaTime
            );
    }
}
