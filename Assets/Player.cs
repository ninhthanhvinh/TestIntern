using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    
    public float speed = 3f;
    public float turnSmoothTime = .1f;
    float turnSmoothVelocity;
    public int point;
    public Transform cam;

    public Material[] materials;
    private string playerColor = "Blue";

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        

        if(direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);            
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(movDir.normalized * speed * Time.deltaTime);
        }
    }

    public string GetPlayerColor()
    {
        return playerColor;
    }

    public void ChangeColor()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                playerColor = "Red";
                GetComponent<MeshRenderer>().material = materials[0];
                break;
            case 1:
                playerColor = "Green";
                GetComponent<MeshRenderer>().material = materials[1];
                break;
            case 2:
                playerColor = "Blue";
                GetComponent<MeshRenderer>().material = materials[2];
                break;
            default:
                break;
        }
    }
}
