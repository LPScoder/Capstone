using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class DartFly : MonoBehaviour
{
    // declare variables
    public float speed = 8f;
    public bool dart1go = false;
    public bool dart2go = false;
    public bool dart3go = false;
    public float delay = 0.1f;
    private float timer1;
    private float timer2;
    private float timer4 = 1f;
    private Vector3 offset = new Vector3(3, -7, -269.4f);
    private Vector3 scale = new Vector3(1, 4.9f, 20f);
    private bool gooo = true;
    public Text t;
    static public string output = "Throw a dart!!";
    static public string throws = "If you dare.";
    static public string final;
    static public int score = 300;
    static public int thrownum = 0;
    public Rigidbody rb;
    string reader2 = "";
    string reader3 = "";

    // start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        string path2place = "mypi/capstone/unity.txt";//Placeholder.txt";
        //string path2place = "Placeholder.txt";
        Debug.Log(path2place);
        StreamReader reader = new StreamReader(path2place);
        reader3 = reader.ReadToEnd();
        reader2 = reader3;
        
    }

    // update is called once per frame
    void Update()
    {   
        //input mouse coordinates
        string path2place = "mypi/capstone/unity.txt";//Placeholder.txt";
        //string path2place = "Placeholder.txt";
        //Debug.Log(path2place);
        StreamReader reader = new StreamReader(path2place);
        reader3 = reader.ReadToEnd();
        if(reader3 != reader2){
            dart1go = true;
            Debug.Log("shot 1");}
             

        string[] reader4 = reader3.Split(' ');
        //Debug.Log(float.Parse(reader4[reader4.Length-3]));
        float temp1 = 7;
        float temp2 = (float.Parse(reader4[reader4.Length-1])*0.44f)+1.8f;
        float temp3 = (float.Parse(reader4[reader4.Length-2])*0.11f)+13.356f;
        //find mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 mousePos = Input.mousePosition;   
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
        mousePosition = new Vector3(temp1, temp2, temp3);
        //Debug.Log(mousePosition);

        //if mouse clicked
        if (Input.GetMouseButtonUp(0))
        //send first dart
            dart1go = true;
        if (dart1go){
            //make sure multiple darts dont go at once
            timer1 += Time.deltaTime;
            //only can send dart once
            if(gooo == true){
            transform.position = Vector3.Scale(mousePosition, scale) + offset;
            gooo = false;
            }
            //move dart
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            
            //record movement for other two darts
            if (timer1 > delay){
                if(reader3 != reader2){
                    dart2go = true;}
                if(Input.GetMouseButtonUp(0)) {dart2go = true;}
                if (dart2go){
                    timer2 += Time.deltaTime;
                    if(timer2 > delay){
                        if(reader3 != reader2){
                            dart3go = true;}
                        if(Input.GetMouseButtonUp(0)) {dart3go = true;}
                    }
                }
            }
            
        }
        timer4 += Time.deltaTime;
        reader2 = reader3; 
    }
    private void OnTriggerEnter(Collider other)
    {
        //stop dart
        rb.isKinematic = true;
        if(timer4 > delay){
            //if it hit bullseye
            if (other.gameObject.name == "BullC")
            {
                //make sure dart is stopped
                speed = 0;
                //record score
                DartFly.score -= 25;
                //output score
                DartFly.output = "Score: " + DartFly.score.ToString();
                //make sure multiple scores are not recorded
                timer4 = 0;
                //account for potential busting
                if(DartFly.score < 0){
                    DartFly.score += 25;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
            //if dart hit bullseye
            else if (other.gameObject.name == "DBullC")
            {
                //stop dart
                speed = 0;
                //update score
                DartFly.score -= 50;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                //if user buster, reset score to how it was
                if(DartFly.score < 0){
                    DartFly.score += 50;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }

            //same method for every scoring block

            else if (other.gameObject.name == "20T")
            {
                speed = 0;
                DartFly.score -= 60;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 60;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "19T")
            {
                speed = 0;
                DartFly.score -= 57;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 57;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "18T")
            {
                speed = 0;
                DartFly.score -= 54;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 54;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "17T")
            {
                speed = 0;
                DartFly.score -= 51;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 51;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "16T")
            {
                speed = 0;
                DartFly.score -= 48;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 48;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "15T")
            {
                speed = 0;
                DartFly.score -= 45;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 45;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "14T")
            {
                speed = 0;
                DartFly.score -= 42;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 42;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "20DC")
            {
                speed = 0;
                DartFly.score -= 40;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 40;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "13T")
            {
                speed = 0;
                DartFly.score -= 39;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 39;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "19DC")
            {
                speed = 0;
                DartFly.score -= 38;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 38;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "18DC") || (other.gameObject.name == "12T"))
            {
                speed = 0;
                DartFly.score -= 36;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 36;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "17DC")
            {
                speed = 0;
                DartFly.score -= 34;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 34;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "11T")
            {
                speed = 0;
                DartFly.score -= 33;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 33;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "16DC")
            {
                speed = 0;
                DartFly.score -= 32;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 32;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "15DC") || (other.gameObject.name == "10T"))
            {
                speed = 0;
                DartFly.score -= 30;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 30;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "14DC")
            {
                speed = 0;
                DartFly.score -= 28;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 28;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "9T")
            {
                speed = 0;
                DartFly.score -= 27;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 27;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "13DC")
            {
                speed = 0;
                DartFly.score -= 26;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 26;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "12DC") || (other.gameObject.name == "8T"))
            {
                speed = 0;
                DartFly.score -= 24;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 24;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "11DC")
            {
                speed = 0;
                DartFly.score -= 22;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 22;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if (other.gameObject.name == "7T")
            {
                speed = 0;
                DartFly.score -= 21;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 21;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "20B") || (other.gameObject.name == "20U") || (other.gameObject.name == "10DC"))
            {
                speed = 0;
                DartFly.score -= 20;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 20;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "19B") || (other.gameObject.name == "19U"))
            {
                speed = 0;
                DartFly.score -= 19;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 19;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "18B") || (other.gameObject.name == "18U") || (other.gameObject.name == "6T") || (other.gameObject.name == "9DC"))
            {
                speed = 0;
                DartFly.score -= 18;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 18;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "17B") || (other.gameObject.name == "17U"))
            {
                speed = 0;
                DartFly.score -= 17;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 17;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "16B") || (other.gameObject.name == "16U") || (other.gameObject.name == "8DC"))
            {
                speed = 0;
                DartFly.score -= 16;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 16;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "15B") || (other.gameObject.name == "15U") || (other.gameObject.name == "5T"))
            {
                speed = 0;
                DartFly.score -= 15;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 15;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "14B") || (other.gameObject.name == "14U") || (other.gameObject.name == "7DC"))
            {
                speed = 0;
                DartFly.score -= 14;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 14;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "13B") || (other.gameObject.name == "13U"))
            {
                speed = 0;
                DartFly.score -= 13;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 13;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "12B") || (other.gameObject.name == "12U") || (other.gameObject.name == "4T") || (other.gameObject.name == "6DC"))
            {
                speed = 0;
                DartFly.score -= 12;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 12;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "11B") || (other.gameObject.name == "11U"))
            {
                speed = 0;
                DartFly.score -= 11;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 11;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "10B") || (other.gameObject.name == "10U") ||  (other.gameObject.name == "5DC"))
            {
                speed = 0;
                DartFly.score -= 10;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 10;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "9B") || (other.gameObject.name == "9U") || (other.gameObject.name == "3T"))
            {
                speed = 0;
                DartFly.score -= 9;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 9;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "8B") || (other.gameObject.name == "8U") || (other.gameObject.name == "4DC"))
            {
                speed = 0;
                DartFly.score -= 8;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 8;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "7B") || (other.gameObject.name == "7U"))
            {
                speed = 0;
                DartFly.score -= 7;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 7;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "6B") || (other.gameObject.name == "6U") || (other.gameObject.name == "2T") || (other.gameObject.name == "3DC"))
            {
                speed = 0;
                DartFly.score -= 6;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 6;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "5B") || (other.gameObject.name == "5U"))
            {
                speed = 0;
                DartFly.score -= 5;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 5;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "4B") || (other.gameObject.name == "4U") || (other.gameObject.name == "2DC"))
            {
                speed = 0;
                DartFly.score -= 4;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 4;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "3B") || (other.gameObject.name == "3U") || (other.gameObject.name == "1T"))
            {
                speed = 0;
                DartFly.score -= 3;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 3;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "2B") || (other.gameObject.name == "2U") || (other.gameObject.name == "1DC"))
            {
                speed = 0;
                DartFly.score -= 2;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 2;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else if ((other.gameObject.name == "1B") || (other.gameObject.name == "1U"))
            {
                speed = 0;
                DartFly.score -= 1;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
                if(DartFly.score < 0){
                    DartFly.score += 1;
                    DartFly.output = "Bust! Score: " + DartFly.score.ToString();
                }
            }
            else{
                speed = 0;
                DartFly.score -= 0;
                DartFly.output = "Score: " + DartFly.score.ToString();
                timer4 = 0;
            }
            //track number of throws
            thrownum += 1;
            DartFly.throws = "Throws: " + DartFly.thrownum.ToString();
        }
        //if user hit 0, tell them that they won
        if(DartFly.score == 0){
            DartFly.final = "Congratulations! You won in" + "\n" + DartFly.thrownum.ToString() + " throws";
            string path = "ScoreDatabase.txt";
            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(DartFly.thrownum.ToString());
            writer.Close();
        }
    }

}
