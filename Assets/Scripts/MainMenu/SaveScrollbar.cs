using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveScrollbar : MonoBehaviour
{
    private Scrollbar scrollbar;
    public float range;
    public float rangeOffset;
    void Start()
    {
        scrollbar = GetComponent<Scrollbar>();
    }

    public void ListScrollbar(RectTransform list) 
    {
        list.localPosition = new Vector3(list.localPosition.x,scrollbar.value * range + rangeOffset, list.localPosition.z);
    }
}
