using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSController : MonoBehaviour
{
    
    private float hAxis;
    private float vAxis;
    
    public void Move(Vector2 inputDirection)
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        
        Vector2 moveInput = inputDirection;
        transform.position = new Vector2(hAxis, vAxis).normalized;
       
    }
}
