using UnityEngine;

[System.Serializable]
public class MyObject_Data
{
    public string fName;
    public string mName;
    public string lName;
    public uint age;
    public uint grade;
}

[CreateAssetMenu (menuName = "MyObject")]
public class MyObject : ScriptableObject, ISerializable
{
    [SerializeField] MyObject_Data data;
    public object GetSerializable()
    {
        return data;
    }
}
