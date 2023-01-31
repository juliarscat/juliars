#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

const int ROWS = 10;
const int COLUMNS = 10;

char board[ROWS][COLUMNS];
int ships = 5;

void initializeBoard() {
  // initialize the board with '-'
  for (int i = 0; i < ROWS; i++) {
    for (int j = 0; j < COLUMNS; j++) {
      board[i][j] = '-';
    }
  }

  // place the ships randomly on the board
  srand(time(0));
  for (int i = 0; i < ships; i++) {
    int x = rand() % ROWS;
    int y = rand() % COLUMNS;
    if (board[x][y] == '-') {
      board[x][y] = 'S';
    }
    else {
      i--;
    }
  }
}

void printBoard() {
  cout << "  0 1 2 3 4 5 6 7 8 9" << endl;
  for (int i = 0; i < ROWS; i++) {
    cout << i << " ";
    for (int j = 0; j < COLUMNS; j++) {
      cout << board[i][j] << " ";
    }
    cout << endl;
  }
}

bool attack(int x, int y) {
  if (board[x][y] == 'S') {
    cout << "You hit a ship!" << endl;
    board[x][y] = 'H';
    ships--;
    return true;
  }
  else {
    cout << "You missed." << endl;
    board[x][y] = 'M';
    return false;
  }
}

int main() {
  initializeBoard();

  while (ships > 0) {
    printBoard();
    int x, y;
    cout << "Enter the coordinates to attack (row column): ";
    cin >> x >> y;
    if (attack(x, y)) {
      cout << "You sank a ship! " << ships << " ships left." << endl;
    }
  }

  cout << "You won the game!" << endl;

  return 0;
}
