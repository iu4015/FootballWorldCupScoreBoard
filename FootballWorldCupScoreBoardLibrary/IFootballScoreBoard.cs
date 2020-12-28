using System.Collections.Generic;

namespace FootballWorldCupScoreBoard
{
    /// <summary>
    /// Football scoreboard interface
    /// Contains methods for performing functions of interacting with the football scoreboard
    /// </summary>
    public interface IFootballScoreBoard
    {
        /// <summary>
        /// Removes the game with the specified gameId from the scoreboard
        /// </summary>
        /// <param name="gameId">The gameId of the game to remove.</param>
        /// <returns>true if the game with the specified gameId exists; otherwise, false.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when gameId is null.</exception>
        bool FinishGame(string gameId);
        /// <summary>
        /// Gets a collection containing a summary of games.
        /// </summary>
        /// <param name="customComparer">The IComparer implementation to use when comparing
        ///     elements or null to use the default comparer.</param>
        /// <returns>A enumerator, which supports a simple iteration over a collection of the Game type.</returns>
        IEnumerable<Game> GetSummary(IComparer<Game> customComparer = null);
        /// <summary>
        /// Adds a new game to the scoreboard.
        /// </summary>
        /// <param name="homeTeam">The name of the home team.</param>
        /// <param name="awayTeam">The name of the away team.</param>
        /// <returns>gameId if the game is successfully added.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when homeTeam is null. -or- awayTeam is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when the specified homeTeam is same as the specified awayTeam. -or- 
        ///     The specified homeTeam has already been playing. -or-
        ///     The specified awayTeam has already been playing.</exception>
        string StartGame(string homeTeam, string awayTeam);
        /// <summary>
        /// Updates the score of the game with the specified gameId.
        /// </summary>
        /// <param name="gameId">The gameId of the game to update its score.</param>
        /// <param name="homeScore">The value of the home team's score to update. The value must be bigger or equal to zero.</param>
        /// <param name="awayScore">The value of the away team's score to update. The value must be bigger or equal to zero.</param>
        /// <returns>true if the score successfully updated; otherwise, false.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when gameId is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown when a game with the specified gameId does not exist.</exception>
        bool UpdateScore(string gameId, int homeScore, int awayScore);
    }
}