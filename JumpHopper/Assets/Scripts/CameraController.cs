using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;

    public Vector3 offset = new Vector3(0, 5, -8);// カメラのオフセット
    // Start is called before the first frame update

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            // プレイヤーの位置にオフセットを加えた位置にカメラを配置
            transform.position = player.position + offset;

            // カメラが常にプレイヤーを向くようにする
            transform.LookAt(player);
        }
        else
        {
            Debug.LogWarning("Player Transform is not assigned in CameraController.");
        }
        
    }
}
