using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class analyzeCode : MonoBehaviour
{

    public string path;
    public string program;
    public string actualCode;
    public GameObject robot;
    public HingeJoint rf1, rr1, lf1, lr1;
    public JointMotor rf, rr, lf, lr;

    public Text input;

    // Start is called before the first frame update
    void Start()
    {

  
        rf = rf1.motor;
        rr = rr1.motor;
        lf = lf1.motor;
        lr = lr1.motor;

        rf1.motor = rf;
        rr1.motor = rr;
        lf1.motor = lf;
        lr1.motor = lr;

      
        //input.text = values("drawasds(2,5)")[0].ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rf1.useMotor = true;
        rr1.useMotor = true;
        lf1.useMotor = true;
        lr1.useMotor = true;

        rf = rf1.motor;
        rr = rr1.motor;
        lf = lf1.motor;
        lr = lr1.motor;

        rf.force = 100;
        rr.force = 100;
        lf.force = 100;
        lr.force = 100;
   

        //rf.targetVelocity = 1000;
        //rr.targetVelocity = 1000;
        //lf.targetVelocity = 1000;
        //lr.targetVelocity = 1000;

        rf1.motor = rf;
        rr1.motor = rr;
        lf1.motor = lf;
        lr1.motor = lr;

    }

    public void Play()
    {

        StartCoroutine("Run");
    }

    IEnumerator Run()
    {
        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        TextAsset asset = (UnityEngine.TextAsset)Resources.Load(program);


        path = "Assets/opMode.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);


        program = reader.ReadToEnd();

        actualCode = getBetween(program, "//write below(don't delete)", "//write above(don't delete)");

        //Debug.Log(actualCode);

        yield return new WaitForSeconds(0);

        string[] lines = actualCode.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        for(int i = 0; i <= lines.Length-1; i++)
        {
            if (lines[i].Contains("driveForward"))
            {
                //StartCoroutine("driveForward");
                StartCoroutine("driveForward", values(lines[i]));
            }
            else if (lines[i].Contains("driveBackward"))
            {
                StartCoroutine("driveBackward", values(lines[i]));
            }
            else if (lines[i].Contains("turnLeft"))
            {
                StartCoroutine("turnLeft", values(lines[i]));
            }
            else if (lines[i].Contains("turnRight"))
            {
                StartCoroutine("turnRight", values(lines[i]));
            }
            else if (lines[i].Contains(""))
            {
                continue;
            }
            else
            {
                Debug.Log("ERROR");
            }


        }





    }

    public static string getBetween(string strSource, string strStart, string strEnd)
    {
        int Start, End;
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            return strSource.Substring(Start, End - Start);
        }
        else
        {
            return "";
        }
    }

    IEnumerator driveForward(float[] tp)
    {
        rf1.useMotor = true;
        rr1.useMotor = true;
        lf1.useMotor = true;
        lr1.useMotor = true;

        rf = rf1.motor;
        rr = rr1.motor;
        lf = lf1.motor;
        lr = lr1.motor;

        rf.force = 100;
        rr.force = 100;
        lf.force = 100;
        lr.force = 100;


        rf.targetVelocity = -500 * tp[1];
        rr.targetVelocity = -500 * tp[1];
        lf.targetVelocity = -500 * tp[1];
        lr.targetVelocity = -500 * tp[1];

        rf1.motor = rf;
        rr1.motor = rr;
        lf1.motor = lf;
        lr1.motor = lr;

        Debug.Log("driveForward");
        
        yield return new WaitForSeconds(tp[0]);

        rf1.useMotor = true;
        rr1.useMotor = true;
        lf1.useMotor = true;
        lr1.useMotor = true;

        rf = rf1.motor;
        rr = rr1.motor;
        lf = lf1.motor;
        lr = lr1.motor;

        rf.force = 100;
        rr.force = 100;
        lf.force = 100;
        lr.force = 100;


        rf.targetVelocity = 0;
        rr.targetVelocity = 0;
        lf.targetVelocity = 0;
        lr.targetVelocity = 0;

        rf1.motor = rf;
        rr1.motor = rr;
        lf1.motor = lf;
        lr1.motor = lr;
    }

    IEnumerator driveBackward(float[] tp)
    {
        rf1.useMotor = true;
        rr1.useMotor = true;
        lf1.useMotor = true;
        lr1.useMotor = true;

        rf = rf1.motor;
        rr = rr1.motor;
        lf = lf1.motor;
        lr = lr1.motor;

        rf.force = 100;
        rr.force = 100;
        lf.force = 100;
        lr.force = 100;


        rf.targetVelocity = -500 * tp[1];
        rr.targetVelocity = -500 * tp[1];
        lf.targetVelocity = -500 * tp[1];
        lr.targetVelocity = -500 * tp[1];

        rf1.motor = rf;
        rr1.motor = rr;
        lf1.motor = lf;
        lr1.motor = lr;

        Debug.Log("driveBackward");

        yield return new WaitForSeconds(tp[0]);

        rf1.useMotor = true;
        rr1.useMotor = true;
        lf1.useMotor = true;
        lr1.useMotor = true;

        rf = rf1.motor;
        rr = rr1.motor;
        lf = lf1.motor;
        lr = lr1.motor;

        rf.force = 100;
        rr.force = 100;
        lf.force = 100;
        lr.force = 100;


        rf.targetVelocity = 0;
        rr.targetVelocity = 0;
        lf.targetVelocity = 0;
        lr.targetVelocity = 0;

        rf1.motor = rf;
        rr1.motor = rr;
        lf1.motor = lf;
        lr1.motor = lr;
    }

    IEnumerator turnLeft(float[] dp)
    {
        Debug.Log("turnLeft");

        yield return new WaitForSeconds(0);

    }

    IEnumerator turnRight(float[] dp)
    {
        Debug.Log("turnRight");

        yield return new WaitForSeconds(0);

    }

    public float[] values(String input)
    {
        String [] vals = new String[2];
        float[] val = new float[2];

        String s = input;
        s = s.Substring(s.IndexOf("(") + 1);
        s = s.Substring(0, s.IndexOf(")"));

        vals = s.Split(',');

        val[0] = float.Parse(vals[0]);
        val[1] = float.Parse(vals[1]);
        return val;

    }



}
