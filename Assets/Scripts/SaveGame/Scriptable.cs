using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Scriptable : MonoBehaviour
{
    // Assuming you have an array of Scriptable Objects
    public ScriptableObject[] scriptableObjectsArray;

    void Start()
    {
        // Convert Scriptable Objects to binary data
        byte[] binaryData = ConvertScriptableObjectsToBinary(scriptableObjectsArray);

        // Save the binary data to a file
        SaveBinaryDataToFile("yourBinaryFileName.dat", binaryData);
    }

    byte[] ConvertScriptableObjectsToBinary(ScriptableObject[] scriptableObjects)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream();

        // Serialize each Scriptable Object and write it to the memory stream
        foreach (ScriptableObject scriptableObject in scriptableObjects)
        {
            formatter.Serialize(memoryStream, scriptableObject);
        }

        // Get the binary data from the memory stream
        byte[] binaryData = memoryStream.ToArray();

        // Close the memory stream
        memoryStream.Close();

        return binaryData;
    }

    void SaveBinaryDataToFile(string fileName, byte[] binaryData)
    {
        // Save the binary data to a file
        File.WriteAllBytes(Application.persistentDataPath + "/" + fileName, binaryData);

        Debug.Log("Binary data saved to: " + Application.persistentDataPath + "/" + fileName);
    }
}
