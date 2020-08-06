using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class PersistentServices
{
    public static void increaseBossScore()
    {
        string path = Application.persistentDataPath + "\\BossScore.txt";
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
            StreamWriter defaultStream = new StreamWriter(path, false);
            defaultStream.WriteLine("0");
            defaultStream.Close();
        }
            StreamReader inputStream = new StreamReader(path);
            string value = "";

        int nextVal = 0;
            while (!inputStream.EndOfStream)
            {
                value = inputStream.ReadLine();
                if (value != null || value != "")
                {
                    nextVal = int.Parse(value) + 1;
                }
            }
            
            inputStream.Close();

        StreamWriter outputStream = new StreamWriter(path, false);
        outputStream.WriteLine(nextVal);
        outputStream.Close();
    }
}
