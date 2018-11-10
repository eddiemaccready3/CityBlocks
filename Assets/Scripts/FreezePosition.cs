using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreezePosition : MonoBehaviour {

    [SerializeField] private float seconds;

    Rigidbody2D m_Rigidbody;

    void Awake()
    {
        m_Rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Invoke("UnfreezePosition", seconds);
        Invoke("LoadMenuScene", 4f);
    }

    private void LoadMenuScene()
    {
        SceneManager.LoadScene(2);
    }

    private void UnfreezePosition()
    {
        m_Rigidbody.constraints = RigidbodyConstraints2D.None;
    }
}
