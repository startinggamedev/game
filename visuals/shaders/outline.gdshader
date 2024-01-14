shader_type canvas_item;

// If you intend to read from mipmaps with `textureLod()` LOD values greater than `0.0`,
// use `filter_nearest_mipmap` instead. This shader doesn't require it.
uniform sampler2D screen_texture : hint_screen_texture,filter_nearest;

void fragment() {
	vec4 input = texture(TEXTURE,UV);
	vec4 output = input;
	if (input.a == 0.){
		output.rgb = vec3(0.);
		output.a += texture(TEXTURE,UV + TEXTURE_PIXEL_SIZE).a; 
		output.a += texture(TEXTURE,UV - TEXTURE_PIXEL_SIZE).a;
		output.a += texture(TEXTURE,UV + vec2(TEXTURE_PIXEL_SIZE.x,0.)).a;
		output.a += texture(TEXTURE,UV - vec2(TEXTURE_PIXEL_SIZE.x,0.)).a;
		output.a += texture(TEXTURE,UV + vec2(0.,TEXTURE_PIXEL_SIZE.y)).a;
		output.a += texture(TEXTURE,UV - vec2(0.,TEXTURE_PIXEL_SIZE.y)).a;
		output.a += texture(TEXTURE,UV + vec2(-TEXTURE_PIXEL_SIZE.x,TEXTURE_PIXEL_SIZE.y)).a;
		output.a += texture(TEXTURE,UV - vec2(-TEXTURE_PIXEL_SIZE.x,TEXTURE_PIXEL_SIZE.y)).a;
		}
	COLOR = output;
}

//void light() {
	// Called for every pixel for every light affecting the CanvasItem.
	// Uncomment to replace the default light processing function with this one.
//}
