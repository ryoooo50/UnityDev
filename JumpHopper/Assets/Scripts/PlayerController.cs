using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public Image healthBar;
    private Vector3 initialPosition;

    void Start()
    {
        // プレイヤーの初期位置を記憶
        initialPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        // 落下した場合の処理
        if (transform.position.y < -20f)
        {
            // 体力を半分に設定
            SetHealth(0.5f);
            // プレイヤーをリセットするなどの処理を追加
            transform.position = initialPosition;
            Debug.Log("Player has fallen below -10 on the Y-axis. Health set to 50% and position reset.");
        }
        
    }

    public void SetHealth(float percent) 
    {
        percent = Mathf.Clamp01(percent);

        var rt = healthBar.rectTransform;
        rt.sizeDelta = new Vector2(200 * percent,rt.sizeDelta.y);
    }
}
