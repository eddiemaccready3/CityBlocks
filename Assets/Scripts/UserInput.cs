using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UserInput : MonoBehaviour {

    [SerializeField] AudioClip blockDestroy;

    [SerializeField] BlockDestroyed blockDestroyedScript;
    //Destroy blockColor = new Destroy();

    
    //[SerializeField] ParticleSystem blockDestroyParticles;
    
    private const string SHAPET1 = "10000111";
    private const string SHAPET2 = "1000001100001";
    private const string SHAPET3 = "11100001";
    private const string SHAPET4 = "1000011000001";

    private const string SHAPEO  = "11000011";

    private const string SHAPES1 = "110000011";
    private const string SHAPES2 = "100001100001";

    private const string SHAPEZ1 = "1100011";
    private const string SHAPEZ2 = "10000011000001";

    private const string SHAPEI1 = "1000001000001000001";
    private const string SHAPEI2 = "1111";

    private const string SHAPEJ1 = "11000001000001";
    private const string SHAPEJ2 = "1110001";
    private const string SHAPEJ3 = "10000010000011";
    private const string SHAPEJ4 = "1000111";

    private const string SHAPEL1 = "1100001000001";
    private const string SHAPEL2 = "111000001";
    private const string SHAPEL3 = "1000001000011";
    private const string SHAPEL4 = "100000111";

    private const string SHAPEX  = "1000011100001";

    private const string SHAPEV1  = "1100001";
    private const string SHAPEV2  = "10000011";
    private const string SHAPEV3  = "1000011";
    private const string SHAPEV4  = "11000001";

    private const string SHAPEARROW1  = "10100001";
    private const string SHAPEARROW2  = "1000000100001";
    private const string SHAPEARROW3  = "10000101";
    private const string SHAPEARROW4  = "1000010000001";

    private const string SHAPEDASH1  = "100001";
    private const string SHAPEDASH2  = "10000001";

    private const string SHAPESHORTI1  = "1000001";
    private const string SHAPESHORTI2  = "11";

    AudioSource audioSource;

    
    private List<Vector3> listBlocksClickedOn = new List<Vector3>();
    private List<Vector3> checkBlocksClickedOn = new List<Vector3>();
    
    private List<int> checkShapeGrid = new List<int>();
    private List<int> shapeMatchIndexes = new List<int>();
    
    private List<string> listTagsClicked = new List<string>();
    private List<string> listOfShapes = new List<string>();
    private List<string> shapeTGrid = new List<string>();
    private List<string> shapeSGrid = new List<string>();
    private List<string> shapeZGrid = new List<string>();
    private List<string> shapeIGrid = new List<string>();
    private List<string> shapeJGrid = new List<string>();
    private List<string> shapeLGrid = new List<string>();
    private List<string> shapeVGrid = new List<string>();
    private List<string> shapeXGrid = new List<string>();
    private List<string> shapeArrowGrid = new List<string>();
    private List<string> shapeDashGrid = new List<string>();
    private List<string> shapeShortIGrid = new List<string>();
    
    private Vector3 blockClickedPoition;
    private Vector3 newPosToCheckShape;

    private ScoreBoard scoreBoard;
    private Timer timer;

    [SerializeField] GameObject destroyer;
    [SerializeField] GameObject explosionParticle;
    [SerializeField] GameObject trigger;
    GameObject[] explosion;

    private string name = "Particles";


    //GameObject blueBlock = new GameObject("BlueBlock");
    //GameObject redBlock = new GameObject("RedBlock");
    //GameObject destroyer;
    //GameObject destroyer;
    //GameObject destroyer;
    //GameObject destroyer;

    private string tagFirstBlockClicked;
    private string currentGridIndex;
    
    private bool match;
    public SimGravity resetIsGrounded;

    private float minX = 0f;
    private float minY = 0f;

    private int shapeGridPosX = 0;
    private int shapeGridPosY = 0;

	// Use this for initialization
	
        
    void Start ()
    {
        
        scoreBoard = FindObjectOfType<ScoreBoard>();
        timer = FindObjectOfType<Timer>();
        listBlocksClickedOn.Clear();
        listTagsClicked.Clear();
        match = false;
        PopulateShapesList();
        PopulateShapeGridList();


        audioSource = GetComponent<AudioSource>();
        //audioSource.volume = 0.25f;

        //string temp = string.Join(" , ", listOfShapes.Select(x => x.ToString()).ToArray());
        //print("Shape List: " + temp);
        //string temp2 = string.Join(" , ", shapeTGrid.Select(x => x.ToString()).ToArray());
        //print("Shape T Grid: " + temp2);

    }

    private void PopulateShapeGridList()
    {
        shapeTGrid.Add(SHAPET1);
        shapeTGrid.Add(SHAPET2);
        shapeTGrid.Add(SHAPET3);
        shapeTGrid.Add(SHAPET4);

        shapeSGrid.Add(SHAPES1);
        shapeSGrid.Add(SHAPES2);

        shapeZGrid.Add(SHAPEZ1);
        shapeZGrid.Add(SHAPEZ2);

        shapeIGrid.Add(SHAPEI1);
        shapeIGrid.Add(SHAPEI2);

        shapeJGrid.Add(SHAPEJ1);
        shapeJGrid.Add(SHAPEJ2);
        shapeJGrid.Add(SHAPEJ3);
        shapeJGrid.Add(SHAPEJ4);

        shapeLGrid.Add(SHAPEL1);
        shapeLGrid.Add(SHAPEL2);
        shapeLGrid.Add(SHAPEL3);
        shapeLGrid.Add(SHAPEL4);

        shapeVGrid.Add(SHAPEV1);
        shapeVGrid.Add(SHAPEV2);
        shapeVGrid.Add(SHAPEV3);
        shapeVGrid.Add(SHAPEV4);

        shapeArrowGrid.Add(SHAPEARROW1);
        shapeArrowGrid.Add(SHAPEARROW2);
        shapeArrowGrid.Add(SHAPEARROW3);
        shapeArrowGrid.Add(SHAPEARROW4);

        shapeDashGrid.Add(SHAPEDASH1);
        shapeDashGrid.Add(SHAPEDASH2);

        shapeShortIGrid.Add(SHAPESHORTI1);
        shapeShortIGrid.Add(SHAPESHORTI2);
    }

    private void PopulateShapesList()
    {
        listOfShapes.Add("ShapeX");
        listOfShapes.Add("ShapeT");
        listOfShapes.Add("ShapeS");
        listOfShapes.Add("ShapeZ");
        listOfShapes.Add("ShapeL");
        listOfShapes.Add("ShapeJ");
        listOfShapes.Add("ShapeI");
        listOfShapes.Add("ShapeO");
        listOfShapes.Add("ShapeArrow");
        listOfShapes.Add("ShapeV");
        listOfShapes.Add("ShapeShortI");
        listOfShapes.Add("ShapeDash");
        
    }

    // Update is called once per frame
    void Update ()
    {
        CheckMouseClicks();
        //OnMouseUp();
    }

    private void CheckMouseClicks()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                        Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
            PopulateClickedLists(hit);
        }

        if (Input.GetMouseButtonUp(0))
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    Vector3 gridCheck = new Vector3(x, y, 0);
                    if (listBlocksClickedOn.Contains(gridCheck))
                    {
                        checkShapeGrid.Add(1);
                    }
                    else
                    {
                        checkShapeGrid.Add(0);
                    }

                    //print("Grid pos: " + checkShapeGrid[checkShapeGrid.Count]);
                }
            }

            string grid = string.Join("", checkShapeGrid.Select(x => x.ToString()).ToArray());
            print(grid);

            //Compare this list to Shape

            for (int s = 0; s < listOfShapes.Count; s++)
            {
                if (GameObject.FindWithTag(listOfShapes[s]) != null & s == 0)
                {
                    CheckForShapeX();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null & s == 1)
                {
                    CheckForShapeT();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null & s == 2)
                {
                    CheckForShapeS();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null & s == 3)
                {
                    CheckForShapeZ();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null & s == 4)
                {
                    CheckForShapeL();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null & s == 5)
                {
                    CheckForShapeJ();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null & s == 6)
                {
                    CheckForShapeI();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null & s == 7)
                {
                    CheckForShapeO();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null & s == 8)
                {
                    CheckForShapeArrow();
                }
                
                else if (GameObject.FindWithTag(listOfShapes[s]) != null & s == 9)
                {
                    CheckForShapeV();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null & s == 10)
                {
                    CheckForShapeShortI();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null & s == 11)
                {
                    CheckForShapeDash();
                }
            }

            //If matched, destroy matching Blocks at original coordinates

            

            listBlocksClickedOn.Clear();
            listTagsClicked.Clear();
            checkShapeGrid.Clear();
            checkBlocksClickedOn.Clear();
            shapeMatchIndexes.Clear();

            minX = 0f;
            minY = 0f;
            match = false;

            //blueBlock.GetComponent<resetIsGrounded>().isGrounded = false;

        }
    }

    private void CheckForShapeT()
    {
        for (int g = 0; g < shapeTGrid.Count; g++)
        {
            currentGridIndex = shapeTGrid[g];
            shapeMatchIndexes.Clear();
            for (int i = 0; i < currentGridIndex.Length; i++)
            {
                if (currentGridIndex[i] == '1')
                {
                    shapeMatchIndexes.Add(i);
                }
            }

            //string shapeMatchIndexString = string.Join("", shapeMatchIndexes.Select(x => x.ToString()).ToArray());
            //print("Match Indexes: " + shapeMatchIndexString);

            for (int i = 0; i < (61 - currentGridIndex.Length); i++)
            {
                if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1 & checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    //print("Match shape T!");
                    Match4BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeT"));
                    scoreBoard.ScoreHit(350);
                    timer.timeLeft = timer.timeLeft + 10f;
                }
            }

            shapeMatchIndexes.Clear();
        }
    }

    

    private void CheckForShapeO()
    {
        for (int i = 0; i < SHAPEO.Length; i++)
        {
            if (SHAPEO[i] == '1')
            {
                shapeMatchIndexes.Add(i);
            }
        }

        //string shapeMatchIndexString = string.Join("", shapeMatchIndexes.Select(x => x.ToString()).ToArray());
        //print("Match Indexes: " + shapeMatchIndexString);

        for (int i = 0; i < (61 - SHAPEO.Length); i++)
        {
            if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1 & checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
            {
                //print("Match shape O!");

                Match4BlockShape(i);
                Destroy (GameObject.FindWithTag("ShapeO"));
                scoreBoard.ScoreHit(100);
                timer.timeLeft = timer.timeLeft + 5f;
            }
        }
    }

    private void CheckForShapeS()
    {
        for (int g = 0; g < shapeSGrid.Count; g++)
        {
            currentGridIndex = shapeSGrid[g];
            shapeMatchIndexes.Clear();
            for (int i = 0; i < currentGridIndex.Length; i++)
            {
                if (currentGridIndex[i] == '1')
                {
                    shapeMatchIndexes.Add(i);
                }
            }

            for (int i = 0; i < (61 - currentGridIndex.Length); i++)
            {
                if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1 & checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    Match4BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeS"));
                    scoreBoard.ScoreHit(275);
                    timer.timeLeft = timer.timeLeft + 7f;
                }
            }

            shapeMatchIndexes.Clear();
        }
    }

    private void CheckForShapeZ()
    {
        for (int g = 0; g < shapeZGrid.Count; g++)
        {
            currentGridIndex = shapeZGrid[g];
            shapeMatchIndexes.Clear();
            //print("Current grid: " + currentGridIndex);
            for (int i = 0; i < currentGridIndex.Length; i++)
            {
                if (currentGridIndex[i] == '1')
                {
                    shapeMatchIndexes.Add(i);
                }
            }

            string temp = string.Join(" , ", shapeMatchIndexes.Select(x => x.ToString()).ToArray());
            //print("Match Indexes: " + temp);

            for (int i = 0; i < (61 - currentGridIndex.Length); i++)
            {
                if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1 & checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    Match4BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeZ"));
                    scoreBoard.ScoreHit(275);
                    timer.timeLeft = timer.timeLeft + 7f;
                }
            }

            shapeMatchIndexes.Clear();
        }
    }

    private void CheckForShapeI()
    {
        for (int g = 0; g < shapeIGrid.Count; g++)
        {
            currentGridIndex = shapeIGrid[g];
            shapeMatchIndexes.Clear();
            for (int i = 0; i < currentGridIndex.Length; i++)
            {
                if (currentGridIndex[i] == '1')
                {
                    shapeMatchIndexes.Add(i);
                }
            }

            for (int i = 0; i < (61 - currentGridIndex.Length); i++)
            {
                if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1 & checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    Match4BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeI"));
                    scoreBoard.ScoreHit(175);
                    timer.timeLeft = timer.timeLeft + 5f;
                }
            }

            shapeMatchIndexes.Clear();
        }
    }

    private void CheckForShapeJ()
    {
        for (int g = 0; g < shapeJGrid.Count; g++)
        {
            currentGridIndex = shapeJGrid[g];
            shapeMatchIndexes.Clear();
            for (int i = 0; i < currentGridIndex.Length; i++)
            {
                if (currentGridIndex[i] == '1')
                {
                    shapeMatchIndexes.Add(i);
                }
            }

            for (int i = 0; i < (61 - currentGridIndex.Length); i++)
            {
                if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1 & checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    Match4BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeJ"));
                    scoreBoard.ScoreHit(200);
                    timer.timeLeft = timer.timeLeft + 6f;
                }
            }

            shapeMatchIndexes.Clear();
        }
    }

    private void CheckForShapeL()
    {
        for (int g = 0; g < shapeLGrid.Count; g++)
        {
            currentGridIndex = shapeLGrid[g];
            shapeMatchIndexes.Clear();
            for (int i = 0; i < currentGridIndex.Length; i++)
            {
                if (currentGridIndex[i] == '1')
                {
                    shapeMatchIndexes.Add(i);
                }
            }

            for (int i = 0; i < (61 - currentGridIndex.Length); i++)
            {
                if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1 & checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    Match4BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeL"));
                    scoreBoard.ScoreHit(200);
                    timer.timeLeft = timer.timeLeft + 6f;
                }
            }

            shapeMatchIndexes.Clear();
        }
    }

    private void CheckForShapeX()
    {
        for (int i = 0; i < SHAPEX.Length; i++)
        {
            if (SHAPEX[i] == '1')
            {
                shapeMatchIndexes.Add(i);
            }
        }


        for (int i = 0; i < (61 - SHAPEX.Length); i++)
        {
            if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1 & checkShapeGrid[i + shapeMatchIndexes[3]] == 1 & checkShapeGrid[i + shapeMatchIndexes[4]] == 1)
            {
                //print("Match shape X!");
                Match5BlockShape(i);
                Destroy (GameObject.FindWithTag("ShapeX"));
                scoreBoard.ScoreHit(500);
                timer.timeLeft = timer.timeLeft + 15f;
            }
        }
    }

    

    private void CheckForShapeV()
    {
        for (int g = 0; g < shapeVGrid.Count; g++)
        {
            currentGridIndex = shapeVGrid[g];
            shapeMatchIndexes.Clear();
            //print("Current grid: " + currentGridIndex);
            for (int i = 0; i < currentGridIndex.Length; i++)
            {
                if (currentGridIndex[i] == '1')
                {
                    shapeMatchIndexes.Add(i);
                }
            }

            string temp = string.Join(" , ", shapeMatchIndexes.Select(x => x.ToString()).ToArray());
            //print("Match Indexes: " + temp);

            for (int i = 0; i < (61 - currentGridIndex.Length); i++)
            {
                if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1)
                {
                    //print("Match shape V!");
                    Match3BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeV"));
                    scoreBoard.ScoreHit(100);
                    timer.timeLeft = timer.timeLeft + 3f;
                }
            }

            shapeMatchIndexes.Clear();
        }
    }

    private void CheckForShapeArrow()
    {
        for (int g = 0; g < shapeArrowGrid.Count; g++)
        {
            currentGridIndex = shapeArrowGrid[g];
            shapeMatchIndexes.Clear();
            //print("Current grid: " + currentGridIndex);
            for (int i = 0; i < currentGridIndex.Length; i++)
            {
                if (currentGridIndex[i] == '1')
                {
                    shapeMatchIndexes.Add(i);
                }
            }

            string temp = string.Join(" , ", shapeMatchIndexes.Select(x => x.ToString()).ToArray());
            //print("Match Indexes: " + temp);

            for (int i = 0; i < (61 - currentGridIndex.Length); i++)
            {
                if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1)
                {
                    //print("Match shape V!");
                    Match3BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeArrow"));
                    scoreBoard.ScoreHit(150);
                    timer.timeLeft = timer.timeLeft + 4f;
                }
            }

            shapeMatchIndexes.Clear();
        }
    }

    private void CheckForShapeDash()
    {
        for (int g = 0; g < shapeDashGrid.Count; g++)
        {
            currentGridIndex = shapeDashGrid[g];
            shapeMatchIndexes.Clear();
            //print("Current grid: " + currentGridIndex);
            for (int i = 0; i < currentGridIndex.Length; i++)
            {
                if (currentGridIndex[i] == '1')
                {
                    shapeMatchIndexes.Add(i);
                }
            }

            string temp = string.Join(" , ", shapeMatchIndexes.Select(x => x.ToString()).ToArray());
            //print("Match Indexes: " + temp);

            for (int i = 0; i < (61 - currentGridIndex.Length); i++)
            {
                if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1)
                {
                    //print("Match shape V!");
                    Match2BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeDash"));
                    scoreBoard.ScoreHit(75);
                    timer.timeLeft = timer.timeLeft + 3f;
                }
            }

            shapeMatchIndexes.Clear();
        }
    }

    private void CheckForShapeShortI()
    {
        for (int g = 0; g < shapeShortIGrid.Count; g++)
        {
            currentGridIndex = shapeShortIGrid[g];
            shapeMatchIndexes.Clear();
            //print("Current grid: " + currentGridIndex);
            for (int i = 0; i < currentGridIndex.Length; i++)
            {
                if (currentGridIndex[i] == '1')
                {
                    shapeMatchIndexes.Add(i);
                }
            }

            string temp = string.Join(" , ", shapeMatchIndexes.Select(x => x.ToString()).ToArray());
            //print("Match Indexes: " + temp);

            for (int i = 0; i < (61 - currentGridIndex.Length); i++)
            {
                if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1)
                {
                    //print("Match shape V!");
                    Match2BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeShortI"));
                    scoreBoard.ScoreHit(50);
                    timer.timeLeft = timer.timeLeft + 2f;
                }
            }

            shapeMatchIndexes.Clear();
        }
    }

    private void Match2BlockShape(int i)
    {
        //blockDestroyedScript.blockDestroyed = true;
        GameObject destroyObject = GameObject.Find("Destroy");
        Destroy detroyScript = destroyObject.GetComponent<Destroy>();
        Instantiate(destroyer, new Vector3((i % 6), (i / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[1]) % 6), ((i + shapeMatchIndexes[1]) / 6), 0), Quaternion.identity);
        Instantiate(explosionParticle, new Vector3((i % 6), (i / 6), 0), Quaternion.identity);
        Instantiate(explosionParticle, new Vector3(((i + shapeMatchIndexes[1]) % 6), ((i + shapeMatchIndexes[1]) / 6), 0), Quaternion.identity);
        Invoke("DestroyParticle", 1f);
        match = true;
        if (!audioSource.isPlaying)
        {
            //audioSource.volume = 0.25f;
            audioSource.PlayOneShot(blockDestroy);
            //audioSource.volume = 1f;
        }
        
    }
    
    private void Match3BlockShape(int i)
    {
        //blockDestroyedScript.blockDestroyed = true;
        Instantiate(destroyer, new Vector3((i % 6), (i / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[1]) % 6), ((i + shapeMatchIndexes[1]) / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[2]) % 6), ((i + shapeMatchIndexes[2]) / 6), 0), Quaternion.identity);
        match = true;
        if (!audioSource.isPlaying)
        {
            //audioSource.volume = 0.25f;
            audioSource.PlayOneShot(blockDestroy);
            //audioSource.volume = 1f;
        }
        //blockDestroyParticles.Play();
        
        
    }

    private void Match4BlockShape(int i)
    {
        //blockDestroyedScript.blockDestroyed = true;
        Instantiate(destroyer, new Vector3((i % 6), (i / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[1]) % 6), ((i + shapeMatchIndexes[1]) / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[2]) % 6), ((i + shapeMatchIndexes[2]) / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[3]) % 6), ((i + shapeMatchIndexes[3]) / 6), 0), Quaternion.identity);
        match = true;
        if (!audioSource.isPlaying)
        {
            //audioSource.volume = 0.25f;
            audioSource.PlayOneShot(blockDestroy);
            //audioSource.volume = 1f;
        }
        //blockDestroyParticles.Play();
        
    }

    private void Match5BlockShape(int i)
    {
        //blockDestroyedScript.blockDestroyed = true;
        Instantiate(destroyer, new Vector3((i % 6), (i / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[1]) % 6), ((i + shapeMatchIndexes[1]) / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[2]) % 6), ((i + shapeMatchIndexes[2]) / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[3]) % 6), ((i + shapeMatchIndexes[3]) / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[4]) % 6), ((i + shapeMatchIndexes[4]) / 6), 0), Quaternion.identity);
        match = true;
        if (!audioSource.isPlaying)
        {
            //audioSource.volume = 0.25f;
            audioSource.PlayOneShot(blockDestroy);
            //audioSource.volume = 1f;
        }
        //blockDestroyParticles.Play();
        


    }

    private void DestroyParticle()
    {
        explosion = GameObject.FindGameObjectsWithTag (name);
        for(int i = 0 ; i < explosion.Length; i ++)
        {
        Destroy(explosion[i]);
        }
    }
    private void PopulateClickedLists(RaycastHit2D hit)
    {
        if (hit)
        {
            blockClickedPoition = hit.transform.gameObject.transform.position;
            tagFirstBlockClicked = hit.transform.gameObject.tag;

            if (!listBlocksClickedOn.Contains(blockClickedPoition) & listTagsClicked.Count == 0)
            {
                listBlocksClickedOn.Add(blockClickedPoition);
                listTagsClicked.Add(tagFirstBlockClicked);
            }

            else if (!listBlocksClickedOn.Contains(blockClickedPoition) & listTagsClicked.Contains(tagFirstBlockClicked))
            {
                listBlocksClickedOn.Add(blockClickedPoition);
                listTagsClicked.Add(tagFirstBlockClicked);
            }

            //foreach (Vector3 item in listBlocksClickedOn)
            //{
            //    print("Added to List: " + item);
            //}
        }
    }
}
