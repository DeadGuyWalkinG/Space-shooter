using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed = 15f;
    void Start()
    { 
    
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if(transform.position.y > 5.2f)  //destroys laser object when out of bounds
            Destroy(gameObject);
    }


}
