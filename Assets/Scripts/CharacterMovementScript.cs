using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    [SerializeField] private float startingSpeed = 5.0f;
    [SerializeField] private float forwardSpeed = 1.0f;

    private float amountToIncrease = 0.02f;
    private int counter = 0;
    private float secondsToIncreaseSpeed = 10.0f;
    private Rigidbody rigidbody;
    private Vector3 HorizontalMovementVector = Vector3.zero;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HorizontalMovementControl();
        ForwardForce();
    }

    void HorizontalMovementControl()
    {
        float HorizontalMovement = Input.GetAxis("Horizontal");
        HorizontalMovementVector = new Vector3(HorizontalMovement * startingSpeed * Time.deltaTime, 0.0f, 0.0f);

        transform.position += HorizontalMovementVector;
    }

    void ForwardForce()
    {
        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;

        if (counter < secondsToIncreaseSpeed)
        {
            counter ++;
        }

        else
        {
            counter = 0;
            forwardSpeed += amountToIncrease;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            forwardSpeed = 0f;
            amountToIncrease = 0f;
        }
    }


}
