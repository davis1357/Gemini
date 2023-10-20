using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;

    Rigidbody2D myRigidBody;
    BoxCollider2D myCollider;
    bool isTouching = true;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = new Vector3(this.transform.position.x+11f, mainCamera.transform.position.y, -10);

        PlayerMoves();

        PlayerJumping();
    }

    private void PlayerMoves()
    {
        //myRigidBody.velocity = new Vector2(playerSpeed, 0);
        transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
    }

    private void PlayerJumping()
    {
        if (!isTouching)
        { return; }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.AddRelativeForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            //myRigidBody.AddRelativeForce(0,jumpSpeed,0);
            //myRigidBody.velocity = new Vector2(playerSpeed, jumpSpeed);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Floor")
            isTouching = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
            isTouching = true;
    }
}
