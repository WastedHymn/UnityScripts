using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    [SerializeField]
    public float ScaleMultiplier = 0.1f;

    bool flipFlop = false;
    float scalespeed = 0.5f;
    float rotationspeed = 15f;
    float time = 0f;
    float t = 0;
    Material cubeMaterial;
    Color newColor;
    Vector3 newPosition;
    Quaternion newRotation;
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        cubeMaterial = Renderer.sharedMaterial;
        newColor = ChangeMaterialColor();
        newRotation = ChangeRotation();

    }

    void Update()
    {

        ChangeCubeScale();
        time += Time.deltaTime;
        if (time >= 2f)
        {
            newPosition = ChangeLocation();
            newRotation = ChangeRotation();
            newColor = ChangeMaterialColor();
            time = 0f;
        }
        cubeMaterial.color = Color.Lerp(cubeMaterial.color, newColor, 2f * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, newPosition, 2f * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation,   2f * Time.deltaTime);
        //transform.Rotate(newRotation * Time.deltaTime * .5f);
    }

    Color ChangeMaterialColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        float a = Random.Range(0f, 1f);
        Color newMaterialColor = new Color(r,g,b,a);
        return newMaterialColor;

    }

    Vector3 ChangeLocation()
    {
        int randomY = Random.Range(0, 10);
        int randomZ = Random.Range(-10, 10);
        return new Vector3(transform.position.x, randomY, randomZ);
    }

    Quaternion ChangeRotation()
    {
        int randomX = Random.Range(0, 360);

        return Quaternion.Euler(randomX,transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    void ChangeCubeScale()
    {
        Vector3 objScale = transform.localScale;
        Vector3 newObjScale = objScale * Time.deltaTime * scalespeed;
        if (flipFlop)
        {
            transform.localScale = objScale + (newObjScale);
            if (objScale.x >= 5)
            {
                flipFlop = false;
            }
        }
        else
        {
            transform.localScale = objScale - (newObjScale);
            if (objScale.x <= 1)
            {
                flipFlop = true;
            }
        }

    }
}
