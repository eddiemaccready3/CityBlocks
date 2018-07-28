using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour {

    private List<Vector3> listBlocksClickedOn = new List<Vector3>();
    private List<string> listTagsClicked = new List<string>();

    private Vector3 blockClickedPoition;

    private string tagFirstBlockClicked;

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
            listBlocksClickedOn.Clear();
            listTagsClicked.Clear();
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

            foreach (Vector3 item in listBlocksClickedOn)
            {
                print("Added to List: " + item);
            }
        }
    }
}
