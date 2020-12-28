# Football World Cup ScoreBoard Library
## About

This is a project of a library, driven by real business requirements.
The project is built using Test Driven Development.

## Domain description

A public library allows create thread unsafe live football scoreboard  that shows matches and scores.
The board supports the following operations:
1. Start a game. It adds a game to a scoreboard with specified Home and Away teams.
2. Finish a game. It will remove a game from the scoreboard.
3. Update a score. Receives scores (home team score and away team score) and updates a game score.
4. Get a summary of the games. By default, games are sorted by total score, games with the same total score are returned in descending order of the most recently added. You can specify the sorting of games.