from raylib.static import ffi
from raylib.pyray import PyRay
from raylib.colors import *

pr = PyRay()

W_WIDTH, W_HEIGHT = 800, 600

pr.init_window(W_WIDTH, W_HEIGHT, b"Playing with shaders")
pr.set_target_fps(60)
blank = pr.gen_image_color(W_WIDTH, W_HEIGHT, WHITE)
texture = pr.load_texture_from_image(blank)
pr.unload_image(blank)

shader = pr.load_shader(ffi.new("int *"), "glowing_cursor.fs")

resolution = ffi.new("Vector2 *")
resolution[0].x = W_WIDTH
resolution[0].y = W_HEIGHT
pr.set_shader_value(shader,
                    pr.get_shader_location(shader, "u_resolution"),
                    resolution,
                    pr.UNIFORM_VEC2)

mouse = ffi.new("Vector2 *")
mouse[0].x = W_WIDTH
mouse[0].y = W_HEIGHT

time = ffi.new("float *")
time[0] = 0

while not pr.window_should_close():
    # mouse[0] = pr.get_mouse_position() Y axis is wrong way up
    mouse[0].x = pr.get_mouse_x()
    mouse[0].y = W_HEIGHT - pr.get_mouse_y()
    time[0] = pr.get_time()
    pr.set_shader_value(shader,
                        pr.get_shader_location(shader, "u_mouse"),
                        mouse,
                        pr.UNIFORM_VEC2)
    pr.set_shader_value(shader,
                        pr.get_shader_location(shader, "u_time"),
                        time,
                        pr.UNIFORM_FLOAT)
    pr.begin_drawing()
    pr.clear_background(WHITE)
    pr.begin_shader_mode(shader)
    pr.draw_texture(texture, 0, 0, WHITE)
    pr.end_shader_mode()
    pr.end_drawing()

pr.unload_shader(shader)
pr.close_window()
