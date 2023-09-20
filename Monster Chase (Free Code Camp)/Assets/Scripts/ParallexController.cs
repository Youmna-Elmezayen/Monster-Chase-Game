using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallexController : MonoBehaviour
{
    Transform cam; //Main Camera
    Vector3 camStartPos;
    float distance; // distance between camera start position and its current position

    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed;

    float farthestBack;

    [SerializeField]
    [Range(0.01f, 0.05f)]
    float parallexSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position;

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for(int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
        }

        BackSpeedCalculation(backCount);
    }

    void BackSpeedCalculation(int backCount)
    {
        for(int i = 0; i < backCount; i++) // find the farthest background
        {
            if((backgrounds[i].transform.position.z - cam.position.z) > farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - cam.position.z;
            }
        }

        for(int i = 0; i < backCount; i++) // set speed of backgrounds
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / farthestBack;
        }
    }
    private void LateUpdate()
    {
        distance = cam.position.x - camStartPos.x;
        transform.position = new Vector3(cam.position.x, transform.position.y, 0);

        for(int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backSpeed[i] * parallexSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }
}
