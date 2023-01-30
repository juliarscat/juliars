# Sample code for an app to send data to and host and a port previously scanned. You can alter the code to send random amount of data for example, to test your systems against a DDOS attack


import tkinter as tk
import socket

def send_data():
    HOST = host_entry.get()
    PORT = int(port_entry.get())
    data = data_entry.get()
    try:
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
            s.connect((HOST, PORT))
            s.sendall(data.encode('utf-8'))
            response = s.recv(1024).decode('utf-8')
            result_label['text'] = 'Response: ' + response
    except socket.error as msg:
        result_label['text'] = 'Error: ' + str(msg)

root = tk.Tk()
root.title("Send Large Data to Port")

host_label = tk.Label(root, text="Host:")
host_label.grid(row=0, column=0)

host_entry = tk.Entry(root)
host_entry.grid(row=0, column=1)

port_label = tk.Label(root, text="Port:")
port_label.grid(row=1, column=0)

port_entry = tk.Entry(root)
port_entry.grid(row=1, column=1)

data_label = tk.Label(root, text="Data:")
data_label.grid(row=2, column=0)

data_entry = tk.Text(root, height=10, width=30)
data_entry.grid(row=2, column=1)

send_button = tk.Button(root, text="Send", command=send_data)
send_button.grid(row=3, column=0, columnspan=2, pady=10)

result_label = tk.Label(root, text="")
result_label.grid(row=4, column=0, columnspan=2)

root.mainloop()
