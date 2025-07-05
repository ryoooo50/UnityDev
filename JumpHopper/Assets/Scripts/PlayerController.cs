using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public Image healthBar;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth(float percent) 
    {
        percent = Mathf.Clamp01(percent);

        var rt = healthBar.rectTransform;
        rt.sizeDelta = new Vector2(200 * percent,rt.sizeDelta.y);
    }
}
