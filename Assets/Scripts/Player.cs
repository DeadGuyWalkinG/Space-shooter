using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float fireRate = 0.5f;
    private float canFire = -1f;
    public GameObject laser;

    void Start()
    {
        transform.position = new Vector3(0, 0, -3);
    }

    void Update()
    {
        movement();


        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)   //checks if fire interval is met and key is pressed
            shootLaser();
    }

    void shootLaser()
    {
            canFire = Time.time + fireRate;         //updates fire interval
            Instantiate(laser, transform.position + new Vector3(0,0.5f,0), Quaternion.identity);        //spawns laser object
    }

    void movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);

        //Offsets: -2.4f < Y < 0.5f  &&  -6.4f < X < 6.4

        if (transform.position.y > 0.5f)
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        if (transform.position.y < -2.4f)
            transform.position = new Vector3(transform.position.x, -2.4f, transform.position.z);
        if (transform.position.x > 6.4f)
            transform.position = new Vector3(-6.4f, transform.position.y, transform.position.z);   //spawns player to the opposite end of the bounds and vice versa
        if (transform.position.x < -6.4f)                                                          //gives warp effect
            transform.position = new Vector3(6.4f, transform.position.y, transform.position.z);
    }
}
