using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float jumpForce = 6f;
    private float jumpingBoard = 25f;
    public float moveDistance = 1f;
    public LayerMask groundLayer;   //地面のレイヤー
    public Transform groundCheck;   //地面のチェック     public float groundCheckRadius = 0.2f;   //接地判定の半径
    public float groundCheckRadius = 0.2f; // 接地判定の半径
    private Rigidbody rb;
    public float speed = 5f;
    private float horizontal;
    private float vertical;
    private bool isGrounded;

    private BoardDriven isOnPlatform;

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

        Vector3 platformDelta = Vector3.zero;
        if (isOnPlatform != null && isGrounded)
        {
            platformDelta = isOnPlatform.delta;

            if (platformDelta.y < 0)
            {
                rb.MovePosition(rb.position + new Vector3(0, platformDelta.y, 0));
            }
        }
        
        rb.MovePosition(rb.position + move + platformDelta);
    }
    private bool hasJumpedFromPlatform = false;

    private void OnCollisionStay(Collision collision) 
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            isOnPlatform = collision.gameObject.GetComponent<BoardDriven>();
        }

        if (collision.gameObject.CompareTag("JumpingPlatform"))
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                // 接触した面の法線
                Vector3 normal = contact.normal;

                // 法線が上向き（0.7 以上にしておくと多少の斜面にも対応）Dot(a,b)は内積
                if (Vector3.Dot(normal, Vector3.up) > 0.7f)
                {
                    if (!hasJumpedFromPlatform)
                    {
                        rb.AddForce(Vector3.up * jumpingBoard, ForceMode.Impulse);
                        hasJumpedFromPlatform = true;
                    }
                    break; // 一度ジャンプしたらループを抜ける
                    
                }
            }
        }
        
    }
    private void OnCollisionExit(Collision collision) 
    {
        
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            isOnPlatform = null;
        }

        if (collision.gameObject.CompareTag("JumpingPlatform"))
        {
            hasJumpedFromPlatform = false;
        }
    }
}
