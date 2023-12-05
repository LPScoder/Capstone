using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class ShowText3 : MonoBehaviour
{
    // declare variables
    public Text myname;
    string txtFile = "ScoreDatabase.txt";
    // Start is called before the first frame update
    void Start()
    {
        string texttemp = File.ReadAllText(txtFile);
        StreamReader reader = new StreamReader(txtFile);
        string inputtext = " ";
        string final = "";
        
      /*  while(inputtext != "0")
	{
		inputtext = reader.ReadLine();
        final = final + reader.ReadLine();
        Debug.Log(inputtext); 
    }*/

        myname.text = texttemp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
