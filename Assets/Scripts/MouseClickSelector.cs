using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Checks if a valid object was clicked on by mouse input.
/// </summary>
public class MouseClickSelector : MonoBehaviour, IObjectSelector
{
    [SerializeField]
    private SelectEvent _onObjectSelected;

    private GameObject _selectedObject;
    private Camera _eventCamera;
    private int _layerMask;
    private const string GizmoLayer = "Gizmo";

    public SelectEvent OnObjectSelected
    {
        get { return _onObjectSelected; }
    }

    public GameObject SelectedObject
    {
        get { return _selectedObject; }
    }

    private void Start ()
    {
        _eventCamera = Camera.main;
        _layerMask = 1 << LayerMask.NameToLayer(GizmoLayer);        
        _layerMask = ~_layerMask;                               // Ignore the Gizmo layer only
    }

    private void Update ()
    {
        CheckForObjectSelection();
	}

    private void CheckForObjectSelection()
    {
        RaycastHit hitInfo;
        Ray ray = _eventCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, _layerMask))
        {
            Debug.Log("Hovering");
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Clicked " + hitInfo.transform.name);
                _selectedObject = hitInfo.transform.gameObject;
                _onObjectSelected.Invoke(_selectedObject);
            }
        }
    }
}
