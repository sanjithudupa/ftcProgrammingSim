using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEngine.UI;
 
public class SetText : MonoBehaviour
{

    public InputField input;
    public Dropdown drop;
    public string path;
    public string pathB = "Assets/AutonomousBaseOG.txt";
    public string pathH = "Assets/HardwareOG.txt";
    public string pathO = "Assets/opModeOG.txt";
    public Text theText;
    // Start is called before the first frame update

    [MenuItem("Tools/Read file")]
    void Start()
    {
        StreamReader reader2 = new StreamReader(pathB);
        path = "Assets/AutonomousBase.txt";
        File.Delete(path);
        File.WriteAllText(path, reader2.ReadToEnd());

        StreamReader reader3 = new StreamReader(pathH);
        path = "Assets/Hardware.txt";
        File.Delete(path);
        File.WriteAllText(path, reader3.ReadToEnd());

        StreamReader reader4 = new StreamReader(pathO);
        path = "Assets/opMode.txt";
        File.Delete(path);
        File.WriteAllText(path, reader4.ReadToEnd());


        path = "Assets/opMode.txt";
        

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);

        input.text = reader.ReadToEnd();
        Debug.Log(reader.ReadToEnd());



    }

   

    public void change(){
        if(drop.value == 0)
        {
            ////Write some text to the test.txt file
            //StreamWriter writer = new StreamWriter(path, true);
            //writer.WriteLine(input.text);
            //writer.Close();

            //Re-import the file to update the reference in the editor
            AssetDatabase.ImportAsset(path);
            TextAsset asset = (UnityEngine.TextAsset)Resources.Load(input.text);


            path = "Assets/opMode.txt";
            //Read the text from directly from the test.txt file
            StreamReader reader = new StreamReader(path);
            

            input.text = reader.ReadToEnd();
            Debug.Log(reader.ReadToEnd());


            

        }
        else if (drop.value == 1)
        {
            ////Write some text to the test.txt file
            //StreamWriter writer = new StreamWriter(path, true);
            //writer.WriteLine(input.text);
            //writer.Close();

            //Re-import the file to update the reference in the editor
            AssetDatabase.ImportAsset(path);
            TextAsset asset = (UnityEngine.TextAsset)Resources.Load(input.text);


            path = "Assets/Hardware.txt";
            //Read the text from directly from the test.txt file
            StreamReader reader = new StreamReader(path);

            
            input.text = reader.ReadToEnd();
            Debug.Log(reader.ReadToEnd());



            

        }
        else
        {
            ////Write some text to the test.txt file
            //StreamWriter writer = new StreamWriter(path, true);
            //writer.WriteLine(input.text);
            //writer.Close();

            //Re-import the file to update the reference in the editor
            AssetDatabase.ImportAsset(path);
            TextAsset asset = (UnityEngine.TextAsset)Resources.Load(input.text);


            path = "Assets/opMode.txt";
            //Read the text from directly from the test.txt file
            StreamReader reader = new StreamReader(path);

          

            input.text = reader.ReadToEnd();
            Debug.Log(reader.ReadToEnd());

            

        }

     }
   public void savePressed()
    {
        
        if (drop.value == 0)
        {
           

            path = "Assets/AutonomousBase.txt";

            File.Delete(path);
            File.WriteAllText(path,input.text);


        }
        else if (drop.value == 1)
        {
            

            path = "Assets/Hardware.txt";
            File.Delete(path);
            File.WriteAllText(path, input.text);


        }
        else
        {
            
            path = "Assets/opMode.txt";
            File.Delete(path);
            File.WriteAllText(path, input.text);



        }

    }

    
}
