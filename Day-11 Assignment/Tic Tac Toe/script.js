const cells = document.querySelectorAll(".cell");
const statusText = document.getElementById("status");
const restartBtn = document.getElementById("restartBtn");

let currentPlayer = "X";
let gameActive = true;
let board = ["", "", "", "", "", "", "", "", ""];

const winPatterns = [
  [0,1,2], [3,4,5], [6,7,8], // rows
  [0,3,6], [1,4,7], [2,5,8], // columns
  [0,4,8], [2,4,6]           // diagonals
];

cells.forEach((cell, index) => {
  cell.addEventListener("click", () => handleClick(cell, index));
});

restartBtn.addEventListener("click", restartGame);

function handleClick(cell, index) {
  if (board[index] !== "" || !gameActive) return;

  board[index] = currentPlayer;
cell.textContent = currentPlayer;

cell.classList.add(currentPlayer === "X" ? "x" : "o");


  if (checkWin()) {
    statusText.textContent = `🎉 Player ${currentPlayer} Wins!`;
    gameActive = false;
    return;
  }

  if (!board.includes("")) {
    statusText.textContent = "🤝 It's a Draw!";
    gameActive = false;
    return;
  }

  currentPlayer = currentPlayer === "X" ? "O" : "X";
  statusText.textContent = `Player ${currentPlayer}'s Turn`;
}

function checkWin() {
  for (let pattern of winPatterns) {
    const [a,b,c] = pattern;
    if (board[a] && board[a] === board[b] && board[a] === board[c]) {
      cells[a].classList.add("win");
      cells[b].classList.add("win");
      cells[c].classList.add("win");
      return true;
    }
  }
  return false;
}

function restartGame() {
  currentPlayer = "X";
  gameActive = true;
  board = ["", "", "", "", "", "", "", "", ""];
  statusText.textContent = "Player X's Turn";
  cells.forEach(cell => {
    cell.textContent = "";
cell.classList.remove("win", "x", "o");

  });
}
