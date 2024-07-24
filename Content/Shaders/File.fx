#if OPENGL
    #define SV_POSITION POSITION
    #define VS_SHADERMODEL vs_3_0
    #define PS_SHADERMODEL ps_3_0
#else
    #define VS_SHADERMODEL vs_4_0_level_9_1
    #define PS_SHADERMODEL ps_4_0_level_9_1
#endif

Texture2D palette;
sampler2D palette_sampler = sampler_state
{
    Texture = <palette>;
};

Texture2D SpriteTexture;

sampler2D SpriteTextureSampler = sampler_state
{
    Texture = <SpriteTexture>;
};

struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 TextureCoordinates : TEXCOORD0;
};


float4 MainPS(VertexShaderOutput input) : COLOR
{
	float epsilon = 0.1; // Adjust this value as needed

    float4 color = tex2D(SpriteTextureSampler, input.TextureCoordinates);
    float4 colorOut = color;
    float4 c0 = float4(0.66, 0.84, 1.00, 1.0);
    float4 c1 = float4(0.6, 0.0, 1.0, 1.0);
    float4 c2 = float4(0.26, 0.27, 0.48, 1.0);


    if (//color.r < epsilon// && 
        // abs(color.g - c0.g) < epsilon && 
        // abs(color.b - c0.b) < epsilon
			 color.a != 0.0 
		&& 	(abs(color.r - c0.r) < epsilon )
		&& 	(abs(color.g - c0.g) < epsilon )

		)
    {
        colorOut = float4(0.57, 0.56, 0.00, 1.0); // Change to green
    }
    else if (abs(color.r - c1.r) < epsilon && 
             abs(color.g - c1.g) < epsilon && 
             abs(color.b - c1.b) < epsilon)
    {
        colorOut = float4(0.26, 0.26, 0.26, 1.0); // Change to specified color
    }
	else if (abs(color.r - c2.r) < epsilon && 
             abs(color.g - c2.g) < epsilon && 
             abs(color.b - c2.b) < epsilon)
    {
        colorOut = float4(1.00, 0.58, 0.00, 1.0); // Change to specified color
    }
        

    return colorOut;
}

technique SpriteDrawing
{
    pass P0
    {
        PixelShader = compile PS_SHADERMODEL MainPS();
    }
};