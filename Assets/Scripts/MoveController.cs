using UnityEngine;

public class MoveController : MonoBehaviour
{
    public static bool checkColl;
    private float force=18;
    public static int speed = 15;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (timer.NotPause)
        {
            /*
            Vector3 acceleration = Input.acceleration;
            rb.velocity = new Vector3(acceleration.x * 25, rb.velocity.y, speed);
            if (Input.touchCount > 0&&checkColl)
            {
                rb.AddForce(Vector3.up * force, ForceMode.Impulse);
                checkColl = false;
            }
            */
            
            
            
            float moveHorizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y, speed);
            if (Input.GetKeyDown(KeyCode.UpArrow) && checkColl)
            {
                Jump();
            }
            
            

        }
    }
    public void Jump()
    {
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        checkColl = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
       checkColl = true;
    }
}