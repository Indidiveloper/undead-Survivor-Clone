using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // ... Prefab�� ������ ����
    // ... Ǯ�� ����ϴ� ����Ʈ�� --> Prefab ������ ����Ʈ ������ �����ؾ� �Ѵ�.

    public GameObject[] prefabs;
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // ... ������ Pool�� ��Ȱ��ȭ �� GameObject ����          
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                // ... �߰��ϸ� select ������ �Ҵ�
                select= item;
                select.SetActive(true);
                break;
            }
        }

        // ... �� ã�Ҵٸ�?            
        if (!select) 
        {
            // ... ���Ӱ� Pool�� �����ϰ� Select ������ �Ҵ�
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }




        return select;        
    }


}