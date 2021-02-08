using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        PersistentManagerScript.Instance.characterColor = "Green";
        material = GetComponent<Renderer>().material;
        //material.color = Color.blue;
        material.color = new Color(0.49f, 0.81f, 0.42f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("wall"))
        {
            Material actualMaterial = GetComponent<Renderer>().material;
            if (other.gameObject.GetComponent<Renderer>().material.name.Contains("Pink"))
            {
                actualMaterial.color = new Color(1.0f, 0.56f, 1.0f, 1.0f);
                PersistentManagerScript.Instance.characterColor = "Pink";
            } else if (other.gameObject.GetComponent<Renderer>().material.name.Contains("Green"))
            {
                actualMaterial.color = new Color(0.49f, 0.81f, 0.42f, 1.0f);
                PersistentManagerScript.Instance.characterColor = "Green";
            }
            else if (other.gameObject.GetComponent<Renderer>().material.name.Contains("Blue"))
            {
                actualMaterial.color = new Color(0.3f, 0.58f, 0.82f, 1.0f);
                PersistentManagerScript.Instance.characterColor = "Blue";
            }
        }
    }
}
