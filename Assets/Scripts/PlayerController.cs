using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 25;
    public int rotateSpeed = 5;
    private float horizontal;
    private float vertical;
    public Rigidbody rb;
    private int force = 8;
    private bool onIsland;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * vertical);
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * horizontal);
        if(Input.GetKeyDown(KeyCode.Space) && onIsland == true)
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            onIsland = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Island"))
        {
            onIsland = true;
        }
    }
}
