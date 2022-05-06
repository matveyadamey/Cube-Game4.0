using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        transform.position = player.position + offset;
    }
}
