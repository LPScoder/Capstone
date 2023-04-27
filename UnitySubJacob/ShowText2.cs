using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText2 : MonoBehaviour
{
    // declare variables
    public string score;
    public Text myname;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // assign score to the score recorded from darts hitting board
        score = DartFly.final;
        // display score on screen
        myname.text = score;
    }

    
}
