﻿namespace UI;

public interface IUserInterfaceManager
{
    string GetPlayerName();
    void DisplayMessage(string message);
    string GetPlayerGuess();
    bool AskToContinueGame();
}