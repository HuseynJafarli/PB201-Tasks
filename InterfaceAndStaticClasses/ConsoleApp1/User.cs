namespace ConsoleApp1
{
    public class User: IAccount
    {
        private int _id;
        private static int _count = 0;
        private string _password;
        public int Id {get => _id;}
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password 
        { 
            get => _password; 
            set
            {
                if (PasswordChecker(value))
                {
                    _password = value;
                }
            }
        }

        static User()
        {
            _count = 0;
        }

        public User()
        {
            _count++;
            _id = _count;

        }

        public bool PasswordChecker(string password)
        {
            if(password.Length > 7) 
                if(password.Any(char.IsDigit))
                    if (password.Any(char.IsLower))
                        if (password.Any(char.IsUpper))
                            return true;
            return false;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id} , Full name: {FullName} , Email: {Email}");
        }
    }
}
