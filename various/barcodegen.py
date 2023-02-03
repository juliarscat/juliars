# Generate X barcodes then store them to a DB, if the table does not exist, it creates it automatically

import tkinter as tk
import random
import string
import sqlite3

class Application(tk.Frame):
    def __init__(self, master=None):
        super().__init__(master)
        self.master = master
        self.pack()
        self.create_widgets()

    def create_widgets(self):
        self.barcode_label = tk.Label(self, text="Number of barcodes:")
        self.barcode_label.pack()

        self.barcode_entry = tk.Entry(self)
        self.barcode_entry.pack()

        self.generate_button = tk.Button(self, text="Generate barcodes", command=self.generate_barcodes)
        self.generate_button.pack()

    def generate_barcodes(self):
        num_barcodes = int(self.barcode_entry.get())

        barcodes = []
        for i in range(num_barcodes):
            barcode = ''.join(random.choices(string.ascii_uppercase + string.digits, k=10))
            barcodes.append(barcode)

        self.store_barcodes(barcodes)

    def store_barcodes(self, barcodes):
        conn = sqlite3.connect("barcodes.db")
        c = conn.cursor()
        c.execute("CREATE TABLE IF NOT EXISTS barcodes (barcode text)")

        for barcode in barcodes:
            c.execute("INSERT INTO barcodes (barcode) VALUES (?)", (barcode,))

        conn.commit()
        conn.close()

        self.show_message("Barcodes generated and stored in database!")

    def show_message(self, message):
        tk.messagebox.showinfo("Info", message)

root = tk.Tk()
app = Application(master=root)
app.mainloop()
