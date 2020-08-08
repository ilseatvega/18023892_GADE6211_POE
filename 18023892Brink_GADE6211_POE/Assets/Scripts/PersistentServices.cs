using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class PersistentServices
{
    //the method that wll be called to increase the score and write it to a txt file
    public static void increaseBossScore()
    {
        //using Application.persistentDataPath to make sure that this text file will save on other cmputers' c drive too
        string path = Application.persistentDataPath + "\\BossScore.txt";
        //if path does not exist
        if (!File.Exists(path))
        {
            //create path
            File.Create(path).Dispose();
            //making sure that it's 0 by default (otherwise it's -1, and when they pass the first boss the score will be 0 which is incorrect)
            StreamWriter defaultStream = new StreamWriter(path, false);
            defaultStream.WriteLine("0");
            defaultStream.Close();
        }
        //make value empty
            StreamReader inputStream = new StreamReader(path);
            string value = "";
        //make next val 0
        int nextVal = 0;
            while (!inputStream.EndOfStream)
            {
                value = inputStream.ReadLine();
            //if value isnt null or empty
                if (value != null || value != "")
                {
                //next value will be the value +1
                    nextVal = int.Parse(value) + 1;
                }
            }
            
            inputStream.Close();

        //write the value in the text file
        StreamWriter outputStream = new StreamWriter(path, false);
        outputStream.WriteLine(nextVal);
        outputStream.Close();
    }
}
