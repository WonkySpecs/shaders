#version 330

out vec4 finalColor;

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

void main()
{
    vec2 st = gl_FragCoord.xy / u_resolution;
    vec2 mouseNorm = u_mouse / u_resolution;
    float len = length(st - mouseNorm);
    float offset = abs(sin(u_time * 15)) / 30.0;
    float cmin = 0.1  - offset;
    float cmax = 0.1  + offset;
    if (len > cmin && len < cmax ) {
        finalColor = vec4(1.0, 0.0, 0.0, 1.0);
    } else {
        finalColor = vec4(0.0, 0.0, 0.0, 1.0);
    }
}
