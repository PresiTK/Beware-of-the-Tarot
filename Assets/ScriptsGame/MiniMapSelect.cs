using UnityEngine;

public class MiniMapSelect : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    public RoomNAme roomName;

    private Vector2 originalScale;
    private Vector3 originalPos;
    private Vector2 newScale = new Vector2(5, 5);
    private Vector3 newPos = new Vector3(0, 0, 10); // 👈 Aquí está el Z en 10
    public CharacterMovement characterMovement;

    public float transitionSpeed = 5f;

    private Vector2 targetScale;
    private Vector3 targetPos;

    private bool isScaling = false;

    void Start()
    {
        originalPos = transform.localPosition;
        originalScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
    }

    void Update()
    {
        // Selección de sprite
        if (int.TryParse(roomName.room.Replace("Sala", ""), out int index) && index >= 0 && index < sprites.Length)
        {
            spriteRenderer.sprite = sprites[index];
        }
        else
        {
            spriteRenderer.sprite = null;
        }

        // Animación si está activa
        if (isScaling)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, targetScale, Time.deltaTime * transitionSpeed);
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime * transitionSpeed);

            if (Vector2.Distance(transform.localScale, targetScale) < 0.01f &&
                Vector3.Distance(transform.localPosition, targetPos) < 0.01f)
            {
                transform.localScale = targetScale;
                transform.localPosition = targetPos;
                isScaling = false;
            }
        }

        // Lógica de activación
        if (characterMovement.map)
        {
            ScaleMap();
        }
        else
        {
            DesScaleMap();
        }
    }

    private void ScaleMap()
    {
        if (!isScaling || targetScale != newScale)
        {
            targetScale = newScale;
            targetPos = newPos;
            isScaling = true;
        }
    }

    private void DesScaleMap()
    {
        if (!isScaling || targetScale != originalScale)
        {
            targetScale = originalScale;
            // Asegura que el Z siga en 10 al volver
            targetPos = new Vector3(originalPos.x, originalPos.y, 10);
            isScaling = true;
        }
    }
}
