document.addEventListener('DOMContentLoaded', () => {
    const startGameButton = document.getElementById('start-game');
    const gameContainer = document.getElementById('game-container');
    const gamesList = document.getElementById('games-list');

    startGameButton.addEventListener('click', startGame);

    function createBoard(boardrow, gameId) {
        const boardElement = document.createElement('div');
        boardElement.className = 'board';
        boardrow.forEach((board, rowIndex) => {
            board.cells.forEach((cellRow, cellRowIndex) => {
                cellRow.forEach((cell, cellIndex) => {
                    const cellElement = document.createElement('div');
                    cellElement.className = 'cell';
                    cellElement.textContent = cell;
                    cellElement.addEventListener('click', () => makeMove(gameId, board.id, rowIndex, cellIndex));
                    boardElement.appendChild(cellElement);
                });
            });
        });

        return boardElement;
    }

    function startGame() {
        fetch(`${CONFIG.BACKEND_URL}/Game/start`, {
            method: 'POST'
        })
        .then(response => response.json())
        .then(game => {
            gameContainer.innerHTML = '';
            console.log(game);
            game.boards.forEach(board => {
                gameContainer.appendChild(createBoard(board, game.id));
            });
        })
        .catch(error => console.error('Error starting game:', error));
    }

    function makeMove(gameId, boardId, row, column) {
        fetch(`${CONFIG.BACKEND_URL}/Game/move`, {
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
        })
        .catch(error => console.error('Error making move:', error));
    }

    function listGames() {
        fetch(`${CONFIG.BACKEND_URL}/Game/all`)
        .then(response => response.json())
        .then(games => {
            gamesList.innerHTML = '';
            games.forEach(game => {
                const gameItem = document.createElement('div');
                gameItem.textContent = `Game ID: ${game.id}, Winner: ${game.winner ? game.winner.name : 'None'}`;
                gameItem.addEventListener('click', () => loadGame(game.id));
                gamesList.appendChild(gameItem);
            });
        })
        .catch(error => console.error('Error listing games:', error));
    }

    function loadGame(gameId) {
        fetch(`${CONFIG.BACKEND_URL}/Game/${gameId}/status`)
        .then(response => response.json())
        .then(game => {
            gameContainer.innerHTML = '';
            game.boards.forEach(board => {
                gameContainer.appendChild(createBoard(board, game.id));
            });
        })
        .catch(error => console.error('Error loading game:', error));
    }

    function deleteGame(gameId) {
        fetch(`${CONFIG.BACKEND_URL}/Game/${gameId}`, {
            method: 'DELETE'
        })
        .then(() => {
            listGames();
        })
        .catch(error => console.error('Error deleting game:', error));
    }

    // Automatically list games when the page loads
    listGames();
});
