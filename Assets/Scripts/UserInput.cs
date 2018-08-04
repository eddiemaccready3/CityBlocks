using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UserInput : MonoBehaviour {

    private const string SHAPET1 = "10000111";
    private const string SHAPET2 = "1000001100001";
    private const string SHAPET3 = "11100001";
    private const string SHAPET4 = "1000011000001";
    private const string SHAPEO  = "11000011";
    private const string SHAPES1 = "10000111";
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
    
    private Vector3 blockClickedPoition;
    private Vector3 newPosToCheckShape;

    [SerializeField] GameObject destroyer;

    private string tagFirstBlockClicked;
    private string currentGridIndex;
    
    private bool match;

    private float minX = 0f;
    private float minY = 0f;

    private int shapeGridPosX = 0;
    private int shapeGridPosY = 0;

	// Use this for initialization
	void Start ()
    {
        listBlocksClickedOn.Clear();
        listTagsClicked.Clear();
        match = false;
        PopulateShapesList();
        PopulateShapeGridList();

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
            //MatchShapes();

            //Move positions saved in list to lower left coordinates
            //int length = listBlocksClickedOn.Count;
            //minX = listBlocksClickedOn.Min(v => v.x);
            //minY = listBlocksClickedOn.Min(v => v.y);
            //float newXPos;
            //float newYPos;
            //float zPos;

            //for (int i = 0; i < length; i++)
            //{
            //    newXPos = listBlocksClickedOn[i].x - minX;
            //    newYPos = listBlocksClickedOn[i].y - minY;
            //    zPos = listBlocksClickedOn[i].z;
            //    newPosToCheckShape = new Vector3(newXPos, newYPos, zPos);
            //    checkBlocksClickedOn.Add(newPosToCheckShape);
            //    //print("New position " + checkBlocksClickedOn[i]);
            //}
            
            //foreach (Vector3 item in checkBlocksClickedOn)
            //{
            //    item.Set(item.x - minX, item.y, item.z);
            //    item.Set(item.x, item.y - minY, item.z);
            //    print("New position " + item);
            //}
            //foreach (Vector3 item in checkBlocksClickedOn)
            //{
            //    print("New Sorted position " + item);
            //}
            //print("Min x value: " + minX);
            //print("Min y value: " + minY);

            //checkBlocksClickedOn.Sort((a, b) => a.y.CompareTo(b.y));
            //checkBlocksClickedOn.Sort((a, b) => a.x.CompareTo(b.x));
            //foreach (Vector3 item in checkBlocksClickedOn)
            //{
            //    print("New Sorted position " + item);
            //}

            //Create List of Blocks clicked on in a 6 x 10 grid
            //for (int y = 0; y < 10; y++)
            //{
            //    for (int x = 0; x < 6; x++)
            //    {
            //        Vector3 gridCheck = new Vector3(x, y, 0);
            //        if (checkBlocksClickedOn.Contains(gridCheck))
            //        {
            //            checkShapeGrid.Add(1);
            //        }
            //        else
            //        {
            //            checkShapeGrid.Add(0);
            //        }

            //        //print("Grid pos: " + checkShapeGrid[checkShapeGrid.Count]);
            //    }
            //}

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
                if (GameObject.Find(listOfShapes[s]) != null & s == 0)
                {
                    CheckForShapeX();
                }

                else if (GameObject.Find(listOfShapes[s]) != null & s == 1)
                {
                    CheckForShapeT();
                }

                else if (GameObject.Find(listOfShapes[s]) != null & s == 2)
                {
                    CheckForShapeS();
                }

                else if (GameObject.Find(listOfShapes[s]) != null & s == 3)
                {
                    CheckForShapeZ();
                }

                else if (GameObject.Find(listOfShapes[s]) != null & s == 4)
                {
                    CheckForShapeL();
                }

                else if (GameObject.Find(listOfShapes[s]) != null & s == 5)
                {
                    CheckForShapeJ();
                }

                else if (GameObject.Find(listOfShapes[s]) != null & s == 6)
                {
                    CheckForShapeI();
                }

                else if (GameObject.Find(listOfShapes[s]) != null & s == 7)
                {
                    CheckForShapeO();
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

            for (int i = 0; i < (60 - currentGridIndex.Length); i++)
            {
                if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1 & checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    print("Match shape T!");
                    //print(i);
                    match = true;
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

        for (int i = 0; i < (60 - SHAPEO.Length); i++)
        {
            if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1 & checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
            {
                print("Match shape O!");

                Instantiate(destroyer, new Vector3((i % 6), (i / 6), 0), Quaternion.identity);
                Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[1]) % 6), ((i + shapeMatchIndexes[1]) / 6), 0), Quaternion.identity);
                Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[2]) % 6), ((i + shapeMatchIndexes[2]) / 6), 0), Quaternion.identity);
                Instantiate(destroyer, new Vector3(((i + shapeMatchIndexes[3]) % 6), ((i + shapeMatchIndexes[3]) / 6), 0), Quaternion.identity);

                print(i);
                match = true;
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

            for (int i = 0; i < (60 - currentGridIndex.Length); i++)
            {
                if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1 & checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    print("Match shape S!");
                    //print(i);
                    match = true;
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

            for (int i = 0; i < (60 - currentGridIndex.Length); i++)
            {
                if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1 & checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    print("Match shape Z!");
                    //print(i);
                    match = true;
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

            for (int i = 0; i < (60 - currentGridIndex.Length); i++)
            {
                if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1 & checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    print("Match shape I!");
                    //print(i);
                    match = true;
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

            for (int i = 0; i < (60 - currentGridIndex.Length); i++)
            {
                if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1 & checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    print("Match shape J!");
                    //print(i);
                    match = true;
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

            for (int i = 0; i < (60 - currentGridIndex.Length); i++)
            {
                if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1 & checkShapeGrid[i + shapeMatchIndexes[3]] == 1)
                {
                    print("Match shape L!");
                    match = true;
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


        for (int i = 0; i < (60 - SHAPEX.Length); i++)
        {
            if (match == false & checkShapeGrid[i] == 1 & checkShapeGrid[i + shapeMatchIndexes[1]] == 1 & checkShapeGrid[i + shapeMatchIndexes[2]] == 1 & checkShapeGrid[i + shapeMatchIndexes[3]] == 1 & checkShapeGrid[i + shapeMatchIndexes[4]] == 1)
            {
                print("Match shape X!");
                //print(i);
                match = true;
            }
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

    //private void MatchShapes()
    //{

    //}
}
