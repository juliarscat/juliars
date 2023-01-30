# Mouse mover app in python to move the mouse randonmly during X minutes

import tkinter as tk
import time
import random
import pyautogui

def move_mouse():
    x, y = pyautogui.position()
    pyautogui.moveTo(x + random.randint(-100, 100), y + random.randint(-100, 100), duration=0.25)
    root.after(250, move_mouse)

def start_moving_mouse():
    minutes = int(entry.get())
    end_time = time.time() + 60 * minutes
    move_mouse()
    while time.time() < end_time:
        time.sleep(1)
    pyautogui.alert(text='Time is up!', title='Mouse Mover')

root = tk.Tk()
root.title("Mouse Mover")

label = tk.Label(root, text="Enter the number of minutes:")
label.pack()

entry = tk.Entry(root)
entry.pack()

button = tk.Button(root, text="Start", command=start_moving_mouse)
button.pack()

root.mainloop()
