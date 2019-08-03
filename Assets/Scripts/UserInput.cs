using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UserInput : MonoBehaviour {

    //CONSTANTS

    //Strings
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

    private const string SHAPEMEDI1  = "1000001000001";
    private const string SHAPEMEDI2  = "111";

    //VARIABLES

    //Ints
    [SerializeField] int reqBlocksOnScreen;
    private int picNumber;

    //Floats
    private float pointRadius;

    //Strings
    private string coinBalanceName = "coin";
    private string scoreBalanceName = "score";

    //Lists
    private List<string> listColorCounter = new List<string>();

    private List<Vector3> listBlocksClickedOn = new List<Vector3>();
    private List<Vector3> checkBlocksClickedOn = new List<Vector3>();

    private List<float> listBlocksClickedOnX = new List<float>();
    private List<float> listBlocksClickedOnY = new List<float>();

    //Arrays
    private int [,] shapeT0 = new int [,]
    {
        { 1, 0 },
        { 1, 1 },
        { 1, 0 }
    };
    private int [,] shapeT90 = new int [,]
    {
        { 1, 1, 1 },
        { 0, 1, 0 }
    };
    private int [,] shapeT180 = new int [,]
    {
        { 0, 1 },
        { 1, 1 },
        { 0, 1 }
    };
    private int [,] shapeT270 = new int [,]
    {
        { 0, 1, 0 },
        { 1, 1, 1 }
    };
    private int [,] shapeO = new int [,]
    {
        { 1, 1 },
        { 1, 1 }
    };
    private int [,] shapeS0 = new int [,]
    {
        { 0, 1, 1 },
        { 1, 1, 0 }
    };
    private int [,] shapeS90 = new int [,]
    {
        { 1, 0 },
        { 1, 1 },
        { 0, 1 }
    };
    private int [,] shapeZ0 = new int [,]
    {
        { 1, 1, 0 },
        { 0, 1, 1 }
    };
    private int [,] shapeZ90 = new int [,]
    {
        { 0, 1 },
        { 1, 1 },
        { 1, 0 }
    };
    private int [,] shapeI0 = new int [,]
    {
        { 1 },
        { 1 },
        { 1 },
        { 1 }
    };
    private int [,] shapeI= new int [,]
    {
        { 1, 1, 1, 1 }
    };
    private int [,] shapeJ0 = new int [,]
    {
        { 0, 1 },
        { 0, 1 },
        { 1, 1 }
    };
    private int [,] shapeJ90 = new int [,]
    {
        { 1, 0, 0 },
        { 1, 1, 1 }
    };
    private int [,] shapeJ180 = new int [,]
    {
        { 1, 1 },
        { 1, 0 },
        { 1, 0 }
    };
    private int [,] shapeJ270 = new int [,]
    {
        { 1, 1, 1 },
        { 0, 0, 1 }
    };
    private int [,] shapeL0 = new int [,]
    {
        { 1, 0 },
        { 1, 0 },
        { 1, 1 }
    };
    private int [,] shapeL90 = new int [,]
    {
        { 1, 1, 1 },
        { 1, 0, 0 }
    };
    private int [,] shapeL180 = new int [,]
    {
        { 1, 1 },
        { 0, 1 },
        { 0, 1 }
    };
    private int [,] shapeL270 = new int [,]
    {
        { 0, 0, 1 },
        { 1, 1, 1 }
    };
    private int [,] shapeX= new int [,]
    {
        { 0, 1, 0 },
        { 1, 1, 1 },
        { 0, 1, 0 }
    };
    private int [,] shapeV0 = new int [,]
    {
        { 1, 0 },
        { 1, 1 }
    };
    private int [,] shapeV90 = new int [,]
    {
        { 1, 1 },
        { 0, 1 }
    };
    private int [,] shapeArrow0 = new int [,]
    {
        { 0, 1, 0 },
        { 1, 0, 1 }
    };
    private int [,] shapeArrow90 = new int [,]
    {
        { 1, 0 },
        { 0, 1 },
        { 1, 0 }
    };
    private int [,] shapeArrow180 = new int [,]
    {
        { 1, 0, 1 },
        { 0, 1, 0 }
    };
    private int [,] shapeArrow270 = new int [,]
    {
        { 0, 1 },
        { 1, 0 },
        { 0, 1 }
    };
    private int [,] shapeDash0 = new int [,]
    {
        { 0, 1 },
        { 1, 0 }
    };
    private int [,] shapeDash90 = new int [,]
    {
        { 1, 0 },
        { 0, 1 }
    };
    private int [,] shapeShortI0 = new int [,]
    {
        { 1 },
        { 1 }
    };
    private int [,] shapeShortI90 = new int [,]
    {
        { 1, 1 }
    };
    private int [,] shapeMedI0 = new int [,]
    {
        { 1 },
        { 1 },
        { 1 }
    };
    private int [,] shapeMedI90 = new int [,]
    {
        { 1, 1, 1 },
    };

    //Game Objects
    [SerializeField] BlockDestroyed blockDestroyedScript;

    //Audio
    [SerializeField] AudioClip blockDestroy;
    AudioSource audioSource;

    //Layers
    [SerializeField] LayerMask layerMask;

    //Scripts
    private PauseGame pauseGame;
    private ScoreBoard scoreBoardScript;
    private ScoreCounter scoreCounterScript;
    private Timer timer;
    private CoinsCounter coinsCounterScript;
    private Counter counterScript;
    private GameSaver gameSaverScript;

    //private string scoreBalanceText = "scoreBalanceText";
    //private string coinBalanceText = "coinBalanceText";

    //Destroy blockColor = new Destroy();

    
    //[SerializeField] ParticleSystem blockDestroyParticles;



    

    


    

    private float minXClicked;
    private float maxXClicked;
    private float minYClicked;
    private float maxYClicked;

    private Vector3 centerXYClicked;
    
    private List<int> checkShapeGrid = new List<int>();
    private List<int> shapeMatchIndexes = new List<int>();
    
    private List<string> listTagsClicked = new List<string>();
    private List<string> listOfShapes = new List<string>();
    private List<string> listOfBlocks = new List<string>();
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
    private List<string> shapeMedIGrid = new List<string>();

    public List<string> shapesMatched = new List<string>();

    private List<GameObject> listOfBlockGameObjects = new List<GameObject>();
    
    private Vector3 blockClickedPoition;
    private Vector3 newPosToCheckShape;

    

    [SerializeField] GameObject destroyer;
    [SerializeField] GameObject explosionParticle;
    [SerializeField] GameObject trigger;
    GameObject[] explosion;

    private GameObject[] everyGameObjectsArray;

    private string tagFirstBlockClicked;
    private string currentGridIndex;
    
    private bool match;
    public SimGravity resetIsGrounded;

    private float minX = 0f;
    private float minY = 0f;

    private int shapeGridPosX = 0;
    private int shapeGridPosY = 0;

    [SerializeField] private GameObject Points500;
    [SerializeField] private GameObject Points350;
    [SerializeField] private GameObject Points300;
    [SerializeField] private GameObject Points225;
    [SerializeField] private GameObject Points200;
    [SerializeField] private GameObject Points150;
    [SerializeField] private GameObject Points125;
    [SerializeField] private GameObject Points100;
    [SerializeField] private GameObject Points75;
    [SerializeField] private GameObject Points50;

    private int shapeOPoints = 300;
    private int shapeTPoints = 350;
    private int shapeSPoints = 350;
    private int shapeZPoints = 350;
    private int shapeIPoints = 225;
    private int shapeJPoints = 200;
    private int shapeLPoints = 200;
    private int shapeVPoints = 100;
    private int shapeXPoints = 500;
    private int shapeArrowPoints = 150;
    private int shapeDashPoints = 75;
    private int shapeShortIPoints = 50;
    private int shapeMedIPoints = 125;

    private int coinGold = 25;
    private int coinSilver = 15;
    private int coinBronze = 8;

    // Use this for initialization

    private void Awake()
    {
        
    }

    void Start ()
    {
        pauseGame = FindObjectOfType<PauseGame>();
        pauseGame.pauseAuto = false;
        pauseGame.pauseManual = false;

        scoreBoardScript = FindObjectOfType<ScoreBoard>();
        scoreCounterScript = FindObjectOfType<ScoreCounter>();
        coinsCounterScript = FindObjectOfType<CoinsCounter>();
        counterScript = FindObjectOfType<Counter>();
        timer = FindObjectOfType<Timer>();
        gameSaverScript = FindObjectOfType<GameSaver>();
        listBlocksClickedOn.Clear();
        listTagsClicked.Clear();
        match = false;
        PopulateShapesList();
        PopulateShapeGridList();

        pointRadius = 0.001f;

        audioSource = GetComponent<AudioSource>();

        listOfBlockGameObjects.Clear();

        shapesMatched.Clear();

        //print("Saved Matches made: " + PlayerPrefs.GetInt("London" + gameSaverScript.keyHighMatchesPerLevel));
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

        shapeMedIGrid.Add(SHAPEMEDI1);
        shapeMedIGrid.Add(SHAPEMEDI2);
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
        listOfShapes.Add("ShapeMedI");
        listOfShapes.Add("ShapeArrow");
        listOfShapes.Add("ShapeV");
        listOfShapes.Add("ShapeShortI");
        listOfShapes.Add("ShapeDash");
        
    }

    // Update is called once per frame
    void Update ()
    {
        if(pauseGame.pauseManual == false)
        {
            CheckMouseClicks();
        }
    }
    

    private void CheckMouseClicks()
    {
        if (Input.GetMouseButton(0))
        {
            
            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                        Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            Collider2D hit = Physics2D.OverlapCircle(origin, pointRadius, layerMask);
            if(hit != null)
            {
                //print("Block clicked on: " + hit.transform.name + " at " + hit.transform.position);
            }
            //if(hit2 != null)
            //{
            //    print("Collider position: " + hit2.transform.position.x + ", " + hit2.transform.position.y);
            //    print("Layer: " + hit2.gameObject.name + hit2.transform.gameObject.layer);
            //}
            //RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
            PopulateClickedLists(hit);
        }

        if (Input.GetMouseButtonUp(0))
        {
            pointRadius = 0.001f;

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
            //print(grid);

            //Compare this list to Shape

            

            for (int s = 0; s < listOfShapes.Count; s++)
            {
                if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 0)
                {
                    CheckForShapeX();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 1)
                {
                    CheckForShapeT();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 2)
                {
                    CheckForShapeS();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 3)
                {
                    CheckForShapeZ();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 4)
                {
                    CheckForShapeL();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 5)
                {
                    CheckForShapeJ();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 6)
                {
                    CheckForShapeI();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 7)
                {
                    //print("Check for O");
                    CheckForShapeO();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 8)
                {
                    CheckForShapeMedI();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 9)
                {
                    CheckForShapeArrow();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 10)
                {
                    CheckForShapeV();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 11)
                {
                    CheckForShapeShortI();
                }

                else if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 12)
                {
                    CheckForShapeDash();
                }
            }
            //}

            //If matched, destroy matching Blocks at original coordinates

            checkShapeGrid.Clear();

            string temp = string.Join(" , ", listOfBlocks.Select(x => x.ToString()).ToArray());
            //print("Block List: " + temp);

            foreach (Vector3 p in listBlocksClickedOn)
            {
                //print("Block position: " + p);
            }

            listBlocksClickedOnX.Clear();
            listBlocksClickedOnY.Clear();
            listBlocksClickedOn.Clear();
            listTagsClicked.Clear();
            checkShapeGrid.Clear();
            checkBlocksClickedOn.Clear();
            shapeMatchIndexes.Clear();

            

            minX = 0f;
            minY = 0f;
            match = false;
        }
    }

    private void CountAllBlocksOnScreen()
    {
        listOfBlockGameObjects.Clear();

        everyGameObjectsArray = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        for (int i = 0; i < everyGameObjectsArray.Length; i++)
        {
            if (everyGameObjectsArray[i].layer == 12)
            {
                listOfBlockGameObjects.Add(everyGameObjectsArray[i]);
            }
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

            string temp = string.Join(" , ", shapeMatchIndexes.Select(x => x.ToString()).ToArray());
            //print("Match Indexes: " + temp);

            for (int i = 0; i < (61 - currentGridIndex.Length); i++)
            {
                if (match == false && checkShapeGrid[i] == 1 && checkShapeGrid[i + shapeMatchIndexes[1]] == 1 && checkShapeGrid[i + shapeMatchIndexes[2]] == 1 && checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    //print("Match shape T!");
                    Match4BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeT"));
                    if (!shapesMatched.Contains("ShapeT"))
                    {
                        shapesMatched.Add("ShapeT");
                    }
                    counterScript.AddInAmount(shapeTPoints, scoreBalanceName);
                    Instantiate(Points350, centerXYClicked, Quaternion.identity);
                    timer.timeLeft = timer.timeLeft + 2f;
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

            string temp = string.Join(" , ", shapeMatchIndexes.Select(x => x.ToString()).ToArray());
            //print("Match Indexes: " + temp);

        for (int i = 0; i < (61 - SHAPEO.Length); i++)
        {
            if (match == false && checkShapeGrid[i] == 1 && checkShapeGrid[i + shapeMatchIndexes[1]] == 1 && checkShapeGrid[i + shapeMatchIndexes[2]] == 1 && checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
            {
                //print("Match shape O!");

                Match4BlockShape(i);
                Destroy (GameObject.FindWithTag("ShapeO"));
                if (!shapesMatched.Contains("ShapeO"))
                    {
                        shapesMatched.Add("ShapeO");
                    }
                counterScript.AddInAmount(shapeOPoints, scoreBalanceName);
                Instantiate(Points300, centerXYClicked, Quaternion.identity);
                timer.timeLeft = timer.timeLeft + 2f;
            }
        }

        shapeMatchIndexes.Clear();
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

            string temp = string.Join(" , ", shapeMatchIndexes.Select(x => x.ToString()).ToArray());
            //print("Match Indexes: " + temp);

            for (int i = 0; i < (61 - currentGridIndex.Length); i++)
            {
                if (match == false && checkShapeGrid[i] == 1 && checkShapeGrid[i + shapeMatchIndexes[1]] == 1 && checkShapeGrid[i + shapeMatchIndexes[2]] == 1 && checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    Match4BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeS"));
                    if (!shapesMatched.Contains("ShapeS"))
                    {
                        shapesMatched.Add("ShapeS");
                    }
                    counterScript.AddInAmount(shapeSPoints, scoreBalanceName);
                    Instantiate(Points350, centerXYClicked, Quaternion.identity);
                    timer.timeLeft = timer.timeLeft + 3f;
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
                if (match == false && checkShapeGrid[i] == 1 && checkShapeGrid[i + shapeMatchIndexes[1]] == 1 && checkShapeGrid[i + shapeMatchIndexes[2]] == 1 && checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    Match4BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeZ"));
                    if (!shapesMatched.Contains("ShapeZ"))
                    {
                        shapesMatched.Add("ShapeZ");
                    }
                    counterScript.AddInAmount(shapeZPoints, scoreBalanceName);
                    Instantiate(Points350, centerXYClicked, Quaternion.identity);
                    timer.timeLeft = timer.timeLeft + 3f;
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

            string temp = string.Join(" , ", shapeMatchIndexes.Select(x => x.ToString()).ToArray());
            //print("Match Indexes: " + temp);

            for (int i = 0; i < (61 - currentGridIndex.Length); i++)
            {
                if (match == false && checkShapeGrid[i] == 1 && checkShapeGrid[i + shapeMatchIndexes[1]] == 1 && checkShapeGrid[i + shapeMatchIndexes[2]] == 1 && checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    Match4BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeI"));
                    if (!shapesMatched.Contains("ShapeI"))
                    {
                        shapesMatched.Add("ShapeI");
                    }
                    counterScript.AddInAmount(shapeIPoints, scoreBalanceName);
                    Instantiate(Points225, centerXYClicked, Quaternion.identity);
                    timer.timeLeft = timer.timeLeft + 2f;
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

            string temp = string.Join(" , ", shapeMatchIndexes.Select(x => x.ToString()).ToArray());
            //print("Match Indexes: " + temp);

            for (int i = 0; i < (61 - currentGridIndex.Length); i++)
            {
                if (match == false && checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 && checkShapeGrid[i + shapeMatchIndexes[2]] == 1 && checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    Match4BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeJ"));
                    if (!shapesMatched.Contains("ShapeJ"))
                    {
                        shapesMatched.Add("ShapeJ");
                    }
                    counterScript.AddInAmount(shapeJPoints, scoreBalanceName);
                    Instantiate(Points200, centerXYClicked, Quaternion.identity);
                    timer.timeLeft = timer.timeLeft + 2f;
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

            string temp = string.Join(" , ", shapeMatchIndexes.Select(x => x.ToString()).ToArray());
            //print("Match Indexes: " + temp);

            for (int i = 0; i < (61 - currentGridIndex.Length); i++)
            {
                if (match == false && checkShapeGrid[i] == 1 && checkShapeGrid[i + shapeMatchIndexes[1]] == 1 && checkShapeGrid[i + shapeMatchIndexes[2]] == 1 && checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    Match4BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeL"));
                    if (!shapesMatched.Contains("ShapeL"))
                    {
                        shapesMatched.Add("ShapeL");
                    }
                    counterScript.AddInAmount(shapeLPoints, scoreBalanceName);
                    Instantiate(Points200, centerXYClicked, Quaternion.identity);
                    timer.timeLeft = timer.timeLeft + 2f;
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

            string temp = string.Join(" , ", shapeMatchIndexes.Select(x => x.ToString()).ToArray());
            //print("Match Indexes: " + temp);


        for (int i = 0; i < (61 - SHAPEX.Length); i++)
        {
            if (match == false && checkShapeGrid[i] == 1 && checkShapeGrid[i + shapeMatchIndexes[1]] == 1 && checkShapeGrid[i + shapeMatchIndexes[2]] == 1 && checkShapeGrid[i + shapeMatchIndexes[3]] == 1 && checkShapeGrid[i + shapeMatchIndexes[4]] == 1)
            {
                //print("Match shape X!");
                Match5BlockShape(i);
                Destroy (GameObject.FindWithTag("ShapeX"));
                if (!shapesMatched.Contains("ShapeX"))
                    {
                        shapesMatched.Add("ShapeX");
                    }
                counterScript.AddInAmount(shapeXPoints, scoreBalanceName);
                Instantiate(Points500, centerXYClicked, Quaternion.identity);
                timer.timeLeft = timer.timeLeft + 3f;
            }
        }

        shapeMatchIndexes.Clear();
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
                if (match == false && checkShapeGrid[i] == 1 && checkShapeGrid[i + shapeMatchIndexes[1]] == 1 && checkShapeGrid[i + shapeMatchIndexes[2]] == 1)
                {
                    //print("Match shape V!");
                    Match3BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeV"));
                    if (!shapesMatched.Contains("ShapeV"))
                    {
                        shapesMatched.Add("ShapeV");
                    }
                    counterScript.AddInAmount(shapeVPoints, scoreBalanceName);
                    Instantiate(Points100, centerXYClicked, Quaternion.identity);
                    timer.timeLeft = timer.timeLeft + 1f;
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
                if (match == false && checkShapeGrid[i] == 1 && checkShapeGrid[i + shapeMatchIndexes[1]] == 1 && checkShapeGrid[i + shapeMatchIndexes[2]] == 1)
                {
                    //print("Match shape V!");
                    Match3BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeArrow"));
                    if (!shapesMatched.Contains("ShapeArrow"))
                    {
                        shapesMatched.Add("ShapeArrow");
                    }
                    counterScript.AddInAmount(shapeArrowPoints, scoreBalanceName);
                    Instantiate(Points150, centerXYClicked, Quaternion.identity);
                    timer.timeLeft = timer.timeLeft + 1f;
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
                if (match == false && checkShapeGrid[i] == 1 && checkShapeGrid[i + shapeMatchIndexes[1]] == 1)
                {
                    //print("Match shape V!");
                    Match2BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeDash"));
                    if (!shapesMatched.Contains("ShapeDash"))
                    {
                        shapesMatched.Add("ShapeDash");
                    }
                    counterScript.AddInAmount(shapeDashPoints, scoreBalanceName);
                    Instantiate(Points75, centerXYClicked, Quaternion.identity);
                    timer.timeLeft = timer.timeLeft + 1f;
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
                if (match == false && checkShapeGrid[i] == 1 && checkShapeGrid[i + shapeMatchIndexes[1]] == 1)
                {
                    //print("Match shape V!");
                    Match2BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeShortI"));
                    if (!shapesMatched.Contains("ShapeShortI"))
                    {
                        shapesMatched.Add("ShapeShortI");
                    }
                    counterScript.AddInAmount(shapeShortIPoints, scoreBalanceName);
                    Instantiate(Points50, centerXYClicked, Quaternion.identity);
                    timer.timeLeft = timer.timeLeft + 1f;
                }
            }

            shapeMatchIndexes.Clear();
        }
    }

    private void CheckForShapeMedI()
    {
        for (int g = 0; g < shapeMedIGrid.Count; g++)
        {
            currentGridIndex = shapeMedIGrid[g];
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
                if (match == false && checkShapeGrid[i] == 1 && checkShapeGrid[i + shapeMatchIndexes[1]] == 1)
                {
                    Match3BlockShape(i);
                    Destroy (GameObject.FindWithTag("ShapeMedI"));
                    if (!shapesMatched.Contains("ShapeMedI"))
                    {
                        shapesMatched.Add("ShapeMedI");
                    }
                    counterScript.AddInAmount(shapeMedIPoints, scoreBalanceName);
                    Instantiate(Points125, centerXYClicked, Quaternion.identity);
                    timer.timeLeft = timer.timeLeft + 2f;
                }
            }

            shapeMatchIndexes.Clear();
        }
    }


    private void Match2BlockShape(int i)
    {
        Instantiate(destroyer, new Vector3((i % 6), (i / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[1]) % 6), ((i + shapeMatchIndexes[1]) / 6), 0), Quaternion.identity);
        match = true;
        FindCenterBlocksClicked();
        PlayBreakSound();

    }

    

    private void Match3BlockShape(int i)
    {
        Instantiate(destroyer, new Vector3((i % 6), (i / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[1]) % 6), ((i + shapeMatchIndexes[1]) / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[2]) % 6), ((i + shapeMatchIndexes[2]) / 6), 0), Quaternion.identity);
        match = true;
        FindCenterBlocksClicked();

        PlayBreakSound();
    }

    private void Match4BlockShape(int i)
    {
        Instantiate(destroyer, new Vector3((i % 6), (i / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[1]) % 6), ((i + shapeMatchIndexes[1]) / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[2]) % 6), ((i + shapeMatchIndexes[2]) / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[3]) % 6), ((i + shapeMatchIndexes[3]) / 6), 0), Quaternion.identity);
        match = true;
        FindCenterBlocksClicked();

        PlayBreakSound();
    }

    private void Match5BlockShape(int i)
    {
        Instantiate(destroyer, new Vector3((i % 6), (i / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[1]) % 6), ((i + shapeMatchIndexes[1]) / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[2]) % 6), ((i + shapeMatchIndexes[2]) / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[3]) % 6), ((i + shapeMatchIndexes[3]) / 6), 0), Quaternion.identity);
        Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[4]) % 6), ((i + shapeMatchIndexes[4]) / 6), 0), Quaternion.identity);
        match = true;
        FindCenterBlocksClicked();

        PlayBreakSound();
    }

    private void PlayBreakSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.volume = PlayerPrefs.GetFloat(gameSaverScript.sfxVolumeLevel);
            audioSource.PlayOneShot(blockDestroy);
        }
    }

    private void FindCenterBlocksClicked()
    {
        minXClicked = listBlocksClickedOnX.Min();
        maxXClicked = listBlocksClickedOnX.Max();
        minYClicked = listBlocksClickedOnY.Min();
        maxYClicked = listBlocksClickedOnY.Max();

        centerXYClicked = new Vector3((minXClicked + maxXClicked) / 2, (minYClicked + maxYClicked) / 2, 0);
        //print("Center XY Clicked: " + centerXYClicked);
    }

    private void DestroyParticle()
    {
        explosion = GameObject.FindGameObjectsWithTag (name);
        for(int i = 0 ; i < explosion.Length; i ++)
        {
        Destroy(explosion[i]);
        }
    }
    private void PopulateClickedLists(Collider2D hit)
    {
        if (hit)
        {
            blockClickedPoition = hit.transform.gameObject.transform.position;
            tagFirstBlockClicked = hit.transform.gameObject.tag;

            if (!listBlocksClickedOn.Contains(blockClickedPoition) && listTagsClicked.Count == 0)
            {
                listBlocksClickedOn.Add(blockClickedPoition);
                listTagsClicked.Add(tagFirstBlockClicked);
                listBlocksClickedOnX.Add(blockClickedPoition.x);
                listBlocksClickedOnY.Add(blockClickedPoition.y);
                pointRadius = 0.2f;
            }

            else if (!listBlocksClickedOn.Contains(blockClickedPoition) && listTagsClicked.Contains(tagFirstBlockClicked))
            {
                listBlocksClickedOn.Add(blockClickedPoition);
                listTagsClicked.Add(tagFirstBlockClicked);
                listBlocksClickedOnX.Add(blockClickedPoition.x);
                listBlocksClickedOnY.Add(blockClickedPoition.y);
            }

            //print("Block Clicked pos: " + blockClickedPoition.x + ", " + blockClickedPoition.y);
        }
    }
}
