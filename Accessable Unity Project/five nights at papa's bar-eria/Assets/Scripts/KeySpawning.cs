using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawning : MonoBehaviour
{
    public Transform[] Spawners;
    public GameObject KeyPrefab; // renamed for clarity
    public Material ZeroColor;
    public Material OneColor;
    public Material TwoColor;
    public Material ThreeColor;

    [HideInInspector] public Vector3 KeySize;
    private int SpawnerRandom;

    void Start()
    {
        StartCoroutine(DelayedLoop());
    }

    IEnumerator DelayedLoop()
    {
        for (int i = 0; i < 30; i++)
        {


            // Choose random length and spawner
            KeySize = new Vector3(1, 1, Random.Range(1f, 10f));
            SpawnerRandom = Random.Range(0, Spawners.Length);

            // Wait before spawning next key
            yield return new WaitForSeconds(3.5f);

            // Instantiate first
            GameObject newKey = Instantiate(
                KeyPrefab,
                Spawners[SpawnerRandom].position,
                Spawners[SpawnerRandom].rotation
            );

            // Then set its scale
            newKey.transform.localScale = KeySize;

            // Then color it
            var keyRenderer = newKey.GetComponent<Renderer>();
            if (keyRenderer != null)
            {
                switch (SpawnerRandom)
                {
                    case 0: keyRenderer.material = ZeroColor; break;
                    case 1: keyRenderer.material = OneColor; break;
                    case 2: keyRenderer.material = TwoColor; break;
                    case 3: keyRenderer.material = ThreeColor; break;
                }
            }

        }

    }
}