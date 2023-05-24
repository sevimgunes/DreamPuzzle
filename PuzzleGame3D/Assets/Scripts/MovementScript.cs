using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private GameObject parentCube;
    private GameObject currentCube;
    private bool isRotating = false;
    private float rotationDuration = 1.0f;
    private float movingwayx;
    private float movingwayy;
    private Camera mCamera;
    private bool clickdone;

    private void Start()
    {
        mCamera = Camera.main;
        clickdone = true;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && clickdone)
        {
            RaycastHit hit;
            Ray ray = mCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                GameObject clickedObject = hit.transform.gameObject;
                if (clickedObject.CompareTag("Cube"))
                {
                    currentCube = clickedObject;
                    ChangeColor();
                }
            }
        }
    }

    public void MoveUp()
    {
        movingwayx = 90f;
        movingwayy = 0;
        Move();
    }

    public void MoveDown()
    {
        movingwayx = -90f;
        movingwayy = 0;
        Move();
    }

    public void MoveLeft()
    {
        movingwayx = 0f;
        movingwayy = 90f;
        Move();
    }

    public void MoveRight()
    {
        movingwayx = 0f;
        movingwayy = -90f;
        Move();
    }

    public void MoveParent()
    {
        currentCube = parentCube;
    }

    private void Move()
    {
        if (!isRotating && currentCube != null)
        {
            isRotating = true;
            clickdone = false;
            StartCoroutine(RotateCube(currentCube));
        }
    }

    private IEnumerator RotateCube(GameObject cube)
    {
        Quaternion startRotation = cube.transform.rotation;
        Quaternion endRotation = cube.transform.rotation * Quaternion.Euler(movingwayx, movingwayy, 0f);
        float elapsed = 0f;

        while (elapsed < rotationDuration)
        {
            cube.transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsed / rotationDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        cube.transform.rotation = endRotation;
        isRotating = false;
        clickdone = true;
    }

    private void ChangeColor()
    {
        currentCube.GetComponent<MeshRenderer>().material.color = Color.red;
        StartCoroutine(WaitAndChangeBack(currentCube, 0.2f));
    }

    private IEnumerator WaitAndChangeBack(GameObject cube, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        cube.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
