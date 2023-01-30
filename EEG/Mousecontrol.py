import pyautogui
import numpy as np
import bluetooth

def move_cursor(eeg_data):
    # Get the mean EEG data across all channels
    mean_eeg = np.mean(eeg_data)

    # Use the mean EEG data to determine the direction to move the cursor
    if mean_eeg < 0.3:
        direction = "left"
    elif mean_eeg < 0.6:
        direction = "up"
    elif mean_eeg < 0.9:
        direction = "right"
    else:
        direction = "down"

    # Get the current mouse position
    current_position = pyautogui.position()

    # Determine the new mouse position based on the direction
    speed = 100 # Change this to control the speed of the cursor movement
    if direction == "left":
        new_position = (current_position[0] - speed, current_position[1])
    elif direction == "up":
        new_position = (current_position[0], current_position[1] - speed)
    elif direction == "right":
        new_position = (current_position[0] + speed, current_position[1])
    else:
        new_position = (current_position[0], current_position[1] + speed)

    # Move the mouse to the new position
    pyautogui.moveTo(new_position[0], new_position[1])

# Connect to the Bluetooth device
bd_addr = "00:11:22:33:44:55" # Replace with the address of your Bluetooth device
port = 1
sock = bluetooth.BluetoothSocket(bluetooth.RFCOMM)
sock.connect((bd_addr, port))

# Continuously receive EEG data from the Bluetooth device and move the cursor
while True:
    eeg_data = sock.recv(1024) # Replace with code to receive EEG data from the Bluetooth device
    move_cursor(eeg_data)

# Close the Bluetooth socket
sock.close()
