using System;

static class Lexer
{
    public static String[] SplitToWords(this String phrase) =>
        phrase.ToLower().Split(" .,;:-+*/=^\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
}
