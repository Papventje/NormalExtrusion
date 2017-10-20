using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeExtrusion : MonoBehaviour {

    private Renderer soldierRenderer;
    [SerializeField] [Range(-0.002f, 0.003f)] private float Value = 0f;
    [SerializeField] Transform soldierMesh;

    private void Start()
    {
        Value = 0.0f;
        soldierRenderer = soldierMesh.gameObject.GetComponent<Renderer>();

        soldierRenderer.material.shader = Shader.Find("Custom/Vertex");

    }

    private void Update()
    {
        soldierRenderer.material.SetFloat("_Amount", Value);

        //Value += 0.001f;
    }

    void Increase()
    {
        Value += 0.02f;
    }

    void Decrease()
    {
        Value -= 0.02f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fast Food")
        {
            Increase();
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Healthy Food")
        {
            Decrease();
            Destroy(other.gameObject);
        }
    }
}
