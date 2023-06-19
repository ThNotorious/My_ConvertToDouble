namespace Homework22_Convert
{
    public static class MyConvert
    {
        public static double ToDouble(string acceptedString)
        {
            if (string.IsNullOrEmpty(acceptedString))
            {
                throw new FormatException("Пустая строка недопустима!");
            }

            bool oneSeparator = false;
            double result = 0.0;
            double multiplier = 1.0;

            try
            {
                foreach (char c in acceptedString)
                {
                    if (!char.IsDigit(c) && c != '.')
                    {
                        throw new FormatException("Недопустимые символы в выражении!");
                    }
                    else if (c == '.' && !oneSeparator)
                    {
                        oneSeparator = true;
                    }
                    else if (c == '.' && oneSeparator)
                    {
                        throw new FormatException("Недопустимые символы в выражении!");
                    }
                    else if (char.IsDigit(c))
                    {
                        if (!oneSeparator)
                        {
                            result = result * 10 + (c - '0');
                        }
                        else
                        {
                            multiplier /= 10;
                            result += (c - '0') * multiplier;
                        }
                    }
                }

                return result;
            }
            catch
            {
                throw new FormatException("Неизвестная ошибка!");
            }
            
        }
    }
}
