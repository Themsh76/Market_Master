using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public static class Speicherung 
{
    
    public static void SaveProgress()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameValues data = new GameValues();

        formatter.Serialize(stream, data);

        Debug.Log("Saved");

        stream.Close();

    }

    public static GameValues LoadProgress()
    {
        string path = Application.persistentDataPath + "/game.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameValues data = formatter.Deserialize(stream) as GameValues;
            stream.Close();

            Debug.Log("Loaded");
            return data;

        }

        else
        {
            Debug.Log("Save not Found " +  path);
            return null;
        }
    }
}
