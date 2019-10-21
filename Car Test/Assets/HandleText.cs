using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class HandleText : MonoBehaviour
{
    
    
    [MenuItem("Tools/Write file")]
    static void WriteString()
    {
        string path = "Assets/opMode.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Test");
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        TextAsset asset = (UnityEngine.TextAsset)Resources.Load("test");

        //Print the text from the file
        Debug.Log(asset.text);
    }

    [MenuItem("Tools/Read file")]
    static void ReadString()
    {
        string path = "Assets/opMode1.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        //HandleText.input.text = reader.ReadToEnd();
        

    }
     void Start()
    {
        //ReadString();
    }



}