using UnityEngine;

[AddComponentMenu("Image Effects/Lutify")]
[ExecuteInEditMode]
[DisallowMultipleComponent]
[RequireComponent(typeof(Camera))]
public class Lutify : MonoBehaviour
{
	public enum SplitMode
	{
		None,
		Horizontal,
		Vertical
	}

	public RandomSkyScript SkyboxChangeScript;

	public Texture2D LookupTexture1;

	public Texture2D LookupTexture2;

	public Texture2D LookupTexture3;

	public Texture2D LookupTexture4;

	[Tooltip("The texture to use as a lookup table. Size should be: height = sqrt(width)")]
	public Texture2D LookupTexture;

	[Tooltip("Shows a before/after comparison by splitting the screen in half.")]
	public SplitMode Split;

	[Tooltip("Lutify will automatically detect the correct shader to use for the device but you can force it to only use the compatibility shader.")]
	public bool ForceCompatibility;

	[Tooltip("Sets the filter mode for the LUT texture. You'll want to set this to Point when using palette reduction LUTs.")]
	public FilterMode LutFiltering = FilterMode.Bilinear;

	[Tooltip("Blending factor.")]
	[Range(0f, 1f)]
	public float Blend = 1f;

	public int _LastSelectedCategory;

	public int _ThumbWidth = 110;

	public int _ThumbHeight;

	private int cache_ThumbWidth;

	private int cache_ThumbHeight;

	private bool cache_IsLinear;

	public RenderTexture _PreviewRT;

	protected Texture3D m_Lut3D;

	protected int m_BaseTextureIntanceID;

	protected bool m_Use2DLut;

	public Shader Shader2D;

	public Shader Shader3D;

	protected Material m_Material2D;

	protected Material m_Material3D;

	public bool IsLinear
	{
		get
		{
			return QualitySettings.activeColorSpace == ColorSpace.Linear;
		}
	}

	public Material Material
	{
		get
		{
			if (m_Use2DLut || ForceCompatibility)
			{
				if (m_Material2D == null)
				{
					m_Material2D = new Material(Shader2D);
					m_Material2D.hideFlags = HideFlags.HideAndDontSave;
				}
				return m_Material2D;
			}
			if (m_Material3D == null)
			{
				m_Material3D = new Material(Shader3D);
				m_Material3D.hideFlags = HideFlags.HideAndDontSave;
			}
			return m_Material3D;
		}
	}

	private void LateUpdate()
	{
		if (Application.loadedLevel == 2)
		{
			if (SkyboxChangeScript.counter == 0)
			{
				LookupTexture = LookupTexture1;
			}
			else if (SkyboxChangeScript.counter == 1)
			{
				LookupTexture = LookupTexture2;
			}
			else if (SkyboxChangeScript.counter == 2)
			{
				LookupTexture = LookupTexture3;
			}
			else if (SkyboxChangeScript.counter == 3)
			{
				LookupTexture = LookupTexture4;
			}
			else
			{
				LookupTexture = LookupTexture1;
			}
		}
	}

