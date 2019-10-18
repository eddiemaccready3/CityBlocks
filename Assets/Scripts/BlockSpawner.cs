using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    public GameObject[] blocks;
    private Collider2D[] hitColliders;
    private Vector2 overlapBoxPosition;
    private Vector2 instantiatePosition;
    private Vector2 overlapBoxSize;
    private int qtyCollidersHit;

    private PauseGameStatus pauseGameScript;

    void Start ()
    {
        pauseGameScript = FindObjectOfType<PauseGameStatus>();
        //pauseGameScript.pauseAuto = true;
        //pauseGameScript.pauseManual = true;

        overlapBoxPosition = new Vector2(transform.position.x, transform.position.y - 1f);
        instantiatePosition = new Vector2(transform.position.x, transform.position.y - 1f);
        overlapBoxSize = new Vector2(.8f, 1.8f);

    }

    private void Update()
    {
        hitColliders = Physics2D.OverlapBoxAll(overlapBoxPosition, overlapBoxSize, 0, layerMask);
        qtyCollidersHit = hitColliders.Length;
        if (hitColliders.Length < 1)
        {
            int i = Random.Range(0, blocks.Length);
            Instantiate(blocks[i],
                    instantiatePosition,
                    Quaternion.identity);
        }
    }
}
