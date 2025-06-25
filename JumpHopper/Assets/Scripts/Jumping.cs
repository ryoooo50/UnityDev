using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float jumpForce = 5f;
    public float moveDistance = 1f;
    public LayerMask groundLayer;   //地面のレイヤー
    public Transform groundCheck;   //地面のチェック     public float groundCheckRadius = 0.2f;   //接地判定の半径
    public float groundCheckRadius = 0.2f; // 接地判定の半径
    private Rigidbody rb;
    public float speed = 5f;
    private float horizontal;
    private float vertical;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //入力の取得
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //よくわからん
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        //スペースキーでジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate() 
    {
        Vector3 move = new Vector3(horizontal, 0f, vertical) * speed * Time.fixedDeltaTime;
        
        rb.MovePosition(rb.position + move);
    }
}
