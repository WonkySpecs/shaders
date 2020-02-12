#version 330

out vec4 finalColor;

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

float rand(vec2 v)
{
    return fract(sin(dot(v, vec2(69.0, 420.0))) * 10000.0);
}

vec2 truchetPattern(vec2 v, float r)
{
    float idx = fract(r + fract(u_time));
    if (idx > 0.75) return vec2(1.0) - v;
    else if (idx > 0.5) return vec2(1.0 - v.x, v.y);
    else if (idx > 0.25) return 1.0 - vec2(1.0 - v.x, v.y);
    return v;
}

void main()
{
    vec2 st = gl_FragCoord.xy / u_resolution * 5.0;
    vec2 fpos = fract(st);
    vec2 ipos = ceil(st);
    vec2 tile = truchetPattern(fpos, rand(ipos));
    float color = smoothstep(tile.x-0.3,tile.x,tile.y)-
                  smoothstep(tile.x,tile.x+0.3,tile.y);
    finalColor = vec4(vec3(color), 1.0);
}
