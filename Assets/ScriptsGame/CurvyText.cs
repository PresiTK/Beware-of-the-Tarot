using UnityEngine;
using TMPro;

public class CurvedText : MonoBehaviour
{
    public float curveRadius = 200f;
    private TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
        text.ForceMeshUpdate();
    }

    void Update()
    {
        if (!text) return;

        var mesh = text.mesh;
        var vertices = mesh.vertices;
        var charCount = text.textInfo.characterCount;

        for (int i = 0; i < charCount; i++)
        {
            var charInfo = text.textInfo.characterInfo[i];
            if (!charInfo.isVisible) continue;

            int vertexIndex = charInfo.vertexIndex;
            for (int j = 0; j < 4; j++)
            {
                Vector3 orig = vertices[vertexIndex + j];
                float angle = (orig.x / curveRadius);
                float y = Mathf.Sin(angle) * curveRadius;
                float z = Mathf.Cos(angle) * curveRadius - curveRadius;
                vertices[vertexIndex + j] = new Vector3(orig.x, y, z);
            }
        }

        mesh.vertices = vertices;
        text.canvasRenderer.SetMesh(mesh);
    }
}