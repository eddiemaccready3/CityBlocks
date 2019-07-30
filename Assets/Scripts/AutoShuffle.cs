using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class AutoShuffle : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] int qtyMaxBlocksOnScreen;
    [SerializeField] int yTopRow;
    [SerializeField] GameObject noMatches;

    private ShuffleBlocks shuffleBlocks;
    private SpinShuffleIcon spinShuffleIcon;
    private PauseGame pauseGame;
    private GravityUI gravityUI;

    private Vector2 instantiatePosition;

    public bool tooFewBlocks = true;
    private bool enoughBlocks = false;
    private bool confirmMatchesFound = false;

    private List<string> listOfShapes = new List<string>();
    private List<GameObject> allBlocksFoundList = new List<GameObject>();
    
    private GameObject[] allGameObjectsFoundArray;
    private GameObject groundUI;

    private float windowSpeed;

    private int picNumber = 0;

    private int [,] allBlocks = new int[15, 15];
    private int [,] blueBlocks = new int[15, 15];
    private int [,] redBlocks = new int[15, 15];
    private int [,] yellowBlocks = new int[15, 15];
    private int [,] greenBlocks = new int[15, 15];
    private int [,] purpleBlocks = new int[15, 15];
    private int [,] orangeBlocks = new int[15, 15];
    private int [,] pinkBlocks = new int[15, 15];
    private int [,] peachBlocks = new int[15, 15];
    private int [,] brownBlocks = new int[15, 15];

    private int [] checkForTArray = new int[]
    {

        0, 2,
        0, 1,   1, 1,
        0, 0,

        ////////////////////

        0, 1,   1, 1,   2, 1,
                1, 0,

        ////////////////////

                1, 2,
        0, 1,   1, 1,
                1, 0,

        ////////////////////

        
                1, 1,
        0, 0,   1, 0,   2, 0
        
    };

    private int [] checkForOArray = new int[]
    {
        
        0, 1,   1, 1,
        0, 0,   1, 0

    };

    private int [] checkForSArray = new int[]
    {
        
        
                1, 1,   2, 1,
        0, 0,   1, 0,

        ////////////////////

        0, 2,
        0, 1,   1, 1,
                1, 0

    };

    private int [] checkForZArray = new int[]
    {

        0, 1,   1, 1,
                1, 0,   2, 0,

        ////////////////////

                1, 2,
        0, 1,   1, 1,
        0, 0

    };

    private int [] checkForIArray = new int[]
    {

        0, 0,   1, 0,   2, 0,   3, 0,

        ////////////////////

        0, 3,
        0, 2,
        0, 1,
        0, 0

    };

    private int [] checkForJArray = new int[]
    {

                1, 2,
                1, 1,
        0, 0,   1, 0,

        ////////////////////

        0, 1,
        0, 0,   1, 0,   2, 0,

        ////////////////////

        0, 2,   1, 2,
        0, 1,
        0, 0,   

        ////////////////////

        0, 1,   1, 1,   2, 1,
                        2, 0

    };

    private int [] checkForLArray = new int[]
    {
        
        0, 2,
        0, 1,
        0, 0,   1, 0,

        ////////////////////

        0, 1,   1, 1,   2, 1,
        0, 0,

        ////////////////////

        0, 2,   1, 2,
                1, 1,
                1, 0,

        ////////////////////

                        2, 1,
        0, 0,   1, 0,   2, 0

    };

    private int [] checkForXArray = new int[]
    {
        
                1, 2,
        0, 1,   1, 1,   2, 1,
                1, 0
        
    };

    private int [] checkForVArray = new int[]
    {
        
        0, 1,
        0, 0,   1, 0,

        ////////////////////

        0, 1,   1, 1,
        0, 0,

        ////////////////////

        0, 1,   1, 1,
                1, 0,

        ////////////////////

                1, 1,
        0, 0,   1, 0

    };

    private int [] checkForArrowArray = new int[]
    {

                1, 1,
        0, 0,           2, 0,

        ////////////////////

        0, 2,
                1, 1,
        0, 0,

        ////////////////////

        0, 1,           2, 1,
                1, 0,

        ////////////////////

                1, 2,
        0, 1,
                1, 0

    };

    private int [] checkForDashArray = new int[]
    {

                1, 1,
        0, 0,

        ////////////////////

        0, 1,
                1, 0

    };

    private int [] checkForShortIArray = new int[]
    {

        0, 1,
        0, 0,

        ////////////////////

        0, 0,   1, 0

    };

    private int [] checkForMedIArray = new int[]
    {

        0, 2,
        0, 1,
        0, 0,

        ////////////////////

        0, 0,   1, 0,   2, 0

    };


    private bool checkForT = false;
    private bool checkForO = false;
    private bool checkForS = false;
    private bool checkForZ = false;
    private bool checkForI = false;
    private bool checkForJ = false;
    private bool checkForL = false;
    private bool checkForX = false;
    private bool checkForV = false;
    private bool checkForArrow = false;
    private bool checkForDash = false;
    private bool checkForShortI = false;
    private bool checkForMedI = false;

    private bool matchForT = false;
    private bool matchForO = false;
    private bool matchForS = false;
    private bool matchForZ = false;
    private bool matchForI = false;
    private bool matchForJ = false;
    private bool matchForL = false;
    private bool matchForX = false;
    private bool matchForV = false;
    private bool matchForArrow = false;
    private bool matchForDash = false;
    private bool matchForShortI = false;
    private bool matchForMedI = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        PopulateShapesList();
        shuffleBlocks = FindObjectOfType<ShuffleBlocks>();
        spinShuffleIcon = FindObjectOfType<SpinShuffleIcon>();
        pauseGame = FindObjectOfType<PauseGame>();
        //groundUI = GameObject.FindWithTag("GroundUI");
        //groundUI.GetComponent<Collider2D>().  .isActiveAndEnabled(false);
        shuffleBlocks.currentShuffleLoopDelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FindQtyAllBlocksOnScreen();

        if (allBlocksFoundList.Count < qtyMaxBlocksOnScreen)
        {
            tooFewBlocks = true;
            enoughBlocks = false;
        }

        if (allBlocksFoundList.Count == qtyMaxBlocksOnScreen)
        {
            enoughBlocks = true;
        }

        if (tooFewBlocks == true && enoughBlocks == true)
        {
            //print("tooFewBlocks & enoughBlocks are True");
            tooFewBlocks = false;
            //enoughBlocks = false;
            BuildBlocksArray();
            CheckScreenForShapes();
            IfNoMatchesAutoShuffle();

        }

        ClearArrays();
    }

    //{
    //    yield return new WaitForSeconds(timeElapsed);

    IEnumerator SetWindowSpeed(float speed)
    {
        yield return new WaitForSeconds(1f);
        gravityUI.gravityModifier = speed;
        gravityUI.isGroundedUI = false;
    }

    private void IfNoMatchesAutoShuffle()
    {
        if (matchForT == false &&
                        matchForO == false &&
                        matchForS == false &&
                        matchForZ == false &&
                        matchForI == false &&
                        matchForJ == false &&
                        matchForL == false &&
                        matchForX == false &&
                        matchForV == false &&
                        matchForArrow == false &&
                        matchForDash == false &&
                        matchForShortI == false &&
                        matchForMedI == false)
        {
            //ScreenCapture.CaptureScreenshot("MatchPic" + picNumber + ".png");
            //picNumber++;
            //print("No matches found!");
            pauseGame.pauseAuto = true;
            pauseGame.pauseManual = true;
            Vector2 instantiatePosition = new Vector2(2.5f, 5f);
            Instantiate(noMatches, instantiatePosition, Quaternion.identity);

            //groundUI.SetActive(true);

            //gravityUI = FindObjectOfType<GravityUI>();
            //groundUI = GameObject.FindWithTag("GroundUI");

            //gravityUI.gravityModifier = 5;
            //SetWindowSpeed(-5);
            //groundUI.SetActive(false);
            InvokeShuffleAndRotate();
            //Invoke("InvokeShuffleAndRotate", 0.5f);
        }

        else
        {
            //print("Matches found.");
            //confirmMatchesFound = true;
            tooFewBlocks = false;
            pauseGame.pauseAuto = false;
            pauseGame.pauseManual = false;
        }

        matchForT = false;
        matchForO = false;
        matchForS = false;
        matchForZ = false;
        matchForI = false;
        matchForJ = false;
        matchForL = false;
        matchForX = false;
        matchForV = false;
        matchForArrow = false;
        matchForDash = false;
        matchForShortI = false;
        matchForMedI = false;
    }

    private void InvokeShuffleAndRotate()
    {
        spinShuffleIcon.rotate = true;
        spinShuffleIcon.Rotate();
        shuffleBlocks.InvokeChangeBlockColors();
        //tooFewBlocks = true;
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

    private void FindQtyAllBlocksOnScreen()
    {
        allGameObjectsFoundArray = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        for (int i = 0; i < allGameObjectsFoundArray.Length; i++)
        {
            if (allGameObjectsFoundArray[i].layer == 12 && allGameObjectsFoundArray[i].transform.position.y <= yTopRow)
            {
                allBlocksFoundList.Add(allGameObjectsFoundArray[i]);
            }
        }
        Array.Clear(allGameObjectsFoundArray, 0, allGameObjectsFoundArray.Length);
    }

    private void BuildBlocksArray()
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 6; x++)
            {
                Vector2 checkPosition = new Vector2(x, y);
                Vector2 checkBoxSize = new Vector2(0.25f, 0.85f);
                //Vector2 currentBlock = gameObject.transform.position;
                //string currentBlockTag = gameObject.transform.tag;
                Collider2D[] hitColliders = Physics2D.OverlapBoxAll(checkPosition, checkBoxSize, 0, layerMask);


                if (hitColliders.Length > 0)
                {
                    //print("Block Tag: " + hitColliders[0].GetComponent<Collider2D>().tag);
                    //print("Block Position: " + hitColliders[0].GetComponent<Collider2D>().transform.position);
                    if (hitColliders[0].GetComponent<Collider2D>().tag == "Blue")
                    {
                        allBlocks[x, y] = 10;
                    }

                    else if (hitColliders[0].GetComponent<Collider2D>().tag == "Red")
                    {
                        allBlocks[x, y] = 11;
                    }

                    else if (hitColliders[0].GetComponent<Collider2D>().tag == "Yellow")
                    {
                        allBlocks[x, y] = 12;
                    }

                    else if (hitColliders[0].GetComponent<Collider2D>().tag == "Green")
                    {
                        allBlocks[x, y] = 13;
                    }

                    else if (hitColliders[0].GetComponent<Collider2D>().tag == "DarkGreen")
                    {
                        allBlocks[x, y] = 14;
                    }

                    else if (hitColliders[0].GetComponent<Collider2D>().tag == "DarkPink")
                    {
                        allBlocks[x, y] = 15;
                    }

                    else if (hitColliders[0].GetComponent<Collider2D>().tag == "Pink")
                    {
                        allBlocks[x, y] = 16;
                    }

                    else
                    {
                        allBlocks[x, y] = 99;
                    }

                }

                Array.Clear(hitColliders, 0, hitColliders.Length);
            }
        }
    }

    private void CheckScreenForShapes()
    {
        FindShapeIconsOnScreen();
        CheckBlocksForShapeMatches();
    }

    private void CheckBlocksForShapeMatches()
    {
        if (checkForO == true)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if(matchForO == false)
                    {
                        if (CheckBoard4Blocks0Rot(allBlocks, checkForOArray, x, y))
                        {
                            //print("Blocks in O Shape Found at: " + x + ", " + y);
                            matchForO = true;
                        }

                        else
                        {
                            matchForO = false;
                        }
                    }
                }
            }
        }
        if (checkForS == true)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if(matchForS == false)
                    {
                        if (CheckBoard4Blocks2Rot(allBlocks, checkForSArray, x, y))
                        {
                            //print("Blocks in S Shape Found at: " + x + ", " + y);
                            matchForS = true;
                        }

                        else
                        {
                            matchForS = false;
                        }
                    }
                }
            }
        }
        if (checkForZ == true)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if(matchForJ == false)
                    {
                        if (CheckBoard4Blocks2Rot(allBlocks, checkForZArray, x, y))
                        {
                            //print("Blocks in Z Shape Found at: " + x + ", " + y);
                            matchForZ = true;
                        }

                        else
                        {
                            matchForZ = false;
                        }
                    }
                }
            }
        }
        if (checkForI == true)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if(matchForI == false)
                    {
                        if (CheckBoard4Blocks2Rot(allBlocks, checkForIArray, x, y))
                        {
                            //print("Blocks in I Shape Found at: " + x + ", " + y);
                            matchForI = true;
                        }

                        else
                        {
                            matchForI = false;
                        }
                    }
                }
            }
        }
        if (checkForJ == true)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if(matchForJ == false)
                    {
                        if (CheckBoard4Blocks4Rot(allBlocks, checkForJArray, x, y))
                        {
                            //print("Blocks in J Shape Found at: " + x + ", " + y);
                            matchForJ = true;
                        }

                        else
                        {
                            matchForJ = false;
                        }
                    }
                }
            }
        }
        if (checkForL == true)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if(matchForL == false)
                    {
                        if (CheckBoard4Blocks4Rot(allBlocks, checkForLArray, x, y) == true)
                        {
                            //print("Blocks in L Shape Found at: " + x + ", " + y);
                            matchForL = true;
                        }

                        else
                        {
                            matchForL = false;
                        }
                    }
                }
            }
        }
        if (checkForX == true)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if(matchForX == false)
                    {
                        if (CheckBoard5Blocks0Rot(allBlocks, checkForXArray, x, y) == true)
                        {
                            //print("Blocks in X Shape Found at: " + x + ", " + y);
                            matchForX = true;
                        }

                        else
                        {
                            matchForX = false;
                        }
                    }
                }
            }
        }
        if (checkForV == true)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if(matchForV == false)
                    {
                        if (CheckBoard3Blocks4Rot(allBlocks, checkForVArray, x, y))
                        {
                            //print("Blocks in V Shape Found at: " + x + ", " + y);
                            matchForV = true;
                        }

                        else
                        {
                            matchForV = false;
                        }
                    }
                }
            }
        }
        if (checkForArrow == true)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    
                    if(matchForArrow == false)
                    {
                        if (CheckBoard3Blocks4Rot(allBlocks, checkForArrowArray, x, y))
                        {
                            //print("Blocks in Arrow Shape Found at: " + x + ", " + y);
                            matchForArrow = true;
                        }

                        else
                        {
                            matchForArrow = false;
                        }
                    }
                }
            }
        }
        if (checkForDash == true)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if(matchForDash == false)
                    {
                        if (CheckBoard2Blocks2Rot(allBlocks, checkForDashArray, x, y) == true)
                        {
                            //print("Blocks in Dash Shape found at: " + x + ", " + y);
                            matchForDash = true;
                        }

                        else
                        {
                            matchForDash = false;
                        }
                    }
                }
            }
        }
        if (checkForShortI == true)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if(matchForShortI == false)
                    {
                        if (CheckBoard2Blocks2Rot(allBlocks, checkForShortIArray, x, y))
                        {
                            //print("Blocks in Short I Shape Found at: " + x + ", " + y);
                            matchForShortI = true;
                        }

                        else
                        {
                            matchForShortI = false;
                        }
                    }
                }
            }
        }
        if (checkForMedI == true)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if(matchForMedI == false)
                    {
                        if (CheckBoard3Blocks2Rot(allBlocks, checkForMedIArray, x, y))
                        {
                            //print("Blocks in Medium I Shape Found at: " + x + ", " + y);
                            matchForMedI = true;
                        }

                        else
                        {
                            matchForMedI = false;
                        }
                    }
                }
            }
        }
    }

    private void FindShapeIconsOnScreen()
    {
        for (int s = 0; s < listOfShapes.Count; s++)
        {
            if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 0)
            {
                checkForX = true;
                //print("Check for X true.");
            }
            else if (GameObject.FindWithTag(listOfShapes[s]) == null && s == 0)
            {
                checkForX = false;
                //print("Check for X false.");
            }

            if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 1)
            {
                checkForT = true;
                //print("Check for T true.");
            }
            else if (GameObject.FindWithTag(listOfShapes[s]) == null && s == 1)
            {
                checkForT = false;
                //print("Check for T false.");
            }

            if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 2)
            {
                checkForS = true;
                //print("Check for S true.");
            }
            else if (GameObject.FindWithTag(listOfShapes[s]) == null && s == 2)
            {
                checkForS = false;
                //print("Check for S false.");
            }

            if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 3)
            {
                checkForZ = true;
                //print("Check for Z true.");
            }
            else if (GameObject.FindWithTag(listOfShapes[s]) == null && s == 3)
            {
                checkForZ = false;
                //print("Check for Z false.");
            }

            if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 4)
            {
                checkForL = true;
                //print("Check for L true.");
            }
            else if (GameObject.FindWithTag(listOfShapes[s]) == null && s == 4)
            {
                checkForL = false;
                //print("Check for L false.");
            }

            if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 5)
            {
                checkForJ = true;
                //print("Check for J true.");
            }
            else if (GameObject.FindWithTag(listOfShapes[s]) == null && s == 5)
            {
                checkForJ = false;
                //print("Check for J false.");
            }

            if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 6)
            {
                checkForI = true;
                //print("Check for I true.");
            }
            else if (GameObject.FindWithTag(listOfShapes[s]) == null && s == 6)
            {
                checkForI = false;
                //print("Check for I false.");
            }

            if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 7)
            {
                checkForO = true;
                //print("Check for O true.");
            }
            else if (GameObject.FindWithTag(listOfShapes[s]) == null && s == 7)
            {
                checkForO = false;
                //print("Check for O false.");
            }

            if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 8)
            {
                checkForMedI = true;
                //print("Check for Medium I true.");
            }
            else if (GameObject.FindWithTag(listOfShapes[s]) == null && s == 8)
            {
                checkForMedI = false;
                //print("Check for Medium I false.");
            }

            if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 9)
            {
                checkForArrow = true;
                //print("Check for Arrow true.");
            }
            else if (GameObject.FindWithTag(listOfShapes[s]) == null && s == 9)
            {
                checkForArrow = false;
                //print("Check for Arrow false.");
            }

            if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 10)
            {
                checkForV = true;
                //print("Check for V true.");
            }
            else if (GameObject.FindWithTag(listOfShapes[s]) == null && s == 10)
            {
                checkForV = false;
                //print("Check for V false.");
            }

            if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 11)
            {
                checkForShortI = true;
                //print("Check for Short I true.");
            }
            else if (GameObject.FindWithTag(listOfShapes[s]) == null && s == 11)
            {
                checkForShortI = false;
                //print("Check for Short I false.");
            }

            if (GameObject.FindWithTag(listOfShapes[s]) != null && s == 12)
            {
                checkForDash = true;
                //print("Check for Dash true.");
            }
            else if (GameObject.FindWithTag(listOfShapes[s]) == null && s == 12)
            {
                checkForDash = false;
                //print("Check for Dash false.");
            }
        }
    }


    private bool CheckBoard2Blocks2Rot(int [,] board, int [] shape, int xCheck, int yCheck)
    {
        if
        (
            board[shape[0] + xCheck, shape[1] + yCheck] != 0 &&
            board[shape[2] + xCheck, shape[3] + yCheck] != 0 &&

            board[shape[4] + xCheck, shape[5] + yCheck] != 0 &&
            board[shape[6] + xCheck, shape[7] + yCheck] != 0 &&

            ((board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[2] + xCheck, shape[3] + yCheck]) ||

            (board[shape[4] + xCheck, shape[5] + yCheck] == board[shape[6] + xCheck, shape[7] + yCheck]))
        )
        {
            //print("True; Board coordinates to check: " + shape[0] + "+ " + xCheck + ", " + shape[1] + "+ " + yCheck);
            //print("True; Rot1, First Board check: " + board[shape[0] + xCheck, shape[1] + yCheck]);
            //print("True; Board coordinates to check: " + shape[2] + "+ " + xCheck + ", " + shape[3] + "+ " + yCheck);
            //print("True; Rot1, Second Board check: " + board[shape[2] + xCheck, shape[3] + yCheck]);

            //print("True; Board coordinates to check: " + shape[4] + "+ " + xCheck + ", " + shape[5] + "+ " + yCheck);
            //print("True; Rot2, First Board check: " + board[shape[4] + xCheck, shape[5] + yCheck]);
            //print("True; Board coordinates to check: " + shape[6] + "+ " + xCheck + ", " + shape[7] + "+ " + yCheck);
            //print("True; Rot2, Second Board check: " + board[shape[6] + xCheck, shape[7] + yCheck]);

            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckBoard3Blocks2Rot(int [,] board, int [] shape, int xCheck, int yCheck)
    {
        if
        (
            board[shape[0] + xCheck, shape[1] + yCheck] != 0 &&
            board[shape[2] + xCheck, shape[3] + yCheck] != 0 &&
            board[shape[4] + xCheck, shape[5] + yCheck] != 0 &&

            board[shape[6] + xCheck, shape[7] + yCheck] != 0 &&
            board[shape[8] + xCheck, shape[9] + yCheck] != 0 &&
            board[shape[10] + xCheck, shape[11] + yCheck] != 0 &&

            ((board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[2] + xCheck, shape[3] + yCheck] &&
            board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[4] + xCheck, shape[5] + yCheck]) ||

            (board[shape[6] + xCheck, shape[7] + yCheck] == board[shape[8] + xCheck, shape[9] + yCheck] &&
            board[shape[6] + xCheck, shape[7] + yCheck] == board[shape[10] + xCheck, shape[11] + yCheck]))
        )
        {   
            //print("True; Board coordinates to check: " + shape[0] + "+ " + xCheck + ", " + shape[1] + "+ " + yCheck);
            //print("True; Rot1, First Board check: " + board[shape[0] + xCheck, shape[1] + yCheck]);
            //print("True; Board coordinates to check: " + shape[2] + "+ " + xCheck + ", " + shape[3] + "+ " + yCheck);
            //print("True; Rot1, Second Board check: " + board[shape[2] + xCheck, shape[3] + yCheck]);
            //print("True; Board coordinates to check: " + shape[4] + "+ " + xCheck + ", " + shape[5] + "+ " + yCheck);
            //print("True; Rot1, Third Board check: " + board[shape[4] + xCheck, shape[5] + yCheck]);
            
            //print("True; Board coordinates to check: " + shape[6] + "+ " + xCheck + ", " + shape[7] + "+ " + yCheck);
            //print("True; Rot2, First Board check: " + board[shape[6] + xCheck, shape[7] + yCheck]);
            //print("True; Board coordinates to check: " + shape[8] + "+ " + xCheck + ", " + shape[9] + "+ " + yCheck);
            //print("True; Rot2, Second Board check: " + board[shape[8] + xCheck, shape[9] + yCheck]);
            //print("True; Board coordinates to check: " + shape[10] + "+ " + xCheck + ", " + shape[11] + "+ " + yCheck);
            //print("True; Rot2, Third Board check: " + board[shape[10] + xCheck, shape[11] + yCheck]);
            
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckBoard3Blocks4Rot(int [,] board, int [] shape, int xCheck, int yCheck)
    {
        if
        (
            board[shape[0] + xCheck, shape[1] + yCheck] != 0 &&
            board[shape[2] + xCheck, shape[3] + yCheck] != 0 &&
            board[shape[4] + xCheck, shape[5] + yCheck] != 0 &&

            board[shape[6] + xCheck, shape[7] + yCheck] != 0 &&
            board[shape[8] + xCheck, shape[9] + yCheck] != 0 &&
            board[shape[10] + xCheck, shape[11] + yCheck] != 0 &&

            board[shape[12] + xCheck, shape[13] + yCheck] != 0 &&
            board[shape[14] + xCheck, shape[15] + yCheck] != 0 &&
            board[shape[16] + xCheck, shape[17] + yCheck] != 0 &&

            board[shape[18] + xCheck, shape[19] + yCheck] != 0 &&
            board[shape[20] + xCheck, shape[21] + yCheck] != 0 &&
            board[shape[22] + xCheck, shape[23] + yCheck] != 0 &&

            ((board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[2] + xCheck, shape[3] + yCheck] &&
            board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[4] + xCheck, shape[5] + yCheck]) ||

            (board[shape[6] + xCheck, shape[7] + yCheck] == board[shape[8] + xCheck, shape[9] + yCheck] &&
            board[shape[6] + xCheck, shape[7] + yCheck] == board[shape[10] + xCheck, shape[11] + yCheck]) ||

            (board[shape[12] + xCheck, shape[13] + yCheck] == board[shape[14] + xCheck, shape[15] + yCheck] &&
            board[shape[12] + xCheck, shape[13] + yCheck] == board[shape[16] + xCheck, shape[17] + yCheck]) ||

            (board[shape[18] + xCheck, shape[19] + yCheck] == board[shape[20] + xCheck, shape[21] + yCheck] &&
            board[shape[18] + xCheck, shape[19] + yCheck] == board[shape[22] + xCheck, shape[23] + yCheck]))
        )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckBoard4Blocks0Rot(int [,] board, int [] shape, int xCheck, int yCheck)
    {
        if
        (
            board[shape[0] + xCheck, shape[1] + yCheck] != 0 &&
            board[shape[2] + xCheck, shape[3] + yCheck] != 0 &&
            board[shape[4] + xCheck, shape[5] + yCheck] != 0 &&
            board[shape[6] + xCheck, shape[7] + yCheck] != 0 &&

            ((board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[2] + xCheck, shape[3] + yCheck]) &&
            (board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[4] + xCheck, shape[5] + yCheck]) &&
            (board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[6] + xCheck, shape[7] + yCheck]))
        )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckBoard4Blocks2Rot(int [,] board, int [] shape, int xCheck, int yCheck)
    {
        if
        (
            board[shape[0] + xCheck, shape[1] + yCheck] != 0 &&
            board[shape[2] + xCheck, shape[3] + yCheck] != 0 &&
            board[shape[4] + xCheck, shape[5] + yCheck] != 0 &&
            board[shape[6] + xCheck, shape[7] + yCheck] != 0 &&

            board[shape[8] + xCheck, shape[9] + yCheck] != 0 &&
            board[shape[10] + xCheck, shape[11] + yCheck] != 0 &&
            board[shape[12] + xCheck, shape[13] + yCheck] != 0 &&
            board[shape[14] + xCheck, shape[15] + yCheck] != 0 &&

            ((board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[2] + xCheck, shape[3] + yCheck] &&
            board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[4] + xCheck, shape[5] + yCheck] &&
            board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[6] + xCheck, shape[7] + yCheck]) ||

            (board[shape[8] + xCheck, shape[9] + yCheck] == board[shape[10] + xCheck, shape[11] + yCheck] &&
            board[shape[8] + xCheck, shape[9] + yCheck] == board[shape[12] + xCheck, shape[13] + yCheck] &&
            board[shape[8] + xCheck, shape[9] + yCheck] == board[shape[14] + xCheck, shape[15] + yCheck]))
        )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckBoard4Blocks4Rot(int [,] board, int [] shape, int xCheck, int yCheck)
    {
        if
        (
            board[shape[0] + xCheck, shape[1] + yCheck] != 0 &&
            board[shape[2] + xCheck, shape[3] + yCheck] != 0 &&
            board[shape[4] + xCheck, shape[5] + yCheck] != 0 &&
            board[shape[6] + xCheck, shape[7] + yCheck] != 0 &&

            board[shape[8] + xCheck, shape[9] + yCheck] != 0 &&
            board[shape[10] + xCheck, shape[11] + yCheck] != 0 &&
            board[shape[12] + xCheck, shape[13] + yCheck] != 0 &&
            board[shape[14] + xCheck, shape[15] + yCheck] != 0 &&

            board[shape[16] + xCheck, shape[17] + yCheck] != 0 &&
            board[shape[18] + xCheck, shape[19] + yCheck] != 0 &&
            board[shape[20] + xCheck, shape[21] + yCheck] != 0 &&
            board[shape[22] + xCheck, shape[23] + yCheck] != 0 &&

            board[shape[24] + xCheck, shape[25] + yCheck] != 0 &&
            board[shape[26] + xCheck, shape[27] + yCheck] != 0 &&
            board[shape[28] + xCheck, shape[29] + yCheck] != 0 &&
            board[shape[30] + xCheck, shape[31] + yCheck] != 0 &&

            ((board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[2] + xCheck, shape[3] + yCheck] &&
            board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[4] + xCheck, shape[5] + yCheck] &&
            board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[6] + xCheck, shape[7] + yCheck]) ||

            (board[shape[8] + xCheck, shape[9] + yCheck] == board[shape[10] + xCheck, shape[11] + yCheck] &&
            board[shape[8] + xCheck, shape[9] + yCheck] == board[shape[12] + xCheck, shape[13] + yCheck] &&
            board[shape[8] + xCheck, shape[9] + yCheck] == board[shape[14] + xCheck, shape[15] + yCheck]) ||

            (board[shape[16] + xCheck, shape[17] + yCheck] == board[shape[18] + xCheck, shape[19] + yCheck] &&
            board[shape[16] + xCheck, shape[17] + yCheck] == board[shape[20] + xCheck, shape[21] + yCheck] &&
            board[shape[16] + xCheck, shape[17] + yCheck] == board[shape[22] + xCheck, shape[23] + yCheck]) ||

            (board[shape[24] + xCheck, shape[25] + yCheck] == board[shape[26] + xCheck, shape[27] + yCheck] &&
            board[shape[24] + xCheck, shape[25] + yCheck] == board[shape[28] + xCheck, shape[29] + yCheck] &&
            board[shape[24] + xCheck, shape[25] + yCheck] == board[shape[30] + xCheck, shape[31] + yCheck]))
        )
        {
            //print("True; Board coordinates to check: " + shape[0] + "+ " + xCheck + ", " + shape[1] + "+ " + yCheck);
            //print("True; Rot1, First Board check: " + board[shape[0] + xCheck, shape[1] + yCheck]);
            //print("True; Board coordinates to check: " + shape[2] + "+ " + xCheck + ", " + shape[3] + "+ " + yCheck);
            //print("True; Rot1, Second Board check: " + board[shape[2] + xCheck, shape[3] + yCheck]);
            //print("True; Board coordinates to check: " + shape[4] + "+ " + xCheck + ", " + shape[5] + "+ " + yCheck);
            //print("True; Rot1, First Board check: " + board[shape[4] + xCheck, shape[5] + yCheck]);
            //print("True; Board coordinates to check: " + shape[6] + "+ " + xCheck + ", " + shape[7] + "+ " + yCheck);
            //print("True; Rot1, Second Board check: " + board[shape[6] + xCheck, shape[7] + yCheck]);

            //print("True; Board coordinates to check: " + shape[8] + "+ " + xCheck + ", " + shape[9] + "+ " + yCheck);
            //print("True; Rot2, First Board check: " + board[shape[8] + xCheck, shape[9] + yCheck]);
            //print("True; Board coordinates to check: " + shape[10] + "+ " + xCheck + ", " + shape[11] + "+ " + yCheck);
            //print("True; Rot2, Second Board check: " + board[shape[10] + xCheck, shape[11] + yCheck]);
            //print("True; Board coordinates to check: " + shape[12] + "+ " + xCheck + ", " + shape[13] + "+ " + yCheck);
            //print("True; Rot2, First Board check: " + board[shape[12] + xCheck, shape[13] + yCheck]);
            //print("True; Board coordinates to check: " + shape[14] + "+ " + xCheck + ", " + shape[15] + "+ " + yCheck);
            //print("True; Rot2, Second Board check: " + board[shape[14] + xCheck, shape[15] + yCheck]);

            //print("True; Board coordinates to check: " + shape[16] + "+ " + xCheck + ", " + shape[17] + "+ " + yCheck);
            //print("True; Rot3, First Board check: " + board[shape[16] + xCheck, shape[17] + yCheck]);
            //print("True; Board coordinates to check: " + shape[18] + "+ " + xCheck + ", " + shape[19] + "+ " + yCheck);
            //print("True; Rot3, Second Board check: " + board[shape[18] + xCheck, shape[19] + yCheck]);
            //print("True; Board coordinates to check: " + shape[20] + "+ " + xCheck + ", " + shape[21] + "+ " + yCheck);
            //print("True; Rot3, First Board check: " + board[shape[20] + xCheck, shape[21] + yCheck]);
            //print("True; Board coordinates to check: " + shape[22] + "+ " + xCheck + ", " + shape[23] + "+ " + yCheck);
            //print("True; Rot3, Second Board check: " + board[shape[22] + xCheck, shape[23] + yCheck]);

            //print("True; Board coordinates to check: " + shape[24] + "+ " + xCheck + ", " + shape[25] + "+ " + yCheck);
            //print("True; Rot4, First Board check: " + board[shape[24] + xCheck, shape[25] + yCheck]);
            //print("True; Board coordinates to check: " + shape[26] + "+ " + xCheck + ", " + shape[27] + "+ " + yCheck);
            //print("True; Rot4, Second Board check: " + board[shape[26] + xCheck, shape[27] + yCheck]);
            //print("True; Board coordinates to check: " + shape[28] + "+ " + xCheck + ", " + shape[29] + "+ " + yCheck);
            //print("True; Rot4, First Board check: " + board[shape[28] + xCheck, shape[29] + yCheck]);
            //print("True; Board coordinates to check: " + shape[30] + "+ " + xCheck + ", " + shape[31] + "+ " + yCheck);
            //print("True; Rot4, Second Board check: " + board[shape[30] + xCheck, shape[31] + yCheck]);
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckBoard5Blocks0Rot(int [,] board, int [] shape, int xCheck, int yCheck)
    {
        if
        (
            board[shape[0] + xCheck, shape[1] + yCheck] != 0 &&
            board[shape[2] + xCheck, shape[3] + yCheck] != 0 &&
            board[shape[4] + xCheck, shape[5] + yCheck] != 0 &&
            board[shape[6] + xCheck, shape[7] + yCheck] != 0 &&
            board[shape[8] + xCheck, shape[9] + yCheck] != 0 &&

            ((board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[2] + xCheck, shape[3] + yCheck] &&
            board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[4] + xCheck, shape[5] + yCheck] &&
            board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[6] + xCheck, shape[7] + yCheck] &&
            board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[8] + xCheck, shape[9] + yCheck]))
        )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ClearArrays()
    {
        allBlocksFoundList.Clear();

        Array.Clear(allBlocks, 0, allBlocks.Length);
        Array.Clear(blueBlocks, 0, blueBlocks.Length);
        Array.Clear(redBlocks, 0, redBlocks.Length);
        Array.Clear(yellowBlocks, 0, yellowBlocks.Length);
        Array.Clear(greenBlocks, 0, greenBlocks.Length);
        Array.Clear(brownBlocks, 0, brownBlocks.Length);
        Array.Clear(purpleBlocks, 0, purpleBlocks.Length);
        Array.Clear(pinkBlocks, 0, pinkBlocks.Length);
        Array.Clear(peachBlocks, 0, peachBlocks.Length);
        Array.Clear(orangeBlocks, 0, orangeBlocks.Length);
    }
}
