using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject DoorPrefab;
    public GameObject ObstaclesPrefabs;
    public GameObject ConesPrefab;
    public GameObject Player;
    public GameObject ObjectsParent;

    public float objDistance;

    public enum ObjectType { Door, Obstacle }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObjectSpawn());
    }

    IEnumerator ObjectSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);

            SetObjectType();
            
        }
    }

    private void SetObjectType()
    {
        ObjectType obj = GetRandomObjectType();

        GameObject newObj = null;

        Vector3 objPos =  new Vector3(0, 0, Player.transform.position.z + objDistance);

        switch ( obj )
        {
            case ObjectType.Door:
                newObj = Instantiate(DoorPrefab, objPos, Quaternion.identity, ObjectsParent.transform);
                Destroy(newObj, 5);
                break;
            case ObjectType.Obstacle:
                newObj = Instantiate(ObstaclesPrefabs, objPos + new Vector3(0, Random.Range(2.8f, 15.4f), 0), Quaternion.identity, ObjectsParent.transform);
                Destroy(newObj, 5);
                break;
        }
        
    }

    private static ObjectType GetRandomObjectType()
    {
        ObjectType[] objectTypes = (ObjectType[])(System.Enum.GetValues(typeof(ObjectType)));
        return objectTypes[Random.Range(0, objectTypes.Length)];
    }

}
