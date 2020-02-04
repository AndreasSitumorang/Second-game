using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObject : MonoBehaviour {

    public GameObject prefab;
    private Stack<GameObject> inactiveInstance = new Stack<GameObject>();

    public GameObject GetObject()
    {
        GameObject spawnedGameObject;
        if(inactiveInstance.Count > 0)
        {
            spawnedGameObject = inactiveInstance.Pop();
        }

        else
        {
            spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);
            PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>();
            pooledObject.pool = this;
        }
        spawnedGameObject.transform.SetParent(null);
        spawnedGameObject.SetActive(true);
        return spawnedGameObject;
    }

    public void ReturnObject(GameObject toReturn)
    {
        PooledObject pooledObject = toReturn.GetComponent<PooledObject>();

        if(pooledObject != null && pooledObject.pool == this)
        {
            toReturn.transform.SetParent(transform);
            toReturn.SetActive(false);

            inactiveInstance.Push(toReturn);
        }
        else
        {
            Debug.LogWarning(toReturn.name + "was return to pool");
            Destroy(toReturn);
        }
    }





    public class PooledObject : MonoBehaviour
    {
        public SimpleObject pool;
    }
    // Use this for initialization
    /*void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/
}