	protected virtual void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			Debug.LogWarning("Image effects aren't supported on this device");
			base.enabled = false;
			return;
		}
		if (!SystemInfo.supports3DTextures)
		{
			m_Use2DLut = true;
		}
		if ((!m_Use2DLut && (!Shader3D || !Shader3D.isSupported)) || (m_Use2DLut && (!Shader2D || !Shader2D.isSupported)))
		{
			Debug.LogWarning("The shader is null or unsupported on this device");
			base.enabled = false;
		}
	}

	protected virtual void OnEnable()
	{
		if (LookupTexture != null && LookupTexture.GetInstanceID() != m_BaseTextureIntanceID)
		{
			ConvertBaseTexture3D();
		}
	}

	protected virtual void OnDisable()
	{
		if ((bool)m_Material2D)
		{
			Object.DestroyImmediate(m_Material2D);
		}
		if ((bool)m_Material3D)
		{
			Object.DestroyImmediate(m_Material3D);
		}
		if ((bool)m_Lut3D)
		{
			Object.DestroyImmediate(m_Lut3D);
		}
		m_BaseTextureIntanceID = -1;
	}

	protected void SetIdentityLut3D()
	{
		int num = 16;
		Color[] array = new Color[num * num * num];
		float num2 = 1f / (1f * (float)num - 1f);
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num; j++)
			{
				for (int k = 0; k < num; k++)
				{
					array[i + j * num + k * num * num] = new Color((float)i * num2, (float)j * num2, (float)k * num2, 1f);
				}
			}
		}
		if ((bool)m_Lut3D)
		{
			Object.DestroyImmediate(m_Lut3D);
		}
		m_Lut3D = new Texture3D(num, num, num, TextureFormat.ARGB32, false);
		m_Lut3D.hideFlags = HideFlags.HideAndDontSave;
		m_Lut3D.SetPixels(array);
		m_Lut3D.Apply();
		m_BaseTextureIntanceID = -1;
	}

	public bool ValidDimensions(Texture2D tex2D)
	{
		if (tex2D == null || tex2D.height != Mathf.FloorToInt(Mathf.Sqrt(tex2D.width)))
		{
			return false;
		}
		return true;
	}

	protected void ConvertBaseTexture3D()
	{
		if (!ValidDimensions(LookupTexture))
		{
			Debug.LogWarning("The given 2D texture " + LookupTexture.name + " cannot be used as a LUT. Pick another texture or adjust dimension to e.g. 256x16.");
			return;
		}
		m_BaseTextureIntanceID = LookupTexture.GetInstanceID();
		int height = LookupTexture.height;
		Color[] pixels = LookupTexture.GetPixels();
		Color[] array = new Color[pixels.Length];
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < height; j++)
			{
				for (int k = 0; k < height; k++)
				{
					int num = height - j - 1;
					array[i + j * height + k * height * height] = pixels[k * height + i + num * height * height];
				}
			}
		}
		if ((bool)m_Lut3D)
		{
			Object.DestroyImmediate(m_Lut3D);
		}
		m_Lut3D = new Texture3D(height, height, height, TextureFormat.ARGB32, false);
		m_Lut3D.hideFlags = HideFlags.HideAndDontSave;
		m_Lut3D.wrapMode = TextureWrapMode.Clamp;
		m_Lut3D.SetPixels(array);
		m_Lut3D.Apply();
	}

	protected virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (LookupTexture == null || Blend <= 0f)
		{
			Graphics.Blit(source, destination);
			return;
		}
		int num = 0;
		if (Split == SplitMode.Horizontal)
		{
			num = 2;
		}
		else if (Split == SplitMode.Vertical)
		{
			num = 4;
		}
		if (IsLinear)
		{
			num++;
		}
		if (m_Use2DLut || ForceCompatibility)
		{
			RenderLut2D(source, destination, num);
		}
		else
		{
			RenderLut3D(source, destination, num);
		}
	}

	private void RenderLut3D(RenderTexture source, RenderTexture destination, int pass)
	{
		if (LookupTexture.GetInstanceID() != m_BaseTextureIntanceID)
		{
			ConvertBaseTexture3D();
		}
		if (m_Lut3D == null)
		{
			SetIdentityLut3D();
		}
		m_Lut3D.filterMode = LutFiltering;
		float num = m_Lut3D.width;
		Material.SetTexture("_LookupTex3D", m_Lut3D);
		Material.SetVector("_Params", new Vector3((num - 1f) / num, 1f / (2f * num), Blend));
		Graphics.Blit(source, destination, Material, pass);
	}

	private void RenderLut2D(RenderTexture source, RenderTexture destination, int pass)
	{
		LookupTexture.filterMode = LutFiltering;
		float num = Mathf.Sqrt(LookupTexture.width);
		Material.SetTexture("_LookupTex2D", LookupTexture);
		Material.SetVector("_Params", new Vector4(1f / (float)LookupTexture.width, 1f / (float)LookupTexture.height, num - 1f, Blend));
		Graphics.Blit(source, destination, Material, pass + ((LutFiltering == FilterMode.Point) ? 6 : 0));
	}
}
