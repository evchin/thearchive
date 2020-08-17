using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArtInfo : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    Transform bg;
    Image image;
    TextMeshProUGUI title;
    TextMeshProUGUI artist;
    TextMeshProUGUI movement;
    TextMeshProUGUI year;

    [SerializeField] float maxDistance = 5f;
    Painting closestPainting;

    private void Awake() 
    {
        bg = canvas.transform.Find("BG");
        image = bg.GetComponent<Image>();
        title = bg.transform.Find("Title").GetComponent<TextMeshProUGUI>();
        artist = bg.transform.Find("Artist").GetComponent<TextMeshProUGUI>();
        year = bg.transform.Find("Year").GetComponent<TextMeshProUGUI>();
        movement = bg.transform.Find("Movement").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        closestPainting = FindClosestPainting();
        if (closestPainting == null)
        {
            DisableArtInfoCanvas();
        }
        else
        {
            SetUpArtInfoCanvas();
            UpdateArtInfoText();
        }
    }

    private void DisableArtInfoCanvas()
    {
        image.color = new Color32(0, 0, 0, 0);
        title.text = "";
        artist.text = "";
        year.text = "";
        movement.text = "";
    }

    private void SetUpArtInfoCanvas()
    {
        image.color = new Color32(0, 0, 0, 255);
        canvas.transform.position = closestPainting.transform.position + new Vector3(0, -closestPainting.transform.localScale.y / 2f, 0);
        float yRotation = closestPainting.transform.eulerAngles.y;
        canvas.transform.eulerAngles = new Vector3(canvas.transform.eulerAngles.x, yRotation, canvas.transform.eulerAngles.z);
    }

    private void UpdateArtInfoText()
    {
        title.text = closestPainting.title;
        artist.text = closestPainting.artist;
        year.text = closestPainting.year;
        movement.text = closestPainting.movement;
    }

    private Painting FindClosestPainting()
    {
        GameObject[] paintings;
        paintings = GameObject.FindGameObjectsWithTag("Art");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach(GameObject painting in paintings)
        {
            Vector3 diff = painting.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = painting;
                distance = curDistance;
            }
        }

        if (distance > maxDistance) return null;
        return closest.GetComponent<Painting>();
    }
}
