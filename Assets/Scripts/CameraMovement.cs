using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
   // public GameObject contextMenuConfiguration;
	private float speed = 2.0f;
	private float zoomSpeed = 2.0f;

	public float minX = -360.0f;
	public float maxX = 360.0f;
	
	public float minY = -45.0f;
	public float maxY = 45.0f;

	public float sensX = 100.0f;
	public float sensY = 100.0f;
	
	float rotationY = 0.0f;
	float rotationX = 0.0f;

    public float turnSpeed = 4.0f;		// Speed of camera turning when mouse moves in along an axis
    public float panSpeed = 4.0f;		// Speed of the camera when being panned
  //  public float zoomSpeed = 4.0f;		// Speed of the camera going back and forth

    private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
    private bool isPanning;		// Is the camera being panned?
    public Texture2D cursorTexturePan;
    public Texture2D cursorTexturePoint;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


	void Update () {

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		transform.Translate(0, scroll * zoomSpeed*4, scroll * zoomSpeed, Space.World);

        // Get the right mouse button
        if (Input.GetMouseButtonDown(1) && (!Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.LeftControl)))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isPanning = true;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                transform.position = hit.point;
                Debug.Log("You have rightclicked " + hit.transform.name);
                //contextMenuConfiguration.SetActive(true);
            }
        }

        if (!Input.GetMouseButton(1)) isPanning = false;

		if (Input.GetKey(KeyCode.RightArrow)){
            transform.position += Vector3.right * speed * Time.deltaTime * 4;
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
            transform.position += Vector3.left * speed * Time.deltaTime * 4;
		}
		if (Input.GetKey(KeyCode.UpArrow)){
            transform.position += Vector3.forward * speed * Time.deltaTime * 4;
		}
		if (Input.GetKey(KeyCode.DownArrow)){
            transform.position += Vector3.back * speed * Time.deltaTime * 4;
		}

        //if (Input.GetMouseButton(0) && (!Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.LeftControl)))
        //{
        //    rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime*1;
        //    rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime*1;
        //    rotationY = Mathf.Clamp (rotationY, minY, maxY);
        //    transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
        //}

        if (isPanning)
        {
         //  Cursor.SetCursor(cursorTexturePan, hotSpot, cursorMode);

            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed + 5, pos.z);
            transform.Translate(move, Space.Self);
        }
        else
        {
           // Cursor.SetCursor(cursorTexturePoint, hotSpot, cursorMode);
        }
        //if (Input.GetMouseButtonDown(1))
        //{
        //    Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - Input.mousePosition);

        //    Vector3 move = new Vector3(pos.x * 4, pos.y * 4, 0);
        //    transform.Translate(move, Space.Self);
        //}
        //if (Input.GetMouseButton(1))
        //{

        //    //Grab the current mouse position on the screen
        //    mousePosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - camera.transform.position.z));

        //    //Rotates toward the mouse
            
        //        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg - 90);

        //    //Judge the distance from the object and the mouse
        //    distanceFromObject = (Input.mousePosition - camera.WorldToScreenPoint(transform.position)).magnitude;

        //    //Move towards the mouse
        //    transform.gameObject.AddForce(direction * speed * distanceFromObject * Time.deltaTime);

        //}//End Move Towards If Case
	}

   
}
