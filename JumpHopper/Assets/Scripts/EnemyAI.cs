using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float patrolSpeed = 2f;      // 巡回時の移動速度
    public float chaseSpeed = 5f;       // 追跡時の移動速度
    public float chaseDistance = 10f;   // プレイヤーを追いかける距離
    public float waypointTolerance = 0.5f; // Waypointに到達したと判定する距離

    [Header("プレイヤと巡回地点")]
    public Transform player;
    public Transform[] patrolWaypoints;
    private int currentWaypointIndex = 0; // 現在の巡回地点のインデックス
    private int distanceToPlayerMode = 0; // 追跡中かどうか
    private bool isChasing = false; // プレイヤーに近いかどうか
    private Vector3 initialPosition; // 初期位置を記憶するための変数


    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPosition;
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }

        if (patrolWaypoints.Length == 0)
        {
            initialPosition = transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseDistance)
        {
            isChasing = true;
            distanceToPlayerMode = 1; // プレイヤーに近づいたら追跡を開始
            Debug.Log($"プレイヤーに近づいた: {distanceToPlayer}m");
            if (distanceToPlayer < waypointTolerance)
            {

                // プレイヤーに十分近づいたら、追跡をやめる
                distanceToPlayerMode = 2;
                Debug.Log("プレイヤーに十分近づいたため、追跡をやめます。");
            }
        }
        else
        {
            distanceToPlayerMode = 2;
            isChasing = false; // プレイヤーから離れたら追跡をやめる
        }
        switch (distanceToPlayerMode)
        {
            case 0:
                Patrol(); // 巡回モード
                break;
            case 1:
                ChasePlayer(); // 追跡モード
                break;
            case 2:
                Stop();
                break;
        }
        // if (isChasing)
        // {
        //     ChasePlayer();
        // }
        // else
        // {
        //     Patrol();
        // }
    }
    void ChasePlayer()
    {
        Vector3 targetPosition = player.position;
        targetPosition.y = transform.position.y;
        // プレイヤーの方向を向く
        transform.LookAt(player.position);
        // プレイヤーに向かって移動する
        transform.position += transform.forward * chaseSpeed * Time.deltaTime;
    }
    void Patrol()
    {
        if (patrolWaypoints.Length > 0)
        {
            Vector3 targetPosition = patrolWaypoints[currentWaypointIndex].position;
            // ★★★ 修正点: WaypointのY座標を敵自身のY座標に固定する ★★★
            targetPosition.y = transform.position.y;
            // Waypointの方向を向く
            transform.LookAt(targetPosition);
            // Waypointへ移動する
            transform.position += transform.forward * patrolSpeed * Time.deltaTime;

            // Waypointに十分に近づいたら、次のWaypointへ
            if (Vector3.Distance(transform.position, targetPosition) < waypointTolerance)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= patrolWaypoints.Length)
                {
                    currentWaypointIndex = 0; // 最後のWaypointに到達したら最初に戻る
                }
            }
        }
        else
        {
            // 巡回地点が設定されていない場合は何もしない（その場に留まる）
        }
    }
    void Stop()
    {
        // 何もしない（その場に留まる）
        // ここに必要な処理を追加することも可能
    }
}
