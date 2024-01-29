using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveUI : MonoBehaviour
{
    Transform tf;
    public GameObject saveData;
    public static int saveCount;
    private void OnEnable()
    {
        saveCount = 0;
        tf = this.gameObject.GetComponent<Transform>();
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath + "/Save/");
        FileInfo[] saveFile = directoryInfo.GetFiles("*.sv");
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(1060.0f, 780.0f + 250.0f * (saveFile.Length > 2 ? saveFile.Length - 2 : 0));
        for (int i = 0; i < saveFile.Length + 1; i++) 
        {
            Vector3 site = transform.position;
            site.y += 250.0f - i * 250.0f + 125f * (saveFile.Length > 2 ? saveFile.Length - 2 : 0);
            Instantiate(saveData, site, transform.rotation, tf);
        }
    }

    private void OnDisable()
    {
        for(int i = 0; i < transform.childCount; i++) 
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
    }

}
