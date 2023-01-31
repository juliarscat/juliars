import tkinter as tk
import requests
from bs4 import BeautifulSoup

def search_data():
    # URL to the website to be searched
    url = entry.get()

    # Send a request to the website and get the response
    response = requests.get(url)

    # Check if the request was successful
    if response.status_code == 200:
        # Parse the response using BeautifulSoup
        soup = BeautifulSoup(response.text, 'html.parser')

        # Find the data you want to extract from the website
        data = soup.find_all('p')

        # Write the data to a text file
        with open('data.txt', 'w') as f:
            for item in data:
                f.write(item.text + '\n')

        label.config(text='Data exported to data.txt')
    else:
        label.config(text='Request failed with status code: ' + str(response.status_code))

# Create the GUI window
root = tk.Tk()
root.title("Data Exporter")
root.geometry("300x150")

# Create a label
label = tk.Label(root, text="Enter URL:")
label.pack()

# Create an entry widget to input the URL
entry = tk.Entry(root)
entry.pack()

# Create a button to search data and export it
search_button = tk.Button(root, text="Search and Export", command=search_data)
search_button.pack()

# Start the GUI event loop
root.mainloop()
