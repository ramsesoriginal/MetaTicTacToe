document.addEventListener('DOMContentLoaded', () => {
    const startGameButton = document.getElementById('start-game');
    const gameContainer = document.getElementById('game-container');
    const gamesList = document.getElementById('games-list');

    startGameButton.addEventListener('click', startGame);

    function createBoard(board, gameId) {
        const boardElement = document.createElement('div');
        boardElement.className = 'board';

        board.cells.forEach((row, rowIndex) => {
            row.forEach((cell, cellIndex) => {
                const cellElement = document.createElement('div');
                cellElement.className = 'cell';
                cellElement.textContent = cell.value === null ? '' : (cell.value ? 'X' : 'O');
                cellElement.addEventListener('click', () => makeMove(gameId, board.id, rowIndex, cellIndex));
                boardElement.appendChild(cellElement);
            });
        });

        return boardElement;
    }

    function startGame() {
        fetch('https://your-backend-url/api/game/start', {
            method: 'POST'
        })
        .then(response => response.json())
        .then(game => {
            gameContainer.innerHTML = '';
            game.boards.forEach(board => {
                gameContainer.appendChild(createBoard(board, game.id));
            });
        });
    }

    function makeMove(gameId, boardId, row, column) {
        fetch('https://your-backend-url/api/game/move', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                gameId: gameId,
                boardRow: Math.floor(boardId / 3),
                boardColumn: boardId % 3,
                cellRow: row,
                cellColumn: column,
                player: true // This should be dynamically set based on the current player
            })
        })
        .then(response => response.json())
        .then(game => {
            gameContainer.innerHTML = '';
            game.boards.forEach(board => {
                gameContainer.appendChild(createBoard(board, game.id));
            });
        });
    }

    function listGames() {
        fetch('https://your-backend-url/api/game/all')
        .then(response => response.json())
        .then(games => {
            gamesList.innerHTML = '';
            games.forEach(game => {
                const gameItem = document.createElement('div');
                gameItem.textContent = `Game ID: ${game.id}, Winner: ${game.winner ? game.winner.name : 'None'}`;
                gameItem.addEventListener('click', () => loadGame(game.id));
                gamesList.appendChild(gameItem);
            });
        });
    }

    function loadGame(gameId) {
        fetch(`https://your-backend-url/api/game/${gameId}/status`)
        .then(response => response.json())
        .then(game => {
            gameContainer.innerHTML = '';
            game.boards.forEach(board => {
                gameContainer.appendChild(createBoard(board, game.id));
            });
        });
    }

    // Automatically list games when the page loads
    listGames();
});
