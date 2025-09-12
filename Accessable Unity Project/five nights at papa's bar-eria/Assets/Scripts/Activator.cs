using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
public class Activator : MonoBehaviour
{
    public InputActionReference key;
    GameObject note;
    public GameObject[] Activators;
    private Material baseColor;

    public Material color;
   

    // Start is called before the first frame update
    void Start()
    {
        key.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        KeyRead();
    }

    void KeyRead()
    {
        Vector2 keyInput = key.action.ReadValue<Vector2>();

        if (keyInput.y > 0)
        {


            GameObject aKey = Activators[0];

            SphereCollider aKeyCol = aKey.GetComponent<SphereCollider>();

            aKeyCol.enabled = true;

            GameObject aKeyObject = Activators[0].GameObject();

            Renderer aKeyRenderer = aKeyObject.GetComponent<Renderer>();

            aKeyRenderer.material.SetColor("_Color", Color.yellow);


        }
        else if (keyInput.y < 0)
        {

            GameObject bKey = Activators[1];

            SphereCollider bKeyCol = bKey.GetComponent<SphereCollider>();

            bKeyCol.enabled = true;

            Renderer bKeyRenderer = bKey.GetComponent<Renderer>();

            bKeyRenderer.material.SetColor("_Color", Color.cyan);

        }
        else if (keyInput.x > 0)
        {

            GameObject cKey = Activators[2];

            SphereCollider cKeyCol = cKey.GetComponent<SphereCollider>();

            cKeyCol.enabled = true;

            Renderer cKeyRenderer = cKey.GetComponent<Renderer>();

            cKeyRenderer.material.SetColor("_Color", Color.green);

        }
        else if (keyInput.x < 0)
        {

            GameObject switcherKey = Activators[3];

            SphereCollider switcherKeyCol = switcherKey.GetComponent<SphereCollider>();

            switcherKeyCol.enabled = true;

            Renderer switcherKeyRenderer = switcherKey.GetComponent<Renderer>();

            switcherKeyRenderer.material.SetColor("_Color", Color.blue);

        }
        else
        {
            foreach (GameObject keyObject in Activators)
            {
                SphereCollider keyCollider = keyObject.GetComponent<SphereCollider>();
                keyCollider.enabled = false;

                Renderer keyRenderer = keyObject.GetComponent<Renderer>();
                if (keyRenderer != null)
                {
                    keyRenderer.material.SetColor("_Color", Color.white);
                }
            }
        }
    }
    
}
