using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UserInput : MonoBehaviour {

    private List<Vector3> listBlocksClickedOn = new List<Vector3>();
    private List<Vector3> checkBlocksClickedOn = new List<Vector3>();
    private List<int> checkShapeGrid = new List<int>();
    private List<string> listTagsClicked = new List<string>();

    private Vector3 blockClickedPoition;
    private Vector3 newPosToCheckShape;

    private string tagFirstBlockClicked;

    private float minX = 0f;
    private float minY = 0f;

    private int shapeGridPosX = 0;
    private int shapeGridPosY = 0;

	// Use this for initialization
	void Start () {
		listBlocksClickedOn.Clear();
        listTagsClicked.Clear();
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
            int length = listBlocksClickedOn.Count;
            minX = listBlocksClickedOn.Min(v => v.x);
            minY = listBlocksClickedOn.Min(v => v.y);
            float newXPos;
            float newYPos;
            float zPos;

            for (int i = 0; i < length; i++)
            {
                newXPos = listBlocksClickedOn[i].x - minX;
                newYPos = listBlocksClickedOn[i].y - minY;
                zPos = listBlocksClickedOn[i].z;
                newPosToCheckShape = new Vector3(newXPos, newYPos, zPos);
                checkBlocksClickedOn.Add(newPosToCheckShape);
                //print("New position " + checkBlocksClickedOn[i]);
            }
            
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

            //Create List of Blocks clicked on in a 9 x 9 grid
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Vector3 gridCheck = new Vector3(x, y, 0);
                    if (checkBlocksClickedOn.Contains(gridCheck))
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

            string grid = string.Join(";", checkShapeGrid.Select(x => x.ToString()).ToArray());
            print(grid);

            //Compare this list to Shape
            //If matched, destroy matching Blocks at original coordinates


            listBlocksClickedOn.Clear();
            listTagsClicked.Clear();
            checkShapeGrid.Clear();

            minX = 0f;
            minY = 0f;

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
