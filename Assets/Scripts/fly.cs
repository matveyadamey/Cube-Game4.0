using UnityEngine;

public class fly : MonoBehaviour
{
    public int force;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(12, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector3(0, force, 0),ForceMode.Impulse);
        }
    }
}
