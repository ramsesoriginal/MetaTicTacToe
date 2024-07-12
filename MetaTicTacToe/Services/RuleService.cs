using MetaTicTacToe.Models;

namespace MetaTicTacToe.Services
{
    /// <summary>
    /// Service for validating moves in the Meta Tic Tac Toe game according to various rules.
    /// </summary>
    public class RuleService : IRuleService
    {
        private readonly IEnumerable<IRule> _rules;

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleService"/> class.
        /// </summary>
        /// <param name="rules">The collection of rules to validate moves against.</param>
        public RuleService(IEnumerable<IRule> rules)
        {
            _rules = rules;
        }

        /// <summary>
        /// Validates a move by checking it against all defined rules.
        /// </summary>
        /// <param name="game">The game instance to validate the move against.</param>
        /// <param name="move">The move to validate.</param>
        /// <returns><c>true</c> if the move is valid according to all rules; otherwise, <c>false</c>.</returns>
        public bool ValidateMove(Game game, Move move)
        {
            return _rules.All(rule => rule.IsMoveValid(game, move));
        }
    }
}
