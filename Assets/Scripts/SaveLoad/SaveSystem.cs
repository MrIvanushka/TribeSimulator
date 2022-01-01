using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static void Save<Data>(Data data, string path)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    private static Data Load<Data>(string path)
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data data = (Data)formatter.Deserialize(stream);

            stream.Close();
            return data;
        }
        return default(Data);
    }

    public static void SaveData(GeneralSaveData data)
    {
        Save(data, Application.persistentDataPath + "/general.save");
    }

    public static GeneralSaveData LoadData()
    {
        return Load<GeneralSaveData>(Application.persistentDataPath + "/general.save");
    }

    public static void SaveGame(GameData data)
    {
        Save(data, Application.persistentDataPath + "/game.save");
    }

    public static GameData LoadGame()
    {
        return Load<GameData>(Application.persistentDataPath + "/game.save");
    }

    public static void SaveSettings(SettingsData data)
    {
        Save(data, Application.persistentDataPath + "/settings.save");
    }

    public static SettingsData LoadSettings()
    {
        return Load<SettingsData>(Application.persistentDataPath + "/settings.save");
    }

    public static void DeleteGame()
    {
        string path = Application.persistentDataPath + "/game.save";
        File.Delete(path);
    }

}
