
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    public float speed;
    public GameObject jetpackActivation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") ,
            Input.GetAxis("Vertical"))*speed*Time.deltaTime;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            jetpackActivation.SetActive(true);
        }
        else
        {
            jetpackActivation.SetActive(false);
        }
        
    }
}

