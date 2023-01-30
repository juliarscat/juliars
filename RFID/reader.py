# Python code to read RFID and create a list of read RFID tags using a Raspberry Pi and a MFRC522 module
import RPi.GPIO as GPIO
import MFRC522
import time

# Setup the MFRC522 reader
MIFAREReader = MFRC522.MFRC522()

# Create an empty list to store the RFID data
rfid_data = []

# Read the RFID data and store it in the list
while True:
    # Scan for RFID tags
    (status, TagType) = MIFAREReader.MFRC522_Request(MIFAREReader.PICC_REQIDL)
 
    # If an RFID tag is found
    if status == MIFAREReader.MI_OK:
        print("Tag detected")
 
        # Get the UID of the RFID tag
        (status, uid) = MIFAREReader.MFRC522_Anticoll()
 
        # If the UID is successfully read
        if status == MIFAREReader.MI_OK:
            # Store the UID in the list
            rfid_data.append(uid)
 
            print("UID: " + str(uid))
 
    time.sleep(1)
 
# Store the RFID data in a file
with open("rfid_data.txt", "w") as file:
    for item in rfid_data:
        file.write("%s\n" % item)
