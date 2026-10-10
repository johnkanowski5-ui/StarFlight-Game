using UnityEngine;

public static class SimpleSpriteFactory
{
    public static GameObject CreateSprite(string name, Color color, Vector2 size, Vector3 position)
    {
        var go = new GameObject(name);
        var sr = go.AddComponent<SpriteRenderer>();
        sr.color = color;
        sr.sprite = CreateSpriteTexture(size, color);
        go.transform.position = position;
        return go;
    }

    private static Sprite CreateSpriteTexture(Vector2 size, Color color)
    {
        int width = 64;
        int height = 64;
        var texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
        var pixels = new Color[width * height];

        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = color;
        }

        texture.SetPixels(pixels);
        texture.Apply();
        texture.filterMode = FilterMode.Point;

        return Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f), 64f);
    }
}
