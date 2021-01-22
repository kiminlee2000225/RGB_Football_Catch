using System.Collections.Generic;
using UnityEngine;

public class BallLoader : MonoBehaviour
{
    public string jsonFilePath = "BallInfo.json";
    public Dictionary<int, Ball> ballsDict;
    public GameObject ballPrefab;

    // Set these values in the inspector
    public float redBallVelocity;
    public float greenBallVelocity;
    public float blueBallVelocity;

    private Color materialColor;

    /*   
    *   Convert the json data for the balls to a List of Ball classes. Utilize this list to create a dictionary
    *   of the Ball classes where the key is the ballId. This will help reduce time when searching and selecting
    *   which ball to instantiate and shoot. 
    */
    void Awake()
    {
        BallList ballList = JsonUtility.FromJson<BallList>(JSONFileReader.LoadJsonAsResource(jsonFilePath));

        ballsDict = new Dictionary<int, Ball>();
        foreach (Ball ball in ballList.balls)
        {
            ballsDict.Add(ball.ballId, ball);
        }
    }

    /*   
    *   <param name="id"> An integer representing a ballId.</param>
    *   <returns>A GameObject representing a ball (prefab) object with a specific material and a GameObject name depending on the ballId parameter</returns>
    *   The returned gameobject will differ in name and the material's color. 
    */
    public GameObject InstantiateBallWithId(int id)
    {
        ballsDict.TryGetValue(id, out Ball ball);

        ColorUtility.TryParseHtmlString(ball.colorHex, out materialColor);
        Material newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.SetColor("_Color", materialColor);
        ballPrefab.GetComponent<Renderer>().material = newMaterial;

        ballPrefab.name = ball.name;

        return ballPrefab;
    }

    /*   
    *   <param name="id"> An integer representing a ballId.</param>
    *   <returns>A velocity as a float depending on the ballId parameter.</returns>
    *   The red ball will return the weakest velocity, while the green ball will return an average velocity, 
    *   and the blue ball will return the highest velocity. 
    */
    public float SetVelocityWithId(int id)
    {
        float velocity = 0f;
        switch(id)
        {
            case 0:
                velocity = redBallVelocity;
                break;
            case 1:
                velocity = greenBallVelocity;
                break;
            case 2:
                velocity = blueBallVelocity;
                break;
            default:
                break;
        }
        return velocity;
    }
}
