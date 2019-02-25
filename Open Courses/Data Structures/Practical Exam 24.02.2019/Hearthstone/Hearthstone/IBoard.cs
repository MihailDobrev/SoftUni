using System;
using System.Collections.Generic;
using System.Text;

public interface IBoard
{
    void Draw(Card card);

    bool Contains(string name);

    int Count();

    void Play(string attackerCardName, string attackedCardName);

    void Remove(string name);

    void RemoveDeath();

    IEnumerable<Card> GetBestInRange(int start, int end);

    IEnumerable<Card> ListCardsByPrefix(string prefix);

    IEnumerable<Card> SearchByLevel(int level);

    void Heal(int health);
}