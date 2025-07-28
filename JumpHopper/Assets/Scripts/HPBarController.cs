using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBarController : MonoBehaviour
{

    [Header("HPゲージUI要素")]
    [SerializeField] private Image hpBarFillImage; // HPバー本体のImage
    [SerializeField] private TextMeshProUGUI hpText; // HP数値を表示するTextMeshProUGUI

    [Header("HP設定")]
    [SerializeField] private float maxHP = 100f; // 最大HP
    private float currentHP; // 現在のHP
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP; // 初期HPを最大HPに設定
        UpdatteHPUI(); 
    }

    public void SetHP(float newHP)
    {
        // HPが最大値を超えないように制限
        currentHP = Mathf.Clamp(newHP, 0, maxHP);
        UpdatteHPUI();
    }

    public void TakeDamage(float damageAmount)
    {
        SetHP(currentHP - damageAmount);
        Debug.Log($"ダメージを受けた: {damageAmount}. 現在のHP: {currentHP}");
        if (currentHP <= 0)
        {
            Debug.Log("Game Over");
            // ここに死亡時の処理を追加
        }
    }
    public void Heal(float healAmount)
    {
        SetHP(currentHP + healAmount);
        Debug.Log($"回復: {healAmount}. 現在のHP: {currentHP}");
    }

    private void UpdatteHPUI()
    {
        // HPバーのFillAmountを更新
        hpBarFillImage.fillAmount = currentHP / maxHP;
        // HP数値を更新
        hpText.text = $"{currentHP:F0}/{maxHP:F0}";
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(5);
        }
    }
}
