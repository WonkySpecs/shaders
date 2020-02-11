#version 330

out vec4 finalColor;

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

void main()
{
    vec2 st = gl_FragCoord.xy / u_resolution;
    vec2 mouseNorm = u_mouse / u_resolution;
    finalColor = vec4(st.x, st.y, sin(u_time) * mouseNorm.x, 1.0);
}
