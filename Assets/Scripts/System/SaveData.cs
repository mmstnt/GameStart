using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveData : MonoBehaviour
{
    [SerializeField]
    PlayerData data;

    private void Update()
    {
    }

    public void Save() 
    {
        BinaryFormatter bf = new BinaryFormatter();
        Stream s = File.Open(Application.dataPath + "/Save/"+"Save01"+".sv", FileMode.Create);
        bf.Serialize(s, data);
        s.Close();
    }

    public void Load() 
    {
        BinaryFormatter bf = new BinaryFormatter();
        Stream s = File.Open(Application.dataPath + "/Save/" + "Save01" + ".sv", FileMode.Open);
        data = (PlayerData)bf.Deserialize(s);
    }

    [System.Serializable]
    public class PlayerData 
    {
        public string name;
    }
}
