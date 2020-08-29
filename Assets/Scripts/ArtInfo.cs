using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArtInfo : MonoBehaviour
{
    [SerializeField] Canvas canvasPrefab;
    [SerializeField] Transform canvasParent;
    private GameObject[] paintings;
    
    private void Awake() 
    {
        paintings = GameObject.FindGameObjectsWithTag("Art");
    }

    private void Start() 
    {
        foreach(GameObject p in paintings)
        {
            Painting painting = p.GetComponent<Painting>();
            Canvas canvasInstance = Instantiate(canvasPrefab, canvasParent);
            PositionCanvasInstance(p, canvasInstance);
            UpdateCanvasInstanceText(painting, canvasInstance);
        }
    }

    private void UpdateCanvasInstanceText(Painting p, Canvas canvasInstance)
    {
        Transform bg = canvasInstance.transform.Find("BG");
        Transform mainPanel = bg.Find("Main Panel");
        Transform secondPanel = bg.Find("Second Panel");

        mainPanel.Find("Title").GetComponent<TextMeshProUGUI>().text = p.title;
        mainPanel.Find("Artist").GetComponent<TextMeshProUGUI>().text = p.artist;
        mainPanel.Find("Year").GetComponent<TextMeshProUGUI>().text = p.year;
        mainPanel.Find("Movement").GetComponent<TextMeshProUGUI>().text = p.movement;
        secondPanel.Find("Description").GetComponent<TextMeshProUGUI>().text = p.description;
        secondPanel.Find("Source").GetComponent<TextMeshProUGUI>().text = p.source;
    }

    private static void PositionCanvasInstance(GameObject painting, Canvas canvasInstance)
    {
        canvasInstance.transform.position = new Vector3(painting.transform.position.x, painting.transform.position.y-painting.transform.localScale.y / 1.9f, painting.transform.position.z);
        float yRotation = painting.transform.eulerAngles.y;
        canvasInstance.transform.eulerAngles = new Vector3(canvasInstance.transform.eulerAngles.x, yRotation, canvasInstance.transform.eulerAngles.z);
    }
}
