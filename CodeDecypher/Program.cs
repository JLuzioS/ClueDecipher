using CodeDecypher;

var clues = new List<Clue>
{
    new Clue("682", 1, 0),
    new Clue("614", 0, 1),
    new Clue("206", 0, 2),
    new Clue("738", 0, 0),
    new Clue("380", 0, 1)
};

DecipherClues.Decipher(clues);
