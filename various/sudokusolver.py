# A simple Sudoku solver app
import tkinter as tk

class SudokuUI:
  def __init__(self, master):
    self.master = master
    self.master.title("Sudoku Solver")
    self.board = [[0 for x in range(9)] for y in range(9)]
    self.entries = [[0 for x in range(9)] for y in range(9)]

    for row in range(9):
      for col in range(9):
        entry = tk.Entry(width=2, font=("Arial", 20))
        entry.grid(row=row, column=col)
        self.entries[row][col] = entry

    solve_button = tk.Button(text="Solve", command=self.solve)
    solve_button.grid(row=9, column=4, pady=5)

  def solve(self):
    for row in range(9):
      for col in range(9):
        try:
          self.board[row][col] = int(self.entries[row][col].get())
        except ValueError:
          self.board[row][col] = 0

    if solve_sudoku(self.board):
      for row in range(9):
        for col in range(9):
          self.entries[row][col].delete(0, tk.END)
          self.entries[row][col].insert(0, str(self.board[row][col]))
    else:
      print("No solution found")

def solve_sudoku(board):
  for row in range(9):
    for col in range(9):
      if board[row][col] == 0:
        for num in range(1, 10):
          if is_valid(board, row, col, num):
            board[row][col] = num
            if solve_sudoku(board):
              return True
            board[row][col] = 0
        return False
  return True

def is_valid(board, row, col, num):
  for i in range(9):
    if board[i][col] == num or board[row][i] == num:
      return False
  row_start = (row//3) * 3
  col_start = (col//3) * 3
  for i in range(3):
    for j in range(3):
      if board[row_start + i][col_start + j] == num:
        return False
  return True

if __name__ == "__main__":
  root = tk.Tk()
  app = SudokuUI(root)
  root.mainloop()
