using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    GameObject markerPrefab;

    Record[] records = new Record[0];
    RectTransform rect;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void Initialize(int count)
    {
        rect = rect ?? GetComponent<RectTransform>();
        foreach (Record record in records)
        {
            Destroy(record.marker);
        }

        var width = rect.rect.size.x;
        var left = -width / 2;

        records = new Record[count];
        for (var i = 0; i < count; i++)
        {
            var x = left + width * (i + 1) / (count + 1);
            
            records[i].marker = Instantiate(markerPrefab, transform);
            records[i].marker.transform.localPosition = new Vector3(x, 0f, 0f);
        }
    }

    public void SetProgress(int position, bool isRight)
    {
        records[position].correct = isRight;
        records[position].marker.GetComponent<Image>().color = isRight ? Color.green : Color.red;
    }

    protected struct Record {
        public GameObject marker;
        public bool correct;
    }

    public Client.Satisfaction Evaluate()
    {
        if (records.Count(e => e.correct) == 0)
            return Client.Satisfaction.ANGRY;

        if (records.Count(e => !e.correct) == 0)
            return Client.Satisfaction.HAPPY;
            
        return Client.Satisfaction.NEUTRAL;
    }
}
