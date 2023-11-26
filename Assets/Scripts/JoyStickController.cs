using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickController : MonoBehaviour
{
    [SerializeField]private RectTransform joyStickOutline;
    [SerializeField] private RectTransform joyStickButton;
    [SerializeField] private float moveFactor;
    private Vector3 move;
    private Vector3 tapPosition;
    private bool canControlJoyStick;
    // Start is called before the first frame update
    void Start()
    {
        HideJoyStick();
    }
    public void TappedOnJoyStickZone()
    {
        Debug.Log("ekrana dokunuldu");
        tapPosition = Input.mousePosition;
        joyStickOutline.position = tapPosition;
        ShowJoyStick();
    }
    private void ShowJoyStick()
    {
        joyStickOutline.gameObject.SetActive(true);
        canControlJoyStick = true;

    }
    private void HideJoyStick()
    {
        joyStickOutline.gameObject.SetActive(false);
        canControlJoyStick = false;
        move = Vector3.zero;
    }
    private void ControlJoyStick()
    {
        Vector3 currentPosition = Input.mousePosition;
        Vector3 direction = currentPosition - tapPosition;

        float canvasYScale = GetComponentInParent<Canvas>().GetComponent<RectTransform>().localScale.y;
        float moveMagnitude = direction.magnitude * moveFactor * canvasYScale;

        float joyStickOutLineHalfWidth = joyStickOutline.rect.width / 3;
        float newWidth = joyStickOutLineHalfWidth * canvasYScale;

        moveMagnitude = Mathf.Min(moveMagnitude, newWidth);

        move = direction.normalized * moveMagnitude;

        Vector3 targetPos = tapPosition + move;
        joyStickButton.position = targetPos;

        if (Input.GetMouseButtonUp(0))
        {
            HideJoyStick();
        }
    }

    public Vector3 GetMovePosition()
    {
        return move/ 1.75f;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (canControlJoyStick)
        {
            ControlJoyStick();
        }
        
    }
}
