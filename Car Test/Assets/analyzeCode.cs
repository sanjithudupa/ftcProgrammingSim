using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows;


public class analyzeCode : MonoBehaviour
{
    public Renderer robotRenderer;
    public ColorPicker picker;
    public string path;
    public string program;
    public string actualCode;
    public GameObject robot;
    public HingeJoint rf1, rr1, lf1, lr1;
    public JointMotor rf, rr, lf, lr;

	public Quaternion startRot;
	public Vector3    startPos;

    public GameObject settings;
    public String programName;
    public InputField nameInput;
    public Text ProgramTitle;
    public InputField colorInput;
    

    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("colorHex"));
        
        nameInput.text = PlayerPrefs.GetString("programName", "Linear Op Mode");
        colorInput.text = PlayerPrefs.GetString("colorHex");
  
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
        PlayerPrefs.SetString("colorHex", colorInput.text);


        robotRenderer.material.color = picker.CurrentColor;

        Debug.Log(picker.CurrentColor);

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

        ProgramTitle.text = PlayerPrefs.GetString("programName", "Linear Op Mode");

        colorInput.text = PlayerPrefs.GetString("colorHex");
    }

    public void Play()
    {

        StartCoroutine(Run(0));
    }

	public void Reset()
	{
		rf.force = 0;
		rr.force = 0;
		lf.force = 0;
		lr.force = 0;

		rf.targetVelocity = 0;
		rr.targetVelocity = 0;
		lf.targetVelocity = 0;
		lr.targetVelocity = 0;

        //robot.transform.position = new Vector3(1,7,0); 

        SceneManager.LoadScene(1);


    }

    

	IEnumerator Run(int lastIndex)
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

        yield return new WaitForSeconds(1);

        string[] lines = actualCode.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        
        for(int i = lastIndex; i <= lines.Length-1; i++)
        {
            if (lines[i].Contains("driveForward"))
            {
                //StartCoroutine("driveForward");
                StartCoroutine(driveForward(values(lines[i]), i));
                Debug.Log("f1");
                break;
            }
            else if (lines[i].Contains("driveBackward"))
            {
				StartCoroutine(driveBackward(values(lines[i]), i));
                Debug.Log("f2");
                break;
            }
            else if (lines[i].Contains("turnLeft"))
            {
				StartCoroutine(turnLeft(values(lines[i]), i));
                Debug.Log("f3");
                break;
            }
            else if (lines[i].Contains("turnRight"))
            {
				StartCoroutine(turnRight(values(lines[i]), i));
                //break;
                Debug.Log("f4");
                break;
            }
            //else if (lines[i].Contains(""))
            //{
            //    Debug.Log("f5");
            //    //break;
            //    break;
            //}
            //else
            //{
            //    Debug.Log("ERROR");
            //    //break;
            //    break;
            //}


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

    IEnumerator driveForward(float[] tp, int i)
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
        lf.targetVelocity = -550 * tp[1];
        lr.targetVelocity = -550 * tp[1];

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

		StartCoroutine(Run(i + 1));
    }

    IEnumerator driveBackward(float[] tp, int i)
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


        rf.targetVelocity = 500 * tp[1];
        rr.targetVelocity = 500 * tp[1];
        lf.targetVelocity = -650 * tp[1];
        lr.targetVelocity = -650 * tp[1];

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
		StartCoroutine(Run(i + 1));
	}

    IEnumerator turnLeft(float[] dp, int i)
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


		rf.targetVelocity = -700 * dp[1];
		rr.targetVelocity = -700 * dp[1];
		lf.targetVelocity = 500 * dp[1];
		lr.targetVelocity = 500 * dp[1];

		rf1.motor = rf;
		rr1.motor = rr;
		lf1.motor = lf;
		lr1.motor = lr;

		Debug.Log("turnLeft");

		yield return new WaitForSeconds(dp[0]);

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
		StartCoroutine(Run(i + 1));


		//Debug.Log("turnLeft");

		//yield return new WaitForSeconds(0);

	}

    IEnumerator turnRight(float[] dp, int i)
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


		rf.targetVelocity = -500 * dp[1];
		rr.targetVelocity = 1000 * dp[1];
		lf.targetVelocity = 1000 * dp[1];
		lr.targetVelocity = -500 * dp[1];

		rf1.motor = rf;
		rr1.motor = rr;
		lf1.motor = lf;
		lr1.motor = lr;

		Debug.Log("turnRight");

		yield return new WaitForSeconds(dp[0]);

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

		StartCoroutine(Run(i + 1));
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

    public void settingsWindow(bool open)
    {
       settings.SetActive(open);
       
    }

    public void nameChanged()
    {
        PlayerPrefs.SetString("programName",nameInput.text);


    }

    public void colorChanged()
    {

        PlayerPrefs.SetString("colorHex", colorInput.text);
    }

    public void exitToMenu()
    {
        settings.SetActive(false);
        SceneManager.LoadScene(0);
    }


}
