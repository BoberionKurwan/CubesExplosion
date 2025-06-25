using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private int _leftMouseButton = 0;
    public event Action<Cube> CubeClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Cube cube = hit.collider.GetComponent<Cube>();
                
                if (cube != null) 
                CubeClicked?.Invoke(cube);
            }
        }
    }
}