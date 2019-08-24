using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System;
using System.Linq;

public class AutoShuffle : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] int qtyMaxBlocksOnScreen;
    [SerializeField] int yTopRow;
    [SerializeField] GameObject noMatches;
    [SerializeField] GameObject dot;

    private ShuffleBlocks shuffleBlocks;
    private PauseGame pauseGame;

    private Vector2 instantiatePosition;

    public bool tooFewBlocks = true;
    private bool enoughBlocks = false;

    private List<string> listOfShapes = new List<string>();
    private List<GameObject> allBlocksFoundList = new List<GameObject>();

    private GameObject[] allGameObjectsFoundArray;

    private int[,] allBlocks = new int[15, 15];
    private int[,] blueBlocks = new int[15, 15];
    private int[,] redBlocks = new int[15, 15];
    private int[,] yellowBlocks = new int[15, 15];
    private int[,] greenBlocks = new int[15, 15];
    private int[,] purpleBlocks = new int[15, 15];
    private int[,] orangeBlocks = new int[15, 15];
    private int[,] pinkBlocks = new int[15, 15];
    private int[,] peachBlocks = new int[15, 15];
    private int[,] brownBlocks = new int[15, 15];

    //Create arrays for each shape in every rotation
    private int[] checkForTArray = new int[]
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

    private int[] checkForOArray = new int[]
    {

        0, 1,   1, 1,
        0, 0,   1, 0

    };

    private int[] checkForSArray = new int[]
    {


                1, 1,   2, 1,
        0, 0,   1, 0,

        ////////////////////

        0, 2,
        0, 1,   1, 1,
                1, 0

    };

    private int[] checkForZArray = new int[]
    {

        0, 1,   1, 1,
                1, 0,   2, 0,

        ////////////////////

                1, 2,
        0, 1,   1, 1,
        0, 0

    };

    private int[] checkForIArray = new int[]
    {

        0, 0,   1, 0,   2, 0,   3, 0,

        ////////////////////

        0, 3,
        0, 2,
        0, 1,
        0, 0

    };

    private int[] checkForJArray = new int[]
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

    private int[] checkForLArray = new int[]
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

    private int[] checkForXArray = new int[]
    {

                1, 2,
        0, 1,   1, 1,   2, 1,
                1, 0

    };

    private int[] checkForVArray = new int[]
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

    private int[] checkForArrowArray = new int[]
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

    private int[] checkForDashArray = new int[]
    {

                1, 1,
        0, 0,

        ////////////////////

        0, 1,
                1, 0

    };

    private int[] checkForShortIArray = new int[]
    {

        0, 1,
        0, 0,

        ////////////////////

        0, 0,   1, 0

    };

    private int[] checkForMedIArray = new int[]
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

        //Assign game objects to variables
        shuffleBlocks = FindObjectOfType<ShuffleBlocks>();
        pauseGame = FindObjectOfType<PauseGame>();
        shuffleBlocks.currentShuffleLoopDelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FindQtyAllBlocksOnScreen();

        

        //Check if all blocks have fallen in place before checking for matches
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
            tooFewBlocks = false;
            CheckScreenForShapes();
            IfNoMatchesAutoShuffle();
        }

        ClearArrays();
    }

    private void IfNoMatchesAutoShuffle()
    {
        if (    matchForT == false &&
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
            pauseGame.pauseAuto = true;
            pauseGame.pauseManual = true;
            Vector2 instantiatePosition = new Vector2(2.5f, 5f);
            Instantiate(noMatches, instantiatePosition, Quaternion.identity);

            InvokeShuffleAndRotate();
        }

        else
        {
            tooFewBlocks = false;
            pauseGame.pauseAuto = false;
            pauseGame.pauseManual = false;
        }

        //Reset all matches to false
        SetMatchBoolsToFalse();
    }

    private void SetMatchBoolsToFalse()
    {
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

    private void SetCheckForBoolsToFalse()
    {
        checkForT = false;
        checkForO = false;
        checkForS = false;
        checkForZ = false;
        checkForI = false;
        checkForJ = false;
        checkForL = false;
        checkForX = false;
        checkForV = false;
        checkForArrow = false;
        checkForDash = false;
        checkForShortI = false;
        checkForMedI = false;
    }

    private void InvokeShuffleAndRotate()
    {
        shuffleBlocks.InvokeChangeBlockColors();
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
            //Only add game objects on the Blocks Layer
            if (allGameObjectsFoundArray[i].layer == 12 && allGameObjectsFoundArray[i].transform.position.y <= yTopRow)
            {
                allBlocksFoundList.Add(allGameObjectsFoundArray[i]);
            }
        }

        //Clear array to reset for next time
        Array.Clear(allGameObjectsFoundArray, 0, allGameObjectsFoundArray.Length);
    }

    private void BuildBlocksArray()
    {
        //Iterate through the blocks on the screen row by row, and populate an array
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 6; x++)
            {
                //Use OverlapBox Collider check to create an array of all blocks found on screen
                Vector2 checkPosition = new Vector2(x, y);
                Vector2 checkBoxSize = new Vector2(0.25f, 0.25f);
                Collider2D hitColliders = Physics2D.OverlapBox(checkPosition, checkBoxSize, 0, layerMask);

                //Assign unique number to each color of block and populate array
                if (hitColliders != null)
                {
                    if (hitColliders.GetComponent<Collider2D>().tag == "Blue")
                    {
                        allBlocks[x, y] = 10;
                    }

                    else if (hitColliders.GetComponent<Collider2D>().tag == "Red")
                    {
                        allBlocks[x, y] = 11;
                    }

                    else if (hitColliders.GetComponent<Collider2D>().tag == "Yellow")
                    {
                        allBlocks[x, y] = 12;
                    }

                    else if (hitColliders.GetComponent<Collider2D>().tag == "Green")
                    {
                        allBlocks[x, y] = 13;
                    }

                    else if (hitColliders.GetComponent<Collider2D>().tag == "DarkGreen")
                    {
                        allBlocks[x, y] = 14;
                    }

                    else if (hitColliders.GetComponent<Collider2D>().tag == "DarkPink")
                    {
                        allBlocks[x, y] = 15;
                    }

                    else if (hitColliders.GetComponent<Collider2D>().tag == "Pink")
                    {
                        allBlocks[x, y] = 16;
                    }

                    else
                    {
                        allBlocks[x, y] = 99;
                    }

                }

                else if (hitColliders == null)
                {
                    allBlocks[x, y] = 99;
                }

                hitColliders = null;
            }
        }
    }

    private void CheckScreenForShapes()
    {
        //Determine which shapes to match against are currently on the screen
        FindShapeIconsOnScreen();

        //Check if any matches can be made from current blocks on screen
        CheckBlocksForShapeMatches();
    }

    private bool CheckByShape(bool shapeCheck, bool shapeMatch, int[] arrayToCheckFor, Func<int[,], int[], int, int, bool> shapeSizeAndRot)
    {
        if (shapeCheck == true)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    if (shapeMatch == false)
                    {
                        if (shapeSizeAndRot(allBlocks, arrayToCheckFor, x, y))
                        {
                            shapeMatch = true;
                        }

                        else
                        {
                            shapeMatch = false;
                        }
                    }
                }
            }
        }

        return shapeMatch;
    }

    private void CheckBlocksForShapeMatches()
    {
        BuildBlocksArray();
        
        //Set all Match bools to false
        SetMatchBoolsToFalse();

        //Iterate through all blocks on screen to see if shapes on screen can be matched in any rotation
        matchForO = CheckByShape(checkForO, matchForO, checkForOArray, CheckBoard4Blocks0Rot);
        matchForS = CheckByShape(checkForS, matchForS, checkForSArray, CheckBoard4Blocks2Rot);
        matchForZ = CheckByShape(checkForZ, matchForZ, checkForZArray, CheckBoard4Blocks2Rot);
        matchForI = CheckByShape(checkForI, matchForI, checkForIArray, CheckBoard4Blocks2Rot);
        matchForJ = CheckByShape(checkForJ, matchForJ, checkForJArray, CheckBoard4Blocks4Rot);
        matchForL = CheckByShape(checkForL, matchForL, checkForLArray, CheckBoard4Blocks4Rot);
        matchForX = CheckByShape(checkForX, matchForX, checkForXArray, CheckBoard5Blocks0Rot);
        matchForT = CheckByShape(checkForT, matchForT, checkForTArray, CheckBoard4Blocks4Rot);
        matchForV = CheckByShape(checkForV, matchForV, checkForVArray, CheckBoard3Blocks4Rot);
        matchForArrow = CheckByShape(checkForArrow, matchForArrow, checkForArrowArray, CheckBoard3Blocks4Rot);
        matchForDash = CheckByShape(checkForDash, matchForDash, checkForDashArray, CheckBoard2Blocks2Rot);
        matchForShortI = CheckByShape(checkForShortI, matchForShortI, checkForShortIArray, CheckBoard2Blocks2Rot);
        matchForMedI = CheckByShape(checkForMedI, matchForMedI, checkForMedIArray, CheckBoard3Blocks2Rot);
    }

    private bool SetCheckBool(int listIndex, int indexToVerify, bool shapeToSet)
    {
        if (GameObject.FindWithTag(listOfShapes[listIndex]) != null && listIndex == indexToVerify)
        {
            shapeToSet = true;
        }
        else if (GameObject.FindWithTag(listOfShapes[listIndex]) == null && listIndex == indexToVerify)
        {
            shapeToSet = false;
        }

        return shapeToSet;
    }

    private void FindShapeIconsOnScreen()
    {
        SetCheckForBoolsToFalse();
        
        for (int s = 0; s < listOfShapes.Count; s++)
        {
            checkForX = SetCheckBool(s, 0, checkForX);
            checkForT = SetCheckBool(s, 1, checkForT);
            checkForS = SetCheckBool(s, 2, checkForS);
            checkForZ = SetCheckBool(s, 3, checkForZ);
            checkForL = SetCheckBool(s, 4, checkForL);
            checkForJ = SetCheckBool(s, 5, checkForJ);
            checkForI = SetCheckBool(s, 6, checkForI);
            checkForO = SetCheckBool(s, 7, checkForO);
            checkForMedI = SetCheckBool(s, 8, checkForMedI);
            checkForArrow = SetCheckBool(s, 9, checkForArrow);
            checkForV = SetCheckBool(s, 10, checkForV);
            checkForShortI = SetCheckBool(s, 11, checkForShortI);
            checkForDash = SetCheckBool(s, 12, checkForDash);
        }
    }

    //Methods to compare arrays for each shape to blocks on screen
    //separated by qty of blocks per shape, and possible rotations of each shape
    private bool CheckBoard2Blocks2Rot(int[,] board, int[] shape, int xCheck, int yCheck)
    {
        if
        (
            board[shape[0] + xCheck, shape[1] + yCheck] != 99 &&
            board[shape[2] + xCheck, shape[3] + yCheck] != 99 &&

            board[shape[4] + xCheck, shape[5] + yCheck] != 99 &&
            board[shape[6] + xCheck, shape[7] + yCheck] != 99 &&

            board[shape[0] + xCheck, shape[1] + yCheck] != 0 &&
            board[shape[2] + xCheck, shape[3] + yCheck] != 0 &&

            board[shape[4] + xCheck, shape[5] + yCheck] != 0 &&
            board[shape[6] + xCheck, shape[7] + yCheck] != 0 &&


            ((board[shape[0] + xCheck, shape[1] + yCheck] == board[shape[2] + xCheck, shape[3] + yCheck]) ||
            (board[shape[4] + xCheck, shape[5] + yCheck] == board[shape[6] + xCheck, shape[7] + yCheck]))
        )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckBoard3Blocks2Rot(int[,] board, int[] shape, int xCheck, int yCheck)
    {
        if
        (
            
        
            board[shape[0] + xCheck, shape[1] + yCheck] != 99 &&
            board[shape[2] + xCheck, shape[3] + yCheck] != 99 &&
            board[shape[4] + xCheck, shape[5] + yCheck] != 99 &&

            board[shape[6] + xCheck, shape[7] + yCheck] != 99 &&
            board[shape[8] + xCheck, shape[9] + yCheck] != 99 &&
            board[shape[10] + xCheck, shape[11] + yCheck] != 99 &&

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
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckBoard3Blocks4Rot(int[,] board, int[] shape, int xCheck, int yCheck)
    {
        if
        (
            board[shape[0] + xCheck, shape[1] + yCheck] != 99 &&
            board[shape[2] + xCheck, shape[3] + yCheck] != 99 &&
            board[shape[4] + xCheck, shape[5] + yCheck] != 99 &&

            board[shape[6] + xCheck, shape[7] + yCheck] != 99 &&
            board[shape[8] + xCheck, shape[9] + yCheck] != 99 &&
            board[shape[10] + xCheck, shape[11] + yCheck] != 99 &&

            board[shape[12] + xCheck, shape[13] + yCheck] != 99 &&
            board[shape[14] + xCheck, shape[15] + yCheck] != 99 &&
            board[shape[16] + xCheck, shape[17] + yCheck] != 99 &&

            board[shape[18] + xCheck, shape[19] + yCheck] != 99 &&
            board[shape[20] + xCheck, shape[21] + yCheck] != 99 &&
            board[shape[22] + xCheck, shape[23] + yCheck] != 99 &&

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

    private bool CheckBoard4Blocks0Rot(int[,] board, int[] shape, int xCheck, int yCheck)
    {
        if
        (
            board[shape[0] + xCheck, shape[1] + yCheck] != 99 &&
            board[shape[2] + xCheck, shape[3] + yCheck] != 99 &&
            board[shape[4] + xCheck, shape[5] + yCheck] != 99 &&
            board[shape[6] + xCheck, shape[7] + yCheck] != 99 &&

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

    private bool CheckBoard4Blocks2Rot(int[,] board, int[] shape, int xCheck, int yCheck)
    {
        if
        (
            board[shape[0] + xCheck, shape[1] + yCheck] != 99 &&
            board[shape[2] + xCheck, shape[3] + yCheck] != 99 &&
            board[shape[4] + xCheck, shape[5] + yCheck] != 99 &&
            board[shape[6] + xCheck, shape[7] + yCheck] != 99 &&

            board[shape[8] + xCheck, shape[9] + yCheck] != 99 &&
            board[shape[10] + xCheck, shape[11] + yCheck] != 99 &&
            board[shape[12] + xCheck, shape[13] + yCheck] != 99 &&
            board[shape[14] + xCheck, shape[15] + yCheck] != 99 &&

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

    private bool CheckBoard4Blocks4Rot(int[,] board, int[] shape, int xCheck, int yCheck)
    {
        if
        (
            board[shape[0] + xCheck, shape[1] + yCheck] != 99 &&
            board[shape[2] + xCheck, shape[3] + yCheck] != 99 &&
            board[shape[4] + xCheck, shape[5] + yCheck] != 99 &&
            board[shape[6] + xCheck, shape[7] + yCheck] != 99 &&

            board[shape[8] + xCheck, shape[9] + yCheck] != 99 &&
            board[shape[10] + xCheck, shape[11] + yCheck] != 99 &&
            board[shape[12] + xCheck, shape[13] + yCheck] != 99 &&
            board[shape[14] + xCheck, shape[15] + yCheck] != 99 &&

            board[shape[16] + xCheck, shape[17] + yCheck] != 99 &&
            board[shape[18] + xCheck, shape[19] + yCheck] != 99 &&
            board[shape[20] + xCheck, shape[21] + yCheck] != 99 &&
            board[shape[22] + xCheck, shape[23] + yCheck] != 99 &&

            board[shape[24] + xCheck, shape[25] + yCheck] != 99 &&
            board[shape[26] + xCheck, shape[27] + yCheck] != 99 &&
            board[shape[28] + xCheck, shape[29] + yCheck] != 99 &&
            board[shape[30] + xCheck, shape[31] + yCheck] != 99 &&

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
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckBoard5Blocks0Rot(int[,] board, int[] shape, int xCheck, int yCheck)
    {
        if
        (
            board[shape[0] + xCheck, shape[1] + yCheck] != 99 &&
            board[shape[2] + xCheck, shape[3] + yCheck] != 99 &&
            board[shape[4] + xCheck, shape[5] + yCheck] != 99 &&
            board[shape[6] + xCheck, shape[7] + yCheck] != 99 &&
            board[shape[8] + xCheck, shape[9] + yCheck] != 99 &&

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