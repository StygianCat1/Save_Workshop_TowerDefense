using System;
using System.Collections.Generic;
using UnityEngine;

//Can be created as an asset
[CreateAssetMenu]
public class DatabaseSO : ScriptableObject
{
    //will create a list of the class Object Data
     public List<ObjectData> objectsData;
}

[Serializable]
public class ObjectData
{
    //create Name string var in the database
    [field: SerializeField] public string Name { get; private set; }
    //create ID int var in the database
    [field: SerializeField] public int ID { get; private set; }
    //create Size int var in the database
    [field: SerializeField] public int Size { get; private set; }
    //create Price int var in the database
    [field: SerializeField] public int Price { get; private set; }
    //create Prefab GameObject var in the database
    [field: SerializeField] public GameObject Prefab { get; private set; }    
    //create Turret GameObject var in the database
    [field: SerializeField] public GameObject Turret { get; private set; }
}