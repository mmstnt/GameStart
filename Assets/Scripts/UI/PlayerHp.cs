using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [Header("生命值物件")]
    public Image hpImage;
    public Image hpDelayImage;
    private void Update()
    {
        if (hpDelayImage.fillAmount > hpImage.fillAmount) 
        {
            hpDelayImage.fillAmount -= Time.deltaTime;
        }
    }

    public void playerHealthChange(float persentage) 
    {
        hpImage.fillAmount = persentage;
    }
}
