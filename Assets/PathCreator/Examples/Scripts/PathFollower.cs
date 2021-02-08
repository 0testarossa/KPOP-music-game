using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        public float forwardSpeed = 15;
        float distanceTravelled;
        float leftRightDistance = 0f;
        Boolean isEndOfScene = false;
        Button retryNextSceneButton;
        Text retryNextSceneButtonText;
        Text requirePointsText;

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
                //pathCreator.transform.rotation = Quaternion.Euler(new Vector3(pathCreator.transform.eulerAngles.x, pathCreator.transform.eulerAngles.y + 180, pathCreator.transform.eulerAngles.z));

            }
            retryNextSceneButton = GameObject.Find("Canvas/Button").GetComponent<Button>();
            retryNextSceneButtonText = GameObject.Find("Canvas/Button/ButtonText").GetComponent<Text>();
            requirePointsText = GameObject.Find("Canvas/Text2").GetComponent<Text>();
            retryNextSceneButton.onClick.AddListener(delegate { onButtonClick(); });
            retryNextSceneButton.gameObject.SetActive(false);

            PersistentManagerScript.Instance.points = 0;
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            float horizonstalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            if (pathCreator != null)
            {
                if (distanceTravelled < pathCreator.path.length -2f)
                {
                    //print(transform.rotation);
                    //float xTransform = transform.rotation.x < 0 ? -horizonstalInput* speed *Time.deltaTime : horizonstalInput * speed * Time.deltaTime;
                    distanceTravelled += forwardSpeed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction) + new Vector3(0, 1f, 0);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                    //transform.position = transform.position + new Vector3(horizonstalInput * speed * Time.deltaTime, 0f, 0f);

                    //pathCreator.transform.position = pathCreator.transform.position + new Vector3(xTransform, 0, 0);   
                    //pathCreator.transform.position = pathCreator.transform.position + new Vector3(horizonstalInput * speed * Time.deltaTime, 0, 0);
                    float facing = Camera.main.transform.rotation.y;
                    float DistanceFromNeutral = 0;
                    float transformZ = 0;
                    float transformX = 0;
                    if (facing > -90 && facing < 90)
                    {
                        if (facing >= 0)
                        {
                            DistanceFromNeutral = (90 - facing);
                        }
                        else
                        {
                            if (facing < 0)
                            {
                                DistanceFromNeutral = (90 + facing);
                            }
                        }
                        transformX = (1 / 90) * DistanceFromNeutral;
                        transformZ = 90 - transformX;
                    };
                    float finalX = (transformX * verticalInput) + (transformZ * horizonstalInput);
                    float finalZ = (transformZ * verticalInput) + (transformX * horizonstalInput);

                    float finalX2 = (transformZ * leftRightDistance);
                    float finalZ2 = (transformX * leftRightDistance);


                    var goodPathAngles = new Vector3(pathCreator.transform.eulerAngles.x, pathCreator.transform.eulerAngles.y, pathCreator.transform.eulerAngles.z);
                    Vector3 cubeEulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
                    //pathCreator.transform.rotation = Quaternion.Euler(cubeEulerAngles);
                    //pathCreator.transform.Translate((new Vector3(finalX * 0.01f, 0f, finalZ * 0.01f)) * speed * Time.deltaTime);
                    //pathCreator.transform.rotation = Quaternion.Euler(goodPathAngles);
                    //pathCreator.transform.position = new Vector3(pathCreator.transform.position.x, 0, pathCreator.transform.position.z);


                    leftRightDistance = leftRightDistance + (horizonstalInput * speed * Time.deltaTime);
                    leftRightDistance = leftRightDistance > 2.0f ? 2.0f : leftRightDistance < -2.0f ? -2.0f : leftRightDistance;

                    //transform.position = transform.position + new Vector3(leftRightDistance, 0f, 0f);

                    //transform.Translate((new Vector3(finalX * 0.01f, 0f, finalZ * 0.01f)) * speed * Time.deltaTime);
                    transform.Translate((new Vector3(finalX2 * 0.01f, 0f, finalZ2 * 0.01f)));
                    transform.Translate((new Vector3(finalX * 0.01f, 0f, finalZ * 0.01f)) * speed * Time.deltaTime);
                } else
                {
                    if(isEndOfScene == false)
                    {
                        isEndOfScene = true;
                        showUI();
                        transform.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }




            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        void showUI()
        {
            if (int.Parse(requirePointsText.text) <= PersistentManagerScript.Instance.points)
            {
                if(SceneManager.GetActiveScene().buildIndex == 3) {
                    retryNextSceneButtonText.text = "EXIT";
                } else
                {
                    retryNextSceneButtonText.text = "NEXT";
                }
      
            }
            else
            {
                retryNextSceneButtonText.text = "RETRY";
            }
            retryNextSceneButton.gameObject.SetActive(true);
        }

        void onButtonClick()
        {
            if (int.Parse(requirePointsText.text) <= PersistentManagerScript.Instance.points)
            {
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    Application.Quit();
                }
                else
                {
                    Scene sceneLoaded = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(sceneLoaded.buildIndex + 1);
                }
            }
            else
            {
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
            }
        }
    }
}