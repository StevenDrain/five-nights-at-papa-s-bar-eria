using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Activator : MonoBehaviour
{
    public InputActionReference key;
    GameObject note;
    public SphereCollider[] Activators;

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

            SphereCollider aKey = Activators[0];
            
            aKey.enabled = true;

        }
        else if (keyInput.y < 0)
        {

            SphereCollider bKey = Activators[1];
            
            bKey.enabled = true;

        }
        else if (keyInput.x > 0)
        {

            SphereCollider cKey = Activators[2];

            cKey.enabled = true;

        }
        else if (keyInput.x < 0)
        {

            SphereCollider switcherKey = Activators[3];
            
            switcherKey.enabled = true;

        }
        else
        {
           foreach (SphereCollider keyCollider in Activators)
            {
                keyCollider.enabled = false;
            }
        }
    }
    
}
