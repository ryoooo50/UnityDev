using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float jumpForce = 6f;
    private float jumpingBoard = 12f;
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
    private AudioSource audioSource;
    public AudioClip normalJumpSound;
    public  AudioClip jumpingBoardSound;
    private Animator animator;
    private bool hasJumpedFromPlatform = false;
    public float rotationSpeed = 10f; // 回転速度


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        audioSource = gameObject.GetComponent<AudioSource>();

        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //入力の取得
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //接地判定
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (moveDirection != Vector3.zero)
        {
            // キャラクターの向きを移動方向に合わせる
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        //移動入力が少しでもある場合
        bool isMoving = (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f);
        if (animator != null)
        {
            animator.SetBool("isMoving", isMoving);
        }
        // Debug.Log("Is Moving: " + isMoving);
        //スペースキーでジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            if (animator != null)
            {
                animator.SetTrigger("Jump");
                Debug.Log("Jump Triggered");
            }

            audioSource.PlayOneShot(normalJumpSound); // 通常のジャンプ音を再生
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
        
        rb.MovePosition(rb.position + transform.forward * move.magnitude + platformDelta);
    }

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
                        if (animator != null)
                        {
                            animator.SetTrigger("Jump");
                        }
                        audioSource.PlayOneShot(jumpingBoardSound); // ジャンプボードの音を再生
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
