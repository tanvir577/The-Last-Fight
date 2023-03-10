using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField]float speed;
    [SerializeField]float distance;
    [SerializeField]Transform groundDetection;
    bool isMovingRight = true;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb  = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down,distance);

        if(!groundInfo.collider){
            if(isMovingRight){
                transform.eulerAngles = new Vector3(0,-180,0);
                isMovingRight = false;
            }
            else{
                transform.eulerAngles = new Vector3(0,0,0);
                isMovingRight = true;
            }
        }
    }
}
