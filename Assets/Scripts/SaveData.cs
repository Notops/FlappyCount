using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveData
{

    public static void SavePlayer ( SceneVariables variables)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/GameData3.save";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

        PlayerData data = new PlayerData(variables);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer(SceneVariables variables)
    {
        string path = Application.persistentDataPath + "/GameData3.save";
        if ( !File.Exists(path) )
        {
            SavePlayer(variables);   
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        PlayerData data = formatter.Deserialize(stream) as PlayerData;
        stream.Close();

        return data;
    }
}
