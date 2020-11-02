using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int jumpcounter = 0;
    float jumpforce = 10.0f;
    float gravityModifier = 2.0f;
    float Playerspeed = 10.0f;

    float zlimit = 19.0f;
    float xlimit = 19.0f;


    Rigidbody playerRB;
    Renderer playerRdr;

    public Material[] playerMaterials;
    // Start is called before the first frame update
    void Start()
    {
        
        Physics.gravity *= gravityModifier;

        playerRdr = GetComponent<Renderer>();
        playerRB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float verticalinput = Input.GetAxis("Vertical");
        float horizontalinput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * Playerspeed * verticalinput);
        transform.Translate(Vector3.right * Time.deltaTime * Playerspeed * horizontalinput);

      
        if (transform.position.z < -zlimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zlimit);
            playerRdr.material.color = playerMaterials[2].color;
            
        }
        else if (transform.position.z > zlimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zlimit);
            playerRdr.material.color = playerMaterials[4].color;
           
        }
        else
        {
            playerRdr.material.color = playerMaterials[3].color;
        }

        if (transform.position.x < -xlimit)
        {
            transform.position = new Vector3(-xlimit, transform.position.y, transform.position.z);
            playerRdr.material.color = playerMaterials[1].color;
           
        }
        else if (transform.position.x > xlimit)
        {
            transform.position = new Vector3(xlimit, transform.position.y, transform.position.z);
            playerRdr.material.color = playerMaterials[3].color;
            
        }
       
      

        JumpPlayer();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("GamePlane"))

        {
            jumpcounter = 0;
            playerRdr.material.color = playerMaterials[3].color;

        }
        
    }

    private void JumpPlayer()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumpcounter < 1)
        {
            
            playerRB.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            
            jumpcounter++;

                     //Blue Color
        }
       if(jumpcounter == 1)
        {
            playerRdr.material.color = playerMaterials[0].color;
        }
    }
}
