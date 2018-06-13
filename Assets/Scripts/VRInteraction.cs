using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRInteraction : MonoBehaviour
{
    public Camera vrCamera;
    public Image cursor;
    public float actionRate = 2; // как часто срабатывает взгял
    float nextAction;
    public float multipleCursor = 3; // на сколько увеличится курсор
    RectTransform cursorTransform; // компонент трансформации курсора
    Vector2 startCursorSize; // стартовый размер курсора

    void Start()
    {
        cursorTransform = cursor.GetComponent<RectTransform>(); // получаем компонент
        startCursorSize = cursorTransform.sizeDelta; // сохр стартовый размер курсора
        nextAction = actionRate;
    }


    void Update()
    {
        Ray ray = vrCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit; // объекст с которым столкнется луч
        if (Physics.Raycast(ray, out hit) && hit.transform.GetComponent<IVRInteractible>() != null)
        {
            cursorTransform.sizeDelta += new Vector2(multipleCursor, multipleCursor) * Time.deltaTime;

            if (Time.time >= nextAction)

            {
                // Debug.Log(hit.collider.gameObject.name);
                // cursorTransform.sizeDelta += new Vector2(multipleCursor, multipleCursor) * Time.deltaTime;
                nextAction = Time.time + actionRate;
                ClearCursor();
                hit.transform.GetComponent<IVRInteractible>().OnReady();
            }
        }
        else
        {
            nextAction = Time.time + actionRate;
            ClearCursor();
        }
    }

    void ClearCursor()
    {
        cursorTransform.sizeDelta = startCursorSize;
    }

}