using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Activator : MonoBehaviour
{
    public InputActionReference key;
    public Renderer[] materials;
    public Material pressed;
    public Material baseColor;
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
        Renderer aKeyR = materials[0];
        Renderer bKeyR = materials[1];
        Renderer cKeyR = materials[2];
        Renderer SwitcherKeyR = materials[3];

        SphereCollider aKey = Activators[0];
        SphereCollider bKey = Activators[1];
        SphereCollider cKey = Activators[2];
        SphereCollider switcherKey = Activators[3];

        if (keyInput.y <= 0 || keyInput.y >= 0 || keyInput.x <= 0 || keyInput.x >= 0)
        {
            aKeyR.material = pressed;
            bKeyR.material = pressed;
            cKeyR.material = pressed;
            SwitcherKeyR.material = pressed;

            aKey.enabled = true;
            bKey.enabled = true;
            cKey.enabled = true;
            switcherKey.enabled = true;
        }

        if (keyInput.y > 0)
        {
            

            aKeyR.material = pressed;



            aKey.enabled = true;

        }
        else if (keyInput.y < 0)
        {

            
            bKeyR.material = pressed;

            bKey.enabled = true;

        }
        else if (keyInput.x > 0)
        {

            
            cKeyR.material = pressed;

            cKey.enabled = true;

        }
        else if (keyInput.x < 0)
        {

            
            SwitcherKeyR.material = pressed;

            switcherKey.enabled = true;

        }
        else
        {
            foreach (SphereCollider keyCollider in Activators)
            {
                aKeyR.material = baseColor;
                bKeyR.material = baseColor;
                cKeyR.material = baseColor;
                SwitcherKeyR.material = baseColor;
                keyCollider.enabled = false;

            }
        }
    }
    
}
