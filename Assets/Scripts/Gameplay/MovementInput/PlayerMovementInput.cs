using UnityEngine;
using System.Collections;

public class PlayerMovementInput : MonoBehaviour, IMovementInput
{
    public Vector2 InputVector { get { return inputVector;} }

    Vector2 inputVector = new Vector2();

    // Update is called once per frame
    void Update()
    {
        // read input
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        // normalize input
        if (inputVector.magnitude > 1f)
        {
            inputVector.Normalize();
        }
    }
}
