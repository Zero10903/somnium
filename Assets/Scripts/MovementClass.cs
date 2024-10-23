using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementClass : MonoBehaviour {
    void Update()
    {
        CheckImputs();
    }

    public void CheckImputs(){
        if(Input.GetKey(KeyCode.D)){
            MoveRight();
        }
        if(Input.GetKey(KeyCode.A)){
            MoveLeft();
        }
    }

    public void MoveRight(){
        transform.Translate(Vector3.right);
    }
    public void MoveLeft(){
        transform.Translate(Vector3.left);
    }
}
