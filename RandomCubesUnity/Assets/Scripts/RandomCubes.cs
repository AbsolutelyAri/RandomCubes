/*
    Created by: Krieger
    Date Created: 1/24/2022

    Last Edited by: n/a
    Last Edited Date: 1/26/2021

    Description: Spawns CubePrefab's into the scene.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    //variables
    public GameObject cubePrefab; //new gameobject
    [HideInInspector]
    public List<GameObject> gameObjectList; //list of all the glorious cube children we shall generate
    public float scalingFactor = .95f; //determines scaling factor of cubes
    public int numberOfCubes = 0; //tracks the number of cubes
    public int activeCubes = 0; //just for my personal curiosity, shows how many cubes are currently on screen

    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instantiates the list of gameobjects
        
    } //end of start

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++;
        activeCubes++;
        GameObject gObj = Instantiate<GameObject>(cubePrefab);

        gObj.name = "Cube" + numberOfCubes; //instantiates the new cube's name with the name Cube[number of cubes]

        Color randomColor = new Color(Random.value, Random.value, Random.value); //generates a random color for the cubes (v pretty)
        gObj.GetComponent<Renderer>().material.color = randomColor; //applies the random color

        gObj.transform.position = Random.insideUnitSphere; //generates at a random position within a sphere of raidus 1 

        gameObjectList.Add(gObj);

        List<GameObject> removeList = new List<GameObject>(); //list of objects to be remvoed from the main list

        foreach(GameObject tempObj in gameObjectList)
        {
            float scale = tempObj.transform.localScale.z; //grab the z scale, all the scale values should be the same
            scale *= scalingFactor; //multiply scale by scaling factor to shrink it
            tempObj.transform.localScale = Vector3.one * scale; //applies the change made to scale

            if(scale <= 0.1f)
            {
                removeList.Add(tempObj);
            } //end if
        } //end foreach

        foreach(GameObject tempObj in removeList)
        {
            gameObjectList.Remove(tempObj); //remove the object from removelist from the main gameobjectlist
            Destroy(tempObj); //yeet
            activeCubes--;
        } //end foreach
    } //end update
}
