using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropsScript : MonoBehaviour
{
    public AudioSource music;
    Text textScores;
    float timer = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.Find("PickUpSound").GetComponent<AudioSource>();
        textScores = GameObject.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer = timer - Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //print(PersistentManagerScript.Instance.points);
        //music.time = 37.4f;
        music.time = 129.2f;
        music.Play();
        Invoke("stopMusic", 0.3f);

        //PersistentManagerScript.Instance.points = PersistentManagerScript.Instance.points + 1;
        //print(PersistentManagerScript.Instance.points);

        gameObject.SetActive(false);
        //transform.localScale = new Vector3(0, 0, 0);
        Material material = GetComponent<Renderer>().material;
        //print(material.name.Contains("Green"));
        if(timer <=0)
        {
            if (material.name.Contains(PersistentManagerScript.Instance.characterColor))
            {
                PersistentManagerScript.Instance.points = PersistentManagerScript.Instance.points + 3f;
                textScores.text = PersistentManagerScript.Instance.points.ToString();
            }
            else if (!material.name.Contains("Black"))
            {
                PersistentManagerScript.Instance.points = PersistentManagerScript.Instance.points + 1f;
                textScores.text = PersistentManagerScript.Instance.points.ToString();
            }
            else
            {
                PersistentManagerScript.Instance.points = PersistentManagerScript.Instance.points - 10f;
                PersistentManagerScript.Instance.points = PersistentManagerScript.Instance.points >= 0 ? PersistentManagerScript.Instance.points : 0;
                textScores.text = PersistentManagerScript.Instance.points.ToString();
            }
        }
    }

    void stopMusic()
    {
        music.Stop();
    }
}
