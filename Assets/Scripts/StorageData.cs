using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class StreamData
{
    public  List<StorageData> DataVal;

    public List <StorageData> BikeData;

    public List<StorageData> DataTime;
    
}

[System.Serializable]
public class StorageData
{
    public string KeyData;
    public int ValueData;

    public static bool FindDataValue(string DataFinding, List<string> Key)
    {
        foreach(string data in Key){
            if (DataFinding == data)
            {
                return true;
            }
        }
        return false;
    }
}


