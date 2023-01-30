# generates a password with 16 characters consisting of upper and lowercase letters, digits, and punctuation marks, with option to copy to the clipboard.

import random
import string
import tkinter as tk
from tkinter import messagebox

def generate_password():
    password = ''.join(random.choices(string.ascii_letters + string.digits + string.punctuation, k=16))
    password_entry.delete(0, tk.END)
    password_entry.insert(0, password)

def copy_to_clipboard():
    password = password_entry.get()
    root.clipboard_clear()
    root.clipboard_append(password)
    messagebox.showinfo("Password Copied", "Password has been copied to clipboard.")

root = tk.Tk()
root.geometry("400x200")
root.title("Secure Password Generator")

password_label = tk.Label(root, text="Generated Password:")
password_label.pack()

password_entry = tk.Entry(root, width=50, font=("Helvetica", 14))
password_entry.pack()

generate_button = tk.Button(root, text="Generate", command=generate_password)
generate_button.pack()

copy_button = tk.Button(root, text="Copy to Clipboard", command=copy_to_clipboard)
copy_button.pack()

root.mainloop()
