using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem 
{

    public static void save(SaveObject saveObject)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savefile.octogone";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, saveObject);
        stream.Close();
    }

    public static SaveObject load()
    {
        string path = Application.persistentDataPath + "/savefile.octogone";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveObject save = formatter.Deserialize(stream) as SaveObject;

            stream.Close();

            return save;
        }
        else
        {
            Debug.LogError("No such file exists");
            return null;
        }
    }

}