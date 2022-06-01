using UnityEngine;

public class MoveController : MonoBehaviour
{
    public static bool checkColl;
    private GameObject manage;
    private float force=15;
    public static int speed = 15;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        var aboba = GameObject.Find("aboba").GetComponent<Aboba>();
        manage=aboba.manage;
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
                Jump();
                if (manage.active)
                {
                    manage.SetActive(false);
                }
            }
            */
            
            float moveHorizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y, speed);
            if (Input.GetKeyDown(KeyCode.UpArrow) && checkColl)
            {
                Jump();
                if (manage.active)
                {
                    manage.SetActive(false);
                }
            }
            

        }
    }
    public void Jump()
    {
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        checkColl = false;
        //GetComponent<Animation>().Play();
        //transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0, 0, 90), Time.deltaTime*10);

    }
    private void OnCollisionEnter(Collision collision)
    {
       checkColl = true;
    }
}