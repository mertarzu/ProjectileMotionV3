using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIViewer : MonoBehaviour
{
    [SerializeField] Slider maxHeightSlider;
    [SerializeField] Slider timeSlider;
    [SerializeField] TextMeshProUGUI maxHeightText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] Button playButton;
    public float TimeSlider => timeSlider.value;
    public float MaxHeightSlider => maxHeightSlider.value;
    public void Initialize()
    {
        maxHeightSlider.minValue = 2;
        timeSlider.minValue = 1; 
        maxHeightSlider.maxValue = 14;
        timeSlider.maxValue = 10;
        maxHeightSlider.interactable = true;
        timeSlider.interactable = true;
        playButton.gameObject.SetActive(false);
        maxHeightText.text = "MaxHeight " + System.Math.Round(maxHeightSlider.value, 1);
        timeText.text = "Time " + System.Math.Round(timeSlider.value, 1);
    }

    public void UpdateMaxHeightValue()
    {    
        maxHeightText.text = "MaxHeight " + System.Math.Round(maxHeightSlider.value, 1);      
    }

    public void UpdateTimeValue()
    {      
        timeText.text = "Time " + System.Math.Round(timeSlider.value, 1);
    }
}
